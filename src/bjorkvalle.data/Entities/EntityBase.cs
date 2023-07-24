using SQLite;

namespace bjorkvalle.data.Entities
{
    public record EntityBase
    {
        [PrimaryKey, Column("_id")]
        public Guid Id { get; set; }
    }
}
