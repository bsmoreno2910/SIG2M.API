using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIG2M.Dominio.Entidades
{
    [Table("natureza")]
    public class Natureza
    {

        [Key]
        [Column("cod_natureza")]
        public int CodNatureza { get; set; }

        [Column("descricao")]
        [Required]
        [StringLength(30)]
        public string Descricao { get; set; }
    }
}
