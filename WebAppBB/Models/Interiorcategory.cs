using System;
using System.Collections.Generic;

namespace WebAppBB.Models;

public partial class Interiorcategory
{
    public int Interiorcategoryid { get; set; }

    public string Description { get; set; } = null!;

    public int? Subcategoryid { get; set; }
}
