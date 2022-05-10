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
            builder.HasData(
                new Commodity_Kinds
                {
                    Commodity_KindID = 1,
                    Description = "短袖",
                    Modifier = 1,
                    ModifyTime = DateTime.Now,
                    Creator = 1,
                    CreateTime = DateTime.Now
                },
                new Commodity_Kinds
                {
                    Commodity_KindID = 2,
                    Description = "外套",
                    Modifier = 1,
                    ModifyTime = DateTime.Now,
                    Creator = 1,
                    CreateTime = DateTime.Now
                },
                new Commodity_Kinds
                {
                    Commodity_KindID = 3,
                    Description = "長褲",
                    Modifier = 1,
                    ModifyTime = DateTime.Now,
                    Creator = 1,
                    CreateTime = DateTime.Now
                },
                new Commodity_Kinds
                {
                    Commodity_KindID = 4,
                    Description = "短褲",
                    Modifier = 1,
                    ModifyTime = DateTime.Now,
                    Creator = 1,
                    CreateTime = DateTime.Now
                });
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
            builder.HasData(
                new Payments
                {
                    PaymentID = 1,
                    Payment = "現金",
                    Creator = 1,
                    Modifier = 1,
                    CreateTime = DateTime.Now,
                    ModifyTime = DateTime.Now
                },
                new Payments
                {
                    PaymentID = 2,
                    Payment = "信用卡",
                    Creator = 1,
                    Modifier = 1,
                    CreateTime = DateTime.Now,
                    ModifyTime = DateTime.Now
                });
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
            builder.HasData(
                new Prices
                {
                    PriceID = 1,
                    Price = "優惠價",
                    Creator = 1,
                    Modifier = 1,
                    CreateTime = DateTime.Now,
                    ModifyTime = DateTime.Now
                },
                new Prices
                {
                    PriceID = 2,
                    Price = "標價",
                    Creator = 1,
                    Modifier = 1,
                    CreateTime = DateTime.Now,
                    ModifyTime = DateTime.Now
                },
                new Prices
                {
                    PriceID = 3,
                    Price = "單價",
                    Creator = 1,
                    Modifier = 1,
                    CreateTime = DateTime.Now,
                    ModifyTime = DateTime.Now
                }
            );
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
        public RolesConfiguration()
        {
        }

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
                },
                new Roles
                {
                    RoleID = 2,
                    RoleName = "使用者",
                    CreateTime = DateTime.Now,
                    ModifyTime = DateTime.Now
                });
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
            builder.HasData(
            new Sizes
            {
                SizeID = 1,
                Commodity_KindsID = 1,
                Size = "S",
                Creator = 1,
                Modifier = 1,
                CreateTime = DateTime.Now,
                ModifyTime = DateTime.Now
            },
            new Sizes
            {
                SizeID = 2,
                Commodity_KindsID = 1,
                Size = "M",
                Creator = 1,
                Modifier = 1,
                CreateTime = DateTime.Now,
                ModifyTime = DateTime.Now
            },
            new Sizes
            {
                SizeID = 3,
                Commodity_KindsID = 1,
                Size = "L",
                Creator = 1,
                Modifier = 1,
                CreateTime = DateTime.Now,
                ModifyTime = DateTime.Now
            },
            new Sizes
            {
                SizeID = 4,
                Commodity_KindsID = 2,
                Size = "S",
                Creator = 1,
                Modifier = 1,
                CreateTime = DateTime.Now,
                ModifyTime = DateTime.Now
            },
            new Sizes
            {
                SizeID = 5,
                Commodity_KindsID = 2,
                Size = "M",
                Creator = 1,
                Modifier = 1,
                CreateTime = DateTime.Now,
                ModifyTime = DateTime.Now
            },
            new Sizes
            {
                SizeID = 6,
                Commodity_KindsID = 2,
                Size = "L",
                Creator = 1,
                Modifier = 1,
                CreateTime = DateTime.Now,
                ModifyTime = DateTime.Now
            },
            new Sizes
            {
                SizeID = 7,
                Commodity_KindsID = 3,
                Size = "S",
                Creator = 1,
                Modifier = 1,
                CreateTime = DateTime.Now,
                ModifyTime = DateTime.Now
            },
            new Sizes
            {
                SizeID = 8,
                Commodity_KindsID = 3,
                Size = "M",
                Creator = 1,
                Modifier = 1,
                CreateTime = DateTime.Now,
                ModifyTime = DateTime.Now
            },
            new Sizes
            {
                SizeID = 9,
                Commodity_KindsID = 3,
                Size = "L",
                Creator = 1,
                Modifier = 1,
                CreateTime = DateTime.Now,
                ModifyTime = DateTime.Now
            });
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
            builder.HasData(
             new Status
             {
                 StatusID = 1,
                 State = "已寄送",
                 Modifier = 1,
                 ModifyTime = DateTime.Now,
                 Creator = 1,
                 CreateTime = DateTime.Now
             },
             new Status
             {
                 StatusID = 2,
                 State = "退貨",
                 Modifier = 1,
                 ModifyTime = DateTime.Now,
                 Creator = 1,
                 CreateTime = DateTime.Now
             },
             new Status
             {
                 StatusID = 3,
                 State = "準備中",
                 Modifier = 1,
                 ModifyTime = DateTime.Now,
                 Creator = 1,
                 CreateTime = DateTime.Now
             });
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
            builder.HasData(
                new Tags
                {
                    TagID = 1,
                    Commodity_KindsID = 1,
                    Tag = "男裝",
                    Creator = 1,
                    CreateTime = DateTime.Now,
                    Modifier = 1,
                    ModifyTime = DateTime.Now
                },
                new Tags
                {
                    TagID = 2,
                    Commodity_KindsID = 1,
                    Tag = "女裝",
                    Creator = 1,
                    CreateTime = DateTime.Now,
                    Modifier = 1,
                    ModifyTime = DateTime.Now
                },
                new Tags
                {
                    TagID = 3,
                    Commodity_KindsID = 2,
                    Tag = "男裝",
                    Creator = 1,
                    CreateTime = DateTime.Now,
                    Modifier = 1,
                    ModifyTime = DateTime.Now
                },
                new Tags
                {
                    TagID = 4,
                    Commodity_KindsID = 2,
                    Tag = "女裝",
                    Creator = 1,
                    CreateTime = DateTime.Now,
                    Modifier = 1,
                    ModifyTime = DateTime.Now
                },
                new Tags
                {
                    TagID = 5,
                    Commodity_KindsID = 3,
                    Tag = "男裝",
                    Creator = 1,
                    CreateTime = DateTime.Now,
                    Modifier = 1,
                    ModifyTime = DateTime.Now
                },
                new Tags
                {
                    TagID = 6,
                    Commodity_KindsID = 3,
                    Tag = "女裝",
                    Creator = 1,
                    CreateTime = DateTime.Now,
                    Modifier = 1,
                    ModifyTime = DateTime.Now
                });
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
            builder.HasData(
                new Colors
                {
                    ColorID = 1,
                    Color = "黑色",
                    Url = "https://www.plain-me.com/upload_files/fonlego-rwd/specpic/cop3563_3_02.jpg",
                    Modifier = 1,
                    ModifyTime = DateTime.Now,
                    Creator = 1,
                    CreateTime = DateTime.Now
                },
                new Colors
                {
                    ColorID = 2,
                    Color = "白色",
                    Url = "https://cdn-plain-me.fonlego.com/upload_files/fonlego-rwd/specpic/FSV0001_3_01.jpg",
                    Modifier = 1,
                    ModifyTime = DateTime.Now,
                    Creator = 1,
                    CreateTime = DateTime.Now
                },
                new Colors
                {
                    ColorID = 3,
                    Color = "咖啡",
                    Url = "https://www.plain-me.com/upload_files/fonlego-rwd/specpic/cop3563_3_01.jpg",
                    Modifier = 1,
                    ModifyTime = DateTime.Now,
                    Creator = 1,
                    CreateTime = DateTime.Now
                },
                new Colors
                {
                    ColorID = 4,
                    Color = "黃色",
                    Url = "https://cdn-plain-me.fonlego.com/upload_files/fonlego-rwd/specpic/crv0307_3_01.jpg",
                    Modifier = 1,
                    ModifyTime = DateTime.Now,
                    Creator = 1,
                    CreateTime = DateTime.Now
                },
                new Colors
                {
                    ColorID = 5,
                    Color = "灰色",
                    Url = "https://www.plain-me.com/upload_files/fonlego-rwd/specpic/cop3563_3_03.jpg",
                    Modifier = 1,
                    ModifyTime = DateTime.Now,
                    Creator = 1,
                    CreateTime = DateTime.Now
                },
                new Colors
                {
                    ColorID = 6,
                    Color = "可可",
                    Url = "https://www.plain-me.com/upload_files/fonlego-rwd/specpic/pln1108-221_3_06.jpg",
                    Modifier = 1,
                    ModifyTime = DateTime.Now,
                    Creator = 1,
                    CreateTime = DateTime.Now
                },
                new Colors
                {
                    ColorID = 7,
                    Color = "灰藍",
                    Url = "https://www.plain-me.com/upload_files/fonlego-rwd/specpic/cop3563_3_02.jpg",
                    Modifier = 1,
                    ModifyTime = DateTime.Now,
                    Creator = 1,
                    CreateTime = DateTime.Now
                },
                new Colors
                {
                    ColorID = 8,
                    Color = "杏灰",
                    Url = "https://cdn-plain-me.fonlego.com/upload_files/fonlego-https://www.plain-me.com/upload_files/fonlego-rwd/specpic/pln1108-221_3_03.jpg",
                    Modifier = 1,
                    ModifyTime = DateTime.Now,
                    Creator = 1,
                    CreateTime = DateTime.Now
                },
                new Colors
                {
                    ColorID = 9,
                    Color = "麻灰",
                    Url = "https://cdn-plain-me.fonlego.com/upload_files/fonlego-rwd/specpic/pln3305-221_3_01.jpg",
                    Modifier = 1,
                    ModifyTime = DateTime.Now,
                    Creator = 1,
                    CreateTime = DateTime.Now
                },
                new Colors
                {
                    ColorID = 10,
                    Color = "卡其",
                    Url = "https://cdn-plain-me.fonlego.com/upload_files/fonlego-rwd/specpic/cop1676_3_02.jpg",
                    Modifier = 1,
                    ModifyTime = DateTime.Now,
                    Creator = 1,
                    CreateTime = DateTime.Now
                },
                new Colors
                {
                    ColorID = 11,
                    Color = "紫",
                    Url = "https://cdn-plain-me.fonlego.com/upload_files/fonlego-rwd/specpic/pln1108-221_3_04.jpg",
                    Modifier = 1,
                    ModifyTime = DateTime.Now,
                    Creator = 1,
                    CreateTime = DateTime.Now
                },
                new Colors
                {
                    ColorID = 12,
                    Color = "橘色",
                    Url = "https://cdn-plain-me.fonlego.com/upload_files/fonlego-rwd/specpic/pln0104-221_3_02.jpg",
                    Modifier = 1,
                    ModifyTime = DateTime.Now,
                    Creator = 1,
                    CreateTime = DateTime.Now
                },
                new Colors
                {
                    ColorID = 13,
                    Color = "藍",
                    Url = "https://www.plain-me.com/upload_files/fonlego-rwd/specpic/pln0104-221_3_01.jpg",
                    Modifier = 1,
                    ModifyTime = DateTime.Now,
                    Creator = 1,
                    CreateTime = DateTime.Now
                }
            );
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
                },
                new Members
                {
                    MemberID = 2,
                    Name = "eeeee",
                    Email_Address = "ioioio@gmail.com",
                    Password = "76D80224611FC919A5D54F0FF9FBA446",
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
            builder.HasData(
             new Delivery_Places
             {
                 Delivery_PlaceID = 1,
                 Delivery_Place = "本島",
                 Creator = 1,
                 CreateTime = DateTime.Now,
                 Modifier = 1,
                 ModifyTime = DateTime.Now
             },
              new Delivery_Places
              {
                  Delivery_PlaceID = 2,
                  Delivery_Place = "外島",
                  Creator = 1,
                  CreateTime = DateTime.Now,
                  Modifier = 1,
                  ModifyTime = DateTime.Now
              },
               new Delivery_Places
               {
                   Delivery_PlaceID = 3,
                   Delivery_Place = "外國",
                   Creator = 1,
                   CreateTime = DateTime.Now,
                   Modifier = 1,
                   ModifyTime = DateTime.Now
               });
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
            builder.HasData(
             new Delivery_Options
             {
                 Delivery_OptionsID = 1,
                 Delivery_Option = "快遞",
                 Delivery_PlaceID = 1,
                 Delivery_Cost = 30,
                 Creator = 1,
                 CreateTime = DateTime.Now,
                 Modifier = 1,
                 ModifyTime = DateTime.Now
             },
             new Delivery_Options
             {
                 Delivery_OptionsID = 2,
                 Delivery_Option = "快遞",
                 Delivery_PlaceID = 2,
                 Delivery_Cost = 100,
                 Creator = 1,
                 CreateTime = DateTime.Now,
                 Modifier = 1,
                 ModifyTime = DateTime.Now
             },
             new Delivery_Options
             {
                 Delivery_OptionsID = 3,
                 Delivery_Option = "快遞",
                 Delivery_PlaceID = 3,
                 Delivery_Cost = 300,
                 Creator = 1,
                 CreateTime = DateTime.Now,
                 Modifier = 1,
                 ModifyTime = DateTime.Now
             });
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
            builder.HasData(
            new Coupon_Ways
            {
                Coupon_WayID = 1,
                Coupon_Way = "折價券",
                Creator = 1,
                CreateTime = DateTime.Now,
                ModifyTime = DateTime.Now
            },
            new Coupon_Ways
            {
                Coupon_WayID = 2,
                Coupon_Way = "免運費",
                Creator = 1,
                CreateTime = DateTime.Now,
                ModifyTime = DateTime.Now
            });
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
            builder.HasOne(n => n.CreateMember).WithMany(t => t.CommoditySizesCreator).HasForeignKey(n => n.Creator);
            builder.HasOne(n => n.ModifyMember).WithMany(t => t.CommoditySizesModifer).HasForeignKey(n => n.Modifier);
        }
    }
}