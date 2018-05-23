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

        [Required(ErrorMessage = "*")]
        [MinLength(5, ErrorMessage = "Mínimo 5 caracteres")]
        [MaxLength(25, ErrorMessage = "Máximo 25 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "*")]
        [DisplayFormat(DataFormatString ="{0:n3}")]
        [Display(Name ="Peso (Gramas)")]
        public float Peso { get; set; }

        [Required(ErrorMessage = "*")]
        [Range(1,500,ErrorMessage ="Quantidade mínima de 1 e máxima de 500")]
        public int Quantidade { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Preço Unitário")]
        [DataType(DataType.Currency)]
        public double PrecoUnitario { get; set; }

        [Required(ErrorMessage = "*")]
        public int CategoriaId { get; set; }

        public Categoria Categoria { get; set; }
    }
}