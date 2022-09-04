using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Models.Models
{
    [Table("BasePrice", Schema = "Nas")]
    public partial class BasePrice
    {
        [Key]
        public int ID { get; set; }
        public int BasePriceNameID { get; set; }
        public int PprLatSizeID { get; set; }
        public int? OneSideNormalPrice { get; set; }
        public int? TwoSideNormalPrice { get; set; }
        public int? OneSideForcePrice { get; set; }
        public int? TwoSideForcePrice { get; set; }
        [Required]
        public bool? IsActive { get; set; }

        [ForeignKey(nameof(PprLatSizeID))]
        [InverseProperty("BasePrices")]
        public virtual PprLatSize PprLatSize { get; set; }
    }
}
