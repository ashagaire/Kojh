using Ardalis.ApiEndpoints;
using backend.Features.CompanyFeature.Request;
using backend.Features.CompanyFeature.Response;
using backend.Features.CompanyFeature.ServiceModels;
using backend.Features.CompanyFeature.Services;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace backend.Features.CompanyFeature.EndPoints
{
    public class UpdateCompanyDetails : EndpointBaseAsync
        .WithRequest<UpdateCompanyDetailsRequest>
        .WithActionResult<CompanyResponse>
    {
        private readonly ICompanyServices _services;
        private readonly IMapper _mapper;

        public UpdateCompanyDetails(ICompanyServices companyServices, IMapper mapper)
        {
            _services = companyServices;
            _mapper = mapper;
        }
        [HttpPut("/company/{id}")]
        [SwaggerOperation(
            Summary = "Update Company Details",
            Description = "Update Company Details",
            OperationId = "UpdateCompany",
            Tags = new[] { "Companies" })
            ]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public override async Task<ActionResult<CompanyResponse>> HandleAsync(UpdateCompanyDetailsRequest request, CancellationToken ct = new())
        {
            try
            {
                var response = await _services.UpdateCompanyDetailsAsync(_mapper.Map<CompanyServiceModel>(request), ct);
                if (response is null) return NotFound();

                return Ok(_mapper.Map<CompanyResponse>(response));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
