// Blog 內容
using Lab_Shopping_WebSite.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab_Shopping_WebSite.Models
{
    [Table("Blog_Contents")]
    public class Blog_Contents : IModel
    {
        // Constructor
        public Blog_Contents()
        {
        }

        #region 主鍵
        [Key]
        public int Blog_ContentID { get; set; }

        [Required(ErrorMessage = "Blog_Content Title is Required.")]
        [StringLength(250, ErrorMessage = "欄位長度不可大於250個字元")]
        public string? Blog_Content { get; set; }

        [Required]
        public int Order { get; set; }

        [Required]
        public int BlogID { get; set; }
        public int? Modifier { get; set; }
        public int? Creator { get; set; }

        [ForeignKey("BlogID"), InverseProperty("Contents")]
        public virtual Blogs? Blog { get; set; }

        [ForeignKey("Creator"), InverseProperty("Blog_ContentsCreator")]
        public virtual Members? CreateMember { get; set; }

        [ForeignKey("Modifier"), InverseProperty("Blog_ContentsModifer")]
        public virtual Members? ModifyMember { get; set; }
        #endregion
    }
}
