using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIG2M.Dominio.Entidades
{
    [Table("item_recebimento")]
    public class ItemRecebimento
    {

        [Key]
        [Column("cod_recebimento")]
        public long CodRecebimento { get; set; }

        [Key]
        [Column("sequencia")]
        public int Sequencia { get; set; }

        [Column("cod_material")]
        public int CodMaterial { get; set; }

        [Column("fabricante")]
        [StringLength(20)]
        public string Fabricante { get; set; }

        [Column("unidade")]
        [Required]
        [StringLength(2)]
        public string Unidade { get; set; }

        [Column("multiplicador")]
        public decimal Multiplicador { get; set; }

        [Column("qtde")]
        public decimal Qtde { get; set; }

        [Column("qtde_contada")]
        public decimal QtdeContada { get; set; }

        [Column("qtde_segregada")]
        public decimal QtdeSegregada { get; set; }

        [Column("valor_unit")]
        public decimal ValorUnit { get; set; }

        [Column("valor_ipi")]
        public decimal ValorIpi { get; set; }

        [Column("valor_icms")]
        public decimal ValorIcms { get; set; }

        [Column("status_contagem")]
        [Required]
        public string StatusContagem { get; set; }

        [Column("status_inspecao")]
        [Required]
        public string StatusInspecao { get; set; }

        [Column("obs")]
        [Required]
        [StringLength(50)]
        public string Obs { get; set; }
    }
}
