using Ardalis.ApiEndpoints;
using backend.Features.CompanyFeature.Response;
using backend.Features.CompanyFeature.Request;
using backend.Features.CompanyFeature.ServiceModels;
using backend.Features.CompanyFeature.Services;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace backend.Features.CompanyFeature.EndPoints
{
    public class GetAllCompany : EndpointBaseAsync.WithRequest<GetAllCompanyRequest>.WithActionResult<PaginatedCompanyResponse>
    {
        private readonly ICompanyServices _companyServices;
        private readonly IMapper _mapper;
        public GetAllCompany(ICompanyServices companyServices, IMapper mapper)
        {
            _companyServices = companyServices;
            _mapper = mapper;
        }
        [HttpPost("company/all")]
        [SwaggerOperation(
            Summary = "Get all Companies",
            Description = "Get all Companies",
            OperationId = "GetAllCompanies",
            Tags = new[] { "Companies" })
         ]

        [ProducesResponseType(StatusCodes.Status200OK)]
        public override async Task<ActionResult<PaginatedCompanyResponse>> HandleAsync(GetAllCompanyRequest request, CancellationToken ct = new())
        {
            try
            {
                var result = await _companyServices.GetPaginatedCompaniesAsync(_mapper.Map<PaginatedCompanyServiceModel>(request), ct);
                if (result is null) return NotFound();
                return Ok(_mapper.Map<PaginatedCompanyResponse>(result));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
