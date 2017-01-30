using Infrastructure.Domain;

namespace Domain.ValueObjects.Address
{
    public class Address : ValueObjectBase
    {
        public string AddressLine{ get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }

        protected override void Validate()
        {
            if (string.IsNullOrEmpty(City))
            {
                AddBrokenRule(AddressBusinessRule.CityIsRequired);

            }
        }
    }
}
