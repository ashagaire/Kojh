//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Kojh.DAL.Data.Interfaces;
//using Kojh.DAL.Models;

//namespace Kojh.DAL.Data.Repositories
//{
//    public class SocialMediaRepository : ISocialMediaRepository
//    {
//        private readonly AppDbContext _dbContext;
//        public SocialMediaRepository(AppDbContext dbContext)
//        {
//            _dbContext = dbContext;
//        }

//        public async Task<SocialMedia> AddSocialMediaAsync(SocialMedia socialMedia, CancellationToken ct)
//        {
//            socialMedia.Id = Guid.NewGuid();
//            socialMedia.CreatedAt = DateTime.UtcNow;
//            socialMedia.UpdatedAt = DateTime.UtcNow;
//            _dbContext.SocialMedias.Add(socialMedia);
//            await _dbContext.SaveChangesAsync(ct);
//            return socialMedia;
//        }
//    }
//}
