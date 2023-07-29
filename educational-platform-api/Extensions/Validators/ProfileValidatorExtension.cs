using FluentValidation;
using System.Globalization;

namespace educational_platform_api.Extensions.Validators
{
    public static class ProfileValidatorExtension
    {
        public static IRuleBuilderOptions<T, string> CanParseDateOnly<T>(this IRuleBuilder<T, string> ruleBuilder,
            string format = "dd/MM/yyyy")
        {   
            return ruleBuilder.Must(x => 
                DateTime.TryParseExact(x, format, CultureInfo.InvariantCulture, 
                    DateTimeStyles.None, out DateTime date)); 
        }
    }
}
