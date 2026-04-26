# CookBook

A clean-architecture C# solution for managing recipes, chefs, and gourmets.

## Solution Structure

```
CookBook/
├── src/
│   ├── CookBook.Domain                         # Entities, enums, domain logic
│   │   ├── Base/
│   │   │   └── BaseEntity.cs
│   │   ├── Entities/
│   │   │   ├── Chef.cs
│   │   │   ├── Gourmet.cs
│   │   │   ├── Recipe.cs
│   │   │   ├── RecipeStatus.cs
│   │   │   ├── Ingredient.cs
│   │   │   ├── Photo.cs
│   │   │   ├── Favorite.cs
│   │   │   ├── Rating.cs
│   │   │   └── Comment.cs
│   │   └── Exceptions/
│   │       └── DomainException.cs
│   │
│   ├── CookBook.ValueObjects                   # Value objects with validation
│   │   ├── Base/
│   │   │   └── ValueObject.cs
│   │   ├── Exceptions/
│   │   │   ├── ValueObjectException.cs
│   │   │   ├── InvalidUsernameException.cs
│   │   │   └── InvalidTitleException.cs
│   │   ├── Validators/
│   │   │   ├── UsernameValidator.cs
│   │   │   └── TitleValidator.cs
│   │   ├── Username.cs
│   │   └── Title.cs
│   │
│   └── CookBook.Domain.Repositories.Abstractions   # Repository interfaces
│       ├── Base/
│       │   └── IRepository.cs
│       ├── IChefRepository.cs
│       ├── IGourmetRepository.cs
│       ├── IRecipeRepository.cs
│       ├── IIngredientRepository.cs
│       ├── IPhotoRepository.cs
│       ├── IFavoriteRepository.cs
│       ├── IRatingRepository.cs
│       └── ICommentRepository.cs
│
└── CookBook.sln
```

## Planned Layers

| Layer | Project | Status |
|-------|---------|--------|
| Domain | CookBook.Domain | ✅ Done |
| Value Objects | CookBook.ValueObjects | ✅ Done |
| Repository Abstractions | CookBook.Domain.Repositories.Abstractions | ✅ Done |
| Infrastructure | CookBook.Infrastructure | 🔜 Next |
| Application | CookBook.Application | 🔜 Planned |
| Presentation | CookBook.Presentation | 🔜 Planned |

## Tech Stack

- .NET 8
- Entity Framework Core
- C# 12

## Domain Entities

| Entity | Description |
|--------|-------------|
| Chef | Recipe author |
| Gourmet | Recipe consumer who can rate, comment, and favourite |
| Recipe | Core entity with status lifecycle (Draft → Published → Archived) |
| Ingredient | Belongs to a recipe |
| Photo | Recipe photos, one can be marked as main |
| Favorite | Gourmet ↔ Recipe many-to-many |
| Rating | Score 1–5 per gourmet per recipe |
| Comment | Text feedback from gourmet on a recipe |
