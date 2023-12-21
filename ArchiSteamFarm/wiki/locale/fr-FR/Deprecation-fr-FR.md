# Dépréciation

We're doing our best to follow consistent deprecation policy in order to make both development as well as usage far more consistent.

---

## Qu'est ce la dépréciation ?

Deprecation is the process of smaller or bigger breaking changes that render previously used options, arguments, functionalities or usage cases obsolete. Une désapprobation signifie généralement que quelque chose a été simplement réécrit d'une autre manière, et vous devez vous assurer que vous y passerez dans les meilleurs délais. Dans ce cas, il s'agit simplement de déplacer une fonctionnalité  vers un emplacement plus approprié.

ASF change rapidement et cherche toujours à devenir meilleur. Malheureusement, cela veut dire que nous pouvons changer ou déplacer certaines fonctionnalités existantes vers une autre partie du logiciel, au profit de nouvelles fonctionnalités, de compatibilité et de stabilité. Grâce à cela, nous n’avons pas besoin de nous en tenir aux décisions de développement obsolètes ou tout simplement douloureusement erronées que nous avons prises il y a des années. Nous essayons toujours de fournir un remplacement raisonnable qui corresponde à l'utilisation attendue des fonctionnalités précédemment disponibles. C'est pourquoi la désapprobation est généralement sans danger et nécessite de petites corrections par rapport à l'utilisation précédente.

---

## Étapes de désapprobation

ASF suivra 2 étapes de désapprobation, rendant la transition beaucoup plus facile et moins gênante.

### Étape 1

L'étape 1 se produit une fois que la fonctionnalité donnée est devenue obsolète, avec la disponibilité immédiate d'une autre solution (ou aucune si aucune réinstallation n'est envisagée).

Au cours de cette étape, ASF imprimera l’avertissement approprié lorsque la fonction obsolète est utilisée. Dans la mesure du possible, ASF tentera d'imiter l'ancien comportement et restera compatible avec celui-ci. ASF continuera d’être à l'étape 1 en ce qui concerne cette fonctionnalité au moins jusqu’à la prochaine version stable. C’est le moment où, sans rompre la compatibilité, vous pouvez procéder à la commutation appropriée de tous vos outils et modèles pour satisfaire un nouveau comportement. Vous pouvez confirmer si vous avez effectué toutes les modifications appropriées et de ne plus voir l'avertissement de désapprobation.

### Stage 2

L'étape 2 est planifié après l'étape 1 expliquée ci-dessus et est publiée dans une version stable. Cette étape introduit la suppression complète de l'existence de fonctionnalités obsolètes, ce qui signifie qu'ASF ne reconnaît même pas que vous tentez d'utiliser une fonctionnalité obsolète, encore moins de la respecter, car elle n'existe tout simplement pas dans le code actuel. ASF ne donnera plus aucun avertissement, car il ne reconnaît plus ce que vous essayez de faire.

---

## Sommaire

Vous avez plus ou moins un **mois complet** pour pouvoir effectuer le basculement approprié, ce qui devrait être amplement suffisant même si vous êtes un utilisateur occasionnel de ASF. Après cette période, ASF ne garantit plus que les anciens paramètres n’auront aucun effet (étape 2), faisant en sorte que certaines fonctions cesseront de fonctionner sans que vous le remarquiez. Si vous lancez ASF après plus d'un mois d'inactivité, il est recommandé de **[recommencer à zéro](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Setting-up)** ou de lire tous les journaux des modifications manqués et d'adapter manuellement votre utilisation à la version actuelle.

Dans la plupart des cas, ignorer l'alerte de dépréciation ne rendra pas les fonctionnalités générales d'ASF inutilisables, mais restaurera le fonctionnement par défaut (qui peut ou ne peut pas correspondre à vos préférences personnelles).

---

## Exemple

Nous avons déplacé **[l'argument de commande](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Command-line-arguments)**`--server` vers `IPC` **[Propriétés de configuration globales](https://github.com/JustArchiNET/ArchiSteamFarm/wiki/Configuration#global-config)** dans la version pre-V3.1.2.2.

### Étape 1

L'étape 1 s'est déroulée dans la version V3.1.2.2 où nous avons ajouté l'avertissement approprié à l'utilisation du `--server`. L'argument `--server` a été automatiquement mappé dans la propriété de configuration globale ` IPC: true `, agissant exactement de la même manière que l'ancien commutateur <0 --server</code>. A partir de maintenant. Cela a permis à tout le monde de faire les changements appropriés avant qu'ASF ne cesse d'accepter l'ancien argument.

### Étape 2

L'étape 2 s'est déroulée dans la version V3.1.3.0, juste après la version V3.1.2.9 stable et l'étape 1 expliquée ci-dessus. L'étape 2 a obligé ASF à ne plus reconnaître l'argument `--server` et à le traiter comme tout autre argument non valide transmis, ce qui n'a plus d'effet sur le programme. 177/5000 Pour les personnes qui n'ont toujours pas modifié leur utilisation du `--server` en ` IPC: true `, IPC a complètement cessé de fonctionner, ASF n'effectuant plus le mappage approprié.