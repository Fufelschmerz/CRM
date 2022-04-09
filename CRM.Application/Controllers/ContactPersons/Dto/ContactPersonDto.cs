using System;
using System.Collections.Generic;
using CRM.Domain.ContactPersons.Enums;

namespace CRM.Application.Controllers.ContactPersons.Dto
{
    public class ContactPersonDto
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Patronymic { get; set; }

        public string Post { get; set; }

        public IEnumerable<ContactDataDto> ContactData { get; set; }
    }
}