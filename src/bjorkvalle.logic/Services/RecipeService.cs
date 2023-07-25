namespace bjorkvalle.logic.Services
{
    public interface IRecipeService
    {
        Task<List<RecipeDto>> GetAllAsync();
        Task Delete(Guid recipeId);
        Task Create(RecipeDto dto);
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

        public async Task Delete(Guid recipeId)
        {
            await _db.DeleteAsync(recipeId);
        }

        public async Task Create(RecipeDto dto)
        {
            var entity = MapToEntity(dto);
            entity.Id = Guid.NewGuid();

            await _db.CreateAsync(entity);
        }

        private RecipeDto MapToDto(Recipe entity)
        {
            return new RecipeDto
            {
                Id = entity.Id,
                Title = entity.Title,
                Html = entity.Html,
                Delta = entity.Delta,
            };
        }

        private Recipe MapToEntity(RecipeDto dto)
        {
            return new Recipe
            {
                Id = dto.Id,
                Title = dto.Title,
                Html = dto.Html,
                Delta = dto.Delta,
            };
        }
    }
}
