namespace CRM.Domain.Common.Commands.Contexts
{
    using global::Commands.Absctractions.Cotexts;
    using global::Domain.Abstracions.Identification;
    using System;

    public class DeleteCommandContext<T> : ICommandContext where T : class, IHasId, new ()
    {
        public DeleteCommandContext(T objWithId)
        {
            ObjWithId = objWithId ??
                throw new ArgumentNullException(nameof(objWithId));
        }

        public T ObjWithId { get; }
    }
}
