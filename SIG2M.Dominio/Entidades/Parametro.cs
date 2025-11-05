using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIG2M.Dominio.Entidades
{
    [Table("parametro")]
    public class Parametro
    {

        [Key]
        [Column("cod_material")]
        public int CodMaterial { get; set; }

        [Key]
        [Column("cod_almox")]
        [Required]
        [StringLength(10)]
        public string CodAlmox { get; set; }

        [Column("trd")]
        public int Trd { get; set; }

        [Column("esd")]
        public int Esd { get; set; }

        [Column("ted")]
        public int Ted { get; set; }

        [Column("limite")]
        public int Limite { get; set; }

        [Column("crd")]
        public int Crd { get; set; }
    }
}
