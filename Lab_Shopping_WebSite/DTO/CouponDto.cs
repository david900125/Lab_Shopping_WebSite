namespace Lab_Shopping_WebSite.DTO
{
    public class CraeteCouponDto
    {
        public string Coupon_Key { get; set; }
        public string Coupon_Title { get; set; }
        public string Coupon_Content { get; set; }
        public int Coupon_WayID { get; set; }
        public int Issued_Amount { get; set; }
        public decimal DisCount { get; set; }
        public bool isIssued { get; set; }
    }
}
