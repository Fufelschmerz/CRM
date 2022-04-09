using CRM.Domain.ContactPersons.Enums;

namespace CRM.Application.Controllers.ContactPersons.Dto
{
    public class ContactDataDto
    {
        public string Value { get; set; }
        
        public string Comment { get; set; }

        public ContactDataType ContactDataType { get; set; }
    }
}