using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Models.Models
{
    [Table("PprLat", Schema = "Nas")]
    public partial class PprLat
    {
        [Key]
        public int ID { get; set; }
        [Column(TypeName = "decimal(9, 3)")]
        public decimal X { get; set; }
        [Column(TypeName = "decimal(9, 3)")]
        public decimal Y { get; set; }
        public int PprLatSizeID { get; set; }
        public int PprModelID { get; set; }
        [Required]
        public bool? IsActive { get; set; }
        public bool? IsRotate { get; set; }

        [ForeignKey(nameof(PprLatSizeID))]
        [InverseProperty("PprLats")]
        public virtual PprLatSize PprLatSize { get; set; }
        [ForeignKey(nameof(PprModelID))]
        [InverseProperty("PprLats")]
        public virtual PprModel PprModel { get; set; }
    }
}
