using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIG2M.Dominio.Entidades
{
    [Table("inventario")]
    public class Inventario
    {

        [Key]
        [Column("cod_inventario")]
        public int CodInventario { get; set; }

        [Key]
        [Column("contador")]
        public int Contador { get; set; }

        [Column("cont_nr")]
        public int ContNr { get; set; }

        [Column("cod_lote")]
        [Required]
        [StringLength(30)]
        public string CodLote { get; set; }

        [Column("cod_material")]
        public int CodMaterial { get; set; }

        [Column("qtde")]
        public decimal Qtde { get; set; }

        [Column("validade")]
        public DateTime Validade { get; set; }

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

        [Column("mascara")]
        public int Mascara { get; set; }

        [Column("tipo_estoque")]
        [Required]
        public string TipoEstoque { get; set; }

        [Column("n_cod_lote")]
        [Required]
        [StringLength(30)]
        public string NCodLote { get; set; }

        [Column("n_validade")]
        public DateTime NValidade { get; set; }

        [Column("n_endereco")]
        [Required]
        [StringLength(20)]
        public string NEndereco { get; set; }

        [Column("n_status")]
        [Required]
        public string NStatus { get; set; }

        [Column("n_fabricante")]
        [StringLength(18)]
        public string NFabricante { get; set; }

        [Column("n_mascara")]
        public int NMascara { get; set; }

        [Column("qtde_atual")]
        public decimal QtdeAtual { get; set; }

        [Column("qtde_contada")]
        public decimal QtdeContada { get; set; }

        [Column("valor_medio")]
        public decimal ValorMedio { get; set; }
    }
}
