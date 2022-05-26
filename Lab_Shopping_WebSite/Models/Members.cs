// Members 會員
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Lab_Shopping_WebSite.Interfaces;

namespace Lab_Shopping_WebSite.Models
{
    [Table("Members")]
    public class Members : IModel
    {
        public Members()
        {
        }

        [Key]
        public int MemberID { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email Address is Required.")]
        [StringLength(320, ErrorMessage = "欄位長度不可大於320個字元")]
        public string? Email_Address { get; set; }

        [Required(ErrorMessage = "")]
        public string? Password { get; set; }
        [Required]
        public string? Name { get; set; }
        public string? Address { get; set; }
        [Phone]
        public string? Phone_Number { get; set; }
        public bool? Gender { get; set; }
        public DateOnly? BirthDay { get; set; }
        public int RoleID { get; set; }
        public DateTime? LastSignin { get; set; }
        [JsonIgnore]
        public int? Modifier { get; set; }
        [JsonIgnore]
        public int? Creator { get; set; }
        [JsonIgnore]

        [ForeignKey("RoleID"), InverseProperty("Members")]
        public virtual Roles? Role { get; set; }
        [JsonIgnore]
        [ForeignKey("Creator"), InverseProperty("MembersCreator")]
        public virtual Members? CreateMember { get; set; }
        [JsonIgnore]
        [ForeignKey("Modifier"), InverseProperty("MembersModifer")]
        public virtual Members? ModifyMember { get; set; }

        public virtual ICollection<Sales>? Sales { get; set; }
        public virtual ICollection<Like_Commodities>? Like_Commodities { get; set; }
        public virtual ICollection<Received_Coupons>? Received_Coupons { get; set; }
        public virtual ICollection<Recently_Viewed>? Recently_Viewed { get; set; }
        public virtual ICollection<Shopping_Carts>? Shopping_Carts { get; set; }
        // Creater
        public virtual ICollection<Action_Auths>? Action_AuthCreator { get; set; }
        public virtual ICollection<Action_Auths>? Action_AuthsModifer { get; set; }
        public virtual ICollection<Blog_Contents>? Blog_ContentsCreator { get; set; }
        public virtual ICollection<Blog_Contents>? Blog_ContentsModifer { get; set; }
        public virtual ICollection<Blog_Hrefs>? Blog_HrefsCreator { get; set; }
        public virtual ICollection<Blog_Hrefs>? Blog_HrefsModifer { get; set; }
        public virtual ICollection<Blog_Images>? Blog_ImagesCreator { get; set; }
        public virtual ICollection<Blog_Images>? Blog_ImagesModifer { get; set; }
        public virtual ICollection<Blogs>? BlogsCreator { get; set; }
        public virtual ICollection<Blogs>? BlogsModifer { get; set; }
        public virtual ICollection<Colors>? ColorsCreator { get; set; }
        public virtual ICollection<Colors>? ColorsModifer { get; set; }
        public virtual ICollection<Commodities>? CommoditiesCreator { get; set; }
        public virtual ICollection<Commodities>? CommoditiesModifer { get; set; }
        public virtual ICollection<Commodity_Images>? CommodityImagesCreator { get; set; }
        public virtual ICollection<Commodity_Images>? CommodityImagesModifer { get; set; }
        public virtual ICollection<Commodity_Kinds>? CommodityKindsCreator { get; set; }
        public virtual ICollection<Commodity_Kinds>? CommodityKindsModifer { get; set; }
        public virtual ICollection<Commodity_Prices>? CommodityPricesCreator { get; set; }
        public virtual ICollection<Commodity_Prices>? CommodityPricesModifer { get; set; }
        public virtual ICollection<Commodity_Sizes>? CommoditySizesCreator { get; set; }
        public virtual ICollection<Commodity_Sizes>? CommoditySizesModifer { get; set; }
        public virtual ICollection<Commodity_Tags>? CommodityTagsCreator { get; set; }
        public virtual ICollection<Commodity_Tags>? CommodityTagsModifer { get; set; }
        public virtual ICollection<Coupon_Uses>? CouponUsesCreator { get; set; }
        public virtual ICollection<Coupon_Uses>? CouponUsesModifer { get; set; }
        public virtual ICollection<Coupon_Ways>? CouponWaysCreator { get; set; }
        public virtual ICollection<Coupon_Ways>? CouponWaysModifer { get; set; }
        public virtual ICollection<Coupons>? CouponsCreator { get; set; }
        public virtual ICollection<Coupons>? CouponsModifer { get; set; }
        public virtual ICollection<Delivery_Options>? DeliveryOptionsCreator { get; set; }
        public virtual ICollection<Delivery_Options>? DeliveryOptionsModifer { get; set; }
        public virtual ICollection<Delivery_Places>? DeliveryPlacesCreator { get; set; }
        public virtual ICollection<Delivery_Places>? DeliveryPlacesModifer { get; set; }
        public virtual ICollection<Files>? FilesCreator { get; set; }
        public virtual ICollection<Files>? FilesModifer { get; set; }
        public virtual ICollection<Href_Coordinations>? HrefCoordinationsCreator { get; set; }
        public virtual ICollection<Href_Coordinations>? HrefCoordinationsModifer { get; set; }
        public virtual ICollection<Inventories>? InventoriesCreator { get; set; }
        public virtual ICollection<Inventories>? InventoriesModifer { get; set; }
        public virtual ICollection<Like_Commodities>? LikeCommoditiesCreator { get; set; }
        public virtual ICollection<Like_Commodities>? LikeCommoditiesModifer { get; set; }
        [JsonIgnore]
        public virtual ICollection<Members>? MembersCreator { get; set; }
        [JsonIgnore]
        public virtual ICollection<Members>? MembersModifer { get; set; }
        public virtual ICollection<Menus>? MenusCreator { get; set; }
        public virtual ICollection<Menus>? MenusModifer { get; set; }
        public virtual ICollection<Pages>? PagesCreator { get; set; }
        public virtual ICollection<Pages>? PagesModifer { get; set; }
        public virtual ICollection<Payments>? PaymentsCreator { get; set; }
        public virtual ICollection<Payments>? PaymentsModifer { get; set; }
        public virtual ICollection<Prices>? PricesCreator { get; set; }
        public virtual ICollection<Prices>? PricesModifer { get; set; }
        public virtual ICollection<Received_Coupons>? ReceivedCouponsCreator { get; set; }
        public virtual ICollection<Received_Coupons>? ReceivedCouponsModifer { get; set; }
        public virtual ICollection<Recently_Viewed>? RecentlyViewedCreator { get; set; }
        public virtual ICollection<Recently_Viewed>? RecentlyViewedModifer { get; set; }
        public virtual ICollection<Roles>? RolesCreator { get; set; }
        public virtual ICollection<Roles>? RolesModifer { get; set; }
        public virtual ICollection<Sales_items>? SalesitemsCreator { get; set; }
        public virtual ICollection<Sales_items>? SalesitemsModifer { get; set; }
        public virtual ICollection<Sales>? SalesCreator { get; set; }
        public virtual ICollection<Sales>? SalesModifer { get; set; }
        public virtual ICollection<Shopping_Carts>? ShoppingCartsCreator { get; set; }
        public virtual ICollection<Shopping_Carts>? ShoppingCartsModifer { get; set; }
        public virtual ICollection<Shops>? ShopsCreator { get; set; }
        public virtual ICollection<Shops>? ShopsModifer { get; set; }
        public virtual ICollection<Sizes>? SizesCreator { get; set; }
        public virtual ICollection<Sizes>? SizesModifer { get; set; }
        public virtual ICollection<Status>? StatusCreator { get; set; }
        public virtual ICollection<Status>? StatusModifer { get; set; }
        public virtual ICollection<Subscribes>? SubscribesCreator { get; set; }
        public virtual ICollection<Subscribes>? SubscribesModifer { get; set; }
        public virtual ICollection<Tags>? TagsCreator { get; set; }
        public virtual ICollection<Tags>? TagsModifer { get; set; }
    }
}