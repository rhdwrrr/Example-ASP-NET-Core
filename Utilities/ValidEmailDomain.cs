using System.ComponentModel.DataAnnotations;

namespace OrigamiEdu.Utilities
{
    public class ValidEmailDomain : ValidationAttribute
    {
        private readonly string[] allowedDomain;

        public ValidEmailDomain(string[] allowedDomain)
        {
            this.allowedDomain = allowedDomain;
        }
        public override bool IsValid(object value)
        {
            string[] getDomain = value.ToString().Split('@');
            bool result = false;
            foreach (var item in allowedDomain)
            {
                if(getDomain[1].ToLower() == item.ToLower())
                {
                    result = true;
                }
            }
            return result;
            // return base.IsValid(value);
        }
    }
}