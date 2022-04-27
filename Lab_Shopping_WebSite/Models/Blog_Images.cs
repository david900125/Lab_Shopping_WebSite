// 複合主鍵
// Blog 圖片
using Lab_Shopping_WebSite.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab_Shopping_WebSite.Models
{
    [Table("Blog_Images")]
    public class Blog_Images : IModel
    {
        // Constructor
        public Blog_Images()
        {
        }

        #region 屬性

        [Required(ErrorMessage = "BlogID is required")]
        [ForeignKey("Blog")]
        public int BlogID { get; set; }

        [Required]
        [ForeignKey("Commodity")]
        public int FileID { get; set; }

        [Required]
        public int Order { get; set; }
        public int? Modifier { get; set; }
        public int? Creator { get; set; }

        [InverseProperty("Images")]
        public virtual Blogs? Blog { get; set; }

        [InverseProperty("Blog_Images")]
        public virtual Files? File { get; set; }

        [ForeignKey("Creator"), InverseProperty("Blog_ImagesCreator")]
        public virtual Members? CreateMember { get; set; }

        [ForeignKey("Modifier"), InverseProperty("Blog_ImagesModifer")]
        public virtual Members? ModifyMember { get; set; }
        #endregion
    }
}
