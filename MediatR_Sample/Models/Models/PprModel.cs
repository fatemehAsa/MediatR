using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Models.Models
{
    [Table("PprModel", Schema = "Nas")]
    public partial class PprModel
    {
        public PprModel()
        {
            PprLats = new HashSet<PprLat>();
        }

        [Key]
        public int ID { get; set; }
        public int PprID { get; set; }
        public string ModelName { get; set; }
        [Column(TypeName = "decimal(9, 3)")]
        public decimal Width { get; set; }
        [Column(TypeName = "decimal(9, 3)")]
        public decimal Height { get; set; }
        public byte PprModelDoubletype { get; set; }
        [StringLength(50)]
        public string Description { get; set; }
        public int PaperTypeID { get; set; }
        public int WasteNumber { get; set; }
        public bool? TwoFaceGluey { get; set; }
        public byte SortType { get; set; }
        public int? ZinkSizeID { get; set; }
        public int HLab { get; set; }
        public int VLab { get; set; }
        [Required]
        public bool? IsActive { get; set; }

        [ForeignKey(nameof(PprID))]
        [InverseProperty("PprModels")]
        public virtual Ppr Ppr { get; set; }
        [InverseProperty(nameof(PprLat.PprModel))]
        public virtual ICollection<PprLat> PprLats { get; set; }
    }
}
