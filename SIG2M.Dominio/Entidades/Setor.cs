using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIG2M.Dominio.Entidades
{
    [Table("setor")]
    public class Setor
    {

        [Key, Required]
        [Column("sigla")] 
        [StringLength(10)]
        public string Sigla { get; set; }

        [Column("nome")]
        [Required]
        [StringLength(40)]
        public string Nome { get; set; }

        [Column("coordenador")]
        [Required]
        [StringLength(40)]
        public string Coordenador { get; set; }

        [Column("distrito")]
        [Required]
        [StringLength(20)]
        public string Distrito { get; set; }

        [Column("rua")]
        [Required]
        [StringLength(40)]
        public string Rua { get; set; }

        [Column("numero")]
        [Required]
        [StringLength(6)]
        public string Numero { get; set; }

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

        [Column("e_mail")]
        [Required]
        [StringLength(40)]
        public string EMail { get; set; }

        [Column("online")]
        [Required]
        public string Online { get; set; }
    }
}
