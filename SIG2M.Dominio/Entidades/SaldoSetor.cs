using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIG2M.Dominio.Entidades
{
    [Table("saldo_setor")]
    public class SaldoSetor
    {

        [Key]
        [Column("sigla")]
        [Required]
        [StringLength(10)]
        public string Sigla { get; set; }

        [Key]
        [Column("cod_material")]
        public int CodMaterial { get; set; }

        [Column("qtde")]
        public decimal Qtde { get; set; }

        [Column("data")]
        public DateTime Data { get; set; }
    }
}
