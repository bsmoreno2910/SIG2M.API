using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIG2M.Dominio.Entidades
{
    [Table("mat_natureza")]
    public class MatNatureza
    {

        [Column("cod_material")]
        public int CodMaterial { get; set; }

        [Column("cod_natureza")]
        public int CodNatureza { get; set; }

        [Column("obs")]
        [Required]
        [StringLength(100)]
        public string Obs { get; set; }
    }
}
