using Lab_Shopping_WebSite.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lab_Shopping_WebSite.DBContext
{
    public class BlogHrefsConfiguration : IEntityTypeConfiguration<Blog_Hrefs>
    {
        public void Configure(EntityTypeBuilder<Blog_Hrefs> builder)
        {
            builder.HasKey(n => new { n.BlogID, n.CommodityID });
            builder.HasOne(n => n.CreateMember).WithOne().OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(n => n.ModifyMember).WithOne().OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(n => n.CreateMember).WithMany(t => t.Blog_HrefsCreator).HasForeignKey(n => n.Creator);
            builder.HasOne(n => n.ModifyMember).WithMany(t => t.Blog_HrefsModifer).HasForeignKey(n => n.Modifier);
        }
    }
    public class BlogImagesConfiguration : IEntityTypeConfiguration<Blog_Images>
    {
        public void Configure(EntityTypeBuilder<Blog_Images> builder)
        {
            builder.HasKey(n => new { n.BlogID, n.FileID });
            builder.HasOne(n => n.CreateMember).WithOne().OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(n => n.ModifyMember).WithOne().OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(n => n.CreateMember).WithMany(t => t.Blog_ImagesCreator).HasForeignKey(n => n.Creator);
            builder.HasOne(n => n.ModifyMember).WithMany(t => t.Blog_ImagesModifer).HasForeignKey(n => n.Modifier);
        }
    }
    public class CommodityImagesConfiguration : IEntityTypeConfiguration<Commodity_Images>
    {
        public void Configure(EntityTypeBuilder<Commodity_Images> builder)
        {
            //builder.HasKey(n => new { n.CommodityID, n.FileID });
            builder.HasOne(n => n.CreateMember).WithOne().OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(n => n.ModifyMember).WithOne().OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(n => n.CreateMember).WithMany(t => t.CommodityImagesCreator).HasForeignKey(n => n.Creator);
            builder.HasOne(n => n.ModifyMember).WithMany(t => t.CommodityImagesModifer).HasForeignKey(n => n.Modifier);
        }

    }
    public class CommodityTagsConfiguration : IEntityTypeConfiguration<Commodity_Tags>
    {
        public void Configure(EntityTypeBuilder<Commodity_Tags> builder)
        {
            builder.HasKey(n => new { n.CommodityID, n.TagID });
            builder.HasOne(n => n.CreateMember).WithOne().OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(n => n.ModifyMember).WithOne().OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(n => n.CreateMember).WithMany(t => t.CommodityTagsCreator).HasForeignKey(n => n.Creator);
            builder.HasOne(n => n.ModifyMember).WithMany(t => t.CommodityTagsModifer).HasForeignKey(n => n.Modifier);
        }
    }
    public class CouponUsesConfiguration : IEntityTypeConfiguration<Coupon_Uses>
    {
        public void Configure(EntityTypeBuilder<Coupon_Uses> builder)
        {
            builder.HasKey(n => new { n.SaleID, n.CouponID });
            builder.HasOne(n => n.CreateMember).WithOne().OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(n => n.ModifyMember).WithOne().OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(n => n.CreateMember).WithMany(t => t.CouponUsesCreator).HasForeignKey(n => n.Creator);
            builder.HasOne(n => n.ModifyMember).WithMany(t => t.CouponUsesModifer).HasForeignKey(n => n.Modifier);
        }

    }
    public class LikeCommoditiesConfiguration : IEntityTypeConfiguration<Like_Commodities>
    {
        public void Configure(EntityTypeBuilder<Like_Commodities> builder)
        {
            builder.HasKey(n => new { n.MemberID, n.CommodityID });
            builder.HasOne(n => n.CreateMember).WithOne().OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(n => n.ModifyMember).WithOne().OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(n => n.CreateMember).WithMany(t => t.LikeCommoditiesCreator).HasForeignKey(n => n.Creator);
            builder.HasOne(n => n.ModifyMember).WithMany(t => t.LikeCommoditiesModifer).HasForeignKey(n => n.Modifier);
        }
    }
    public class MenusConfiguration : IEntityTypeConfiguration<Menus>
    {
        public void Configure(EntityTypeBuilder<Menus> builder)
        {
            builder.HasOne(n => n.CreateMember).WithOne().OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(n => n.ModifyMember).WithOne().OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(n => n.CreateMember).WithMany(t => t.MenusCreator).HasForeignKey(n => n.Creator);
            builder.HasOne(n => n.ModifyMember).WithMany(t => t.MenusModifer).HasForeignKey(n => n.Modifier);
        }
    }
    public class PaymentsConfiguration : IEntityTypeConfiguration<Payments>
    {
        public void Configure(EntityTypeBuilder<Payments> builder)
        {
            builder.HasOne(n => n.CreateMember).WithOne().OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(n => n.ModifyMember).WithOne().OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(n => n.CreateMember).WithMany(t => t.PaymentsCreator).HasForeignKey(n => n.Creator);
            builder.HasOne(n => n.ModifyMember).WithMany(t => t.PaymentsModifer).HasForeignKey(n => n.Modifier);
        }
    }
    public class PricesConfiguration : IEntityTypeConfiguration<Prices>
    {
        public void Configure(EntityTypeBuilder<Prices> builder)
        {
            builder.HasOne(n => n.CreateMember).WithOne().OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(n => n.ModifyMember).WithOne().OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(n => n.CreateMember).WithMany(t => t.PricesCreator).HasForeignKey(n => n.Creator);
            builder.HasOne(n => n.ModifyMember).WithMany(t => t.PricesModifer).HasForeignKey(n => n.Modifier);
        }
    }
    public class PagesConfiguration : IEntityTypeConfiguration<Pages>
    {
        public void Configure(EntityTypeBuilder<Pages> builder)
        {
            builder.HasKey(n => new { n.PageID, n.MenuID });
            builder.HasOne(n => n.CreateMember).WithOne().OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(n => n.ModifyMember).WithOne().OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(n => n.CreateMember).WithMany(t => t.PagesCreator).HasForeignKey(n => n.Creator);
            builder.HasOne(n => n.ModifyMember).WithMany(t => t.PagesModifer).HasForeignKey(n => n.Modifier);
        }
    }
    public class RolesConfiguration : IEntityTypeConfiguration<Roles>
    {
        public void Configure(EntityTypeBuilder<Roles> builder)
        {
            builder.HasOne(n => n.CreateMember).WithOne().OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(n => n.ModifyMember).WithOne().OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(n => n.CreateMember).WithMany(t => t.RolesCreator).HasForeignKey(n => n.Creator);
            builder.HasOne(n => n.ModifyMember).WithMany(t => t.RolesModifer).HasForeignKey(n => n.Modifier);

            builder.HasData(
                new Roles
                {
                    RoleID = 1,
                    RoleName = "管理者",
                    CreateTime = DateTime.Now,
                    ModifyTime = DateTime.Now
                }

            );
        }
    }
    public class ReceivedCouponsConfiguration : IEntityTypeConfiguration<Received_Coupons>
    {
        public void Configure(EntityTypeBuilder<Received_Coupons> builder)
        {
            builder.HasKey(n => new { n.MemberID, n.CouponID });
            builder.HasOne(n => n.CreateMember).WithOne().OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(n => n.ModifyMember).WithOne().OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(n => n.CreateMember).WithMany(t => t.ReceivedCouponsCreator).HasForeignKey(n => n.Creator);
            builder.HasOne(n => n.ModifyMember).WithMany(t => t.ReceivedCouponsModifer).HasForeignKey(n => n.Modifier);
        }
    }
    public class ReceivedViewedConfiguration : IEntityTypeConfiguration<Recently_Viewed>
    {
        public void Configure(EntityTypeBuilder<Recently_Viewed> builder)
        {
            builder.HasKey(n => new { n.MemberID, n.CommodityID });
            builder.HasOne(n => n.CreateMember).WithOne().OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(n => n.ModifyMember).WithOne().OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(n => n.CreateMember).WithMany(t => t.RecentlyViewedCreator).HasForeignKey(n => n.Creator);
            builder.HasOne(n => n.ModifyMember).WithMany(t => t.RecentlyViewedModifer).HasForeignKey(n => n.Modifier);
        }
    }
    public class ShoppingCartsConfiguration : IEntityTypeConfiguration<Shopping_Carts>
    {
        public void Configure(EntityTypeBuilder<Shopping_Carts> builder)
        {
            builder.HasKey(n => new { n.MemberID, n.Commodity_SizeID });
            builder.HasOne(n => n.CreateMember).WithOne().OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(n => n.ModifyMember).WithOne().OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(n => n.CreateMember).WithMany(t => t.ShoppingCartsCreator).HasForeignKey(n => n.Creator);
            builder.HasOne(n => n.ModifyMember).WithMany(t => t.ShoppingCartsModifer).HasForeignKey(n => n.Modifier);
        }
    }
    public class SalesitemConfiguration : IEntityTypeConfiguration<Sales_items>
    {
        public void Configure(EntityTypeBuilder<Sales_items> builder)
        {
            builder.HasKey(n => new { n.SaleID, n.Commodity_SizeID });
            builder.HasOne(n => n.CreateMember).WithOne().OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(n => n.ModifyMember).WithOne().OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(n => n.CreateMember).WithMany(t => t.SalesitemsCreator).HasForeignKey(n => n.Creator);
            builder.HasOne(n => n.ModifyMember).WithMany(t => t.SalesitemsModifer).HasForeignKey(n => n.Modifier);
        }
    }
    public class ShopsConfiguration : IEntityTypeConfiguration<Shops>
    {
        public void Configure(EntityTypeBuilder<Shops> builder)
        {
            builder.HasOne(n => n.CreateMember).WithOne().OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(n => n.ModifyMember).WithOne().OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(n => n.CreateMember).WithMany(t => t.ShopsCreator).HasForeignKey(n => n.Creator);
            builder.HasOne(n => n.ModifyMember).WithMany(t => t.ShopsModifer).HasForeignKey(n => n.Modifier);
        }
    }
    public class SizesConfiguration : IEntityTypeConfiguration<Sizes>
    {
        public void Configure(EntityTypeBuilder<Sizes> builder)
        {
            builder.HasOne(n => n.CreateMember).WithOne().OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(n => n.ModifyMember).WithOne().OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(n => n.CreateMember).WithMany(t => t.SizesCreator).HasForeignKey(n => n.Creator);
            builder.HasOne(n => n.ModifyMember).WithMany(t => t.SizesModifer).HasForeignKey(n => n.Modifier);
        }
    }
    public class StatusConfiguration : IEntityTypeConfiguration<Status>
    {
        public void Configure(EntityTypeBuilder<Status> builder)
        {
            builder.HasOne(n => n.CreateMember).WithOne().OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(n => n.ModifyMember).WithOne().OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(n => n.CreateMember).WithMany(t => t.StatusCreator).HasForeignKey(n => n.Creator);
            builder.HasOne(n => n.ModifyMember).WithMany(t => t.StatusModifer).HasForeignKey(n => n.Modifier);
        }
    }
    public class SubscribesConfiguration : IEntityTypeConfiguration<Subscribes>
    {
        public void Configure(EntityTypeBuilder<Subscribes> builder)
        {
            builder.HasOne(n => n.CreateMember).WithOne().OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(n => n.ModifyMember).WithOne().OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(n => n.CreateMember).WithMany(t => t.SubscribesCreator).HasForeignKey(n => n.Creator);
            builder.HasOne(n => n.ModifyMember).WithMany(t => t.SubscribesModifer).HasForeignKey(n => n.Modifier);
        }
    }
    public class TagsConfiguration : IEntityTypeConfiguration<Tags>
    {
        public void Configure(EntityTypeBuilder<Tags> builder)
        {
            builder.HasOne(n => n.CreateMember).WithOne().OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(n => n.ModifyMember).WithOne().OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(n => n.CreateMember).WithMany(t => t.TagsCreator).HasForeignKey(n => n.Creator);
            builder.HasOne(n => n.ModifyMember).WithMany(t => t.TagsModifer).HasForeignKey(n => n.Modifier);
        }
    }
    public class SalesConfiguration : IEntityTypeConfiguration<Sales>
    {
        public void Configure(EntityTypeBuilder<Sales> builder)
        {
            builder.HasOne(n => n.CreateMember).WithOne().OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(n => n.ModifyMember).WithOne().OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(n => n.CreateMember).WithMany(t => t.SalesCreator).HasForeignKey(n => n.Creator);
            builder.HasOne(n => n.ModifyMember).WithMany(t => t.SalesModifer).HasForeignKey(n => n.Modifier);
        }
    }
    public class BlogContentsConfiguration : IEntityTypeConfiguration<Blog_Contents>
    {
        public void Configure(EntityTypeBuilder<Blog_Contents> builder)
        {
            builder.HasOne(n => n.CreateMember).WithOne().OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(n => n.ModifyMember).WithOne().OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(n => n.CreateMember).WithMany(t => t.Blog_ContentsCreator).HasForeignKey(n => n.Creator);
            builder.HasOne(n => n.ModifyMember).WithMany(t => t.Blog_ContentsModifer).HasForeignKey(n => n.Modifier);
        }
    }
    public class BlogsConfiguration : IEntityTypeConfiguration<Blogs>
    {
        public void Configure(EntityTypeBuilder<Blogs> builder)
        {
            builder.HasOne(n => n.CreateMember).WithOne().OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(n => n.ModifyMember).WithOne().OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(n => n.CreateMember).WithMany(t => t.BlogsCreator).HasForeignKey(n => n.Creator);
            builder.HasOne(n => n.ModifyMember).WithMany(t => t.BlogsModifer).HasForeignKey(n => n.Modifier);
        }
    }
    public class ColorsConfiguration : IEntityTypeConfiguration<Colors>
    {
        public void Configure(EntityTypeBuilder<Colors> builder)
        {
            builder.HasOne(n => n.CreateMember).WithOne().OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(n => n.ModifyMember).WithOne().OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(n => n.CreateMember).WithMany(t => t.ColorsCreator).HasForeignKey(n => n.Creator);
            builder.HasOne(n => n.ModifyMember).WithMany(t => t.ColorsModifer).HasForeignKey(n => n.Modifier);
        }
    }
    public class CommoditiesConfiguration : IEntityTypeConfiguration<Commodities>
    {
        public void Configure(EntityTypeBuilder<Commodities> builder)
        {
            builder.HasOne(n => n.CreateMember).WithOne().OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(n => n.ModifyMember).WithOne().OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(n => n.CreateMember).WithMany(t => t.CommoditiesCreator).HasForeignKey(n => n.Creator);
            builder.HasOne(n => n.ModifyMember).WithMany(t => t.CommoditiesModifer).HasForeignKey(n => n.Modifier);
        }
    }
    public class CommodityKindsConfiguration : IEntityTypeConfiguration<Commodity_Kinds>
    {
        public void Configure(EntityTypeBuilder<Commodity_Kinds> builder)
        {
            builder.HasOne(n => n.CreateMember).WithOne().OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(n => n.ModifyMember).WithOne().OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(n => n.CreateMember).WithMany(t => t.CommodityKindsCreator).HasForeignKey(n => n.Creator);
            builder.HasOne(n => n.ModifyMember).WithMany(t => t.CommodityKindsModifer).HasForeignKey(n => n.Modifier);
        }
    }
    public class MembersConfiguration : IEntityTypeConfiguration<Members>
    {
        public void Configure(EntityTypeBuilder<Members> builder)
        {
            builder.HasOne(n => n.CreateMember).WithOne().OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(n => n.ModifyMember).WithOne().OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(n => n.CreateMember).WithMany(t => t.MembersCreator).HasForeignKey(n => n.Creator);
            builder.HasOne(n => n.ModifyMember).WithMany(t => t.MembersModifer).HasForeignKey(n => n.Modifier);
            // seeds
            builder.HasData(
                new Members
                {
                    MemberID = 1,
                    Name = "administrator",
                    Email_Address = "root@gmail.com",
                    Password = "63A9F0EA7BB98050796B649E85481845",
                    RoleID = 1,
                    Modifier = 1,
                    ModifyTime = DateTime.Now,
                    Creator = 1,
                    CreateTime = DateTime.Now
                }
            );
        }
    }
    public class InventoriesConfiguration : IEntityTypeConfiguration<Inventories>
    {
        public void Configure(EntityTypeBuilder<Inventories> builder)
        {
            builder.HasOne(n => n.CreateMember).WithOne().OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(n => n.ModifyMember).WithOne().OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(n => n.CreateMember).WithMany(t => t.InventoriesCreator).HasForeignKey(n => n.Creator);
            builder.HasOne(n => n.ModifyMember).WithMany(t => t.InventoriesModifer).HasForeignKey(n => n.Modifier);
        }
    }
    public class HrefCoordinationsConfiguration : IEntityTypeConfiguration<Href_Coordinations>
    {
        public void Configure(EntityTypeBuilder<Href_Coordinations> builder)
        {
            builder.HasOne(n => n.CreateMember).WithOne().OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(n => n.ModifyMember).WithOne().OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(n => n.CreateMember).WithMany(t => t.HrefCoordinationsCreator).HasForeignKey(n => n.Creator);
            builder.HasOne(n => n.ModifyMember).WithMany(t => t.HrefCoordinationsModifer).HasForeignKey(n => n.Modifier);
        }
    }
    public class FilesConfiguration : IEntityTypeConfiguration<Files>
    {
        public void Configure(EntityTypeBuilder<Files> builder)
        {
            builder.HasOne(n => n.CreateMember).WithOne().OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(n => n.ModifyMember).WithOne().OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(n => n.CreateMember).WithMany(t => t.FilesCreator).HasForeignKey(n => n.Creator);
            builder.HasOne(n => n.ModifyMember).WithMany(t => t.FilesModifer).HasForeignKey(n => n.Modifier);
        }
    }
    public class DeliveryPlacesConfiguration : IEntityTypeConfiguration<Delivery_Places>
    {
        public void Configure(EntityTypeBuilder<Delivery_Places> builder)
        {
            builder.HasOne(n => n.CreateMember).WithOne().OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(n => n.ModifyMember).WithOne().OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(n => n.CreateMember).WithMany(t => t.DeliveryPlacesCreator).HasForeignKey(n => n.Creator);
            builder.HasOne(n => n.ModifyMember).WithMany(t => t.DeliveryPlacesModifer).HasForeignKey(n => n.Modifier);
        }
    }
    public class DeliveryOptionsConfiguration : IEntityTypeConfiguration<Delivery_Options>
    {
        public void Configure(EntityTypeBuilder<Delivery_Options> builder)
        {
            builder.HasOne(n => n.CreateMember).WithOne().OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(n => n.ModifyMember).WithOne().OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(n => n.CreateMember).WithMany(t => t.DeliveryOptionsCreator).HasForeignKey(n => n.Creator);
            builder.HasOne(n => n.ModifyMember).WithMany(t => t.DeliveryOptionsModifer).HasForeignKey(n => n.Modifier);
        }
    }
    public class CouponsConfigurations : IEntityTypeConfiguration<Coupons>
    {
        public void Configure(EntityTypeBuilder<Coupons> builder)
        {
            builder.HasOne(n => n.CreateMember).WithOne().OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(n => n.ModifyMember).WithOne().OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(n => n.CreateMember).WithMany(t => t.CouponsCreator).HasForeignKey(n => n.Creator);
            builder.HasOne(n => n.ModifyMember).WithMany(t => t.CouponsModifer).HasForeignKey(n => n.Modifier);
        }
    }
    public class CouponsUsesConfigurations : IEntityTypeConfiguration<Coupon_Uses>
    {
        public void Configure(EntityTypeBuilder<Coupon_Uses> builder)
        {
            builder.HasOne(n => n.CreateMember).WithOne().OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(n => n.ModifyMember).WithOne().OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(n => n.CreateMember).WithMany(t => t.CouponUsesCreator).HasForeignKey(n => n.Creator);
            builder.HasOne(n => n.ModifyMember).WithMany(t => t.CouponUsesModifer).HasForeignKey(n => n.Modifier);
        }
    }
    public class CouponsWaysConfigurations : IEntityTypeConfiguration<Coupon_Ways>
    {
        public void Configure(EntityTypeBuilder<Coupon_Ways> builder)
        {
            builder.HasOne(n => n.CreateMember).WithOne().OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(n => n.ModifyMember).WithOne().OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(n => n.CreateMember).WithMany(t => t.CouponWaysCreator).HasForeignKey(n => n.Creator);
            builder.HasOne(n => n.ModifyMember).WithMany(t => t.CouponWaysModifer).HasForeignKey(n => n.Modifier);
        }
    }
    public class CommodityPricesConfiguration : IEntityTypeConfiguration<Commodity_Prices>
    {
        public void Configure(EntityTypeBuilder<Commodity_Prices> builder)
        {
            builder.HasOne(n => n.CreateMember).WithOne().OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(n => n.ModifyMember).WithOne().OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(n => n.CreateMember).WithMany(t => t.CommodityPricesCreator).HasForeignKey(n => n.Creator);
            builder.HasOne(n => n.ModifyMember).WithMany(t => t.CommodityPricesModifer).HasForeignKey(n => n.Modifier);
        }
    }
    public class CommoditySizesConfiguration : IEntityTypeConfiguration<Commodity_Sizes>
    {
        public void Configure(EntityTypeBuilder<Commodity_Sizes> builder)
        {
            builder.HasOne(n => n.CreateMember).WithOne().OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(n => n.ModifyMember).WithOne().OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(n => n.Size).WithOne().OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(n => n.CreateMember).WithMany(t => t.CommoditySizesCreator).HasForeignKey(n => n.Creator);
            builder.HasOne(n => n.ModifyMember).WithMany(t => t.CommoditySizesModifer).HasForeignKey(n => n.Modifier);
        }
    }
}