// 喜歡商品
// 購物車
using Lab_Shopping_WebSite.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab_Shopping_WebSite.Models
{
    [Table("Shopping_Carts")]
    public class Shopping_Carts : IModel
    {
        // Constructor
        public Shopping_Carts()
        {
        }

        #region 屬性
        public int MemberID { get; set; }

        public int Commodity_SizeID { get; set; }

        [Required]
        [Precision(10, 2)]
        public decimal Amount { get; set; }
        public int? Modifier { get; set; }
        public int? Creator { get; set; }

        [ForeignKey("MemberID"), InverseProperty("Shopping_Carts")]
        public virtual Members? Member { get; set; }
        [ForeignKey("CommodityID"), InverseProperty("Shopping_Carts")]
        public virtual Commodities? Commodity { get; set; }

        [ForeignKey("Creator"), InverseProperty("ShoppingCartsCreator")]
        public virtual Members? CreateMember { get; set; }

        [ForeignKey("Modifier"), InverseProperty("ShoppingCartsModifer")]
        public virtual Members? ModifyMember { get; set; }
        #endregion
    }
}