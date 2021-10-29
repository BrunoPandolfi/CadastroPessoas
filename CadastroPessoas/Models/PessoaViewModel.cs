using CadastroPessoas.Validations;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroPessoas.Models
{
    public class PessoaViewModel
    {
        [RegularExpression(@"^[A-Za-z\u00C0-\u00FF ]+$", ErrorMessage = "{0} deve possuir somente letras")]
        [Required(ErrorMessage = "{0} é obrigatório")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "{0} é obrigatório")]
        [RegularExpression(@"^[0-9]{3}\.?[0-9]{3}\.?[0-9]{3}\-?[0-9]{2}", ErrorMessage = "{0} inválido")]
        public string Cpf { get; set; }
        [Required(ErrorMessage = "{0} é obrigatório")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DataNascimento(ErrorMessage="Data inválida")]
        public DateTime DataNascimento { get; set; }
        [Required(ErrorMessage = "{0} é obrigatório")]
        [EmailAddress(ErrorMessage = "Entre com um email válido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "{0} é obrigatório")]
        public IFormFile ImgAvatar { get; set; }

        public PessoaViewModel()
        {

        }
    }
}
