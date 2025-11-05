using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIG2M.Dominio.Entidades
{
    [Table("login")]
    public class Login
    {

        [Key]
        [Column("matricula")]
        public int Matricula { get; set; }

        [Column("username")]
        [Required]
        [StringLength(15)]
        public string Username { get; set; }

        [Column("senha")]
        [Required]
        [StringLength(42)]
        public string Senha { get; set; }
    }
}
