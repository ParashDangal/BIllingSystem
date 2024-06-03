namespace bill.Models
{
    public class ItemNameViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

    }
}
