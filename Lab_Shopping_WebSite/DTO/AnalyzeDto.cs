namespace Lab_Shopping_WebSite.DTO
{
    public class AnalyzeDto
    {
        public int Viewed { get; set; } // 瀏覽輛
        public int Sales { get; set; }  // 訂單量
        public int UnShipping { get; set; } // 未出貨
        public int UnPay { get; set; }  // 未付款

    }
}
