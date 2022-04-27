// Blogs
using Lab_Shopping_WebSite.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab_Shopping_WebSite.Models
{
    [Table("Blogs")]
    public class Blogs : IModel
    {
        // Constructor
        public Blogs()
        {
        }

        #region 屬性
        [Key]
        public int BlogID { get; set; }

        [Required(ErrorMessage = "Blog Title is Required.")]
        [StringLength(50, ErrorMessage = "欄位長度不可大於50個字元")]
        public string? Blog_Title { get; set; }
        public int? Modifier { get; set; }
        public int? Creator { get; set; }

        [ForeignKey("Creator"), InverseProperty("BlogsCreator")]
        public virtual Members? CreateMember { get; set; }

        [ForeignKey("Modifier"), InverseProperty("BlogsModifer")]
        public virtual Members? ModifyMember { get; set; }

        public ICollection<Blog_Contents>? Contents { get; set; }
        public ICollection<Blog_Hrefs>? Hrefs { get; set; }
        public ICollection<Blog_Images>? Images { get; set; }
        #endregion
    }
}
