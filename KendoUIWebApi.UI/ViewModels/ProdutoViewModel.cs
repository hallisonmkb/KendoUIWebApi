﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace KendoUIWebApi.UI.ViewModels
{
    public class ProdutoViewModel
    {
        [Key]
        public int ProdutoId { get; set; }

        [Required(ErrorMessage = "Preencha o nome")]
        [MaxLength(250, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
        public string Nome { get; set; }

        [DataType(DataType.Currency)]
        [Range(typeof(decimal), "0", "999999999999")]
        [Required(ErrorMessage = "Preencha um valor")]
        public decimal Valor { get; set; }

        public bool Disponivel { get; set; }

        [DisplayName("Cliente")]
        public int ClienteId { get; set; }

        public virtual ClienteViewModel Cliente { get; set; }
    }
}