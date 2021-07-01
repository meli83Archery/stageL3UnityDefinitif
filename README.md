# stageL3UnityDefinitif

Ce répertoire contient le nécessaire pour un projet sur la simulation de cellules cancéreuse contenant une interface avec Unity.

Trois scripts ont été réalisés : 

- SelectCellule qui va permettre à l'utilisateur de choisir une cellule sur la simulation en faisant un clic gauche de la souris et affiche les propriétés de celles-ci (nom, identifiant, coordonnées, ...) .
Ce qu'il faudrait rajouter dans ce script : 
  - un moyen de mettre en surbrillance la cellule quand on clique dessus, si on reclique dessus elle n'est plus en surbrillance ou quand on sélectionne une nouvelle cellule la nouvelle est en surbrillance mais plus l'ancienne.
  - un moyen de l'associer avec l'interface, c'est-à-dire de faire afficher les propriétés sur la console de l'interface

- Distance_entre_2Cellules, elle va prendre la cellule sélectionnée de la fonction SelecCellule et va demander à l'utilisateur de choisir la deuxième en faisant un clic droit dessus et il affiche leur coordonnées. Il y a une méthode distance2Cellule qui prend en paramètre ces deux cellules et ressort le résultat de la distance entre les deux.
Ce qu'il faudrait rajouter dans ce script :
  - afficher un trait entre les deux cellules sélectionnées
  - afficher la distance au dessus du trait si possible
  - un moyen de l'associer avec l'interface, c'est-à-dire de faire afficher les coordonnées des deux cellules sur la console de l'interface

- ColorationSimulation, elle est sensé colorer les cellules de la simulation en fonction d'une propriété choisie par l'utilisateur. Elle contient une méthode MinMaxRelatif qui prend un string en paramètre qui correxpond à la propriété et ressort un tableau de double dont la première valeur et le minimum et la deuxième le maximum en fonction de celle-ci. (ce script se situe dans la branche dev vu qu'elle n'est pas du tout terminée)
Le dropdown pour les propriétés est fonctionnel et les deux boutons situés sous le deuxième dropdown fonctionne. Si on clique sur le mode absolu,l'utilisateur choisit son minimum et son maximum puis ils sont affichés.Si on clique sur le mode relatif, il appelle la méthode MinMaxRelatif et il affiche les deux valeurs.
Ce qu'il faut rajouter dans ce script :
  - un moyen de récupérer les listes de couleurs composant les palettes (viridis, magma, plasma,...) ainsi qu'une liste de string contenant le nom des palettes
  - faire fonctionner la méthode ColorationCellule qui prend en paramètre un minimum, un maximum, une valeur d'une cellule et une liste de couleur (ou une liste de valeurs hexa correspondant au couleur)
  - Après avoir fait fonctionner cette méthode, il faut itérer sur les autres cellules dans la partie Update
  - associer le deuxième dropdown avec la liste des noms des palettes
  - pour le mode absolu, il faudrait que l'utilisateur choisit dans les deux zones associées situées sous les boutons et prendre en compte les valeurs dans le scripts
  - pour le mode relatif, faire afficher les minimums et les maximums dans ces zones
  - après que toutes les options soient choisi il faudrait afficher quelque part à gauche de la simulation une légende de coloration avec la valeur du minimum et la valeur du maximum



Un script qui serait à faire c'est un script PlanDeCoupe
Dedans il y aura son association avec l'interface : l'interface doit contenir un dropdown proposant les types de coupe. Pour l'instant il y en a à réaliser.
- une coupe simple, elle permettra de couper la simulation en 2 mais pas forcément par le milieu de la simulation
- une tranche
- un quartier, elle enlèvera un quart de la simulation pour mieux voir le centre
- coupe libre, elle demandera à l'utilisateur de placer 3 points dans l'espace (qu'il pourra déplacer comme il le souhaite) et ainsi créer un plan de coupe à partir de ces 3 points

Il pourrait y avoir une méthode par plan de coupe et suivant ce que choisira l'utilisateur, dans le Update on fera appelle à la méthode souhaitée.





