using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIG2M.Dominio.Entidades
{
    [Table("log_administrativo")]
    public class LogAdministrativo
    {

        [Key]
        [Column("cod_log")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CodLog { get; set; }

        [Column("tipo")]
        [Required]
        [StringLength(30)]
        public string Tipo { get; set; }

        [Column("matricula")]
        public int Matricula { get; set; }

        [Column("data")]
        public DateTime Data { get; set; }

        [Column("hora")]
        public TimeSpan Hora { get; set; }

        [Column("origem")]
        [Required]
        [StringLength(30)]
        public string Origem { get; set; }

        [Column("tabela")]
        [Required]
        [StringLength(30)]
        public string Tabela { get; set; }

        [Column("coluna")]
        [Required]
        [StringLength(30)]
        public string Coluna { get; set; }

        [Column("antes")]
        [Required]
        [StringLength(250)]
        public string Antes { get; set; }

        [Column("depois")]
        [Required]
        [StringLength(250)]
        public string Depois { get; set; }
    }
}
