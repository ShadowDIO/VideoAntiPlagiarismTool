using System;
using System.Collections.Generic;

namespace DAL.Models.Database;

public partial class VideoInformation
{
    public int Id { get; set; }

    public string VideoIdentifier { get; set; } = null!;

    public string Title { get; set; } = null!;

    public int Duration { get; set; }

    public string? ThumbnailUrl { get; set; }

    public string? Description { get; set; }

    public string ChannelTitle { get; set; } = null!;

    public int UserId { get; set; }

    public virtual User User { get; set; } = null!;
}
