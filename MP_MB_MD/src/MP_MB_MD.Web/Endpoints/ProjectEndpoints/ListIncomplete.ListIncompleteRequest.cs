using Microsoft.AspNetCore.Mvc;

namespace MP_MB_MD.Web.Endpoints.ProjectEndpoints
{
    public class ListIncompleteRequest
    {
        [FromRoute]
        public int ProjectId { get; set; }
        [FromQuery]
        public string SearchString { get; set; }
    }
}
