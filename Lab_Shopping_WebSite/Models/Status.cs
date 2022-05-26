// 複合主鍵
// 訂單內容
using Lab_Shopping_WebSite.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab_Shopping_WebSite.Models
{
    [Table("Status")]
    public class Status : IModel
    {
        // Constructor
        public Status()
        {
        }

        #region 屬性
        [Key]
        public int StatusID { get; set; }

        [Required]
        [MaxLength(20)]
        public string? State { get; set; }
        public int? Modifier { get; set; }
        public int? Creator { get; set; }

        [ForeignKey("Creator"), InverseProperty("StatusCreator")]
        public virtual Members? CreateMember { get; set; }

        [ForeignKey("Modifier"), InverseProperty("StatusModifer")]
        public virtual Members? ModifyMember { get; set; }
        public virtual ICollection<Sales_items>? Sales_Items { get; set; }
        #endregion
    }
}