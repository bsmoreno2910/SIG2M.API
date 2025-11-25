using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
namespace SIG2M.Dominio.Entidades
{
    [Table("grupo")]
    public class Grupo
    {

        [Key, Required]
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
        [NotMapped, JsonIgnore]
        public IEnumerable<Subgrupo> SubGrupos { get; set; }
    }
}
