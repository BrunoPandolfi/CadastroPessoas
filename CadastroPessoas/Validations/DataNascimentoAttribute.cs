using System;
using System.ComponentModel.DataAnnotations;

namespace CadastroPessoas.Validations
{
    public class DataNascimentoAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime nascimento;
            bool isDate = DateTime.TryParse(value.ToString(), out nascimento );
            if (!isDate)
            {
                return false; 
            }
            if (nascimento > DateTime.Now)
            {
                return false;
            }
            return true;
        }
    }
}
