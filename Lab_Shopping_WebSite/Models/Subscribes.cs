// 訂閱
using Lab_Shopping_WebSite.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab_Shopping_WebSite.Models
{
    [Table("Subscribes")]
    public class Subscribes : IModel
    {
        // Constructor
        public Subscribes()
        {
        }

        #region 屬性
        [Key]
        [Required(ErrorMessage = "SubID is required")]
        public int SubID { get; set; }

        [MaxLength(320)]
        [Required(ErrorMessage = "Email_Address is required.")]
        public string? Email_Address { get; set; }

        [Required]
        public DateTime? Sub_Date { get; set; }
        public int? Modifier { get; set; }
        public int? Creator { get; set; }

        [ForeignKey("Creator"), InverseProperty("SubscribesCreator")]
        public virtual Members? CreateMember { get; set; }

        [ForeignKey("Modifier"), InverseProperty("SubscribesModifer")]
        public virtual Members? ModifyMember { get; set; }
        #endregion
    }
}