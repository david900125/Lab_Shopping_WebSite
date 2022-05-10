using Lab_Shopping_WebSite.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab_Shopping_WebSite.DBContext
{
    public partial class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Action_Auths>? Action_Auths { get; set; }
        public DbSet<Blog_Contents>? Blog_Contents { get; set; }
        public DbSet<Blog_Hrefs>? Blog_Hrefs { get; set; }
        public DbSet<Blog_Images>? Blog_Images { get; set; }
        public DbSet<Blogs>? Blogs { get; set; }
        public DbSet<Colors>? Colors { get; set; }
        public DbSet<Commodities>? Commodities { get; set; }
        public DbSet<Commodity_Images>? Commodity_Images { get; set; }
        public DbSet<Commodity_Kinds>? Commodity_Kinds { get; set; }
        public DbSet<Commodity_Prices>? Commodity_Prices { get; set; }
        public DbSet<Commodity_Sizes>? Commodity_Sizes { get; set; }
        public DbSet<Commodity_Tags>? Commodity_Tags { get; set; }
        public DbSet<Coupon_Uses>? Coupon_Uses { get; set; }
        public DbSet<Coupon_Ways>? Coupon_Ways { get; set; }
        public DbSet<Coupons>? Coupons { get; set; }
        public DbSet<Delivery_Options>? Delivery_Options { get; set; }
        public DbSet<Delivery_Places>? Delivery_Places { get; set; }
        public DbSet<Files>? Files { get; set; }
        public DbSet<Href_Coordinations>? Href_Coordinations { get; set; }
        public DbSet<Inventories>? Inventories { get; set; }
        public DbSet<Like_Commodities>? Like_Commodities { get; set; }
        public DbSet<Members>? Members { get; set; }
        public DbSet<Menus>? Menus { get; set; }
        public DbSet<Pages>? Pages { get; set; }
        public DbSet<Payments>? Payments { get; set; }
        public DbSet<Prices>? Prices { get; set; }
        public DbSet<Received_Coupons>? Received_Coupons { get; set; }
        public DbSet<Recently_Viewed>? Recently_Viewed { get; set; }
        public DbSet<Roles>? Roles { get; set; }
        public DbSet<Sales_items>? Sales_Items { get; set; }
        public DbSet<Sales>? Sales { get; set; }
        public DbSet<Shopping_Carts>? Shopping_Carts { get; set; }
        public DbSet<Shops>? Shops { get; set; }
        public DbSet<Sizes>? Sizes { get; set; }
        public DbSet<Status>? Status { get; set; }
        public DbSet<Subscribes>? Subscribes { get; set; }
        public DbSet<Tags>? Tags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RolesConfiguration());
            modelBuilder.ApplyConfiguration(new MembersConfiguration());           
            modelBuilder.ApplyConfiguration(new PricesConfiguration());
            modelBuilder.ApplyConfiguration(new CommodityKindsConfiguration());
            modelBuilder.ApplyConfiguration(new TagsConfiguration());
            modelBuilder.ApplyConfiguration(new SizesConfiguration());
            modelBuilder.ApplyConfiguration(new ColorsConfiguration());
            modelBuilder.ApplyConfiguration(new BlogsConfiguration());
            modelBuilder.ApplyConfiguration(new BlogHrefsConfiguration());
            modelBuilder.ApplyConfiguration(new BlogImagesConfiguration());
            modelBuilder.ApplyConfiguration(new BlogContentsConfiguration());            
            modelBuilder.ApplyConfiguration(new CommoditiesConfiguration());
            modelBuilder.ApplyConfiguration(new CommodityImagesConfiguration());
            modelBuilder.ApplyConfiguration(new CommodityTagsConfiguration());
            modelBuilder.ApplyConfiguration(new CommodityPricesConfiguration());
            modelBuilder.ApplyConfiguration(new CommoditySizesConfiguration());
            modelBuilder.ApplyConfiguration(new FilesConfiguration());
            modelBuilder.ApplyConfiguration(new DeliveryPlacesConfiguration());
            modelBuilder.ApplyConfiguration(new DeliveryOptionsConfiguration());
            modelBuilder.ApplyConfiguration(new PaymentsConfiguration());
            modelBuilder.ApplyConfiguration(new StatusConfiguration());
            modelBuilder.ApplyConfiguration(new SalesConfiguration());
            modelBuilder.ApplyConfiguration(new SalesitemConfiguration());        
            modelBuilder.ApplyConfiguration(new ShoppingCartsConfiguration());         
            modelBuilder.ApplyConfiguration(new InventoriesConfiguration());
            modelBuilder.ApplyConfiguration(new CouponsWaysConfigurations());
            modelBuilder.ApplyConfiguration(new CouponsConfigurations());
            modelBuilder.ApplyConfiguration(new CouponUsesConfiguration());
            modelBuilder.ApplyConfiguration(new LikeCommoditiesConfiguration());
            modelBuilder.ApplyConfiguration(new MenusConfiguration());
            modelBuilder.ApplyConfiguration(new PagesConfiguration());
            modelBuilder.ApplyConfiguration(new SubscribesConfiguration());
            modelBuilder.ApplyConfiguration(new HrefCoordinationsConfiguration());
            modelBuilder.ApplyConfiguration(new ShopsConfiguration());
            modelBuilder.ApplyConfiguration(new ReceivedCouponsConfiguration());
            modelBuilder.ApplyConfiguration(new ReceivedViewedConfiguration());
        }
        protected override void ConfigureConventions(ModelConfigurationBuilder builder)
        {
            builder.Properties<DateOnly>()
                .HaveConversion<DateOnlyConverter>()
                .HaveColumnType("date");
        }
    }
}
