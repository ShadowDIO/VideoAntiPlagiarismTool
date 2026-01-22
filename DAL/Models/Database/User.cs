using System;
using System.Collections.Generic;

namespace DAL.Models.Database;

public partial class User
{
    public int Id { get; set; }

    public string Email { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public virtual ICollection<VideoInformation> VideoInformations { get; set; } = new List<VideoInformation>();
}
