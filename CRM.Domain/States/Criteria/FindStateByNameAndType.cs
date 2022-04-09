using CRM.Domain.States.Enums;
using Queries.Abstractions.Criterions;

namespace CRM.Domain.States.Criteria
{
    public class FindStateByNameAndType : ICriterion
    {
        public string Name { get; }

        public StatusState Status { get; set; }

        public FindStateByNameAndType(string name, StatusState status)
        {
            Name = name;
            Status = status;
        }
    }
}
