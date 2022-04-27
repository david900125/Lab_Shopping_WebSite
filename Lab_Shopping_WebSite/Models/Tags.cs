// 標籤
using Lab_Shopping_WebSite.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab_Shopping_WebSite.Models
{
    [Table("Tags")]
    public class Tags : IModel
    {
        // Constructor
        public Tags()
        {
        }

        #region 屬性
        [Key]
        [Required(ErrorMessage = "TagID is required")]
        public int TagID { get; set; }

        [Required(ErrorMessage = "Commodity_KindsID is required.")]
        public int Commodity_KindsID { get; set; }

        [Required(ErrorMessage = "欄位長度不可大於10個字元")]
        public string? Tag { get; set; }

        public int? Creator { get; set; }

        public int? Modifier { get; set; }

        [ForeignKey("Commodity_KindsID"), InverseProperty("Tags")]
        public virtual Commodity_Kinds? Commodity_Kind { get; set; }

        [ForeignKey("Modifier"), InverseProperty("TagsCreator")]
        public virtual Members? CreateMember { get; set; }

        [ForeignKey("Creator"), InverseProperty("TagsModifer")]
        public virtual Members? ModifyMember { get; set; }
        public ICollection<Commodity_Tags>? Commodity_Tags { get; set; }
        #endregion
    }
}