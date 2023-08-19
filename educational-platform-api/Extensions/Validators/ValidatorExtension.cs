using FluentValidation;
using System.Globalization;
using System.Text.RegularExpressions;

namespace educational_platform_api.Extensions.Validators
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
        public static IRuleBuilderOptions<T, string> CorrectMobilePhoneFormat<T>(this IRuleBuilder<T, string> ruleBuilder,
            string regexp = @"^[[]([~][]\w|-]+[~]+[,]?)+[]]$")
        {

            return ruleBuilder.Matches(@"\(?\d{3}\)?[-\.]? *\d{3}[-\.]? *[-\.]?\d{4}");
        }
    }
}
