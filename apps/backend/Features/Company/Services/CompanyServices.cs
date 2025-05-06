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
            var companies = await _dbcontext.Companies
                .Include(c => c.SocialMedia)
                .Include(c => c.Memberships)
                    .ThenInclude(m => m.Association)
                        .ThenInclude(a => a.Logo)
                .Include(c => c.Locations)
                    .ThenInclude(l => l.Location)
                .Include(c => c.Logo)
                .ToListAsync(ct);
            if (companies == null || companies.Count == 0)
            {
                throw new Exception("No companies found");
            }
            //var companyServiceModel = _mapper.Map<CompanyServiceModel>(companies);
            //return companyServiceModel;
            return _mapper.Map<List<CompanyServiceModel>>(companies);
        }
    }
}
