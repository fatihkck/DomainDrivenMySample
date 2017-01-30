using System.Collections.Generic;

namespace Infrastructure.Domain
{

    #region  Entity
    public class BusinessRuleEntity
    {
        private string _ruleDescription;

        public BusinessRuleEntity(string ruleDescription)
        {
            _ruleDescription = ruleDescription;
        }

        public string RuleDescription
        {
            get
            {
                return _ruleDescription;
            }
        }
    }
    #endregion

    public abstract class BusinessRule
    {

        #region Private Fields
        private List<BusinessRuleEntity> _brokenRules = new List<BusinessRuleEntity>();
        #endregion

        protected void AddBrokenRule(BusinessRuleEntity rule)
        {
            _brokenRules.Add(rule);
        }
        public IEnumerable<BusinessRuleEntity> GetBrokenRules()
        {
            _brokenRules.Clear();
            Validate();
            return _brokenRules;
        }

        protected abstract void Validate();

    }
}
