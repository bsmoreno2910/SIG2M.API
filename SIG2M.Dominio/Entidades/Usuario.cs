using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIG2M.Dominio.Entidades
{
    [Table("usuario")]
    public class Usuario
    {

        [Key]
        [Column("matricula")]
        public int Matricula { get; set; }

        [Column("nome")]
        [Required]
        [StringLength(50)]
        public string Nome { get; set; }

        [Column("end")]
        [Required]
        [StringLength(40)]
        public string End { get; set; }

        [Column("nro")]
        [Required]
        [StringLength(6)]
        public string Nro { get; set; }

        [Column("complemento")]
        [Required]
        [StringLength(20)]
        public string Complemento { get; set; }

        [Column("bairro")]
        [Required]
        [StringLength(10)]
        public string Bairro { get; set; }

        [Column("cep")]
        [Required]
        [StringLength(10)]
        public string Cep { get; set; }

        [Column("cidade")]
        [Required]
        [StringLength(10)]
        public string Cidade { get; set; }

        [Column("estado")]
        [Required]
        [StringLength(2)]
        public string Estado { get; set; }

        [Column("telefone")]
        [Required]
        [StringLength(12)]
        public string Telefone { get; set; }

        [Column("e_mail")]
        [Required]
        [StringLength(40)]
        public string EMail { get; set; }
    }
}
