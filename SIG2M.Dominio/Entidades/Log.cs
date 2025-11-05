using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIG2M.Dominio.Entidades
{
    [Table("log")]
    public class Log
    {

        [Key]
        [Column("cod_log")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CodLog { get; set; }

        [Column("matricula")]
        public int Matricula { get; set; }

        [Column("data")]
        public DateTime Data { get; set; }

        [Column("hora")]
        public TimeSpan Hora { get; set; }

        [Column("origem")]
        [Required]
        [StringLength(15)]
        public string Origem { get; set; }

        [Column("tabela")]
        [Required]
        [StringLength(20)]
        public string Tabela { get; set; }

        [Column("acao")]
        [Required]
        [StringLength(150)]
        public string Acao { get; set; }
    }
}
