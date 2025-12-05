using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIG2M.Dominio.Entidades
{
    [Table("movimento")]
    public class Movimento
    {

        [Required]
        [Column("ano")]
        public short Ano { get; set; }

        [Key, Required]
        [Column("cod_movimento")]
        public int CodMovimento { get; set; }

        [Column("cod_log")]
        public int CodLog { get; set; }

        [Column("cod_operacao")]
        [Required]
        [StringLength(15)]
        public string CodOperacao { get; set; }

        [Column("cod_material")]
        public int CodMaterial { get; set; }

        [Column("referencia")]
        [Required]
        [StringLength(20)]
        public string Referencia { get; set; }

        [Column("documento")]
        [Required]
        [StringLength(15)]
        public string Documento { get; set; }

        [Column("data")]
        public DateTime Data { get; set; }

        [Column("obs")]
        [Required]
        [StringLength(80)]
        public string Obs { get; set; }

        [Column("lote")]
        [Required]
        [StringLength(30)]
        public string Lote { get; set; }

        [Column("endereco")]
        [Required]
        [StringLength(20)]
        public string Endereco { get; set; }

        [Column("status")]
        [Required]
        public string Status { get; set; }

        [Column("fabricante")]
        [StringLength(20)]
        public string Fabricante { get; set; }

        [Column("validade")]
        public DateTime Validade { get; set; }

        [Column("qtde")]
        public decimal Qtde { get; set; }

        [Column("valor_unitario")]
        public decimal ValorUnitario { get; set; }

        [Column("mascara")]
        public int Mascara { get; set; }

        [Column("tpmov")]
        [Required]
        public string Tpmov { get; set; }
    }
}
