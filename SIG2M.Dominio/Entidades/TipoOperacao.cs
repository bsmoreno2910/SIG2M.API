using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIG2M.Dominio.Entidades
{
    [Table("tipo_operacao")]
    public class TipoOperacao
    {

        [Key]
        [Column("cod_operacao")]
        [Required]
        [StringLength(15)]
        public string CodOperacao { get; set; }

        [Column("descricao")]
        [Required]
        [StringLength(60)]
        public string Descricao { get; set; }

        [Column("tipo")]
        [Required]
        public string Tipo { get; set; }

        [Column("tipo_valor")]
        [Required]
        public string TipoValor { get; set; }

        [Column("recalculo")]
        [Required]
        public string Recalculo { get; set; }

        [Column("contabiliza")]
        [Required]
        public string Contabiliza { get; set; }

        [Column("baixa_empenho")]
        [Required]
        public string BaixaEmpenho { get; set; }
    }
}
