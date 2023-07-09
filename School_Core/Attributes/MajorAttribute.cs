using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace School_Core.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class MajorAttribute : ValidationAttribute
    {
        List<string> _majors;
        public MajorAttribute(params string[] Majors)
        {
            _majors = new List<string>(Majors);
        }

        public override bool IsValid(object? value)
        {
            string obj= (string)value!;

            bool result = false;
            if (value != null)
            {
                foreach (var item in _majors)
                {
                    if (item.ToLower() == obj)
                    {
                        result = true;
                    }
                }
            }
            else
            {
                result = false;
            }
            return result;
        }
    }


}
