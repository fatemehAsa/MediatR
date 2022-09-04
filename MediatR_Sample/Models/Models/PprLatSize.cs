using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Models.Models
{
    [Table("PprLatSize", Schema = "Nas")]
    public partial class PprLatSize
    {
        public PprLatSize()
        {
            BasePrices = new HashSet<BasePrice>();
            PprLats = new HashSet<PprLat>();
        }

        [Key]
        public int ID { get; set; }
        [Column(TypeName = "decimal(9, 3)")]
        public decimal Width { get; set; }
        [Column(TypeName = "decimal(9, 3)")]
        public decimal Height { get; set; }
        [Required]
        public bool? IsActive { get; set; }
        [Required]
        [StringLength(50)]
        public string PprLatSizeName { get; set; }
        public int ShapeType { get; set; }
        public int CuttingFreeSpaceTop { get; set; }
        public int CuttingFreeSpaceDown { get; set; }
        public int CuttingFreeSpaceLeft { get; set; }
        public int CuttingFreeSpaceRight { get; set; }
        [Column(TypeName = "decimal(6, 2)")]
        public decimal FakeWidth { get; set; }
        [Column(TypeName = "decimal(6, 2)")]
        public decimal FakeHeight { get; set; }
        public bool HaveHelperFile { get; set; }
        [Required]
        public bool? IsActiveRemote { get; set; }
        [Required]
        public bool? IsActiveLocal { get; set; }
        public int? NumberOfBoxes { get; set; }
        public int? BoxesID { get; set; }
        public bool HaveSampleFile { get; set; }
        public bool HaveControlFile { get; set; }
        public bool HaveTransparentFile { get; set; }

        [InverseProperty(nameof(BasePrice.PprLatSize))]
        public virtual ICollection<BasePrice> BasePrices { get; set; }
        [InverseProperty(nameof(PprLat.PprLatSize))]
        public virtual ICollection<PprLat> PprLats { get; set; }
    }
}
