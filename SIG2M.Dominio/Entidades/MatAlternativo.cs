using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIG2M.Dominio.Entidades
{
    [Table("mat_alternativo")]
    public class MatAlternativo
    {

        [Key]
        [Column("cod_material")]
        public int CodMaterial { get; set; }

        [Key]
        [Column("cod_alternativo")]
        public int CodAlternativo { get; set; }

        [Column("proporcao")]
        public decimal Proporcao { get; set; }

        [Column("obs")]
        [Required]
        [StringLength(100)]
        public string Obs { get; set; }
    }
}
