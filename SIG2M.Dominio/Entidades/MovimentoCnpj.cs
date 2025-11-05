using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIG2M.Dominio.Entidades
{
    [Table("movimento_cnpj")]
    public class MovimentoCnpj
    {

        [Key]
        [Column("ano")]
        public short Ano { get; set; }

        [Key]
        [Column("cod_movimento")]
        public int CodMovimento { get; set; }

        [Column("cnpj")]
        [Required]
        [StringLength(18)]
        public string Cnpj { get; set; }
    }
}
