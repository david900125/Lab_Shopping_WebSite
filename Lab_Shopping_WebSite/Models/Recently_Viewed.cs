// 瀏覽紀錄
// 複合主鍵
using Lab_Shopping_WebSite.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab_Shopping_WebSite.Models
{
    [Table("Recently_Viewed")]
    public class Recently_Viewed : IModel
    {
        // Constructor
        public Recently_Viewed()
        {
        }

        #region 屬性
        [Key]
        public int Recently_ViewedID { get; set; }
        [Required]
        public int CommodityID { get; set; }
        public int? MemberID { get; set; }
        [Required]
        public DateTime Viewed_Date { get; set; }
        public int? Modifier { get; set; }
        public int? Creator { get; set; }

        [ForeignKey("MemberID"), InverseProperty("Recently_Viewed")]
        public virtual Members? Member { get; set; }
        [ForeignKey("CommodityID"), InverseProperty("Recently_Viewed")]
        public virtual Commodities? Commodity { get; set; }

        [ForeignKey("Creator"), InverseProperty("RecentlyViewedCreator")]
        public virtual Members? CreateMember { get; set; }

        [ForeignKey("Modifier"), InverseProperty("RecentlyViewedModifer")]
        public virtual Members? ModifyMember { get; set; }
        #endregion
    }
}
