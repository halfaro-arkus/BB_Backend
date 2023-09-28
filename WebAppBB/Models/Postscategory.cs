using System;
using System.Collections.Generic;

namespace WebAppBB.Models;

public partial class Postscategory
{
    public int PostcategoriesId { get; set; }

    public int? PostId { get; set; }

    public int? Categoryid { get; set; }

    public int? Subcategoryid { get; set; }

    public int? Interiorcategoryid { get; set; }

    //public virtual Post? Post { get; set; }
}
