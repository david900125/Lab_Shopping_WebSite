// 訂單
using Lab_Shopping_WebSite.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab_Shopping_WebSite.Models
{
    [Table("Payments")]
    public class Payments : IModel
    {
        // Constructor
        public Payments()
        {
        }

        #region 屬性
        [Key]
        [Required]
        public int PaymentID { get; set; }

        [Required(ErrorMessage = "Payment is required.")]
        public string? Payment { get; set; }
        public int? Modifier { get; set; }
        public int? Creator { get; set; }

        [ForeignKey("Creator"), InverseProperty("PaymentsCreator")]
        public virtual Members? CreateMember { get; set; }

        [ForeignKey("Modifier"), InverseProperty("PaymentsModifer")]
        public virtual Members? ModifyMember { get; set; }
        public virtual ICollection<Sales>? Sales { get; set; }
        #endregion
    }
}