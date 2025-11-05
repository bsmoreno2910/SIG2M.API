using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIG2M.Dominio.Entidades
{
    [Table("demanda_reprimida")]
    public class DemandaReprimida
    {

        [Key]
        [Column("sigla")]
        [Required]
        [StringLength(10)]
        public string Sigla { get; set; }

        [Key]
        [Column("cod_material")]
        public int CodMaterial { get; set; }

        [Key]
        [Column("cod_almox")]
        [Required]
        [StringLength(10)]
        public string CodAlmox { get; set; }

        [Key]
        [Column("ano")]
        public short Ano { get; set; }

        [Key]
        [Column("mes")]
        public byte Mes { get; set; }

        [Column("qtde")]
        public decimal Qtde { get; set; }
    }
}
