using DAL.Interfaces;
using DAL.Models.Database;
using Microsoft.EntityFrameworkCore;

namespace DAL.Implementation
{
    public class VideoInformationDAL(IDbContextFactory<VideoScriptAntiplagiarismContext> contextFactory) : IVideoInformationDAL
    {
        private readonly IDbContextFactory<VideoScriptAntiplagiarismContext> ContextFactory = contextFactory;

        public IQueryable<VideoInformation> Get()
        {
            return ContextFactory.CreateDbContext().VideoInformations;
        }

        public int Create(VideoInformation newVideoInformation)
        {
            var dbContext = ContextFactory.CreateDbContext();

            dbContext.VideoInformations.Add(newVideoInformation);

            dbContext.SaveChanges();

            return dbContext.VideoInformations.Last().Id;
        }

        public void Update(VideoInformation videoInformation)
        {
            throw new NotImplementedException();
        }

        public void Delete(int videoInformationId)
        {
            throw new NotImplementedException();
        }
    }
}
