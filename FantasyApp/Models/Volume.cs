using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.ComponentModel.DataAnnotations;

namespace FantasyApp.Models
{
    public class Volume
    {
        public Guid VolumeId { get; set; }
        public string? GoogleId { get; set; }
        public string Title { get; set; } = string.Empty;
        [DataType(DataType.Date)]
        public DateTime Published_date { get; set; }
        public string Description { get; set; } = string.Empty;
        public int ISBN_10 { get; set; }
        public int ISBN_13 { get; set; }
        public string Language { get; set; }
        public string PrintType { get; set; }

        //Navigation Properties
        public virtual ICollection<Author>? Authors { get; set; }
        public virtual ICollection<Category>? Categories { get; set; }
        public virtual Publisher? Publisher { get; set; }
        public virtual MainCategory? MainCategory { get; set; }
    }
}
