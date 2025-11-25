using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIG2M.Dominio.Entidades
{
    [Table("descricao")]
    public class tbdDescricao
    {

        [Key, Required]
        [Column("cod_material")]
        public int CodMaterial { get; set; }

        [Column("descricao")]
        [Required]
        [StringLength(65535)]
        public string Descricao { get; set; }

        [Column("de_estoque")]
        [Required]
        public string DeEstoque { get; set; }
    }
}
