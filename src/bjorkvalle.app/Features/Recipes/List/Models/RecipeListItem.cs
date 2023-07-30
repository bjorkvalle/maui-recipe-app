namespace bjorkvalle.app.Features.Recipes
{
    public record RecipeListItem
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string CoverImg { get; set; }
        //public Dictionary<Guid, string> Tags { get; set; }
        //public byte[] Thumbnail { get; set; }
    }
}
