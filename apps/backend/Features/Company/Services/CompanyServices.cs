using backend.Features.Company.ServiceModels;
using Kojh.DAL.Data.Interfaces;
using Kojh.DAL.Helpers;
using MapsterMapper;

namespace backend.Features.Company.Services
{
    public class CompanyServices : ICompanyServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CompanyServices(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CompanyServiceModel> GetCompanyByIdAsync(Guid id, CancellationToken ct)
        {
            var company = await _unitOfWork.Companies.GetCompanyByIdAsync(id, ct);
            if (company == null)
            {
                throw new Exception($"Company with ID {id} not found");
            }
            return _mapper.Map<CompanyServiceModel>(company);
        }
        public async Task<List<CompanyServiceModel>> GetAllCompaniesAsync(CancellationToken ct)
        {
            var companies = await _unitOfWork.Companies.GetAllCompaniesAsync(ct);

            if (companies == null || companies.Count == 0)
            {
                throw new Exception("No companies found");
            }

            return _mapper.Map<List<CompanyServiceModel>>(companies);
        }

        public async Task<PaginatedCompanyServiceModel> GetPaginatedCompaniesAsync(PaginatedCompanyServiceModel company, CancellationToken ct)
        {

            var companies = await _unitOfWork.Companies.GetPaginatedCompanies(_mapper.Map<CompanyListFilter>(company), ct);

            return new PaginatedCompanyServiceModel
            {
                TotalCount = companies.TotalCount,
                Companies = _mapper.Map<List<CompanyServiceModel>>(companies.Items)
            };
        }
    }
}
