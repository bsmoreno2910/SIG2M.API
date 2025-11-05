using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIG2M.Dominio.Entidades
{
    [Table("itens_empenho")]
    public class ItensEmpenho
    {

        [Key]
        [Column("id_item")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdItem { get; set; }

        [Column("id_empenho")]
        public int IdEmpenho { get; set; }

        [Column("cod_material")]
        public int CodMaterial { get; set; }

        [Column("qtde_pacotes")]
        public decimal QtdePacotes { get; set; }

        [Column("fator")]
        public decimal Fator { get; set; }

        [Column("preco_pacote")]
        public decimal PrecoPacote { get; set; }

        [Column("saldo_unidades")]
        public decimal SaldoUnidades { get; set; }

        [Column("marca")]
        [StringLength(20)]
        public string Marca { get; set; }

        [Column("bloqueado")]
        public decimal Bloqueado { get; set; }

        [Column("data_alteracao")]
        public DateTime DataAlteracao { get; set; }

        [Column("alterado_por")]
        public int AlteradoPor { get; set; }
    }
}
