using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace ProvaCandidato.Data.Entidade
{
    [Table("Cidade")]
    public class Cidade
    {
        [Key]
        [Column("codigo")]
        public int Codigo { get; set; }

        [Column("nome")]
        [StringLength(50, ErrorMessage = "O nome deve conter entre {2} e {1} caracteres.", MinimumLength = 3)]
        [Required]
        public string Nome { get; set; }
    }
}
