using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIG2M.Dominio.Entidades
{
    [Table("parametro_calculo_limite_automatico")]
    public class ParametroCalculoLimiteAutomatico
    {

        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("acao")]
        [Required]
        [StringLength(45)]
        public string Acao { get; set; }

        [Column("tipo")]
        [Required]
        [StringLength(45)]
        public string Tipo { get; set; }

        [Column("cod")]
        public int Cod { get; set; }

        [Column("minimo")]
        public int Minimo { get; set; }

        [Column("ativo")]
        public int Ativo { get; set; }
    }
}
