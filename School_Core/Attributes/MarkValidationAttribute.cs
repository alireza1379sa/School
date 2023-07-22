using System.ComponentModel.DataAnnotations;

namespace School_Core.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class MarkValidationAttribute:ValidationAttribute
    {
        private readonly int _start;
        private readonly int _end;
        public MarkValidationAttribute(int start,int end)
        {
            _start= start;
            _end= end;
        }
        public override bool IsValid(object? value)
        {
            int result = (int)value!;
            if (result >= _start && result <= _end)
            {
                return true;
            }
            return false;
        }
    }
}
