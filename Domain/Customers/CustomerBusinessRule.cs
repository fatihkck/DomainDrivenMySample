using Infrastructure.Domain;

namespace Domain.Customers
{
    public static class CustomerBusinessRule
    {
        public static readonly BusinessRuleEntity CustomerNameRequired = new BusinessRuleEntity("Customer must hava a name");
    }
}
