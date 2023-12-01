# SurcoufStore

# Contexte
Vous travaillez en bin�me avec Xavier, d�veloppeur Front.

Xavier est une instance de Tchat GPT-9, une IA du futur qui fournit un d�veloppeur digital front as a service.
Heureusement pour vous, les investisseurs sont encore r�ticents � confier la partie backend � une IA.

Il vous faut donc cr�er l'API qui sera utilis�e par les diff�rentes solutions propos�es par Xavier.
Cette API utilisera .NET 6 ou + et chaque projet de la solution devra avoir l'option nullable active.

## Mise en place de l'architecture
Le backend sera d�coup� en plusieurs couches/projets :
Domain : les entit�s etc
Application ou UseCase : nom au choix
Infrastructure (note : il est aussi possible d'utiliser l'approche hexagonale avec ports & adapters)
Api : startup project

## Base de donn�es
En utilisant une base de donn�es SQLite, un DbContext expose :
- Category (Id, Name, CategoryId? (Le parent))
- Article (Id, Name (min 2 caract�res et jamais plus de 50), CategoryId, Stock, PriceBuy (> 0), PriceSell (ne doit pas �tre < � PriceBuy))

### Jeu de donn�es
Cat�gories :
- 1, "High Tech"
- 2, "T�l�phonie", 1
- 3, "Android", 2
- 4, "iOS", 2
- 5, "PC", 1
- 6, "Ecrans", 1
- 7, "Ecran PC", 6
- 8, "Ecran TV", 6
- 9, "Electrom�nager"
- 10, "Frigo", 9
- 11, "Lave vaisselle", 9

Article :
- 1, "Samsung S20", 3, 10, 600, 800
- 2, "Xiaomi", 3, 10, 250, 299.99
- 3, "iPhone 14", 4, 8, 900, 1200
- 4, "Pc Gamer", 5, 2, 1800, 2000
- 5, "Kindle", 6, 0, 150, 180
- 6, "Lenovo 27 pouces", 7, 3, 250, 330
- 7, "Samsung The Frame", 8, 10, 1400, 1500
- 8, "Frigo Electrolux", 10, 5, 800, 1000
- 9, "Whirlpool", 11, 5, 450, 550

## API
L'API exposera :
- Une route qui permet d'ajouter un article
- Une route qui retourne la valeur marchande totale des articles
- Une route qui retourne une arborescence compl�te des cat�gories avec les articles � chaque niveau
- Une route qui retourne la liste des articles avec un stock <= � une valeur donn�e en input (par d�faut � 0)

 ## Mise � jour
 Oups, William, l'IA qui analyse le code humain vous dit qu'un audit a �t� fait sur votre code source.
 Votre base de donn�e doit �voluer pour permettre de d�sactiver n'importe quelle ligne.
 Il faut d�sormais faire une migration de la base pour ajouter la propri�t� IsInactive dans chacune des tables.