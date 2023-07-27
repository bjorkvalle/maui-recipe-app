namespace bjorkvalle.logic.Dtos
{
    public record RecipeDto
    {
        public Guid Id { get; init; }
        public string Title { get; init; }
        public string CoverImg { get; set; }
        public string Source { get; set; }
        public string Html { get; init; }
        public string Delta { get; init; }
    }
}
