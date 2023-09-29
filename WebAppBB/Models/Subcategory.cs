using System;
using System.Collections.Generic;

namespace WebAppBB.Models;

public partial class Subcategory
{
    public int Subcategoryid { get; set; }

    public string Description { get; set; } = null!;

    public int? Categoryid { get; set; }


    public bool? featured_header { get; set; }
    public bool? featured_banner { get; set; }
    public bool? featured_titles { get; set; }
    public string? icon { get; set; }
    public string? thumbnail { get; set; }
    public string? main_description { get; set; }
    public string? main_headline { get; set; }
    public string? subcategory_description { get; set; }
    public bool? active { get; set; }
    public bool? static_subcategoryid { get; set; }


}
