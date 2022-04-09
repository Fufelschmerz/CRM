namespace CRM.Application.Controllers.States.Dto
{
    using CRM.Domain.States.Enums;

    public class StateDto
    {

        public string Name { get; set; }

        public StatusState Status { get; set; }

        public bool IsArchive { get; set; }
    }
}
