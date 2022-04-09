namespace CRM.Domain.Common.Commands.Contexts
{
    using global::Commands.Absctractions.Cotexts;
    using global::Domain.Abstracions.Identification;
    using System;

    public class CreateCommandContext<T> : ICommandContext where T : class, IHasId, new ()
    {
        public CreateCommandContext(T objWithId)
        {
            ObjWithId = objWithId ??
                throw new ArgumentNullException();
        }

        public T ObjWithId { get; }
    }
}
