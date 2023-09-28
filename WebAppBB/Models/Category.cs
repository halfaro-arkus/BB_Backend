using System;
using System.Collections.Generic;

namespace WebAppBB.Models;

public partial class Category
{
    public int Categoryid { get; set; }

    public string Description { get; set; } = null!;
}
