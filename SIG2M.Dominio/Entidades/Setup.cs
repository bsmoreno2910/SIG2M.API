using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIG2M.Dominio.Entidades
{
    [Table("setup")]
    public class Setup
    {

        [Key]
        [Column("cod_almox")]
        [Required]
        [StringLength(10)]
        public string CodAlmox { get; set; }

        [Key]
        [Column("nome")]
        [Required]
        [StringLength(30)]
        public string Nome { get; set; }

        [Column("valor")]
        [Required]
        [StringLength(100)]
        public string Valor { get; set; }
    }
}
