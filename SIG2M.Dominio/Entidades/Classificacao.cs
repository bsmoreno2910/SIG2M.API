using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIG2M.Dominio.Entidades
{
    [Table("classificacao")]
    public class Classificacao
    {

        [Key]
        [Column("cod_material")]
        public int CodMaterial { get; set; }

        [Column("tipo_abc")]
        [Required]
        public string TipoAbc { get; set; }

        [Column("tipo_xyzw")]
        [Required]
        public string TipoXyzw { get; set; }

        [Column("cod_almox")]
        [Required]
        [StringLength(10)]
        public string CodAlmox { get; set; }
    }
}
