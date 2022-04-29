// Members 會員
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        public int? Modifier { get; set; }
        public int? Creator { get; set; }

        [ForeignKey("RoleID"), InverseProperty("Members")]
        public virtual Roles? Role { get; set; }

        [ForeignKey("Creator"), InverseProperty("MembersCreator")]
        public virtual Members? CreateMember { get; set; }

        [ForeignKey("Modifier"), InverseProperty("MembersModifer")]
        public virtual Members? ModifyMember { get; set; }

        public ICollection<Sales>? Sales { get; set; }
        public ICollection<Like_Commodities>? Like_Commodities { get; set; }
        public ICollection<Received_Coupons>? Received_Coupons { get; set; }
        public ICollection<Recently_Viewed>? Recently_Viewed { get; set; }
        public ICollection<Shopping_Carts>? Shopping_Carts { get; set; }

        // Creater
        public ICollection<Action_Auths>? Action_AuthCreator { get; set; }
        public ICollection<Action_Auths>? Action_AuthsModifer { get; set; }
        public ICollection<Blog_Contents>? Blog_ContentsCreator { get; set; }
        public ICollection<Blog_Contents>? Blog_ContentsModifer { get; set; }
        public ICollection<Blog_Hrefs>? Blog_HrefsCreator { get; set; }
        public ICollection<Blog_Hrefs>? Blog_HrefsModifer { get; set; }
        public ICollection<Blog_Images>? Blog_ImagesCreator { get; set; }
        public ICollection<Blog_Images>? Blog_ImagesModifer { get; set; }
        public ICollection<Blogs>? BlogsCreator { get; set; }
        public ICollection<Blogs>? BlogsModifer { get; set; }
        public ICollection<Colors>? ColorsCreator { get; set; }
        public ICollection<Colors>? ColorsModifer { get; set; }
        public ICollection<Commodities>? CommoditiesCreator { get; set; }
        public ICollection<Commodities>? CommoditiesModifer { get; set; }
        public ICollection<Commodity_Images>? CommodityImagesCreator { get; set; }
        public ICollection<Commodity_Images>? CommodityImagesModifer { get; set; }
        public ICollection<Commodity_Kinds>? CommodityKindsCreator { get; set; }
        public ICollection<Commodity_Kinds>? CommodityKindsModifer { get; set; }
        public ICollection<Commodity_Prices>? CommodityPricesCreator { get; set; }
        public ICollection<Commodity_Prices>? CommodityPricesModifer { get; set; }
        public ICollection<Commodity_Sizes>? CommoditySizesCreator { get; set; }
        public ICollection<Commodity_Sizes>? CommoditySizesModifer { get; set; }
        public ICollection<Commodity_Tags>? CommodityTagsCreator { get; set; }
        public ICollection<Commodity_Tags>? CommodityTagsModifer { get; set; }
        public ICollection<Coupon_Uses>? CouponUsesCreator { get; set; }
        public ICollection<Coupon_Uses>? CouponUsesModifer { get; set; }
        public ICollection<Coupon_Ways>? CouponWaysCreator { get; set; }
        public ICollection<Coupon_Ways>? CouponWaysModifer { get; set; }
        public ICollection<Coupons>? CouponsCreator { get; set; }
        public ICollection<Coupons>? CouponsModifer { get; set; }
        public ICollection<Delivery_Options>? DeliveryOptionsCreator { get; set; }
        public ICollection<Delivery_Options>? DeliveryOptionsModifer { get; set; }
        public ICollection<Delivery_Places>? DeliveryPlacesCreator { get; set; }
        public ICollection<Delivery_Places>? DeliveryPlacesModifer { get; set; }
        public ICollection<Files>? FilesCreator { get; set; }
        public ICollection<Files>? FilesModifer { get; set; }
        public ICollection<Href_Coordinations>? HrefCoordinationsCreator { get; set; }
        public ICollection<Href_Coordinations>? HrefCoordinationsModifer { get; set; }
        public ICollection<Inventories>? InventoriesCreator { get; set; }
        public ICollection<Inventories>? InventoriesModifer { get; set; }
        public ICollection<Like_Commodities>? LikeCommoditiesCreator { get; set; }
        public ICollection<Like_Commodities>? LikeCommoditiesModifer { get; set; }
        public ICollection<Members>? MembersCreator { get; set; }
        public ICollection<Members>? MembersModifer { get; set; }
        public ICollection<Menus>? MenusCreator { get; set; }
        public ICollection<Menus>? MenusModifer { get; set; }
        public ICollection<Pages>? PagesCreator { get; set; }
        public ICollection<Pages>? PagesModifer { get; set; }
        public ICollection<Payments>? PaymentsCreator { get; set; }
        public ICollection<Payments>? PaymentsModifer { get; set; }
        public ICollection<Prices>? PricesCreator { get; set; }
        public ICollection<Prices>? PricesModifer { get; set; }
        public ICollection<Received_Coupons>? ReceivedCouponsCreator { get; set; }
        public ICollection<Received_Coupons>? ReceivedCouponsModifer { get; set; }
        public ICollection<Recently_Viewed>? RecentlyViewedCreator { get; set; }
        public ICollection<Recently_Viewed>? RecentlyViewedModifer { get; set; }
        public ICollection<Roles>? RolesCreator { get; set; }
        public ICollection<Roles>? RolesModifer { get; set; }
        public ICollection<Sales_items>? SalesitemsCreator { get; set; }
        public ICollection<Sales_items>? SalesitemsModifer { get; set; }
        public ICollection<Sales>? SalesCreator { get; set; }
        public ICollection<Sales>? SalesModifer { get; set; }
        public ICollection<Shopping_Carts>? ShoppingCartsCreator { get; set; }
        public ICollection<Shopping_Carts>? ShoppingCartsModifer { get; set; }
        public ICollection<Shops>? ShopsCreator { get; set; }
        public ICollection<Shops>? ShopsModifer { get; set; }
        public ICollection<Sizes>? SizesCreator { get; set; }
        public ICollection<Sizes>? SizesModifer { get; set; }
        public ICollection<Status>? StatusCreator { get; set; }
        public ICollection<Status>? StatusModifer { get; set; }
        public ICollection<Subscribes>? SubscribesCreator { get; set; }
        public ICollection<Subscribes>? SubscribesModifer { get; set; }
        public ICollection<Tags>? TagsCreator { get; set; }
        public ICollection<Tags>? TagsModifer { get; set; }
    }
}