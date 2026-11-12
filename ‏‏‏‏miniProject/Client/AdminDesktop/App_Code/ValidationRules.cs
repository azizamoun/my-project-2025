using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Text.RegularExpressions;  //Regex
using System.Windows.Controls;     //validationRule
using System.Windows.Forms;

namespace AdminDesktop.App_Code
{
    internal class ValidationRules
    {
    }

    public class RequiredFiledValidationRule : ValidationRule
    {
        public string Message { get; set; }
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string str= value as string;
            if(str!= null)
            {
                if (str.Trim().Length > 0)
                    return ValidationResult.ValidResult;
                                
            }
            return new ValidationResult(false, Message);
           
        }
    }
    public class RegExpValidationRule : ValidationRule
    {
        public string Message { get; set; }
        public string ValidationExpression { get; set; }
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (string.IsNullOrEmpty(ValidationExpression) || string.IsNullOrWhiteSpace(ValidationExpression))
                return new ValidationResult(true, Message);
            string str = value as string;
            if (str != null)
            {
                Regex regex = new Regex(ValidationExpression);
                if (!regex.IsMatch(str))
                    return new ValidationResult(false, Message);
                else
                    return ValidationResult.ValidResult;
            }
            return new ValidationResult(false, Message);

        }
    }
    public class IntValidationRule : ValidationRule
    {
        public string Message { get; set; }
        public int Min {  get; set; }
        public int Max { get; set; }    
        public IntValidationRule() { }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if(Min==0 && Max == 0)
               { 
                Min=int.MinValue;
                Max=int.MaxValue; 
               }
            if(Min>Max)
            {
                int tmp = Min;
                Min = Max;
                Max=tmp;
            }
            string str = value as string;
            if (str != null)
            {
                int num = 0;
                if(!int.TryParse(str, out num)|| !(num>=Min && num<=Max))
                {
                    return new ValidationResult(false, Message);
                }
                else
                {
                    return ValidationResult.ValidResult;
                }
            }
            return new ValidationResult(false , Message);
        }
    }

}
