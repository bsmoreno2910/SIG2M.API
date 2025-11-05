using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIG2M.Dominio.Entidades
{
    [Table("historico_movimento")]
    public class HistoricoMovimento
    {

        [Key]
        [Column("cod_material")]
        public int CodMaterial { get; set; }

        [Key]
        [Column("ano")]
        public short Ano { get; set; }

        [Key]
        [Column("mes")]
        public byte Mes { get; set; }

        [Column("entradas")]
        public decimal Entradas { get; set; }

        [Column("valor_entrada")]
        public decimal ValorEntrada { get; set; }

        [Column("saidas")]
        public decimal Saidas { get; set; }

        [Column("valor_saida")]
        public decimal ValorSaida { get; set; }

        [Column("saldo_final")]
        public decimal SaldoFinal { get; set; }

        [Column("valor_final")]
        public decimal ValorFinal { get; set; }
    }
}
