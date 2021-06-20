using Microsoft.AspNetCore.Mvc.Filters;

namespace MarioTravel.Admin.Infrastructure.ErrorHandling
{
    public abstract class ModelStateTransfer : ActionFilterAttribute
    {
        protected const string Key = nameof(ModelStateTransfer);
    }
}