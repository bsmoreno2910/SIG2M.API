using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIG2M.Dominio.Entidades
{
    [Table("mat_valor")]
    public class MatValor
    {

        [Key]
        [Column("cod_material")]
        public int CodMaterial { get; set; }

        [Column("valor_medio")]
        public decimal ValorMedio { get; set; }

        [Column("valor_atual")]
        public decimal ValorAtual { get; set; }

        [Column("data")]
        public DateTime Data { get; set; }
    }
}
