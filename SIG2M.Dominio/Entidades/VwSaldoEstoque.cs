using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIG2M.Dominio.Entidades
{
    [Table("vw_saldo_setor")]
    public class VwSaldoEstoque
    {
        [Key]
        [Column("sigla")]
        [Required]
        [StringLength(10)]
        public string Sigla { get; set; }

        [Column("cod_material")]
        public int CodMaterial { get; set; }

        [Column("qtde")]
        public decimal Qtde { get; set; }

        [Column("data_hora")]
        public DateTime Data { get; set; }
    }
}
