using System.Data.Entity;
using Venus.Model;

namespace Venus.Data
{
    public static class ContextHelpers
    {
        public static void ApplyStateChanges(this DbContext context)
        {
            foreach (var entity in context.ChangeTracker.Entries<IObjectsWithState>())
            {
                IObjectsWithState stateInfo = entity.Entity;
                entity.State = StateHelpers.ConvertState(stateInfo.State);
            }
        }
    }
}
