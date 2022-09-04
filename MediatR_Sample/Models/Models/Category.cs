using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;



namespace Models.Models
{
    [Table("tbl_Category")]
    public partial class Category
    {
        public Category()
        {
            tbl_Posts = new HashSet<Post>();
        }

        [Key]
        public int GenreId { get; set; }
        [Required]
        [StringLength(150)]
        public string BookGenre { get; set; }
        [Required]
        [StringLength(500)]
        public string GenreDescription { get; set; }

        [InverseProperty(nameof(Post.Genre))]
        public virtual ICollection<Post> tbl_Posts { get; set; }
    }
}
