using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIG2M.Dominio.Entidades
{
    [Table("mat_kit")]
    public class MatKit
    {

        [Key]
        [Column("nome_kit")]
        [Required]
        [StringLength(25)]
        public string NomeKit { get; set; }

        [Key]
        [Column("cod_material")]
        public int CodMaterial { get; set; }

        [Column("proporcao")]
        public decimal Proporcao { get; set; }
    }
}
