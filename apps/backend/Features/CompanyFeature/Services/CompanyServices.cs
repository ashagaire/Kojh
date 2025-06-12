using System.Transactions;
using backend.Features.CompanyFeature.ServiceModels;
using Kojh.DAL.Data.Interfaces;
using Kojh.DAL.Helpers;
using Kojh.DAL.Models;
using MapsterMapper;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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

        public async Task<CompanyServiceModel?> UpdateCompanyDetailsAsync(CompanyServiceModel company, CancellationToken ct)
        {
            var companyToUpdate = await _unitOfWork.Companies.GetCompanyByIdAsync(company.Id, ct);
            if (companyToUpdate is null) return null;

            companyToUpdate.Name = company.Name;
            companyToUpdate.AccountType = company.AccountType;
            companyToUpdate.HomePage = company.HomePage;
            companyToUpdate.GeneralEmailAddress = company.GeneralEmailAddress;
            companyToUpdate.GeneralPhoneNumber = company.GeneralPhoneNumber;
            companyToUpdate.MainAddress = company.MainAddress;
            companyToUpdate.NumberOfEmployee = company.NumberOfEmployee;
            companyToUpdate.Established = company.Established;
            companyToUpdate.BusinessId = company.BusinessId;
            companyToUpdate.ContactPersonEmail = company.ContactPersonEmail;
            companyToUpdate.ConciseDescription = company.ConciseDescription;
            companyToUpdate.CompanyDescription = company.CompanyDescription;

            var updated = await _unitOfWork.Companies.UpdateCompanyAsync(companyToUpdate, ct);
            await _unitOfWork.CompleteAsync(ct);
            return updated is null ? null : _mapper.Map<CompanyServiceModel>(updated);


        }
        public async Task<CompanyServiceModel?> DeleteCompanyAsync(Guid id, CancellationToken ct)
        {
            Company? archived;

            using var transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);

            var companyAssociations = await _unitOfWork.CompanyAssociations.FindAsync(x => x.CompanyId == id, ct);

            var removedCompanyAssociations = await _unitOfWork.CompanyAssociations.RemoveRangeAsync(companyAssociations, ct);
            await _unitOfWork.CompleteAsync(ct);

            if (companyAssociations.Count != removedCompanyAssociations.Count) throw new ArgumentException("Error removing Company with Associations");

            var companyLocations = await _unitOfWork.CompanyLocations.FindAsync(x => x.CompanyId == id, ct);
            var removedCompanyLocations = await _unitOfWork.CompanyLocations.RemoveRangeAsync(companyLocations, ct);
            await _unitOfWork.CompleteAsync(ct);
            if (companyLocations.Count != removedCompanyLocations.Count) throw new ArgumentException("Error removing Company with Locations");

            archived = await _unitOfWork.Companies.RemoveAsync(id, ct);
            await _unitOfWork.CompleteAsync(ct);

            transactionScope.Complete();

            return archived is null ? null : _mapper.Map<CompanyServiceModel>(archived);

        }
        }
}
