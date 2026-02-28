# CVMatchPro - Plateforme de Recrutement

Une application web ASP.NET Core Razor Pages pour la gestion des offres d'emploi et des candidatures avec système de matching intelligent basé sur les CVs.

## Fonctionnalités

- **Gestion des offres d'emploi** : Création, modification, suppression et consultation des offres
- **Système de candidature** : Upload de CV et candidature aux offres
- **Matching intelligent** : Analyse automatique des CVs et scoring de pertinence
- **Tableau de bord Admin** : Gestion des offres et des candidatures
- **Rapports analytiques** : Statistiques sur les offres et candidatures
- **Authentification** : Système de login/register avec ASP.NET Identity
- **Gestion des rôles** : Admin et utilisateurs standards

## Technologies utilisées

- **Framework** : ASP.NET Core 8.0 (Razor Pages + MVC)
- **Base de données** : SQL Server avec Entity Framework Core
- **Authentification** : ASP.NET Core Identity
- **Frontend** : Bootstrap, CSS personnalisé
- **Langage** : C# 12.0

1. **Cloner le repository**
```bash
git clone https://github.com/VOTRE-USERNAME/linkedin.git
cd linkedin
```

2. **Restaurer les packages NuGet**
```bash
dotnet restore
```

3. **Configurer la base de données**
   
   Modifiez la connection string dans `appsettings.json` :
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=LinkedInDB;Trusted_Connection=True;MultipleActiveResultSets=true"
  }
}
```

4. **Appliquer les migrations**
```bash
dotnet ef database update
```

5. **Lancer l'application**
```bash
dotnet run
```

6. **Accéder à l'application**
   
   Ouvrez votre navigateur : `https://localhost:5001` ou `http://localhost:5000`

## ?Compte Admin par défaut

Au premier lancement, un compte administrateur est automatiquement créé :

- **Email** : `admin@example.com`
- **Mot de passe** : `Admin@123`


##  Sécurité

- Les mots de passe sont hachés avec ASP.NET Identity
- Protection CSRF intégrée
- HTTPS obligatoire en production
- **Ne committez jamais vos connection strings de production**

## Fonctionnalités principales

### Pour les candidats :
- Consulter les offres d'emploi disponibles
- Postuler avec upload de CV
- Voir le score de matching avec chaque offre
- Suivre ses candidatures

### Pour les administrateurs :
- Créer et gérer les offres d'emploi
- Consulter toutes les candidatures
- Voir les CVs les plus pertinents pour chaque offre
- Accéder aux rapports statistiques

##  Développement

### Créer une migration
```bash
dotnet ef migrations add NomDeLaMigration
```

### Appliquer les migrations
```bash
dotnet ef database update
```

### Build le projet
```bash
dotnet build
```

##  Licence

Ce projet est développé à des fins éducatives.

## Auteur

Développé avec Kouchih Douae en utilisant ASP.NET Core 8.0
