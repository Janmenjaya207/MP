﻿using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using MP_MB_MD.Core.ProjectAggregate;
using MP_MB_MD.Core.ProjectAggregate.Specifications;
using MP_MB_MD.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MP_MB_MD.Web.Endpoints.ProjectEndpoints
{
    public class GetById : BaseAsyncEndpoint
        .WithRequest<GetProjectByIdRequest>
        .WithResponse<GetProjectByIdResponse>
    {
        private readonly IRepository<Project> _repository;

        public GetById(IRepository<Project> repository)
        {
            _repository = repository;
        }

        [HttpGet(GetProjectByIdRequest.Route)]
        [SwaggerOperation(
            Summary = "Gets a single Project",
            Description = "Gets a single Project by Id",
            OperationId = "Projects.GetById",
            Tags = new[] { "ProjectEndpoints" })
        ]
        public override async Task<ActionResult<GetProjectByIdResponse>> HandleAsync([FromRoute] GetProjectByIdRequest request,
            CancellationToken cancellationToken)
        {
            var spec = new ProjectByIdWithItemsSpec(request.ProjectId);
            var entity = await _repository.GetBySpecAsync(spec); // TODO: pass cancellation token
            if (entity == null) return NotFound();

            var response = new GetProjectByIdResponse
            {
                Id = entity.Id,
                Name = entity.Name,
                Items = entity.Items.Select(item => new ToDoItemRecord(item.Id, item.Title, item.Description, item.IsDone)).ToList()
            };
            return Ok(response);
        }
    }
}
