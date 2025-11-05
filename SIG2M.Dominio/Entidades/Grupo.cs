using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIG2M.Dominio.Entidades
{
    [Table("grupo")]
    public class Grupo
    {

        [Key]
        [Column("cod_grupo")]
        public short CodGrupo { get; set; }

        [Column("nome")]
        [Required]
        [StringLength(35)]
        public string Nome { get; set; }

        [Column("comentario")]
        [Required]
        [StringLength(100)]
        public string Comentario { get; set; }

        [Column("data_inclusao")]
        public DateTime DataInclusao { get; set; }

        [Column("data_exclusao")]
        public DateTime DataExclusao { get; set; }
    }
}
