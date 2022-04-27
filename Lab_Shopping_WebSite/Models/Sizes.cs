// 尺寸
using Lab_Shopping_WebSite.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab_Shopping_WebSite.Models
{
    [Table("Sizes")]
    public class Sizes : IModel
    {
        // Constructor
        public Sizes()
        {
        }

        #region 屬性
        [Key]
        [Required(ErrorMessage = "SizeID is required")]
        public int SizeID { get; set; }

        [Required(ErrorMessage = "CommodityID is required.")]
        public int CommodityID { get; set; }
        public int? Modifier { get; set; }
        public int? Creator { get; set; }

        [Required]
        [StringLength(10, ErrorMessage = "欄位最大10")]
        public string? Size { get; set; }

        [ForeignKey("CommodityID"), InverseProperty("Sizes")]
        public virtual Commodities? Commodity { get; set; }

        [ForeignKey("Creator"), InverseProperty("SizesCreator")]
        public virtual Members? CreateMember { get; set; }

        [ForeignKey("Modifier"), InverseProperty("SizesModifer")]
        public virtual Members? ModifyMember { get; set; }

        public ICollection<Commodity_Sizes>? Commodity_Sizes { get; set; }
        #endregion
    }
}
