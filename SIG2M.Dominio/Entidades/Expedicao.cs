using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIG2M.Dominio.Entidades
{
    [Table("expedicao")]
    public class Expedicao
    {

        [Key]
        [Column("lista")]
        public long Lista { get; set; }

        [Key]
        [Column("contador")]
        public int Contador { get; set; }

        [Column("cod_material")]
        public int CodMaterial { get; set; }

        [Column("cod_lote")]
        [Required]
        [StringLength(30)]
        public string CodLote { get; set; }

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

        [Column("cod_operacao")]
        [Required]
        [StringLength(15)]
        public string CodOperacao { get; set; }

        [Column("sigla")]
        [Required]
        [StringLength(20)]
        public string Sigla { get; set; }

        [Column("qtde")]
        public decimal Qtde { get; set; }

        [Column("qtde_div")]
        public decimal QtdeDiv { get; set; }

        [Column("status_entrega")]
        [Required]
        [StringLength(65)]
        public string StatusEntrega { get; set; }

        [Column("obs")]
        [Required]
        [StringLength(65)]
        public string Obs { get; set; }

        [Column("matricula")]
        public int Matricula { get; set; }

        [Column("recebedor")]
        [Required]
        [StringLength(50)]
        public string Recebedor { get; set; }

        [Column("data")]
        public DateTime Data { get; set; }
    }
}
