using CookBook.Domain;
using CookBook.Domain.Enums;
using CookBook.ValueObjects;
using System;

namespace DomainApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== CookBook Domain App ===");
            Console.WriteLine("Тестирование доменного слоя\n");

            try
            {
                // 1. Создание Username и Chef
                Console.WriteLine("--- 1. Создание шефа ---");
                var chefUsername = new Username("GordonRamsay");
                var chef = new Chef(chefUsername);
                Console.WriteLine($"Шеф: {chef.Username.Value}");
                Console.WriteLine($"ID: {chef.Id}");
                Console.WriteLine($"UUID: {chef.Uuid}");
                Console.WriteLine($"Создан: {chef.CreatedAt}\n");

                // 2. Создание Gourmet
                Console.WriteLine("--- 2. Создание гурмана ---");
                var gourmetUsername = new Username("FoodLover");
                var gourmet = new Gourmet(gourmetUsername);
                Console.WriteLine($"Гурман: {gourmet.Username.Value}");
                Console.WriteLine($"ID: {gourmet.Id}\n");

                // 3. Создание рецепта
                Console.WriteLine("--- 3. Создание рецепта ---");
                var recipeTitle = new RecipeTitle("Борщ");
                var recipe = new Recipe(chef.Id, recipeTitle, "1. Сварить бульон. 2. Добавить свеклу. 3. Добавить капусту.");
                Console.WriteLine($"Рецепт: {recipe.Title.Value}");
                Console.WriteLine($"Статус: {recipe.Status}");
                Console.WriteLine($"ChefId: {recipe.ChefId}\n");

                // 4. Публикация рецепта
                Console.WriteLine("--- 4. Публикация рецепта ---");
                recipe.Publish();
                Console.WriteLine($"Статус после публикации: {recipe.Status}");
                Console.WriteLine($"Опубликован: {recipe.PublishedAt}\n");

                // 5. Создание ингредиента
                Console.WriteLine("--- 5. Создание ингредиента ---");
                var ingredientName = new IngredientName("Свекла");
                var ingredient = new Ingredient(recipe.Id, ingredientName, 300.00m, "г");
                Console.WriteLine($"Ингредиент: {ingredient.Name.Value}");
                Console.WriteLine($"Количество: {ingredient.Quantity} {ingredient.Unit}\n");

                // 6. Создание фото
                Console.WriteLine("--- 6. Создание фото ---");
                var photo = new Photo(recipe.Id, "/photos/borshch.jpg", true);
                Console.WriteLine($"Фото URL: {photo.Url}");
                Console.WriteLine($"Главное фото: {photo.IsMain}\n");

                // 7. Добавление в избранное
                Console.WriteLine("--- 7. Добавление в избранное ---");
                var favorite = new Favorite(gourmet.Id, recipe.Id);
                Console.WriteLine($"Гурман {gourmet.Username.Value} добавил рецепт в избранное");
                Console.WriteLine($"Дата: {favorite.CreatedAt}\n");

                // 8. Оценка рецепта
                Console.WriteLine("--- 8. Оценка рецепта ---");
                var rating = new Rating(gourmet.Id, recipe.Id, 5);
                Console.WriteLine($"Оценка: {rating.Score}/5\n");

                // 9. Комментарий
                Console.WriteLine("--- 9. Комментарий ---");
                var content = new Content("Отличный рецепт! Спасибо!");
                var comment = new Comment(gourmet.Id, recipe.Id, content);
                Console.WriteLine($"Комментарий: {comment.Content.Value}");
                Console.WriteLine($"Автор: {comment.GourmetId}\n");

                Console.WriteLine("=== Все тесты пройдены успешно! ===");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }

            Console.ReadKey();
        }
    }
}