using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIG2M.Dominio.Entidades
{
    [Table("empenho")]
    public class tbdEmpenho
    {

        [Key]
        [Column("id_empenho")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdEmpenho { get; set; }

        [Column("empenho")]
        [Required]
        [StringLength(15)]
        public string Empenho { get; set; }

        [Column("pre_empenho")]
        [Required]
        [StringLength(15)]
        public string PreEmpenho { get; set; }

        [Column("cod_fornecedor")]
        [Required]
        [StringLength(18)]
        public string CodFornecedor { get; set; }

        [Column("processo")]
        [Required]
        [StringLength(15)]
        public string Processo { get; set; }

        [Column("ata_data")]
        public DateTime? AtaData { get; set; }

        [Column("ata_nr")]
        [StringLength(12)]
        public string AtaNr { get; set; }

        [Column("data_pre_empenho")]
        public DateTime DataPreEmpenho { get; set; }

        [Column("data_empenho")]
        public DateTime DataEmpenho { get; set; }

        [Column("fonte_recursos")]
        [Required]
        [StringLength(12)]
        public string FonteRecursos { get; set; }

        [Column("natureza")]
        [Required]
        [StringLength(22)]
        public string Natureza { get; set; }

        [Column("modalidade")]
        [Required]
        [StringLength(22)]
        public string Modalidade { get; set; }

        [Column("nro_modalidade")]
        [Required]
        [StringLength(12)]
        public string NroModalidade { get; set; }

        [Column("observacao")]
        [Required]
        [StringLength(100)]
        public string Observacao { get; set; }

        [Column("valor_total")]
        public decimal ValorTotal { get; set; }

        [Column("origem")]
        public string Origem { get; set; }

        [Column("encaminhamento")]
        public string Encaminhamento { get; set; }

        [Column("recebimento")]
        public string Recebimento { get; set; }

        [Column("data_registro")]
        public DateTime? DataRegistro { get; set; }

        [Column("criado_por")]
        public int? CriadoPor { get; set; }

        [Column("data_validade")]
        public DateTime? DataValidade { get; set; }

        [Column("data_alteracao")]
        public DateTime DataAlteracao { get; set; }

        [Column("alterado_por")]
        public int AlteradoPor { get; set; }

        [Column("data_exclusao")]
        public DateTime DataExclusao { get; set; }

        [Column("excluido_por")]
        public int ExcluidoPor { get; set; }
    }
}
