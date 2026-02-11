using DAL.Models.Database;

namespace DAL.Interfaces
{
    public interface IVideoInformationDAL
    {
        int Create(VideoInformation newVideoInformation);
        void Delete(int videoInformationId);
        IQueryable<VideoInformation> Get();
        void Update(VideoInformation videoInformation);
    }
}