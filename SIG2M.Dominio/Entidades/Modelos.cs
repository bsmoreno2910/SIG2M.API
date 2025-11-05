using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIG2M.Dominio.Entidades
{
    [Table("modelos")]
    public class Modelos
    { 

        [Key]
        [Column("id_modelo")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdModelo { get; set; }

        [Column("escopo")]
        [Required]
        [StringLength(20)]
        public string Escopo { get; set; }

        [Column("nome")]
        [Required]
        [StringLength(30)]
        public string Nome { get; set; }

        [Column("texto")]
        [Required]
        [StringLength(65535)]
        public string Texto { get; set; }
    }
}
