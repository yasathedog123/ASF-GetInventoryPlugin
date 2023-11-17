# Docker

Начиная с версии 3.0.3.2, ASF также доступен в формате **[контейнера docker](https://www.docker.com/what-container)**. Наши Docker-пакеты доступны на **[ghcr.io](https://github.com/orgs/JustArchiNET/packages/container/archisteamfarm/versions)** а также **[Docker Hub](https://hub.docker.com/r/justarchi/archisteamfarm)**.

Важно отметить, что запуск ASF в Docker-контейнере считается **расширенной установкой**,что **не требуется** для подавляющего большинства пользователей и обычно **не дает никаких преимуществ** по сравнению с установкой без контейнеров. Если вы рассматриваете Docker в качестве решения для запуска ASF в качестве службы, например заставляя его автоматически запускаться с вашей ОС, то вы должны подумать над чтением раздела **[управления](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Management-ru-RU#systemd-service-for-linux)** и установкой соответствующего `сервиса`, который будет **почти всегда** лучшей идеей, чем запуск ASF в контейнере Docker.

Запуск ASF в контейнере Docker обычно включает в себя **новых проблем и проблем**, с которыми вам придется столкнуться и решить. Именно поэтому мы **сильно** рекомендуем вам избегать этого, если только вы не обладаете знаниями о Docker и не нуждаетесь в помощи в понимании его внутренностей, о которых мы не будем подробно рассказывать здесь, на ASF вики. This section is mostly for valid use cases of very complex setups, for example in regards to advanced networking or security beyond standard sandboxing that ASF comes with in `systemd` service (which already ensures superior process isolation through very advanced security mechanics). For those handful amount of people, here we explain better ASF concepts in regards to its Docker compatibility, and only that, you're assumed to have adequate Docker knowledge yourself if you decide to use it together with ASF.

---

## Теги

В ASF доступные 4 основных типа **[тегов](https://hub.docker.com/r/justarchi/archisteamfarm/tags)**:


### `main`

This tag always points to the ASF built from latest commit in `main` branch, which works the same as grabbing latest artifact directly from our **[CI](https://github.com/JustArchiNET/ArchiSteamFarm/actions/workflows/publish.yml?query=branch%3Amain)** pipeline. Обычно вам стоит избегать использования этого тега, поскольку на этом уровне в программе наибольшая вероятность наличия ошибок, и эта сборка предназначена для разработчиков и продвинутых пользователей принимающих участие в разработке. The image is being updated with each commit in the `main` GitHub branch, therefore you can expect very often updates (and stuff being broken). Эта сборка отображает текущее состояние проекта ASF, и не гарантируется что она стабильна и протестирована, как и указано в описании цикла выпуска. Этот тег не следует использовать в среде реального применения.


### `released`

По аналогии с тегом выше, этот тег всегда соответствует последней **[версии ASF](https://github.com/JustArchiNET/ArchiSteamFarm/releases)**, включая предварительные. Compared to `main` tag, this image is being updated each time a new GitHub tag is pushed. Предназначен для продвинутых пользователей, которые предпочитают самые свежие версии программного обеспечения, находящиеся на грани того, что можно считать стабильным. Мы рекомендуем это если вы по какой-то причине не хотите использовать тег `latest`. In practice, it works the same as rolling tag pointing to the most recent `A.B.C.D` release at the time of pulling. Пожалуйста, обратите внимание, что использование этого тега аналогично использованию **[предварительных версий](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Release-cycle-ru-RU)**.


### `latest`

This tag in comparison with others, is the only one that includes ASF auto-updates feature and points to the latest **[stable](https://github.com/JustArchiNET/ArchiSteamFarm/releases/latest)** ASF version. Цель этого тега - предоставить разумный контейнер Docker по умолчанию, способный запускать само-обновляемую сборку ASF под конкретную ОС. Поэтому этот образ не должен обновляться как можно чаще, поскольку используемая версия ASF способна при необходимости обновиться самостоятельно. Разумеется, `UpdatePeriod` можно спокойно выключить (поставить равным `0`), но в этом случае вам наверное лучше использовать фиксированный билд `A.B.C.D`. Аналогично, вы можете изменить значение по умолчанию в `UpdateChannel` чтобы сделать авто-обновляемым тег `released`.

Due to the fact that the `latest` image comes with capability of auto-updates, it includes bare OS with OS-specific `linux` ASF version, contrary to all other tags that include OS with .NET runtime and `generic` ASF version. Это связано с тем, что более новая (обновленная) версия ASF может потребовать более новую среду выполнения, чем та, с которой собран образ, что в противном случае потребовало бы пересборку заново, сводя на нет планируемый вариант использования.

### `A.B.C.D`

В сравнении с тегами выше, этот тег полностью зафиксирован, это означает что образ не будет обновляться после публикации. Это работает аналогично сборкам на GitHub, которые никогда не меняются после выпуска, что гарантирует стабильную и неизменную среду. Typically you should use this tag when you want to use some specific ASF release and you don't want to use any kind of auto-updates (e.g. those offered in `latest` tag).

---

## Какой тег лучше для меня?

Это зависит от того, что вам нужно. Для большинства пользователей наилучшим будет тег `latest`, поскольку он предоставляет в точности то же, что и ASF для домашних ПК, но в особом контейнере Docker в качестве услуги. People that are rebuilding their images quite often and would instead prefer full control with ASF version tied to given release are welcome to use `released` tag. Если же вы вместо этого хотите конкретную и фиксированную версию ASF, которая никогда не изменится без вашего явного желания, то для вас доступны сборки `A.B.C.D` на различных этапах развития, к которым вы всегда можете вернуться.

We generally discourage trying `main` builds, as those are here for us to mark current state of ASF project. Нет никаких гарантий что это состояние будет правильно работать, но конечно же вы можете попробовать его использовать если интересуетесь разработкой ASF.

---

## Архитектуры

ASF docker image is currently built on `linux` platform targetting 3 architectures - `x64`, `arm` and `arm64`. Вы можете прочитать больше об этом в разделе **[Совместимость](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Compatibility-ru-RU)**.

Since ASF version V5.0.2.2, our tags are using multi-platform manifest, which means that Docker installed on your machine will automatically select the proper image for your platform when pulling the image. If by any chance you'd like to pull a specific platform image which doesn't match the one you're currently running, you can do that through `--platform` switch in appropriate docker commands, such as `docker run`. Смотрите документацию docker на **[image manifest](https://docs.docker.com/registry/spec/manifest-v2-2)** для получения дополнительной информации.

---

## Использование

Полную справку вы можете найти в **[официальной документации docker](https://docs.docker.com/engine/reference/commandline/docker)**, а мы в этом руководстве рассмотрим только базовое использование, но вы можете узнать больше самостоятельно.

### Hello ASF!

Для начала нам надо проверить что наш docker работает правильно, и этот пример послужит для ASF своего рода "**<a href=https://ru.wikipedia.org/wiki/Hello,_world!>hello world</a>**":

```shell
docker run -it --name asf --pull always --rm justarchi/archisteamfarm
```

`docker run` создаёт новый контейнер docker с ASF и запускает его на переднем плане (`-it`). `--pull always` ensures that up-to-date image will be pulled first, and `--rm` ensures that our container will be purged once stopped, since we're just testing if everything works fine for now.

Если всё завершилось успешно, после получения всех слоев и запуска контейнера вы должны увидеть что ASF успешно запустился и сообщил вам что в нём не задано ботов, это хорошо - мы проверили что ASF корректно работает в docker. Нажмите `CTRL+P` а затем `CTRL+Q` чтобы выйти контейнера docker на переднем плане, а затем остановите контейнер с ASF командой `docker stop asf`.

Если вы внимательно посмотрите на команды выше, вы заметите что мы не задали тег, и поэтому по умолчанию автоматически используется тег `latest`. Если вы хотите использовать тег, отличный от `latest`, например `latest-arm`, тогда его нужно задать в явном виде:

```shell
docker run -it --name asf --pull always --rm justarchi/archisteamfarm:released
```

---

## Использование тома

Если вы используете ASF в контейнере docker то очевидно что вам нужно сконфигурировать саму программу. Это можно сделать различными методами, но мы рекомендуем создать папку ASF `config` на локальной машине, и подключить её как общий том к контейнеру docker с ASF.

Например, предположим что ваша папка config для ASF находится по адресу `/home/archi/ASF/config`. Эта папка содержит `ASF.json` а также файлы конфигурации для ботов, которых мы хотим запустить. Теперь всё что нам нужно сделать это просто подключить эту папку как общий том к нашему контейнеру docker, там где ASF ожидает найти свою папку конфигурации (`/app/config`).

```shell
docker run -it -v /home/archi/ASF/config:/app/config --name asf --pull always justarchi/archisteamfarm
```

Вот и всё, теперь ваш контейнер docker с ASF будет использовать общую папку с вашей локальной машины в режиме чтения и записи, а это всё что вам нужно для конфигурирования ASF. Аналогичным образом вы можете смонтировать другие тома, которые вы хотите сделать общими с ASF, например `/app/logs` или `/app/plugins/MyCustomPluginDirectory`.

Разумеется, это только один из возможных способов получить желаемое, никто не мешает вам, к примеру, создать свой собственный `Dockerfile` который будет копировать файлы конфигурации в папку `/app/config` в контейнере docker с ASF. В этой инструкции мы описываем только основы использования.

### Разрешения для тома

ASF container by default is initialized with default `root` user, which allows it to handle the internal permissions stuff and then eventually switch to `asf` (UID `1000`) user for the remaining part of the main process. While this should be satisfying for the vast majority of users, it does affect the shared volume as newly-generated files will be normally owned by `asf` user, which may not be desired situation if you'd like some other user for your shared volume.

Docker позволяет вам указать **[флаг](https://docs.docker.com/engine/reference/run/#user)** ` --user` команде `docker run`, что задаст пользователя по умолчанию, под которым будет запускаться ASF. Вы можете посмотреть ваши `uid` и `gid` например с помощью команды `id`, и затем передать их в команде. Например, если нужный вам пользователь имеет `uid` и `gid` равные 1001:

```shell
docker run -it -u 1001:1001 -v /home/archi/ASF/config:/app/config --name asf --pull always justarchi/archisteamfarm
```

Remember that by default `/app` directory used by ASF is still owned by `asf`. Если вы запустите ASF от произвольного пользователя, то ваш процесс ASF не будет иметь прав на запись в свои собственные файлы. Этот доступ не является обязательным для работы, но он необходим например для автоматического обновления. In order to fix this, it's enough to change ownership of all ASF files from default `asf` to your new custom user.

```shell
docker exec -u root asf chown -hR 1001:1001 /app
```

Это нужно сделать только один раз после создания вашего контейнера командой `docker run`, и только если вы решите запускать процесс ASF под своим пользователем. Также не забывайте заменить аргумент `1001:1001` в командах выше на `uid` и `gid` которые вы реально хотите использовать для запуска ASF.

### Volume with SELinux

If you're using SELinux in enforced state on your OS, which is the default for example on RHEL-based distros, then you should mount the volume appending `:Z` option, which will set correct SELinux context for it.

```
docker run -it -v /home/archi/ASF/config:/app/config:Z --name asf --pull always justarchi/archisteamfarm
```

Это позволит ASF создавать файлы, нацеленные на данный том, будучи внутри контейнера docker.

---

## Синхронизация нескольких экземпляров

ASF включает поддержку синхронизации нескольких экземпляров, как указано в разделе **[управления](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Management-ru-RU#multiple-instances)**. Если вы запускаете ASF в контейнере docker, у вас также есть возможность "включиться" в этот процесс, в случае если у вас несколько контейнеров с ASF и вам нужно синхронизировать их между собой.

По умолчанию каждый ASF, запущенный внутри контейнера docker, автономен, а значит никакая синхронизация не происходит. Чтобы включить синхронизацию между ними, вы должны привязать путь `/tmp/ASF` в каждом контейнере ASF, который вы хотите синхронизировать, к одному общему пути хост-машины, в режиме чтения-записи. Это делается точно так же, как привязка томов, описанная выше, только с другими путями:

```shell
mkdir -p /tmp/ASF-g1
docker run -v /tmp/ASF-g1:/tmp/ASF -v /home/archi/ASF/config:/app/config --name asf1 --pull always justarchi/archisteamfarm
docker run -v /tmp/ASF-g1:/tmp/ASF -v /home/john/ASF/config:/app/config --name asf2 --pull always justarchi/archisteamfarm
# И так далее, все контейнеры ASF теперь синхронизированы друг с другом.
```

Мы рекомендуем привязывать папку `/tmp/ASF` вашего ASF тоже к временной папке `/tmp` на вашей машине, но конечно же вы вольны выбрать любую другую, удовлетворяющую вашим потребностям. Каждый контейнер ASF, который вы хотите синхронизировать, должен делить общую папку `/tmp/ASF` с другими контейнерами, также участвующими в процессе синхронизации.

Как вы наверное догадались из примера выше, можно также создать две "группы синхронизации", привязав разные пути на хост-машине docker в папке `/tmp/ASF` в ASF.

Привязка `/tmp/ASF` совершенно необязательна и даже не рекомендуется, за исключением случая когда вы точно хотите синхронизировать два или более контейнера ASF. Мы не рекомендуем привязку `/tmp/ASF` для использования одного контейнера, поскольку это не несёт совершенно никакой пользы если вы планируете запускать только один контейнер ASF, и может даже привести к проблемам, которых можно было избежать.

---

## Аргументы командной строки

ASF позволяет передавать **[аргументы командной строки](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments-ru-RU)** в контейнер docker используя переменные среды. Вам следует использовать выделенные переменные среды для поддерживаемых аргументов, и переменную `ASF_ARGS` для всего остального. Это достигается путём добавления к команде `docker run` параметра `-e`, например:

```shell
docker run -it -e "ASF_CRYPTKEY=MyPassword" -e "ASF_ARGS=--no-config-migrate" --name asf --pull always justarchi/archisteamfarm
```

Этот пример корректно передаст ваш аргумент `--cryptkey` процессу ASF, запущенному внутри контейнера docker, а также передаст остальные аргументы. Разумеется, если вы продвинутый пользователь, вы также можете изменить `ENTRYPOINT` или добваить `CMD` и передавать нужные аргументы командной строки самостоятельно.

Если вы не хотите предоставлять пользовательский ключ шифрования или другие расширенные опции, обычно вам не нужно включать никаких специальных переменных среды, так как наши контейнеры docker уже настроены на запуск с ожидаемыми параметрами по умолчанию `--no-restart` `--process-required` `--system-required`, так что эти флаги не должны быть чётко указаны в `ASF_ARGS`.

---

## IPC

Если вы не изменили значение по умолчанию для **[глобального файла конфигурации](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration-ru-RU#global-config)** `IPC`, то он уже включен. Однако, для работы в Docker контейнере необходимо выполнить еще две вещи. Во-первых, вы должны использовать `IPCPassword` или изменить значение по умолчанию `KnownNetworks` в пользовательских `IPC.config`, чтобы позволить вам подключаться снаружи без использования его. Если вы не знаете, что вы делаете, просто используйте `IPCPassword`. Во-вторых, вы должны изменить адрес прослушивания `localhost`, так как Docker не может маршрутизировать внешний трафик до loopback-интерфейса. Пример настройки, при которой запросы будут ожидаться со всех интерфейсов - `http://*:1242`. Разумеется, вы можете указать также более строгие настройки, такие как только приём запросов только от внутренней сети, или сети VPN, но это должен быть маршрут, доступный извне - `localhost` не подходит, поскольку этот маршрут полностью находится внутри гостевой машины.

Чтобы сделать описанное выше, вам нужно использовать **[пользовательскую конфигурацию IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC-ru-RU#user-content-Пользовательская-конфигурация)**, аналогичную приведенной ниже:

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

После того, как мы настроим IPC на использование интерфейса, отличного от loopback, нам нужно сообщить docker что необходимо подключить порт ASF `1242/tcp` с помощью аргумента командной строки `-P` либо `-p`.

Например, эта команда сделает доступным интерфейс ASF IPC (только) для хост-машины:

```shell
docker run -it -p 127.0.0.1:1242:1242 -p [::1]:1242:1242 --name asf --pull always justarchi/archisteamfarm
```

Если вы всё настроили правильно, команда `docker run`, приведенная выше сделает возможной работу с интерфейсом **[IPC](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/IPC-ru-RU)** на вашей хост-машине, по стандартному адресу `localhost:1242`, который теперь корректно маршрутизируется на гостевую машину. Приятно отметить, что мы не маршрутизируем этот адрес дальше, поэтому соединение будет работать только с хост-машины docker, а значит останется безопасным. Разумеется, вы можете разрешить маршрутизацию и далее, если вы понимаете что делаете и предпринимаете соответствующие меры безопасности.

---

### Полный пример

Объединив знания, полученные выше, мы можем сделать полный пример конфигурации, он будет выглядеть примерно так:

```shell
docker run -p 127.0.0.1:1242:1242 -p [::1]:1242:1242 -v /home/archi/ASF/config:/app/config --name asf --pull always justarchi/archisteamfarm
```

Предполагается, что вы будете использовать один ASF контейнер со всеми конфигурационными файлами ASF в `/home/archi/ASF/config`. Вам нужно изменить путь к конфигурационным файлам на соответствующий вашей машине. Эта конфигурация также готова к использованию IPC если вы решите включить в вашу папку конфигурации файл `IPC.config` со следующим содержимым:

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

## Советы профессионалов

Когда ваш контейнер docker с ASF уже готов, вам не нужно каждый раз использовать команду `docker run`. Вы можете легко запускать/останавливать контейнер docker с ASF командами `docker stop asf` и `docker start asf`. Помните, что если вы не пользуетесь тегом `latest`, то обновление ASF потребует от вас снова выполнить `docker stop`, `docker rm`, `docker pull` и `docker run`. Это связано с тем, что вам нужно пересобирать ваш контейнер из свежего образа ASF каждый раз когда вы хотите использовать версию ASF, включенную в этот образ. In `latest` tag, ASF has included capability to auto-update itself, so rebuilding the image is not necessary for using up-to-date ASF (but it's still a good idea to do it from time to time in order to use fresh .NET runtime dependencies and the underlying OS, which might be needed when jumping across major ASF version updates).

Как сказано выше, ASF c тегами отличными от `latest` не будут обновляться автоматически, а это значит что **вы** отвечаете за использование последней версии репозитория `justarchi/archisteamfarm`. Это имеет много преимуществ, потому что обычно приложение не должно изменять свой код во время работы, но мы также понимаем удобство того факта что вам не нужно беспокоиться о версии ASF в контейнере docker. Если вас заботят хорошие практики и правильное использование docker, мы рекомендуем использовать тег `released` вместо `latest`, но если вы не хотите заботиться о нём и просто хотите чтобы ASF работало и обновлялось автоматически, тег `latest` тоже подойдёт.

Обычно вам следует запускать контейнер docker с ASF с глобальной настройкой `Headless: true`. Это явным образом укажет ASF что вы не сможете ввести недостающие данные и запрашивать их не следует. Разумеется, для начальной настройки вам стоит рассмотреть возможность оставить этот параметр равным `false`, чтобы вы легко могли всё настроить, но при длительном использовании вы обычно не привязаны к консоли ASF, и поэтому имеет смысл сообщить об этом ASF и использовать при необходимости **[команду](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands-ru-RU)** `input`. Таким образом ASF не придётся бесконечно ждать пользовательского ввода, который никогда не произойдёт (и тратить на это ресурсы). Это также позволит запускать ASF внутри контейнера в не-интерактивном режиме, что может быть чрезвычайно полезно, например, для пересылки сигналов, делая возможным штатное завершение ASF по запросу `docker stop asf`.