namespace Lab_Shopping_WebSite.DTO
{
    public class CheckOutDto
    {
        public string Address { get; set; }
        public int PaymentID { get; set; }
    }
    public class SaleUpdDto
    {
        public string SaleID { get; set; }
        public string SendDate { get; set; }    
        public bool isChecked { get; set; }
    }
    public class SaleDto
    {
        public string SaleID { get; set; }
        public string Address { get; set; }
        public string Delivery { get; set; }
        public string? SendDate { get; set; }
        public string Established { get; set; }
        public decimal Total_Price { get; set; }
        public bool isChecked { get; set; }
    }
}
