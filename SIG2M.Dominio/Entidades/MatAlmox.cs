using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIG2M.Dominio.Entidades
{
    [Table("mat_almox")]
    public class MatAlmox
    {

        [Key]
        [Column("cod_material")]
        public int CodMaterial { get; set; }

        [Key]
        [Column("cod_almox")]
        [Required]
        [StringLength(10)]
        public string CodAlmox { get; set; }

        [Column("ordem")]
        public byte Ordem { get; set; }
    }
}
