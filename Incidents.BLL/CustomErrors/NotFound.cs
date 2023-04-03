using FluentResults;

namespace Incidents.BLL.CustomErrors
{
    public class NotFound : Error
    {
        public NotFound(string message) : base(message)
        {
            Metadata.Add("HttpStatusCode", 404);
        }
    }
}
