﻿using FluentValidation;
using System.Globalization;
using System.Text.RegularExpressions;
using api.Validators;

namespace api.Extensions.Validators
{
    public static class ValidatorExtension
    {
        public static IRuleBuilderOptions<T, string> CanParseDateTime<T>(this IRuleBuilder<T, string> ruleBuilder,
            string format = "dd/MM/yyyy")
        {   
            return ruleBuilder.Must(x => 
                DateTime.TryParseExact(x, format, CultureInfo.InvariantCulture, 
                    DateTimeStyles.None, out DateTime date));
        }
        public static IRuleBuilderOptions<T, string> CanParseDateTimeOrNull<T>(this IRuleBuilder<T, string> ruleBuilder,
            string format = "dd/MM/yyyy")
        {

            return ruleBuilder.Must(x =>
            {
                if (x == null)
                {
                    return true;
                }
                else
                {
                    return DateTime.TryParseExact(x, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date);
                }
            });
        }

        public static IRuleBuilderOptions<T, string> CorrectPermissionsFormat<T>(this IRuleBuilder<T, string> ruleBuilder,
            string regexp = @"^[[]([~][]\w|-]+[~]+[,]?)+[]]$")
        {

            return ruleBuilder.Must(x =>
                {
                    string str = x;
                    str = str.Replace("\"", "~");
                    return Regex.Match(str, regexp).Success;
                });
        }
        public static IRuleBuilderOptions<T, string> CorrectMobilePhoneFormat<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.Matches(@"\(?\d{3}\)?[-\.]? *\d{3}[-\.]? *[-\.]?\d{4}");
        }
        public static IRuleBuilderOptions<T, TProperty> NotEmptyButAllowNull<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder)
            => ruleBuilder.SetValidator(new NotEmptyButAllowNullValidator<T, TProperty>());

    }
}
