using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MeuEstoque.Models.Classes
{
    public class Produto
    {
        [Key]
        [Column(Order = 0)]
        public int Id { get; set; }

        [Required(ErrorMessage ="*")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "*")]
        public float Peso { get; set; }

        [Required(ErrorMessage = "*")]
        public int Quantidade { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Preço Unitário")]
        public double PrecoUnitario { get; set; }

        [Required(ErrorMessage = "*")]
        public int CategoriaId { get; set; }

        public Categoria Categoria { get; set; }
    }
}