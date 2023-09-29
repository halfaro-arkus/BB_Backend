using System;
using System.Collections.Generic;

namespace WebAppBB.Models;

public partial class Post
{
    public int PostId { get; set; }

    public string Title { get; set; } = null!;

    public string? Url { get; set; }

    public string? Subtitle { get; set; }

    public string Headline { get; set; } = null!;

    public string? Author { get; set; }

    public DateTime? DocumentDate { get; set; }

    public string? Teaser { get; set; }

    public string? TeaserThumbnail { get; set; }

    public bool? UseOnlyHomepage { get; set; }

    public string? MainText { get; set; }

    public string? MetaDescription { get; set; }

    public bool? ImageSpan { get; set; }

    public bool? ImageAlign { get; set; }

    public bool? ImageWrap { get; set; }

    public bool? WrapText { get; set; }

    public int? Display { get; set; }

    public int? Homepage { get; set; }

    public int? CategoryLanding { get; set; }
    public DateTime? created { get; set; }
    public DateTime? modified { get; set; }
    public virtual ICollection<Postscategory> Postscategories { get; set; } = new List<Postscategory>();

    


}
