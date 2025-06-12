using Ardalis.ApiEndpoints;
using backend.Features.CompanyFeature.Services;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace backend.Features.CompanyFeature.EndPoints
{
    public class DeleteCompany : EndpointBaseAsync.WithRequest<Guid>.WithActionResult

    {
        private readonly ICompanyServices _services;

        public DeleteCompany(ICompanyServices companyServices)
        {
            _services = companyServices;
        }

        [HttpDelete("/company/{id}")]
        [SwaggerOperation(
            Summary = "Delete Company",
            Description = "Delete Company",
            OperationId = "DeleteCompany",
            Tags = new[] { "Companies" })
            ]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public override async Task<ActionResult> HandleAsync([FromRoute(Name = "id")] Guid id, CancellationToken ct = new())
        {
            try
            {
                var response = await _services.DeleteCompanyAsync(id, ct);
                if (response is null) return NotFound();
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

    

}
