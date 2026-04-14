using System.Collections.Generic;
using CookBook.ValueObjects.Base;
using CookBook.ValueObjects.Validators;

namespace CookBook.ValueObjects
{
    public class Content : ValueObject
    {
        public string Value { get; private set; }

        public Content(string value)
        {
            var validator = new ContentValidator();
            validator.Validate(value);
            Value = value;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}