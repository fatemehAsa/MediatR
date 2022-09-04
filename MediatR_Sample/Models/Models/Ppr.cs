using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Models.Models
{
    [Table("Ppr", Schema = "Nas")]
    public partial class Ppr
    {
        public Ppr()
        {
            InversePreviousPpr = new HashSet<Ppr>();
            PprModels = new HashSet<PprModel>();
        }

        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public bool CanForce { get; set; }
        public byte PprDoubleType { get; set; }
        public bool Share { get; set; }
        public byte FilmCount { get; set; }
        public int Tiraj { get; set; }
        [Required]
        public bool? IsActiveRemote { get; set; }
        [Required]
        public bool? IsActiveLocal { get; set; }
        public byte HaveModel { get; set; }
        [Required]
        public bool? IsActive { get; set; }
        public int? PreviousPprID { get; set; }
        [Column(TypeName = "time(0)")]
        public TimeSpan? PprHasteTime { get; set; }
        [StringLength(500)]
        public string Description { get; set; }
        public int PaperStuffID { get; set; }
        public int? EstimateDaysForOneSideNormal { get; set; }
        public int? EstimateDaysForOneSideForce { get; set; }
        public int? EstimateDaysForTwoSideNormal { get; set; }
        public int? EstimateDaysForTwoSideForce { get; set; }
        public bool? GetExternalFile { get; set; }
        public bool? NeedToUpdate { get; set; }
        public bool? PriceNeedToUpdate { get; set; }
        public string Guid { get; set; }

        [ForeignKey(nameof(PreviousPprID))]
        [InverseProperty(nameof(Ppr.InversePreviousPpr))]
        public virtual Ppr PreviousPpr { get; set; }
        [InverseProperty(nameof(Ppr.PreviousPpr))]
        public virtual ICollection<Ppr> InversePreviousPpr { get; set; }
        [InverseProperty(nameof(PprModel.Ppr))]
        public virtual ICollection<PprModel> PprModels { get; set; }
    }
}
