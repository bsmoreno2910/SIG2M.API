using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIG2M.Dominio.Entidades
{
    [Table("almoxarifado")]
    public class Almoxarifado
    {
        [Key]
        [Column("cod_almox")]
        [Required]
        [StringLength(10)]
        public string CodAlmox { get; set; }

        [Column("nome")]
        [Required]
        [StringLength(50)]
        public string Nome { get; set; }

        [Column("coordenador")]
        [Required]
        [StringLength(40)]
        public string Coordenador { get; set; }

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
        [StringLength(40)]
        public string Complemento { get; set; }

        [Column("bairro")]
        [Required]
        [StringLength(40)]
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

        [Column("secretaria")]
        [Required]
        [StringLength(40)]
        public string Secretaria { get; set; }

        [Column("data_inclusao")]
        public DateTime DataInclusao { get; set; }

        [Column("data_exclusao")]
        public DateTime DataExclusao { get; set; }
    }
}
