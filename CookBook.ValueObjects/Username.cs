using System.Collections.Generic;
using CookBook.ValueObjects.Base;
using CookBook.ValueObjects.Validators;

namespace CookBook.ValueObjects
{
    public class Username : ValueObject
    {
        public string Value { get; private set; }

        public Username(string value)
        {
            var validator = new UsernameValidator();
            validator.Validate(value);
            Value = value;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}