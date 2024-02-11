# Exercice Projections

*Objectif:* Appliquer certains effets de perspective à l'aide des matrices de transformation.

**Modifiez ce fichier pour répondre aux questions**

## Généralité

Un composant `CustomMatrices` a été ajouté à la caméra *Exercice/Camera* de la scène principale. Ce composant applique la matrice de projection configurée en paramètre à la caméra (de façon continue, donc possible de la modifier lors de l'exécution). Cette matrice est sauvegardée dans un object scriptable afin de pouvoir les conserver, et il suffit d'y glisser-déposer un objet scriptable du même type pour essayer diverses configurations.

## 1

Configurez la résolution du jeu pour être en ratio 16:9. Lancez le jeu à l'aide de la matrice *PerspectiveMatrix*. Modifiez le ratio pour une configuration 4:3. Que constatez-vous?

Remarquez les valeurs de la diagonale de la matrice. Dupliquez l'objet de matrice et paramétrez manuellement les valeurs pour obtenir un résultat satisfaisant. Quelle matrice avez-vous obtenu?

Quand on passe d’un ratio de 16 : 9 à 4 : 3 on peut noter que l’image et son contenu semblent plus étroits sur l’axe horizontal. Il ne semble pas avoir de changement dans la hauteur des éléments dans l’affichage.

|1,3	0		0	0|
|0	1.732051	0	0|
|0	0		-1	-0.60018|
|0	0		-1	0|


## 2

Faites le même exercice que précédemment, mais à l'aide de la matrice *OrthoMatrix*.

On peut constater le même changement qu’avec la perspectiveView, c’est-à-dire que les éléments sont plus étroits en 4 : 3

La matrice obtenue
|0,08	0	0		      0|
|0	0,1	0		      0|
|0	0	-0.0020006	-1.0006|
|0	0	0		      1|



## 3

En conservant un ratio 16:9, dupliquez et modifiez la matrice *OrthoMatrix* en modifiant les deux valeurs supérieures de la dernière colonne (demeurez dans la plage ±1). Que constatez-vous? Qu'arrive-t-il si vous modifiez la troisième valeur de cette colonne? Qu'en est-il de la dernière valeur?

Pour les 2 premières valeurs de la dernière colonne, on peut remarquer qu’elles déplacent les éléments sur les axes X et Y.
 La première valeur déplace l’affichage sur les x.
 la deuxième valeur déplace l’affichage sur les Y.
 les valeurs 1 et -1 corresponde au bord de l’écran de jeu à partir du point d’origine de la caméra.
La troisième ne semble pas faire grand-chose or si la valeur n’est pas -1,1 <valeur<1 alors l’affichage disparait.
La quatrième valeur détermine l’emplacement de la caméra sur l’angle des X plus la valeur est tant que la valeur est plus grande que 1 l’affichage devient plus distant.
 Si la valeur est plus petite que 1, l’affichage disparait simplement.

## 4

Dupliquez et modifiez la matrice *OrthoMatrix*, appliquez les valeurs "-0.2" et "-0.8" aux deux valeurs supérieures de la dernière colonne, et ajoutez les valeurs "-0.01" et "-0.0178" aux deux valeurs supérieures de la troisième colonne. Que constatez-vous?

Donc pour les premières valeurs cause l’affichage à être décalé vers la droite et vers le haut.
Puis l’application des deux dernières valeurs cause la caméra à effectuer une rotation vers la gauche puis une rotation vers le bas.
Donc la 4e colonne semble contrôler la position de la caméra tandis que la troisième contrôle l’angle d’observation. Les deux premières lignes semblent prendre les valeurs pour les axes x et y.


## 5

Désactivez la caméra *Exercice/Camera* et activez la caméra *Exercice/Camera (1)*. Ajoutez un script au projet, à ajouter sur cette dernière caméra, où vous implémenterez un effet de [Travelling Contrarié](https://fr.wikipedia.org/wiki/Travelling_contrari%C3%A9) centré sur le personnage. Il existe plusieurs références sur le web pour des algorithmes (incluant la page anglaise de l'article ci-dessus), mais vous devriez être en mesure de déduire un algorithme à l'aide d'un peu d'algèbre linéaire en analysant l'effet.


En lançant le jeu il y aura un zoom in et un zoom dépassé qui vont ce lancé.
 Après ces coroutines vous pouvez contrôler le zoom avec les touches + et — du numpad.
 La caméra suit le joueur sur l’axe des x faisant en sorte que le joueur est toujours le centre de l’écran sauf quand il marche derrière la caméra.
cinémachine règlerais probablement le problème, mais je ne savais pas si vous vouliez que j’empêche le joueur d’aller derrière la caméra.
Techniquement le Travelling Contrarié est centré sur le joueur même quand il est derriere la différence étant que le zoom ne regardera pas le joueur.