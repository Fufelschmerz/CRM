using System;
using CRM.Domain.ContactPersons.Enums;
using CRM.Domain.Contacts.Enums;

namespace CRM.Application.Controllers.Contacts.Dto
{
    public class ContactListDto
    {
        public long Id { get; set; }

        public ContactDataType ContactDataType { get; set; }

        public string ManagerName { get; set; }

        public string ContactPersonName { get; set; }

        public string ContactPersonSurname { get; set; }

        public string ContactPersonPatronymic { get; set; }

        public DateTime CreationOfDate { get; set; }

        public DateTime EventOfDate { get; set; }

        public DateTime PlannedEventOfDate { get; set; }

        public StateContact StateContact { get; set; }

        public string Comment { get; set; }
    }
}
