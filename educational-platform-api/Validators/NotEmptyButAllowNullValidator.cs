using FluentValidation;
using FluentValidation.Validators;
using System;
using System.Collections;
using System.Collections.Generic;

namespace educational_platform_api.Validators
{
    public class NotEmptyButAllowNullValidator<T, TProperty> : PropertyValidator<T, TProperty>, INotEmptyValidator
    {
        public override string Name => "NotEmptyValidator";

        public override bool IsValid(ValidationContext<T> context, TProperty value)
        {
            if (value == null)
            {
                return true;
            }
            switch (value)
            {
                case string s when s == "":
                case ICollection { Count: 0 }:
                case Array { Length: 0 }:
                case IEnumerable e when !e.GetEnumerator().MoveNext():
                    return false;
            }

            return !EqualityComparer<TProperty>.Default.Equals(value, default);
        }

        protected override string GetDefaultMessageTemplate(string errorCode)
        {
            return Localized(errorCode, Name);
        }
    }

    public interface INotEmptyValidator : IPropertyValidator
    {
    }

}
