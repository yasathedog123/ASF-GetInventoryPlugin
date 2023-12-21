# Partajarea familiei Steam

ASF supports Steam Family Sharing - in order to understand how ASF works with that, you should firstly read how **[Steam Family Sharing works](https://store.steampowered.com/promotion/familysharing)**, which is available on Steam store.

---

## ASF

Support for Steam Family Sharing feature in ASF is transparent, which means that it doesn't introduce any new bot/process config properties - it works out of the box as an extra built-in functionality.

ASF includes appropriate logic in order to be aware of library being locked by family sharing users, therefore it won't "kick" them out of playing session due to launching a game. ASF will act exactly the same as with primary account holding the lock, therefore if that lock is being held either by your steam client, or by one of your family sharing users, ASF will not attempt to farm, instead, it will wait for the lock to be released.

In addition to above, after logging in, ASF will access your **[family sharing settings](https://store.steampowered.com/account/managedevices)**, from which it'll extract up to 5 `steamIDs` allowed to use your library. Those users are given `FamilySharing` permission to use **[commands](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**, especially allowing them to use `pause~` command on bot account that is sharing games with them, which allows to pause automatic cards farming module in order to launch a game that can be shared.

Connecting both functionalities described above allows your friends to `pause~` your cards farming process, start a game, play as long as they wish, and then after they're done playing, cards farming process will be automatically resumed by ASF. Of course, issuing `pause~` is not needed if ASF is currently not farming anything actively, because your friends can launch the game right away, and logic described above ensures that they won't be kicked out of the session.

---

## Limitations

Steam network loves to mislead ASF by broadcasting false status updates, which may lead to ASF believing it's fine to resume process, and in result kick your friend too soon. This is exactly the same issue as the one already explained by us in **[this FAQ entry](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/FAQ#asf-is-kicking-my-steam-client-session-while-im-playing--this-account-is-logged-on-another-pc)**. We recommend exactly the same solutions, mainly promoting your friends to `Operator` permission (or above) and telling them to make use of `pause` and `resume` commands.