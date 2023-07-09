using System.ComponentModel.DataAnnotations;

namespace School_Core.Attributes
{
    public class TimeAttribute: ValidationAttribute
    {
        private readonly TimeSpan begin=new TimeSpan(hours:8,minutes:0, seconds:0);

        private readonly TimeSpan end=new TimeSpan(hours:16,minutes:0,seconds:0);

        public override bool IsValid(object? value)
        {
            bool result = false;
            if (value != null)
            {
                TimeSpan time= (TimeSpan)value;
                if(time>=begin&&time<=end)
                {
                    result = true;
                }
            }
            return result;
        }

    }
}
