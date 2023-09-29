using System;
using System.Collections.Generic;

namespace WebAppBB.Models;

public partial class Interiorcategory
{
    public int Interiorcategoryid { get; set; }

    public string Description { get; set; } = null!;

    public int? Subcategoryid { get; set; }
    public int? categoryid { get; set; }
    public bool? use_url { get; set; }
    public string? thumbnail { get; set; }
    public string? main_description { get; set; }
    public string? subcategory_headline { get; set; }
    public string? subcategory_description { get; set; }
    public bool? active { get; set; }
}
