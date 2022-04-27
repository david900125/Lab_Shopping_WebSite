// 運送方式
using Lab_Shopping_WebSite.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab_Shopping_WebSite.Models
{
    [Table("Delivery_Options")]
    public class Delivery_Options : IModel
    {
        // Constructor
        public Delivery_Options()
        {
        }

        #region 屬性
        [Key]
        [Required]
        public int Delivery_OptionsID { get; set; }

        [Required]
        [MaxLength(10)]
        public string? Delivery_Option { get; set; }

        [Required]
        public int Delivery_PlaceID { get; set; }

        [Required]
        [Precision(5, 2)]
        public decimal Delivery_Cost { get; set; }
        public int? Modifier { get; set; }
        public int? Creator { get; set; }

        [ForeignKey("Delivery_PlaceID"), InverseProperty("Delivery_Options")]
        public Delivery_Places? Delivery_Place { get; set; }

        [ForeignKey("Creator"), InverseProperty("DeliveryOptionsCreator")]
        public virtual Members? CreateMember { get; set; }

        [ForeignKey("Modifier"), InverseProperty("DeliveryOptionsModifer")]
        public virtual Members? ModifyMember { get; set; }
        public ICollection<Sales>? Sales { get; set; }
        #endregion
    }
}