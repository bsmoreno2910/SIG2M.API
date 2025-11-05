using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIG2M.Dominio.Entidades
{
    [Table("historico_consumo")]
    public class HistoricoConsumo
    {

        [Key]
        [Column("cod_material")]
        public int CodMaterial { get; set; }

        [Key]
        [Column("cod_almox")]
        [Required]
        [StringLength(10)]
        public string CodAlmox { get; set; }

        [Column("mes")]
        public int Mes { get; set; }

        [Column("ano")]
        public short Ano { get; set; }

        [Column("qtde")]
        public decimal Qtde { get; set; }
    }
}
