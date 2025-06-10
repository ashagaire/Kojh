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
    public class AddCompany : EndpointBaseAsync.WithRequest<AddCompanyRequest>.WithActionResult<CompanyResponse>
    {
        private readonly ICompanyServices _companyServices;
        private readonly IMapper _mapper;

        public AddCompany(ICompanyServices companyServices, IMapper mapper)
        {
            _companyServices = companyServices;
            _mapper = mapper;
        }

        [HttpPost("/company")]
        [SwaggerOperation(
            Summary = "Add New Company",
            Description = "Add New Company",
            OperationId = "AddCompany",
            Tags = new[] { "Companies" })
            ]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public override async Task<ActionResult<CompanyResponse>> HandleAsync(AddCompanyRequest request, CancellationToken ct = new())
        {
            try
            {
                var response = await _companyServices.AddCompanyAsync(_mapper.Map<CompanyServiceModel>(request), ct);

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
