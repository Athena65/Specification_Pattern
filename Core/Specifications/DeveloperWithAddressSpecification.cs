using Core.Models;

namespace Core.Specifications
{
    public class DeveloperWithAddressSpecification:BaseSpecification<Developer>
    {
        public DeveloperWithAddressSpecification(int years):base(x=>x.EstimatedIncome>years)
        {
            AddInclude(x => x.Address);

        }
    }
}
