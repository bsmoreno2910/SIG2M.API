using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIG2M.Dominio.Entidades
{
    [Table("locker")]
    public class Locker
    {

        [Key]
        [Column("tabela")]
        [Required]
        [StringLength(25)]
        public string Tabela { get; set; }

        [Key]
        [Column("cod_material")]
        public int CodMaterial { get; set; }

        [Column("matricula")]
        public int Matricula { get; set; }

        [Column("data")]
        public DateTime Data { get; set; }

        [Column("hora")]
        public TimeSpan Hora { get; set; }
    }
}
