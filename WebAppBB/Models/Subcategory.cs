using System;
using System.Collections.Generic;

namespace WebAppBB.Models;

public partial class Subcategory
{
    public int Subcategoryid { get; set; }

    public string Description { get; set; } = null!;

    public int? Categoryid { get; set; }
}
