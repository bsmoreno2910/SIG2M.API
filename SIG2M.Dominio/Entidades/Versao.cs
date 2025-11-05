using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIG2M.Dominio.Entidades
{
    [Table("versao")]
    public class tbdVersao
    {

        [Key]
        [Column("versao")]
        [Required]
        [StringLength(16)]
        public string Versao { get; set; }
    }
}
