namespace Services.DTO.Interfaces
{
    public interface IVideoInformation<T>
    {
        int id { get; set; }

        T VideoIdentifier { get; set; }

        int Duration { get; set; }

        string ChannelTitle { get; set; }

        string Title { get; set; }

        string? Description { get; set; }

        string? ThumbnailURL { get; set; }

        DateTime PublishedAt { get; set; }

        DateTime LastModifiedAt { get; set; }

        string UserId { get; set; }
    }
}
