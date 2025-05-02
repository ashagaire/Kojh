using Ardalis.ApiEndpoints;
using backend.Features.ItemFeatures.Response;
using Kojh.DAL.Data.Interfaces;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace backend.Features.ItemFeatures.Endpoints
{

    public class GetAllItems : EndpointBaseAsync.WithoutRequest.WithActionResult<List<ItemResponse>>
    {
        private readonly IItemRepository _ItemRepository;
        private readonly IMapper _mapper;

        public GetAllItems(IItemRepository ItemRepository, IMapper mapper)
        {
            _ItemRepository = ItemRepository;
            _mapper = mapper;
        }

        [HttpGet("apartments/all")]
        [SwaggerOperation(
            Summary = "Get all Apartments",
            Description = "Get all Apartments",
            OperationId = "GetAllApartments",
            Tags = new[] { "Apartments" })
         ]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public override async Task<ActionResult<List<ItemResponse>>> HandleAsync(CancellationToken ct = default)
        {
            var Items = await _ItemRepository.GetAllAsync(ct);
            return Ok(_mapper.Map<List<ItemResponse>>(Items));
        }
    }
}
