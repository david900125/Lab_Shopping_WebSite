// 商品種類
using Lab_Shopping_WebSite.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab_Shopping_WebSite.Models
{
    [Table("Commodity_Kinds")]
    public class Commodity_Kinds : IModel
    {
        // Constructor
        public Commodity_Kinds()
        {
        }

        #region 屬性
        [Key]
        [Required(ErrorMessage = "Commodity_KindID is required")]
        public int Commodity_KindID { get; set; }
        [Required]
        [StringLength(10, ErrorMessage = "欄位長度不可大於10個字元")]
        public string? Description { get; set; }
        public int? Modifier { get; set; }
        public int? Creator { get; set; }
        [ForeignKey("Creator"), InverseProperty("CommodityKindsCreator")]
        public virtual Members? CreateMember { get; set; }

        [ForeignKey("Modifier"), InverseProperty("CommodityKindsModifer")]
        public virtual Members? ModifyMember { get; set; }

        public ICollection<Tags>? Tags { get; set; }
        public ICollection<Sizes>? Sizes { get; set; }
        #endregion
    }
}
