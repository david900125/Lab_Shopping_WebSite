// 商品型號
using Lab_Shopping_WebSite.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab_Shopping_WebSite.Models
{
    [Table("Commodity_Sizes")]
    public class Commodity_Sizes : IModel
    {
        // Constructor
        public Commodity_Sizes()
        {
        }

        #region 屬性

        [Key]
        public int Commodity_SizesID { get; set; }

        [Required(ErrorMessage = "CommodityID is required.")]
        public int CommodityID { get; set; }

        [Required(ErrorMessage = "ColorID is required.")]
        public int ColorID { get; set; }

        [Required(ErrorMessage = "SizeID is required.")]
        public int SizeID { get; set; }
        public int? Modifier { get; set; }
        public int? Creator { get; set; }

        [ForeignKey("CommodityID"), InverseProperty("Commodity_Sizes")]
        public virtual Commodities? Commodity { get; set; }

        [ForeignKey("ColorID"), InverseProperty("Commodity_Sizes")]
        public virtual Colors? Color { get; set; }

        [ForeignKey("SizeID"), InverseProperty("Commodity_Sizes")]
        public virtual Sizes? Size { get; set; }

        [ForeignKey("Creator"), InverseProperty("CommoditySizesCreator")]
        public virtual Members? CreateMember { get; set; }

        [ForeignKey("Modifier"), InverseProperty("CommoditySizesModifer")]
        public virtual Members? ModifyMember { get; set; }

        public ICollection<Inventories>? inventories { get; set; }
        public ICollection<Shopping_Carts>? Shopping_Carts { get; set; }
        #endregion
    }
}
