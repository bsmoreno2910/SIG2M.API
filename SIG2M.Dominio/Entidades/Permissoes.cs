using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIG2M.Dominio.Entidades
{
    [Table("permissoes")]
    public class Permissoes
    {

        [Key]
        [Column("ordem")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Ordem { get; set; }

        [Column("matricula")]
        public int Matricula { get; set; }

        [Column("aplicativos")]
        [Required]
        [StringLength(30)]
        public string Aplicativos { get; set; }
    }
}
