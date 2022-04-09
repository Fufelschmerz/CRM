using CRM.Domain.States.Enums;

namespace CRM.Application.Controllers.States.Actions.GetList
{
    public class GetStateListFilter
    {
        public string Search { get; set; }

        public StatusState? Status { get; set; }

        public bool? IsArchive { get; set; }
    }
}
