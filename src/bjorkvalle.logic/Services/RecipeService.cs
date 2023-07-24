namespace bjorkvalle.logic.Services
{
    public interface IRecipeService
    {
        Task<List<RecipeDto>> GetAllAsync();
    }

    public class RecipeService : IRecipeService
    {
        private readonly DatabaseHandler<Recipe> _db;

        public RecipeService(DatabaseHandler<Recipe> db)
        {
            _db = db;
        }

        public async Task<List<RecipeDto>> GetAllAsync()
        {
            var entities = await _db.GetAllAsync();
            var dtos = entities?.Select(x => MapToDto(x)).ToList() ?? new();

            return dtos;
        }

        public RecipeDto MapToDto(Recipe entity)
        {
            return new RecipeDto
            {
                Title = entity.Title,
                Html = entity.Html,
                Delta = entity.Delta,
            };
        }

        public Recipe MapToEntity(RecipeDto dto)
        {
            return new Recipe
            {
                Title = dto.Title,
                Html = dto.Html,
                Delta = dto.Delta,
            };
        }
    }
}
