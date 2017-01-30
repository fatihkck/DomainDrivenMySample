using Infrastructure.Domain;

namespace Domain.ValueObjects.Address
{
    public static class AddressBusinessRule
    {
        public static readonly BusinessRuleEntity CityIsRequired = new BusinessRuleEntity("An Address must have a city.");
    }
}
