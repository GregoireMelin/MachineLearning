# INTITULE DU PROJET 

# projet-csharp-2017
# Projet C# 2017 : chariots intelligents

# OBJECTIF
 
Automatiser la récupération des colis en créant un programme de gestion des chariots

# DONNEES

# Caractéristiques entrepôts

- Taille : 25x25

# Caractéristiques Chariots 

- Deplacement
	Peuvent se déplacer verticalement et horizontalement
	Pas de déplacement en diagonale (déplacement cartésien en 2 dimension)
- Tourner 
	Rotation sur lui même
- Pas de chariots au même endroit

# PROCEDURE

Quand l'objet est vendu:
	- On prélève sa référence en consultant la BDD
	- On en déduit son emplacement:
    - x,y : Coordonnees (1:25)
		- k : Orientation (nord ou sud)
		- z : Hauteur


