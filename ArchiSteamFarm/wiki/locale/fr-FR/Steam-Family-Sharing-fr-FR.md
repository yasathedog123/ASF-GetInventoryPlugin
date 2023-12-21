# Partage familial Steam

ASF supports Steam Family Sharing - in order to understand how ASF works with that, you should firstly read how **[Steam Family Sharing works](https://store.steampowered.com/promotion/familysharing)**, which is available on Steam store.

---

## ASF

La prise en charge de la fonctionnalité du partage familial dans ASF est transparente, ce qui signifie qu’elle ne présente aucune nouvelle propriété de configuration bot / process. Elle fonctionne immédiatement en tant que fonctionnalité intégrée supplémentaire.

ASF inclut une logique appropriée afin de s’assurer que la bibliothèque est verrouillée par les utilisateurs du partage familial. Par conséquent, elle ne les "coupera" pas de la session en raison du lancement d’une partie. ASF agira exactement de la même manière que le compte principal qui détient le verrou. Par conséquent, si ce verrou est détenu par votre client Steam ou par l’un de vos utilisateurs du partage familial, ASF ne tentera pas de créer une ferme, mais attendra que le verrou soit libre.

In addition to above, after logging in, ASF will access your **[family sharing settings](https://store.steampowered.com/account/managedevices)**, from which it'll extract up to 5 `steamIDs` allowed to use your library. Ces utilisateurs reçoivent l’autorisation ` PartageFamilial` d’utiliser **[les commandes](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Commands)**, leur permettant notamment d’utiliser la commande ` pause ~ ` sur le compte bot qui partage des jeux avec eux, qui permet de mettre en pause le module de farm automatique de cartes afin de lancer un jeu pouvant être partagé.

Connecting both functionalities described above allows your friends to `pause~` your cards farming process, start a game, play as long as they wish, and then after they're done playing, cards farming process will be automatically resumed by ASF. Bien entendu, l'émission de ` pause ~` n'est pas nécessaire si ASF n'effectue actuellement aucune activité de farm active, car vos amis peuvent lancer le jeu immédiatement, et la logique décrite ci-dessus garantit qu'ils ne seront pas expulsés du serveur.

---

## Restriction

Le réseau Steam aime induire en erreur ASF en diffusant de fausses mises à jour de statut, ce qui pourrait conduire ASF à croire qu'il est bon de reprendre le processus et que, par conséquent, expulse votre ami trop tôt. C'est exactement le même problème que celui que nous avons déjà expliqué dans **[cette entrée de la FAQ](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/FAQ#asf-is-kicking-my-steam-client-session-while-im-playing--this-account-is-logged-on-another-pc)**. Nous recommandons exactement les mêmes solutions, principalement promouvoir vos amis à la permission `Opérateur` (ou supérieure) et leur disant de faire usage des commandes `pause` et `reprendre`.