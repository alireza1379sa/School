using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace School_Core.Attributes
{
    public class NationalCode:ValidationAttribute
    {
        Regex regex = new Regex("[^0-9]+");

        public override bool IsValid(object? value)
        {
            string code=(string)value!;
            if(code!=null&&!regex.IsMatch(code)&&code.Length==10)
            {
                return true;
            }
            return false;
        }
    }
}
