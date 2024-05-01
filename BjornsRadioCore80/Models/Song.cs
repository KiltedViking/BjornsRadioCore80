using System;
using System.Collections.Generic;

namespace BjornsRadioCore80.Models;

public partial class Song
{
    public int Id { get; set; }

    public int Album { get; set; }

    public byte AlbumOrder { get; set; }

    public string Title { get; set; } = null!;

    public string? Comments { get; set; }

    public virtual Album AlbumNavigation { get; set; } = null!;
}
