using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIG2M.Dominio.Entidades
{
    [Table("mov")]
    public class tbdMov
    {

        [Column("mov")]
        public int Mov { get; set; }

        [Column("cod_operacao")]
        [Required]
        [StringLength(15)]
        public string CodOperacao { get; set; }

        [Column("cod_material")]
        public int CodMaterial { get; set; }

        [Column("sigla")]
        [Required]
        [StringLength(20)]
        public string Sigla { get; set; }

        [Column("doc")]
        [Required]
        [StringLength(15)]
        public string Doc { get; set; }

        [Column("qtde")]
        public decimal Qtde { get; set; }

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
    }
}
