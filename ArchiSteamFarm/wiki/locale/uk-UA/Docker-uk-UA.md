# Docker

ASF is available as **[docker container](https://www.docker.com/what-container)**. Our docker packages are currently available on **[ghcr.io](https://github.com/JustArchiNET/ArchiSteamFarm/pkgs/container/archisteamfarm)** as well as **[Docker Hub](https://hub.docker.com/r/justarchi/archisteamfarm)**.

It's important to note that running ASF in Docker container is considered **advanced setup**, which is **not needed** for vast majority of users, and typically gives **no advantages** over container-less setup. If you're considering Docker as a solution for running ASF as a service, for example making it start automatically with your OS, then you should consider reading **[management](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Management#systemd-service-for-linux)** section instead and set up a proper `systemd` service which will be **almost always** a better idea than running ASF in a Docker container.

Running ASF in Docker container usually involves **several new problems and issues** that you'll have to face and resolve yourself. This is why we **strongly** recommend you to avoid it unless you already have Docker knowledge and don't need help understanding its internals, about which we won't elaborate here on ASF wiki. This section is mostly for valid use cases of very complex setups, for example in regards to advanced networking or security beyond standard sandboxing that ASF comes with in `systemd` service (which already ensures superior process isolation through very advanced security mechanics). For those handful amount of people, here we explain better ASF concepts in regards to its Docker compatibility, and only that, you're assumed to have adequate Docker knowledge yourself if you decide to use it together with ASF.

---

## Tags

ASF is available through 4 main types of **[tags](https://hub.docker.com/r/justarchi/archisteamfarm/tags)**:


### `main`

This tag always points to the ASF built from latest commit in `main` branch, which works the same as grabbing latest artifact directly from our **[CI](https://github.com/JustArchiNET/ArchiSteamFarm/actions/workflows/publish.yml?query=branch%3Amain)** pipeline. Typically you should avoid this tag, as it's the highest level of bugged software dedicated to developers and advanced users for development purposes. The image is being updated with each commit in the `main` GitHub branch, therefore you can expect very often updates (and stuff being broken). It's here for us to mark current state of ASF project, which is not necessarily guaranteed to be stable or tested, just like pointed out in our release cycle. This tag should not be used in any production environment.


### `released`

Very similar to the above, this tag always points to the latest **[released](https://github.com/JustArchiNET/ArchiSteamFarm/releases)** ASF version, including pre-releases. Compared to `main` tag, this image is being updated each time a new GitHub tag is pushed. Dedicated to advanced/power users that love to live on the edge of what can be considered stable and fresh at the same time. This is what we'd recommend if you don't want to use `latest` tag. In practice, it works the same as rolling tag pointing to the most recent `A.B.C.D` release at the time of pulling. Please note that using this tag is equal to using our **[pre-releases](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Release-cycle)**.


### `latest`

This tag in comparison with others, is the only one that includes ASF auto-updates feature and points to the latest **[stable](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)** ASF version. The objective of this tag is to provide a sane default Docker container that is capable of running self-updating, OS-specific build of ASF. Because of that, the image doesn't have to be updated as often as possible, as included ASF version will always be capable of updating itself if needed. Of course, `UpdatePeriod` can be safely turned off (set to `0`), but in this case you should probably use frozen `A.B.C.D` release instead. Likewise, you can modify default `UpdateChannel` in order to make auto-updating `released` tag instead.

Due to the fact that the `latest` image comes with capability of auto-updates, it includes bare OS with OS-specific `linux` ASF version, contrary to all other tags that include OS with .NET runtime and `generic` ASF version. This is because newer (updated) ASF version might also require newer runtime than the one the image could possibly be built with, which would otherwise require image to be re-built from scratch, nullifying the planned use-case.

### `A.B.C.D`

In comparison with above tags, this tag is completely frozen, which means that the image won't be updated once published. This works similar to our GitHub releases that are never touched after the initial release, which guarantees you stable and frozen environment. Typically you should use this tag when you want to use some specific ASF release and you don't want to use any kind of auto-updates (e.g. those offered in `latest` tag).

---

## Which tag is the best for me?

That depends on what you're looking for. For majority of users, `latest` tag should be the best one as it offers exactly what desktop ASF does, just in special Docker container as a service. People that are rebuilding their images quite often and would instead prefer full control with ASF version tied to given release are welcome to use `released` tag. If you instead want to use some specific frozen ASF version that will never change without your clear intention, `A.B.C.D` releases are available for you as fixed ASF milestones you can always fall back to.

We generally discourage trying `main` builds, as those are here for us to mark current state of ASF project. Nothing guarantees that such state will work properly, but of course you're more than welcome to give them a try if you're interested in ASF development.

---

## Architectures

ASF docker image is currently built on `linux` platform targetting 3 architectures - `x64`, `arm` and `arm64`. You can read more about them in **[compatibility](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility)** section.

Our tags are using multi-platform manifest, which means that Docker installed on your machine will automatically select the proper image for your platform when pulling the image. If by any chance you'd like to pull a specific platform image which doesn't match the one you're currently running, you can do that through `--platform` switch in appropriate docker commands, such as `docker run`. See docker documentation on **[image manifest](https://docs.docker.com/registry/spec/manifest-v2-2)** for more info.

---

## Використання

For complete reference you should use **[official docker documentation](https://docs.docker.com/engine/reference/commandline/docker)**, we'll cover only basic usage in this guide, you're more than welcome to dig deeper.

### Hello ASF!

Firstly we should verify if our docker is even working correctly, this will serve as our ASF "hello world":

```shell
docker run -it --name asf --pull always --rm justarchi/archisteamfarm
```

`docker run` creates a new ASF docker container for you and runs it in the foreground (`-it`). `--pull always` ensures that up-to-date image will be pulled first, and `--rm` ensures that our container will be purged once stopped, since we're just testing if everything works fine for now.

If everything ended successfully, after pulling all layers and starting container, you should notice that ASF properly started and informed us that there are no defined bots, which is good - we verified that ASF in docker works properly. Hit `CTRL+C` to terminate the ASF process and therefore also the container.

If you take a closer look at the command then you'll notice that we didn't declare any tag, which automatically defaulted to `latest` one. If you want to use other tag than `latest`, for example `released`, then you should declare it explicitly:

```shell
docker run -it --name asf --pull always --rm justarchi/archisteamfarm:released
```

---

## Using a volume

If you're using ASF in docker container then obviously you need to configure the program itself. You can do it in various different ways, but the recommended one would be to create ASF `config` directory on local machine, then mount it as a shared volume in ASF docker container.

For example, we'll assume that your ASF config folder is in `/home/archi/ASF/config` directory. This directory contains core `ASF.json` as well as bots that we want to run. Now all we need to do is simply attaching that directory as shared volume in our docker container, where ASF expects its config directory (`/app/config`).

```shell
docker run -it -v /home/archi/ASF/config:/app/config --name asf --pull always justarchi/archisteamfarm
```

And that's it, now your ASF docker container will use shared directory with your local machine in read-write mode, which is everything you need for configuring ASF. In similar, way you can mount other volumes that you'd like to share with ASF, such as `/app/logs` or `/app/plugins`.

Of course, this is just one specific way to achieve what we want, nothing is stopping you from e.g. creating your own `Dockerfile` that will copy your config files into `/app/config` directory inside ASF docker container. We're only covering basic usage in this guide.

### Volume permissions

ASF container by default is initialized with default `root` user, which allows it to handle the internal permissions stuff and then eventually switch to `asf` (UID `1000`) user for the remaining part of the main process. While this should be satisfying for the vast majority of users, it does affect the shared volume as newly-generated files will be normally owned by `asf` user, which may not be desired situation if you'd like some other user for your shared volume.

There are two ways you can change the user ASF is running under. The first one, recommended, is to declare `ASF_USER` environment variable with target UID you want to run under. Second, alternative one, is to pass `--user` **[flag](https://docs.docker.com/engine/reference/run/#user)**, which is directly supported by docker.

You can check your `uid` for example with `id -u` command, then declare it as specified above. For example, if your target user has `uid` of 1001:

```shell
docker run -it -e ASF_USER=1001 -v /home/archi/ASF/config:/app/config --name asf --pull always justarchi/archisteamfarm

# Alternatively, if you understand the limitations below
docker run -it -u 1001 -v /home/archi/ASF/config:/app/config --name asf --pull always justarchi/archisteamfarm
```

The difference between `ASF_USER` and `--user` flag is subtle, but important. `ASF_USER` is custom mechanism supported by ASF, in this scenario docker container still starts as `root`, and then ASF startup script starts main binary under `ASF_USER`. When using `--user` flag, you're starting whole process, including ASF startup script as given user. First option allows ASF startup script to handle permissions and other stuff automatically for you, resolving some common issues that you might've caused, for example it ensures that your `/app` and `/asf` directories are actually owned by `ASF_USER`. In second scenario, since we're not running as `root`, we can't do that, and you're expected to handle all of that yourself in advance.

If you've decided to use `--user` flag, you need to change ownership of all ASF files from default `asf` to your new custom user. You can do so by executing command below:

```shell
# Execute only if you're not using ASF_USER
docker exec -u root asf chown -hR 1001 /app /asf
```

This has to be done only once after you created your container with `docker run`, and only if you decided to use custom user through `--user` docker flag. Also don't forget to change `1001` argument in command above to the `UID` you actually want to run ASF under.

### Volume with SELinux

If you're using SELinux in enforced state on your OS, which is the default for example on RHEL-based distros, then you should mount the volume appending `:Z` option, which will set correct SELinux context for it.

```
docker run -it -v /home/archi/ASF/config:/app/config:Z --name asf --pull always justarchi/archisteamfarm
```

This will allow ASF to create files targetting the volume while inside docker container.

---

## Multiple instances synchronization

ASF includes support for multiple instances synchronization, as stated in **[management](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Management#multiple-instances)** section. When running ASF in docker container, you can optionally "opt-in" into the process, in case you're running multiple containers with ASF and you'd like for them to synchronize with each other.

By default, each ASF running inside a docker container is standalone, which means that no synchronization takes place. In order to enable synchronization between them, you must bind `/tmp/ASF` path in every ASF container that you want to synchronize, to one, shared path on your docker host, in read-write mode. This is achieved exactly the same as binding a volume which was described above, just with different paths:

```shell
mkdir -p /tmp/ASF-g1
docker run -v /tmp/ASF-g1:/tmp/ASF -v /home/archi/ASF/config:/app/config --name asf1 --pull always justarchi/archisteamfarm
docker run -v /tmp/ASF-g1:/tmp/ASF -v /home/john/ASF/config:/app/config --name asf2 --pull always justarchi/archisteamfarm
# And so on, all ASF containers are now synchronized with each other
```

We recommend to bind ASF's `/tmp/ASF` directory also to a temporary `/tmp` directory on your machine, but of course you're free to choose any other one that satisfies your usage. Each ASF container that is expected to be synchronized should have its `/tmp/ASF` directory shared with other containers that are taking part in the same synchronization process.

As you've probably guessed from example above, it's also possible to create two or more "synchronization groups", by binding different docker host paths into ASF's `/tmp/ASF`.

Mounting `/tmp/ASF` is completely optional and actually not recommended, unless you explicitly want to synchronize two or more ASF containers. We do not recommend mounting `/tmp/ASF` for single-container usage, as it brings absolutely no benefits if you expect to run just one ASF container, and it might actually cause issues that could otherwise be avoided.

---

## Аргументи командного рядка

ASF allows you to pass **[command-line arguments](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments)** in docker container through environment variables. You should use specific environment variables for supported switches, and `ASF_ARGS` for the rest. This can be achieved with `-e` switch added to `docker run`, for example:

```shell
docker run -it -e "ASF_CRYPTKEY=MyPassword" -e "ASF_ARGS=--no-config-migrate" --name asf --pull always justarchi/archisteamfarm
```

This will properly pass your `--cryptkey` argument to ASF process being run inside docker container, as well as other args. Of course, if you're advanced user, then you can also modify `ENTRYPOINT` or add `CMD` and pass your custom arguments yourself.

Unless you want to provide custom encryption key or other advanced options, usually you don't need to include any special environment variables, as our docker containers are already configured to run with a sane expected default options of `--no-restart` `--process-required` `--system-required`, so those flags do not need to be specified explicitly in `ASF_ARGS`.

---

## IPC

Assuming you didn't change the default value for `IPC` **[global configuration property](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#global-config)**, it's already enabled. However, you must do two additional things for IPC to work in Docker container. Firstly, you must use `IPCPassword` or modify default `KnownNetworks` in custom `IPC.config` to allow you to connect from the outside without using one. Unless you really know what you're doing, just use `IPCPassword`. Secondly, you have to modify default listening address of `localhost`, as docker can't route outside traffic to loopback interface. An example of a setting that will listen on all interfaces would be `http://*:1242`. Of course, you can also use more restrictive bindings, such as local LAN or VPN network only, but it has to be a route accessible from the outside - `localhost` won't do, as the route is entirely within guest machine.

For doing the above you should use **[custom IPC config](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC#custom-configuration)** such as the one below:

```json
{
    "Kestrel": {
        "Endpoints": {
            "HTTP": {
                "Url": "http://*:1242"
            }
        }
    }
}
```

Once we set up IPC on non-loopback interface, we need to tell docker to map ASF's `1242/tcp` port either with `-P` or `-p` switch.

For example, this command would expose ASF IPC interface to host machine (only):

```shell
docker run -it -p 127.0.0.1:1242:1242 -p [::1]:1242:1242 --name asf --pull always justarchi/archisteamfarm
```

If you set everything properly, `docker run` command above will make **[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC)** interface work from your host machine, on standard `localhost:1242` route that is now properly redirected to your guest machine. It's also nice to note that we do not expose this route further, so connection can be done only within docker host, and therefore keeping it secure. Of course, you can expose the route further if you know what you're doing and ensure appropriate security measures.

---

### Complete example

Combining whole knowledge above, an example of a complete setup would look like this:

```shell
docker run -p 127.0.0.1:1242:1242 -p [::1]:1242:1242 -v /home/archi/ASF/config:/app/config -v /home/archi/ASF/plugins:/app/plugins --name asf --pull always justarchi/archisteamfarm
```

This assumes that you'll use a single ASF container, with all ASF config files in `/home/archi/ASF/config`. You should modify the config path to the one that matches your machine. It's also possible to provide custom plugins for ASF, which you can put in `/home/archi/ASF/plugins`. This setup is also ready for optional IPC usage if you've decided to include `IPC.config` in your config directory with a content like below:

```json
{
    "Kestrel": {
        "Endpoints": {
            "HTTP": {
                "Url": "http://*:1242"
            }
        }
    }
}
```

---

## Pro tips

When you already have your ASF docker container ready, you don't have to use `docker run` every time. You can easily stop/start ASF docker container with `docker stop asf` and `docker start asf`. Keep in mind that if you're not using `latest` tag then using up-to-date ASF will still require from you to `docker stop`, `docker rm` and `docker run` again. This is because you must rebuild your container from fresh ASF docker image every time you want to use ASF version included in that image. In `latest` tag, ASF has included capability to auto-update itself, so rebuilding the image is not necessary for using up-to-date ASF (but it's still a good idea to do it from time to time in order to use fresh .NET runtime dependencies and the underlying OS, which might be needed when jumping across major ASF version updates).

As hinted by above, ASF in tag other than `latest` won't automatically update itself, which means that **you** are in charge of using up-to-date `justarchi/archisteamfarm` repo. This has many advantages as typically the app should not touch its own code when being run, but we also understand convenience that comes from not having to worry about ASF version in your docker container. If you care about good practices and proper docker usage, `released` tag is what we'd suggest instead of `latest`, but if you can't be bothered with it and you just want to make ASF both work and auto-update itself, then `latest` will do.

You should typically run ASF in docker container with `Headless: true` global setting. This will clearly tell ASF that you're not here to provide missing details and it should not ask for those. Of course, for initial setup you should consider leaving that option at `false` so you can easily set up things, but in long-run you're typically not attached to ASF console, therefore it'd make sense to inform ASF about that and use `input` **[command](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)** if need arises. This way ASF won't have to wait infinitely for user input that will not happen (and waste resources while doing so). It will also allow ASF to run in non-interactive mode inside container, which is crucial e.g. in regards to forwarding signals, making it possible for ASF to gracefully close on `docker stop asf` request.