using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIG2M.Dominio.Entidades
{
    [Table("consumo")]
    public class Consumo
    {

        [Key]
        [Column("cod_material")]
        public int CodMaterial { get; set; }

        [Key]
        [Column("ano")]
        public int Ano { get; set; }

        [Column("mes_01")]
        public int Mes01 { get; set; }

        [Column("mes_02")]
        public int Mes02 { get; set; }

        [Column("mes_03")]
        public int Mes03 { get; set; }

        [Column("mes_04")]
        public int Mes04 { get; set; }

        [Column("mes_05")]
        public int Mes05 { get; set; }

        [Column("mes_06")]
        public int Mes06 { get; set; }

        [Column("mes_07")]
        public int Mes07 { get; set; }

        [Column("mes_08")]
        public int Mes08 { get; set; }

        [Column("mes_09")]
        public int Mes09 { get; set; }

        [Column("mes_10")]
        public int Mes10 { get; set; }

        [Column("mes_11")]
        public int Mes11 { get; set; }

        [Column("mes_12")]
        public int Mes12 { get; set; }
    }
}
