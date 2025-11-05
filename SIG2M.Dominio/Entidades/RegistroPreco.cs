using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIG2M.Dominio.Entidades
{
    [Table("registro_preco")]
    public class RegistroPreco
    {

        [Key]
        [Column("id_rp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdRp { get; set; }

        [Column("processo")]
        [Required]
        [StringLength(15)]
        public string Processo { get; set; }

        [Column("data_processo")]
        public DateTime DataProcesso { get; set; }

        [Column("cod_fornecedor")]
        [Required]
        [StringLength(18)]
        public string CodFornecedor { get; set; }

        [Column("ata_nr")]
        [Required]
        [StringLength(12)]
        public string AtaNr { get; set; }

        [Column("ata_data")]
        public DateTime AtaData { get; set; }

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
