using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIG2M.Dominio.Entidades
{
    [Table("fator_sazonal")]
    public class FatorSazonal
    {

        [Key]
        [Column("cod_material")]
        public int CodMaterial { get; set; }

        [Column("mes_01")]
        public decimal Mes01 { get; set; }

        [Column("mes_02")]
        public decimal Mes02 { get; set; }

        [Column("mes_03")]
        public decimal Mes03 { get; set; }

        [Column("mes_04")]
        public decimal Mes04 { get; set; }

        [Column("mes_05")]
        public decimal Mes05 { get; set; }

        [Column("mes_06")]
        public decimal Mes06 { get; set; }

        [Column("mes_07")]
        public decimal Mes07 { get; set; }

        [Column("mes_08")]
        public decimal Mes08 { get; set; }

        [Column("mes_09")]
        public decimal Mes09 { get; set; }

        [Column("mes_10")]
        public decimal Mes10 { get; set; }

        [Column("mes_11")]
        public decimal Mes11 { get; set; }

        [Column("mes_12")]
        public decimal Mes12 { get; set; }
    }
}
