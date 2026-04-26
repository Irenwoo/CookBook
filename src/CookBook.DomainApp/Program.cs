using CookBook.Domain.Entities;
using CookBook.ValueObjects;

Console.OutputEncoding = System.Text.Encoding.UTF8;

Console.WriteLine("==============================================");
Console.WriteLine("       CookBook - Domain Layer               ");
Console.WriteLine("==============================================\n");


// 1. Создание шефа
Console.WriteLine("── 1. Создание шефа ──────────────────────────");
var chef = Chef.Create("Gordon Ramsay");
Console.WriteLine($"✅ Шеф создан: {chef.Username} (Id: {chef.Id})");

// Попытка создать шефа с пустым именем
try
{
    var invalidChef = Chef.Create("");
}
catch (ArgumentException ex)
{
    Console.WriteLine($"❌ Ошибка: {ex.Message}");
}

// Попытка создать шефа с именем > 50 символов
try
{
    var invalidChef = Chef.Create(new string('A', 51));
}
catch (ArgumentException ex)
{
    Console.WriteLine($"❌ Ошибка: {ex.Message}");
}


// 2. Создание гурмана
Console.WriteLine("\n── 2. Создание гурмана ───────────────────────");
var gourmet = Gourmet.Create("Julia Child");
Console.WriteLine($"✅ Гурман создан: {gourmet.Username} (Id: {gourmet.Id})");

// 3. Создание рецепта (черновик)
Console.WriteLine("\n── 3. Создание рецепта ───────────────────────");
var recipe = Recipe.Create(
    chefId: chef.Id,
    title: "Beef Wellington",
    instructions: "1. Wrap beef in puff pastry. 2. Bake at 200°C for 25 min.",
    description: "Classic British dish",
    cookingTime: 90,
    servings: 4
);
Console.WriteLine($"✅ Рецепт создан: '{recipe.Title}'");
Console.WriteLine($"   Статус: {recipe.Status}");
Console.WriteLine($"   Время готовки: {recipe.CookingTime} мин.");
Console.WriteLine($"   Порций: {recipe.Servings}");


// 4. Добавление ингредиентов
Console.WriteLine("\n── 4. Добавление ингредиентов ────────────────");
var ingredient1 = Ingredient.Create(recipe.Id, "Beef Tenderloin", 800, "г");
var ingredient2 = Ingredient.Create(recipe.Id, "Puff Pastry", 500, "г");
var ingredient3 = Ingredient.Create(recipe.Id, "Mushroom Duxelles", 300, "г");
Console.WriteLine($"✅ {ingredient1.Name} — {ingredient1.Quantity} {ingredient1.Unit}");
Console.WriteLine($"✅ {ingredient2.Name} — {ingredient2.Quantity} {ingredient2.Unit}");
Console.WriteLine($"✅ {ingredient3.Name} — {ingredient3.Quantity} {ingredient3.Unit}");

// Попытка создать ингредиент с отрицательным количеством
try
{
    var invalidIngredient = Ingredient.Create(recipe.Id, "Salt", -1, "г");
}
catch (ArgumentException ex)
{
    Console.WriteLine($"❌ Ошибка: {ex.Message}");
}

// 5. Добавление фото
Console.WriteLine("\n── 5. Добавление фото ────────────────────────");
var photo = Photo.Create(recipe.Id, "/images/beef-wellington.jpg", isMain: true);
Console.WriteLine($"✅ Фото добавлено: {photo.Url} (главное: {photo.IsMain})");


// 6. Публикация рецепта
Console.WriteLine("\n── 6. Публикация рецепта ─────────────────────");
Console.WriteLine($"   Статус до: {recipe.Status}");
recipe.Publish();
Console.WriteLine($"✅ Рецепт опубликован!");
Console.WriteLine($"   Статус после: {recipe.Status}");
Console.WriteLine($"   Дата публикации: {recipe.PublishedAt}");

// Попытка опубликовать уже опубликованный рецепт
try
{
    recipe.Publish();
}
catch (InvalidOperationException ex)
{
    Console.WriteLine($"❌ Ошибка: {ex.Message}");
}

// 7. Добавление в избранное
Console.WriteLine("\n── 7. Добавление в избранное ─────────────────");
var favorite = Favorite.Create(gourmet.Id, recipe.Id);
Console.WriteLine($"✅ Гурман '{gourmet.Username}' добавил '{recipe.Title}' в избранное");

// 8. Оценка рецепта
Console.WriteLine("\n── 8. Оценка рецепта ─────────────────────────");
var rating = Rating.Create(gourmet.Id, recipe.Id, 5);
Console.WriteLine($"✅ Гурман '{gourmet.Username}' поставил оценку: {rating.Score}/5");

// Попытка поставить оценку вне диапазона 1-5
try
{
    var invalidRating = Rating.Create(gourmet.Id, recipe.Id, 6);
}
catch (ArgumentException ex)
{
    Console.WriteLine($"❌ Ошибка: {ex.Message}");
}

// Обновление оценки
rating.UpdateScore(4);
Console.WriteLine($"✅ Оценка обновлена: {rating.Score}/5");

// 9. Комментарий к рецепту
Console.WriteLine("\n── 9. Комментарий к рецепту ──────────────────");
var comment = Comment.Create(gourmet.Id, recipe.Id, "Absolutely stunning dish! Tried it last Sunday.");
Console.WriteLine($"✅ Комментарий от '{gourmet.Username}': {comment.Content}");

comment.Edit("Absolutely stunning dish! Made it for Christmas dinner.");
Console.WriteLine($"✅ Комментарий отредактирован: {comment.Content}");

// 10. Архивирование рецепта
Console.WriteLine("\n── 10. Архивирование рецепта ─────────────────");
recipe.Archive();
Console.WriteLine($"✅ Рецепт архивирован. Статус: {recipe.Status}");

// Попытка обновить архивированный рецепт
try
{
    recipe.Update("New Title", "New instructions");
}
catch (InvalidOperationException ex)
{
    Console.WriteLine($"❌ Ошибка: {ex.Message}");
}

// 11. Value Objects
Console.WriteLine("\n── 11. Value Objects ─────────────────────────");
var username1 = Username.Create("Gordon Ramsay");
var username2 = Username.Create("Gordon Ramsay");
var username3 = Username.Create("Jamie Oliver");

Console.WriteLine($"✅ Username создан: {username1.Value}");
Console.WriteLine($"   username1 == username2: {username1 == username2}");
Console.WriteLine($"   username1 == username3: {username1 == username3}");

var title1 = Title.Create("Beef Wellington");
Console.WriteLine($"✅ Title создан: {title1.Value}");

// Попытка создать невалидный Username
try
{
    var invalidUsername = Username.Create("");
}
catch (Exception ex)
{
    Console.WriteLine($"❌ Ошибка: {ex.Message}");
}


Console.WriteLine("\n==============================================");
Console.WriteLine("   Демонстрация доменной логики завершена    ");
Console.WriteLine("==============================================");
