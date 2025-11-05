using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIG2M.Dominio.Entidades
{
    [Table("kit")]
    public class Kit
    {

        [Key]
        [Column("nome_kit")]
        [Required]
        [StringLength(25)]
        public string NomeKit { get; set; }

        [Column("proprietario")]
        public int Proprietario { get; set; }

        [Column("publica")]
        [Required]
        public string Publica { get; set; }

        [Column("agrupar")]
        [Required]
        public string Agrupar { get; set; }

        [Column("Descricao")]
        [Required]
        [StringLength(100)]
        public string Descricao { get; set; }
    }
}
