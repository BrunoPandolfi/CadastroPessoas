using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroPessoas.Models
{
    public class Pessoa
    {
        
        public int Id { get; set; }
        [Required(ErrorMessage = "{0} é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório")]
        public string Cpf { get; set; }
        [Required(ErrorMessage = "{0} é obrigatório")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório")]
        [EmailAddress(ErrorMessage = "Entre com um email válido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório")]
        public string ImgAvatar { get; set; }

        public Pessoa() { }

        public Pessoa (int id, string nome, string cpf, DateTime dataNascimento, string email, string imgAvatar)
        {
            Id = id;
            Nome = nome;
            Cpf = cpf;
            DataNascimento = dataNascimento;
            Email = email;
            ImgAvatar = imgAvatar;
        }
    }
}
