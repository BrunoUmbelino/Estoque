using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MeuEstoque.Models.Classes
{
    public class Usuario
    {
        [Key]
        [Column(Order = 0)]
        public int Id { get; set; }

        [Required(ErrorMessage ="*")]
        public string NomeCompleto { get; set; }

        [Required(ErrorMessage = "*")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        
        [Required(ErrorMessage = "*")]
        [DataType(DataType.Password)]
        public int Senha { get; set; }

        [Required(ErrorMessage = "*")]
        [DataType(DataType.Password)]
        [Compare("Senha")]
        public int SenhaConfirmada { get; set; }

        public int ?NivelDeAcesso { get; set; }
    }
}