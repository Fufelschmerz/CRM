using CRM.Domain.States.Enums;
using DocumentFormat.OpenXml.Drawing;

namespace CRM.Application.Controllers.States.Dto
{
    public class StateListDto
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public StatusState Status { get; set; }

        public bool IsArchive { get; set; }
    }
}
