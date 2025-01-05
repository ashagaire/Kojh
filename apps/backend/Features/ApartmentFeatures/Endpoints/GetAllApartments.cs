using Ardalis.ApiEndpoints;
using backend.Features.ApartmentFeatures.Response;
using Deraa.DAL.Data.Interfaces;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;

namespace backend.Features.ApartmentFeatures.Endpoints
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetAllApartments : EndpointBaseAsync.WithoutRequest.WithActionResult<List<ApartmentResponse>>
    {
        private readonly IApartmentRepository _apartmentRepository;
        private readonly IMapper _mapper;

        public GetAllApartments(IApartmentRepository ApartmentRepository, IMapper mapper)
        {
            _apartmentRepository = ApartmentRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public override async Task<ActionResult<List<ApartmentResponse>>> HandleAsync(CancellationToken ct = default)
        {
            var apartments = await _apartmentRepository.GetAllAsync(ct);
            return Ok(_mapper.Map<List<ApartmentResponse>>(apartments));
        }
    }
}
