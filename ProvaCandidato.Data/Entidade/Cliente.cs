using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace ProvaCandidato.Data.Entidade
{
    [Table("Cliente")]
    public class Cliente
    {
        [Key]
        [Column("codigo")]
        public int Codigo { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "O nome deve conter entre {2} e {1} caracteres.", MinimumLength = 3)]
        [Column("nome")]
        public string Nome { get; set; }


        [Column("data_nascimento")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTime? DataNascimento { get; set; }

        [Column("codigo_cidade")]
        [Display(Name = "Cidade")]
        public int CidadeId { get; set; }

        public bool Ativo { get; set; }

        [ForeignKey("CidadeId")]
        public virtual Cidade Cidade { get; set; }

    }
}