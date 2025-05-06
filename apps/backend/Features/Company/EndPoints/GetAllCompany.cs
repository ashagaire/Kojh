using Ardalis.ApiEndpoints;
using backend.Features.Company.Response;
using backend.Features.Company.Services;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace backend.Features.Company.EndPoints
{
    public class GetAllCompany : EndpointBaseAsync.WithoutRequest.WithActionResult<List<CompanyResponse>>
    {
        private readonly ICompanyServices _companyServices;
        private readonly IMapper _mapper;
        public GetAllCompany(ICompanyServices companyServices, IMapper mapper)
        {
            _companyServices = companyServices;
            _mapper = mapper;
        }
        [HttpGet("company/all")]
        [SwaggerOperation(
            Summary = "Get all Companies",
            Description = "Get all Companies",
            OperationId = "GetAllCompanies",
            Tags = new[] { "Companies" })
         ]

        [ProducesResponseType(StatusCodes.Status200OK)]
        public override async Task<ActionResult<List<CompanyResponse>>> HandleAsync(CancellationToken ct = default)
        {
            var companies = await _companyServices.GetAllCompaniesAsync(ct);
            return Ok(_mapper.Map<List<CompanyResponse>>(companies));
        }
    }
}
