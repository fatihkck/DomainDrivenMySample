using Domain.ValueObjects.Address;
using Infrastructure.Domain;

namespace Domain.Customers
{
    public class Customer : EntityBase<int>, IEntity
    {
        public string Name { get; set; }
        public Address Adress { get; set; }
        protected override void Validate()
        {
            if (string.IsNullOrEmpty(Name))
            {
                AddBrokenRule(CustomerBusinessRule.CustomerNameRequired);
            }
            AddBrokenRuleRange(Adress.GetBrokenRules());
        }
    }
}
