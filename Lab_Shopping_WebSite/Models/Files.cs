// 檔案
using Lab_Shopping_WebSite.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab_Shopping_WebSite.Models
{
    [Table("Files")]
    public class Files : IModel
    {
        // Constructor
        public Files()
        {
        }

        #region 屬性
        [Key]
        public int FileID { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "欄位長度不可大於50個字元")]
        public string FileType { get; set; }

        [Required(ErrorMessage = "FileName is required.")]
        [StringLength(50, ErrorMessage = "欄位長度不可大於50個字元")]
        public string? FileName { get; set; }

        [Required]
        public Int64 FileSize { get; set; }

        [Required]
        [StringLength(250, ErrorMessage = "欄位長度不可大於250個字元")]
        public string? FilePath { get; set; }
        public int? Modifier { get; set; }
        public int? Creator { get; set; }

        [ForeignKey("Creator"), InverseProperty("FilesCreator")]
        public virtual Members? CreateMember { get; set; }

        [ForeignKey("Modifier"), InverseProperty("FilesModifer")]
        public virtual Members? ModifyMember { get; set; }
        public ICollection<Href_Coordinations>? Href_Coordinations { get; set; }
        #endregion
    }
}
