using System.Collections.Generic;
using CookBook.ValueObjects.Base;
using CookBook.ValueObjects.Validators;

namespace CookBook.ValueObjects
{
    public class IngredientName : ValueObject
    {
        public string Value { get; private set; }

        public IngredientName(string value)
        {
            var validator = new IngredientNameValidator();
            validator.Validate(value);
            Value = value;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}