using Ardalis.ApiEndpoints;
using backend.Features.CompanyFeature.Response;
using backend.Features.CompanyFeature.Request;
using backend.Features.CompanyFeature.Services;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace backend.Features.CompanyFeature.EndPoints
{
    public class GetCompanyById : EndpointBaseAsync.WithRequest<GetCompanyByIdRequest>.WithActionResult<CompanyResponse>
    {
        private readonly ICompanyServices _companyServices;
        private readonly IMapper _mapper;

        public GetCompanyById(ICompanyServices companyServices, IMapper mapper)
        {
            _companyServices = companyServices;
            _mapper = mapper;
        }
        [HttpGet("/company/{id:guid}")]
        [SwaggerOperation(
            Summary = "Get Company",
            Description = "Get Company",
            OperationId = "GetCompanyById",
            Tags = new[] { "Companies" })
         ]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public override async Task<ActionResult<CompanyResponse>> HandleAsync(GetCompanyByIdRequest request, CancellationToken ct = new())
        {
            try
            {
                var result = await _companyServices.GetCompanyByIdAsync(request.Id, ct);
                if (result is null) return NotFound();
                return Ok(_mapper.Map<CompanyResponse>(result));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
