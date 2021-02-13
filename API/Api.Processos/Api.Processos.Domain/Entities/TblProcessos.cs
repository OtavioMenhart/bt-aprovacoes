using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Api.Processos.Domain.Entities
{
    [Table("Tbl_Processos")]
    public partial class TblProcessos
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        [Required]
        [StringLength(12)]
        public string NumeroProcesso { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal ValorCausa { get; set; }
        [Required]
        [StringLength(50)]
        public string Escritorio { get; set; }
        [Required]
        [StringLength(100)]
        public string NomeReclamante { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DataInclusao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataEdicao { get; set; }
        public bool FlgAtivo { get; set; }
        public bool FlgAprovado { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataCompra { get; set; }
    }
}
