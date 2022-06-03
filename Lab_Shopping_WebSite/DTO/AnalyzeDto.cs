namespace Lab_Shopping_WebSite.DTO
{
    public class AnalyzeDto
    {
        public int Viewed { get; set; } // 本周瀏覽輛
        public int Sales { get; set; }  // 成交訂單量
        public int UnShipping { get; set; } // 訂單未出貨
        public int UnPay { get; set; }  // 訂單未付款
    }

    public class Top_Commodity_Analyze
    {
        public string? CommodityName { get; set; }
        public int Viewed { get; set; }
        public int Liked { get; set; }
        public int Add_to_Carts { get; set; }
    }

    public class PicturDto
    {
        public List<string> Label { get; set; }
        public List<decimal> Data { get; set; }
    }
}
