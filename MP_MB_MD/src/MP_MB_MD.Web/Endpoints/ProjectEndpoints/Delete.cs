using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using MP_MB_MD.Core.ProjectAggregate;
using MP_MB_MD.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading;
using System.Threading.Tasks;

namespace MP_MB_MD.Web.Endpoints.ProjectEndpoints
{
    public class Delete : BaseAsyncEndpoint
        .WithRequest<DeleteProjectRequest>
        .WithoutResponse
    {
        private readonly IRepository<Project> _repository;

        public Delete(IRepository<Project> repository)
        {
            _repository = repository;
        }

        [HttpDelete(DeleteProjectRequest.Route)]
        [SwaggerOperation(
            Summary = "Deletes a Project",
            Description = "Deletes a Project",
            OperationId = "Projects.Delete",
            Tags = new[] { "ProjectEndpoints" })
        ]
        public override async Task<ActionResult> HandleAsync([FromRoute] DeleteProjectRequest request,
            CancellationToken cancellationToken)
        {
            var aggregateToDelete = await _repository.GetByIdAsync(request.ProjectId); // TODO: pass cancellation token
            if (aggregateToDelete == null) return NotFound();

            await _repository.DeleteAsync(aggregateToDelete);

            return NoContent();
        }
    }
}
