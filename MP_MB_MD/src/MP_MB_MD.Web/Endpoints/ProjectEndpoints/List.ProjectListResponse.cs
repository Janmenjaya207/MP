using MP_MB_MD.Core.ProjectAggregate;
using System.Collections.Generic;

namespace MP_MB_MD.Web.Endpoints.ProjectEndpoints
{
    public class ProjectListResponse
    {
        public List<ProjectRecord> Projects { get; set; } = new();
    }
}
