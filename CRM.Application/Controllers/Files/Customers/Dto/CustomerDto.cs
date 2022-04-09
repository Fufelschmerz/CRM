namespace CRM.Application.Controllers.Files.Customers.Dto
{
    using System;

    public class CustomerDto
    {
        public string Name { get; set; }

        public string SourceName { get; set; }

        public string StateName { get; set; }

        public string Description { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime ? LastDateContact { get; set; }

        public string ManagerName { get; set; }

        public string ContactComment { get; set; }
    }
}