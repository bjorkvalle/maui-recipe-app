using SQLite;

namespace bjorkvalle.data.Entities
{
    [Table("recipes")]
    public record Recipe : EntityBase
    {
        [Column("title")]
        [MaxLength(250), Unique]
        public string Title { get; set; }

        [Column("cover_image")]
        public string CoverImg { get; set; }

        [Column("source")]
        public string Source { get; set; }

        [Column("html")]
        public string Html { get; set; }

        [Column("delta")]
        public string Delta { get; set; }
    }
}
