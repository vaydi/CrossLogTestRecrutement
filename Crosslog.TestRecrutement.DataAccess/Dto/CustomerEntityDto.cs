namespace Crosslog.TestRecrutement.DataAccess.Dto
{
    public class CustomerEntityDto
    {
        public int CustomerId { get; set; }

        public string LastName { get; set; }

        public string FirstName { get; set; }

        public string Address { get; set; }

        public string ZipCode { get; set; }

        public string City { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public int? OrderCount { get; set; }

        public decimal? TotalAmount { get; set; }

        public int? OrderNumber { get; set; }
    }
}