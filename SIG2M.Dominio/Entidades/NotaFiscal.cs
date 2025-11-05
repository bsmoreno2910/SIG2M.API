using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIG2M.Dominio.Entidades
{
    [Table("nota_fiscal")]
    public class NotaFiscal
    {

        [Key]
        [Column("cod_recebimento")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long CodRecebimento { get; set; }

        [Column("cod_nf")]
        [Required]
        [StringLength(15)]
        public string CodNf { get; set; }

        [Column("cod_empenho")]
        [Required]
        [StringLength(20)]
        public string CodEmpenho { get; set; }

        [Column("cod_fornecedor")]
        [Required]
        [StringLength(18)]
        public string CodFornecedor { get; set; }

        [Column("cod_operacao")]
        [Required]
        [StringLength(15)]
        public string CodOperacao { get; set; }

        [Column("serie")]
        [Required]
        [StringLength(1)]
        public string Serie { get; set; }

        [Column("subserie")]
        [Required]
        [StringLength(2)]
        public string Subserie { get; set; }

        [Column("cfop")]
        [Required]
        [StringLength(4)]
        public string Cfop { get; set; }

        [Column("dg_cfop")]
        [Required]
        [StringLength(2)]
        public string DgCfop { get; set; }

        [Column("valor_ipi")]
        public decimal ValorIpi { get; set; }

        [Column("valor_icms")]
        public decimal ValorIcms { get; set; }

        [Column("valor_acessorios")]
        public decimal ValorAcessorios { get; set; }

        [Column("valor_total")]
        public decimal ValorTotal { get; set; }

        [Column("status_nf")]
        [Required]
        public string StatusNf { get; set; }

        [Column("data_emissao")]
        public DateTime DataEmissao { get; set; }

        [Column("data_recebimento")]
        public DateTime DataRecebimento { get; set; }
    }
}
