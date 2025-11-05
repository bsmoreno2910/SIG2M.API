using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIG2M.Dominio.Entidades
{
    [Table("fornecedor")]
    public class Fornecedor
    {

        [Key]
        [Column("cnpj")]
        [Required]
        [StringLength(18)]
        public string Cnpj { get; set; }

        [Column("raza")]
        [Required]
        [StringLength(100)]
        public string Raza { get; set; }

        [Column("nome_curto")]
        [StringLength(20)]
        public string NomeCurto { get; set; }

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
        [StringLength(20)]
        public string Bairro { get; set; }

        [Column("cep")]
        [Required]
        [StringLength(10)]
        public string Cep { get; set; }

        [Column("cidade")]
        [Required]
        [StringLength(20)]
        public string Cidade { get; set; }

        [Column("estado")]
        [Required]
        [StringLength(2)]
        public string Estado { get; set; }

        [Column("telefone")]
        [Required]
        [StringLength(15)]
        public string Telefone { get; set; }

        [Column("contato")]
        [Required]
        [StringLength(20)]
        public string Contato { get; set; }

        [Column("email")]
        [Required]
        [StringLength(40)]
        public string Email { get; set; }

        [Column("fax")]
        [StringLength(15)]
        public string Fax { get; set; }

        [Column("sac")]
        [StringLength(15)]
        public string Sac { get; set; }

        [Column("obs")]
        [StringLength(255)]
        public string Obs { get; set; }
    }
}
