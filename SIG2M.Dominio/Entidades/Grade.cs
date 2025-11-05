using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIG2M.Dominio.Entidades
{
    [Table("grade")]
    public class Grade
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

        [Column("funci")]
        [Required]
        [StringLength(30)]
        public string Funci { get; set; }

        [Column("obs")]
        [Required]
        [StringLength(100)]
        public string Obs { get; set; }

        [Column("status")]
        [Required]
        public string Status { get; set; }

        [Column("tipo")]
        [Required]
        public string Tipo { get; set; }

        [Column("data")]
        public DateTime Data { get; set; }
    }
}
