using System;
using System.Collections.Generic;

namespace MyFirstAPI.Models;

public partial class ProductProfile
{
    public int Id { get; set; }

    public string? Link { get; set; }

    public string? Img { get; set; }

    public int? ProductId { get; set; }

    public virtual Product? Product { get; set; }
}
