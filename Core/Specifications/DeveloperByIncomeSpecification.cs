using Core.Models;

namespace Core.Specifications
{
    public class DeveloperByIncomeSpecification: BaseSpecification<Developer>
    {
        public DeveloperByIncomeSpecification(int years) : base(x => x.EstimatedIncome > years)
        {
            
            AddOrderByDescending(x => x.EstimatedIncome);
        }
    }
}
