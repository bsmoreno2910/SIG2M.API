using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIG2M.Dominio.Entidades
{
    [Table("forn")]
    public class Forn
    {

        [Column("nome_curto_fabricante")]
        [StringLength(20)]
        public string NomeCurtoFabricante { get; set; }

        [Column("cnpj")]
        [StringLength(18)]
        public string Cnpj { get; set; }
    }
}
