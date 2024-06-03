namespace bill.Models.Data
{
    public class ItemNameModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    }
}
