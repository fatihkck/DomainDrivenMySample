using System.Collections.Generic;

namespace Infrastructure.Domain
{
    public abstract class EntityBase<IdType>: BusinessRule
    {
      
        public IdType Id { get; set; }


        protected void  AddBrokenRuleRange(IEnumerable<BusinessRuleEntity> rules)
        {
            foreach (var rule in rules)
            {
                AddBrokenRule(rule);
            }
        }
    
    }
}
