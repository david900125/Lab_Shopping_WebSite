// 商品標籤
using Lab_Shopping_WebSite.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab_Shopping_WebSite.Models
{
    [Table("Commodity_Tags")]
    public class Commodity_Tags : IModel
    {
        // Constructor
        public Commodity_Tags()
        {
        }

        #region 屬性
        [Required(ErrorMessage = "CommodityID is required")]
        public int CommodityID { get; set; }

        [Required(ErrorMessage = "TagID is required.")]
        public int TagID { get; set; }
        public int? Modifier { get; set; }
        public int? Creator { get; set; }


        [ForeignKey("CommodityID"), InverseProperty("Commodity_Tags")]
        public virtual Commodities? Commodity { get; set; }

        [ForeignKey("TagID"), InverseProperty("Commodity_Tags")]
        public virtual Tags? Tag { get; set; }

        [ForeignKey("Creator"), InverseProperty("CommodityTagsCreator")]
        public virtual Members? CreateMember { get; set; }

        [ForeignKey("Modifier"), InverseProperty("CommodityTagsModifer")]
        public virtual Members? ModifyMember { get; set; }
        #endregion
    }
}