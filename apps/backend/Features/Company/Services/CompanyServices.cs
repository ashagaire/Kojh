using backend.Features.Company.ServiceModels;
using Kojh.DAL.Data;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;

namespace backend.Features.Company.Services
{
    public class CompanyServices : ICompanyServices
    {
        private readonly AppDbContext? _dbcontext;
        private readonly IMapper _mapper;

        public CompanyServices(AppDbContext? dbcontext, IMapper mapper)
        {
            _dbcontext = dbcontext;
            _mapper = mapper;
        }

        public async Task<List<CompanyServiceModel>> GetAllCompaniesAsync(CancellationToken ct)
        {
            var companies = await _dbcontext.Companies.ToListAsync(ct);
            if (companies == null)
            {
                throw new Exception("No companies found");
            }
            //var companyServiceModel = _mapper.Map<CompanyServiceModel>(companies);
            //return companyServiceModel;
            return _mapper.Map<List<CompanyServiceModel>>(companies);
        }
    }
}
