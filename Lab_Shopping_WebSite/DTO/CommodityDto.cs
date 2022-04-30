
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
    }

    public class Commodity_Selection_Dto
    {
        public List<int>? Commodity_Kinds { get; set; }
        public List<int>? Commodity_Colors { get; set; }
    }
}
