using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Services.DTO;
using Services.Helpers;

namespace Services.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VideoInformationController : Controller
    {
        private List<VideoInformationDTO<string>> TestData = [
                new VideoInformationDTO<string>() 
                { 
                    id = 1,
                    VideoIdentifier = Guid.NewGuid().ToString(),
                    UserId = "hs.oblivion@gmail.com",
                    Title = "Video 1",
                    ChannelTitle = "Youtube Channel 1",
                    Description = "Test Video 1",
                    Duration = 50, //seconds
                    ThumbnailURL = "https://skillsforges.com/blog/5-youtube-thumbnail-design-ideas-to-catch-more-attention",
                    PublishedAt = new DateTime(2000,01,01),
                    LastModifiedAt = new DateTime(2000,01,05)
                },
            new VideoInformationDTO<string>()
                {
                    id = 2,
                    VideoIdentifier = Guid.NewGuid().ToString(),
                    UserId = "hs.oblivion@gmail.com",
                    Title = "Video 2",
                    ChannelTitle = "Youtube Channel 1",
                    Description = "Test Video 2",
                    Duration = 40, //seconds
                    ThumbnailURL = "https://skillsforges.com/blog/5-youtube-thumbnail-design-ideas-to-catch-more-attention",
                    PublishedAt = new DateTime(2000,01,06),
                    LastModifiedAt = new DateTime(2000,01,07)
                },
            new VideoInformationDTO<string>()
                {
                    id = 3,
                    VideoIdentifier = Guid.NewGuid().ToString(),
                    UserId = "hs.oblivion@gmail.com",
                    Title = "Video 3",
                    ChannelTitle = "Youtube Channel 1",
                    Description = "Test Video 3",
                    Duration = 30, //seconds
                    ThumbnailURL = "https://skillsforges.com/blog/5-youtube-thumbnail-design-ideas-to-catch-more-attention",
                    PublishedAt = new DateTime(2000,01,08),
                    LastModifiedAt = new DateTime(2000,01,09)
                },
            new VideoInformationDTO<string>()
                {
                    id = 4,
                    VideoIdentifier = Guid.NewGuid().ToString(),
                    UserId = "israel.ojeda@vesperamx.com",
                    Title = "Video 4",
                    ChannelTitle = "Youtube Channel 2",
                    Description = "Test Video 4",
                    Duration = 20, //seconds
                    ThumbnailURL = "https://skillsforges.com/blog/5-youtube-thumbnail-design-ideas-to-catch-more-attention",
                    PublishedAt = new DateTime(2000,01,01),
                    LastModifiedAt = new DateTime(2000,01,05)
                },
            ];

        [HttpGet]
        public IActionResult GetVideoInformation([FromServices] ODataQueryOptions<VideoInformationDTO<string>>? odataOptions = null)
        {
            var results = OData2LinqQueryBuilder.Build(odataOptions)?.Invoke(TestData.AsQueryable()).ToList() ?? TestData.AsQueryable().ToList();

            return Ok(results);
        }
    }   
}
