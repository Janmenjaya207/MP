using System.Collections.Generic;

namespace MP_MB_MD.Web.Endpoints.ProjectEndpoints
{
    public class ListIncompleteResponse
    {
        public int ProjectId { get; set; }
        public List<ToDoItemRecord> IncompleteItems { get; set; }
    }
}
