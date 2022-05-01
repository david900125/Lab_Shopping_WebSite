
namespace Lab_Shopping_WebSite.DTO
{
    public class CartDto
    {
        public int CommodityID { get; set; }
        public int SizeID { get; set; }
        public int ColorID { get; set; }
        public int Amount { get; set; }
    }

    public class Commodity_Simple_Dto
    {
        public int CommodityID { get; set; }
        public string CommodityName { get; set; }
        public decimal? CommodityPrice { get; set; }
        public decimal? SpecialPrice { get; set; }
        public string CommodityUrl { get; set; }
        public List<string> CommodityTags { get; set; }
        public List<string> CommodityKinds { get; set; }
    }

    public class Commodity_Selection_Dto
    {
        public List<int>? Commodity_Kinds { get; set; }
        public List<int>? Commodity_Colors { get; set; }
    }

    public class NewCommodityDto
    {
        public string CommodityName { get; set; }
        public string Description { get; set; }
        public string Material { get; set; }
        public bool isReleased { get; set; }
        public decimal Price { get; set; }
        public decimal S_Price { get; set; }
        public int CommodityKinds { get; set; }
        public int CommodityTags { get; set; }
        public List<int> CommoditySizes { get; set; }
        public List<int> CommodityColors { get; set; }
        public List<string> CommodityImages { get; set; }
    }

    public class CommodityDto
    {
        public int CommodityId { get; set; }
        public string CommodityName { get; set; }
        public string Description { get; set; }
        public string Material { get; set; }
        public decimal Price { get; set; }
        public decimal S_Price { get; set; }
        public List<decimal> Amount { get; set; }
        public List<string> CommodityKinds { get; set; }
        public List<string> CommodityTags { get; set; }
        public List<string> CommoditySizes { get; set; }
        public List<string> CommodityColors { get; set; }
        public List<string> CommodityImages { get; set; }
    }
}
