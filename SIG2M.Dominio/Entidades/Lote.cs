using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIG2M.Dominio.Entidades
{
    [Table("lote")]
    public class Lote
    {

        [Key]
        [Column("cod_lote")]
        [Required]
        [StringLength(30)]
        public string CodLote { get; set; }

        [Key]
        [Column("cod_material")]
        public int CodMaterial { get; set; }

        [Column("qtde")]
        public decimal Qtde { get; set; }

        [Column("validade")]
        public DateTime Validade { get; set; }

        [Key]
        [Column("endereco")]
        [Required]
        [StringLength(20)]
        public string Endereco { get; set; }

        [Key]
        [Column("status")]
        [Required]
        public string Status { get; set; }

        [Column("fabricante")]
        [StringLength(20)]
        public string Fabricante { get; set; }

        [Column("mascara")]
        public int Mascara { get; set; }

        [Column("tipo_estoque")]
        [Required]
        public string TipoEstoque { get; set; }
    }
}
