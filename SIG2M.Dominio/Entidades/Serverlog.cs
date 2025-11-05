using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIG2M.Dominio.Entidades
{
    [Table("serverlog")]
    public class Serverlog
    {

        [Column("data")]
        public DateTime Data { get; set; }

        [Column("hora")]
        public TimeSpan Hora { get; set; }

        [Column("ocorrencia")]
        [Required]
        [StringLength(65535)]
        public string Ocorrencia { get; set; }

        [Column("sigla")]
        [StringLength(10)]
        public string Sigla { get; set; }

        [Column("protocolo")]
        public int Protocolo { get; set; }

        [Column("threadsim")]
        public int Threadsim { get; set; }

        [Column("memoria")]
        public int Memoria { get; set; }

        [Key]
        [Column("nrlog")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte Nrlog { get; set; }
    }
}
