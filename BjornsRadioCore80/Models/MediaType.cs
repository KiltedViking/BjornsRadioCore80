using System;
using System.Collections.Generic;

namespace BjornsRadioCore80.Models;

public partial class MediaType
{
    public int Id { get; set; }

    public string TypeName { get; set; } = null!;

    public string? Comments { get; set; }

    public virtual ICollection<Album> Albums { get; set; } = new List<Album>();
}
