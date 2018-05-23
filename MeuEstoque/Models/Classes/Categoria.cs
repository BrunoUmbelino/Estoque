using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MeuEstoque.Models.Classes
{
    public class Categoria
    {
        [Key]
        [Column(Order = 0)]
        public int Id { get; set; }

        [Required(ErrorMessage = "*")]
        public string Nome { get; set; }
    }
}