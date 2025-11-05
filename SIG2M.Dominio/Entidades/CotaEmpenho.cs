using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIG2M.Dominio.Entidades
{
    [Table("cota_empenho")]
    public class CotaEmpenho
    {

        [Key]
        [Column("cod_material")]
        [Required]
        [StringLength(10)]
        public string CodMaterial { get; set; }

        [Column("cmmv")]
        public decimal? Cmmv { get; set; }

        [Column("cota")]
        public decimal? Cota { get; set; }

        [Column("rp")]
        public decimal? Rp { get; set; }

        [Column("empenho")]
        public decimal? Empenho { get; set; }

        [Column("saldo")]
        public decimal? Saldo { get; set; }
    }
}
