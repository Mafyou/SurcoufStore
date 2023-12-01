# SurcoufStore

# Contexte
Vous travaillez en binôme avec Xavier, développeur Front.

Xavier est une instance de Tchat GPT-9, une IA du futur qui fournit un développeur digital front as a service.
Heureusement pour vous, les investisseurs sont encore réticents à confier la partie backend à une IA.

Il vous faut donc créer l'API qui sera utilisée par les différentes solutions proposées par Xavier.
Cette API utilisera .NET 6 ou + et chaque projet de la solution devra avoir l'option nullable active.

## Mise en place de l'architecture
Le backend sera découpé en plusieurs couches/projets :
Domain : les entités etc
Application ou UseCase : nom au choix
Infrastructure (note : il est aussi possible d'utiliser l'approche hexagonale avec ports & adapters)
Api : startup project

## Base de données
En utilisant une base de données SQLite, un DbContext expose :
- Category (Id, Name, CategoryId? (Le parent))
- Article (Id, Name (min 2 caractères et jamais plus de 50), CategoryId, Stock, PriceBuy (> 0), PriceSell (ne doit pas être < à PriceBuy))

### Jeu de données
Catégories :
- 1, "High Tech"
- 2, "Téléphonie", 1
- 3, "Android", 2
- 4, "iOS", 2
- 5, "PC", 1
- 6, "Ecrans", 1
- 7, "Ecran PC", 6
- 8, "Ecran TV", 6
- 9, "Electroménager"
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
- Une route qui retourne une arborescence complète des catégories avec les articles à chaque niveau
- Une route qui retourne la liste des articles avec un stock <= à une valeur donnée en input (par défaut à 0)

 ## Mise à jour
 Oups, William, l'IA qui analyse le code humain vous dit qu'un audit a été fait sur votre code source.
 Votre base de donnée doit évoluer pour permettre de désactiver n'importe quelle ligne.
 Il faut désormais faire une migration de la base pour ajouter la propriété IsInactive dans chacune des tables.