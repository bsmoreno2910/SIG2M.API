using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIG2M.Dominio.Entidades
{
    [Table("material")]
    public class Material
    {

        [Key, Required]
        [Column("cod_material")]
        public int CodMaterial { get; set; }

        [Column("cod_grupo")]
        public short CodGrupo { get; set; }

        [Column("cod_subgrupo")]
        public short CodSubgrupo { get; set; }

        [Column("cod_familia")]
        public short CodFamilia { get; set; }

        [Column("nome")]
        [Required]
        [StringLength(60)]
        public string Nome { get; set; }

        [Column("unidade")]
        [Required]
        [StringLength(2)]
        public string Unidade { get; set; }

        [Column("perecivel")]
        [Required]
        public string Perecivel { get; set; }

        [Column("data_inclusao")]
        public DateTime DataInclusao { get; set; }

        [Column("data_exclusao")]
        public DateTime DataExclusao { get; set; }

        [NotMapped]
        public tbdDescricao Descricao { get; set; }
    }
}
