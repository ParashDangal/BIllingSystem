namespace bill.Models
{
    public class CalculateBillViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Address { get; set; }
        public string? Pan_No { get; set; }
        public decimal Price { get; set; }
        public int ItemNameId { get; set; }
        public string ItemName { get; set; }
        public decimal? TotalPrice { get; set; }
        public int BillNo { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    }
}
