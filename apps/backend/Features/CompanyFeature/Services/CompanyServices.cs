using System.Transactions;
using backend.Features.CompanyFeature.ServiceModels;
using Kojh.DAL.Data.Interfaces;
using Kojh.DAL.Helpers;
using Kojh.DAL.Models;
using MapsterMapper;

namespace backend.Features.CompanyFeature.Services
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

        public async Task<CompanyServiceModel> AddCompanyAsync(CompanyServiceModel company, CancellationToken ct)
        {
            CompanyServiceModel fullyAdded;

            using var transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);

            var added = await _unitOfWork.Companies.AddCompanyAsync(_mapper.Map<Company>(company), ct);
            await _unitOfWork.CompleteAsync(ct);


            List<CompanyAssociation> ExistingMemberships = [];

            foreach (var id in company.Memberships)
            {
                var load = await _unitOfWork.Associations.GetByIdAsync(id, ct);
                if (load is null) continue;

                var newMemberships = new CompanyAssociation
                {
                    CompanyId = added.Id,
                    AssociationId = id
                };
                ExistingMemberships.Add(newMemberships);
            }
            await _unitOfWork.CompanyAssociations.AddCompanyAssociationAsync(ExistingMemberships, ct);
            await _unitOfWork.CompleteAsync(ct);

            List<CompanyLocation> ExistingLocations = [];

            foreach (var id in company.Locations)
            {
                var load = await _unitOfWork.Locations.GetByIdAsync(id, ct);
                if (load is null) continue;

                var newLocations = new CompanyLocation
                {
                    CompanyId = added.Id,
                    LocationId = load.Id
                };
                ExistingLocations.Add(newLocations);
            }
            await _unitOfWork.CompanyLocations.AddCompanyLocationAsync(ExistingLocations, ct);
            await _unitOfWork.CompleteAsync(ct);

            var companyWithIncludes = await _unitOfWork.Companies.GetCompanyByIdAsync(added.Id, ct);

            fullyAdded = _mapper.Map<CompanyServiceModel>(companyWithIncludes);

            transactionScope.Complete();

            return fullyAdded;
        }
    }
}
