// 喜歡商品
// 複合主鍵
using Lab_Shopping_WebSite.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab_Shopping_WebSite.Models
{
    [Table("Like_Commodities")]
    public class Like_Commodities : IModel
    {
        // Constructor
        public Like_Commodities()
        {
        }

        #region 屬性
        public int MemberID { get; set; }

        public int CommodityID { get; set; }

        public DateTime Add_Date { get; set; }
        public int? Modifier { get; set; }
        public int? Creator { get; set; }

        [ForeignKey("MemberID"), InverseProperty("Like_Commodities")]
        public virtual Members? Member { get; set; }
        [ForeignKey("CommodityID"), InverseProperty("Like_Commodities")]
        public virtual Commodities? Commodity { get; set; }

        [ForeignKey("Creator"), InverseProperty("LikeCommoditiesCreator")]
        public virtual Members? CreateMember { get; set; }

        [ForeignKey("Modifier"), InverseProperty("LikeCommoditiesModifer")]
        public virtual Members? ModifyMember { get; set; }
        #endregion
    }
}