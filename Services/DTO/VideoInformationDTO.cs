using Services.DTO.Interfaces;

namespace Services.DTO
{
    public class VideoInformationDTO<T> : IVideoInformation<T>
    {
        public int id { get; set; }

        public required T VideoIdentifier { get; set; }

        public int Duration { get; set; }

        public required string ChannelTitle { get; set; }

        public required string Title { get; set; }

        public string? Description { get; set; }

        public string? ThumbnailURL { get; set; }

        public DateTime PublishedAt { get; set; }

        public DateTime LastModifiedAt { get; set; }

        public required string UserId { get; set; }
    }
}
