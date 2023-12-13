namespace Doordash.Data.Models.Resturants
{
    public class CreateResturantRequest
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string ResturantType { get; set; }

        public string Town { get; set; }

        public string AddressType { get; set; }

        public string AreaCode { get; set; }

        public string StreetAddress { get; set; }

        public string HouseNumber { get; set; }
    }
}
