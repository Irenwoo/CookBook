using System.Collections.Generic;
using CookBook.ValueObjects.Base;
using CookBook.ValueObjects.Validators;

namespace CookBook.ValueObjects
{
    public class RecipeTitle : ValueObject
    {
        public string Value { get; private set; }

        public RecipeTitle(string value)
        {
            var validator = new RecipeTitleValidator();
            validator.Validate(value);
            Value = value;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}