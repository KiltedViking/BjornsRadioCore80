using System;
using System.Collections.Generic;

namespace BjornsRadioCore80.Models;

public partial class Genre
{
    public int Id { get; set; }

    public string GenreName { get; set; } = null!;

    public string? Comments { get; set; }

    public virtual ICollection<Album> Albums { get; set; } = new List<Album>();
}
