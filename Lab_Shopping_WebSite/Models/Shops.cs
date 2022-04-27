// 複合主鍵
// 店家資訊
using Lab_Shopping_WebSite.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab_Shopping_WebSite.Models
{
    [Table("Shops")]
    public class Shops : IModel
    {
        // Constructor
        public Shops()
        {
        }

        #region 屬性
        [Key]
        public int ShopID { get; set; }

        [Required]
        [MaxLength(35)]
        public string? Shop_Address { get; set; }

        [Required]
        [MaxLength(250)]
        public string? Shop_Info { get; set; }
        public int? Modifier { get; set; }
        public int? Creator { get; set; }

        [ForeignKey("Creator"), InverseProperty("ShopsCreator")]
        public virtual Members? CreateMember { get; set; }

        [ForeignKey("Modifier"), InverseProperty("ShopsModifer")]
        public virtual Members? ModifyMember { get; set; }
        #endregion
    }
}