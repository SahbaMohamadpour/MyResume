namespace WebApplication1.Models
{
    public class ContactMe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; } = string.Empty;
        public string Country { get; set; }
        public string PhoneNumber { get; set; }
        
    }
}
