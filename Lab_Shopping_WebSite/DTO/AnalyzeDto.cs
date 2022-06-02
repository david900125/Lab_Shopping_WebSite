namespace Lab_Shopping_WebSite.DTO
{
    public class AnalyzeDto
    {
        public int Viewed { get; set; } // 本周瀏覽輛
        public int Sales { get; set; }  // 成交訂單量
        public int UnShipping { get; set; } // 訂單未出貨
        public int UnPay { get; set; }  // 訂單未付款
    }
}
