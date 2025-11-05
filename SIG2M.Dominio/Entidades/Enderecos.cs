using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIG2M.Dominio.Entidades
{
    [Table("enderecos")]
    public class Enderecos
    {

        [Key]
        [Column("endereco")]
        [Required]
        [StringLength(20)]
        public string Endereco { get; set; }

        [Column("local")]
        [Required]
        [StringLength(20)]
        public string Local { get; set; }

        [Column("ancora")]
        [Required]
        public string Ancora { get; set; }

        [Column("camarafria")]
        [Required]
        public string Camarafria { get; set; }

        [Column("tipo")]
        [Required]
        public string Tipo { get; set; }
    }
}
