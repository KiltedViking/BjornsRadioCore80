using System;
using System.Collections.Generic;

namespace BjornsRadioCore80.Models;

public partial class Album
{
    public int Id { get; set; }

    public string Artist { get; set; } = null!;

    public string Title { get; set; } = null!;

    public string? ReleaseYear { get; set; }

    public int? Genre { get; set; }

    public int? Media { get; set; }

    public string? Comments { get; set; }

    public virtual Genre? GenreNavigation { get; set; }

    public virtual MediaType? MediaNavigation { get; set; }

    public virtual ICollection<Song> Songs { get; set; } = new List<Song>();
}
