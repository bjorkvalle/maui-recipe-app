namespace bjorkvalle.logic.Services
{
    public interface IRecipeService
    {
        Task<List<RecipeDto>> GetAll();
        Task<RecipeDto> GetById(Guid id);
        Task<Guid> Create(RecipeDto dto);
        Task Update(RecipeDto dto);
        Task Delete(Guid recipeId);
    }

    public class RecipeService : IRecipeService
    {
        private readonly Repository<Recipe> _db;

        public RecipeService(Repository<Recipe> db)
        {
            _db = db;
        }

        public async Task<List<RecipeDto>> GetAll()
        {
            var entities = await _db.GetAllAsync();
            return entities?.Select(x => MapToDto(x)).ToList() ?? new();
        }

        public async Task<RecipeDto> GetById(Guid id)
        {
            var entity = await _db.GetByIdAsync(id);
            var dto = MapToDto(entity);
            return dto;
        }

        public async Task Delete(Guid recipeId)
        {
            await _db.DeleteAsync(recipeId);
        }

        public async Task<Guid> Create(RecipeDto dto)
        {
            var entity = MapToEntity(dto);
            entity.Id = Guid.NewGuid();
            await _db.CreateAsync(entity);
            return entity.Id;
        }

        public async Task Update(RecipeDto dto)
        {
            var entity = MapToEntity(dto);
            await _db.UpdateAsync(entity);
        }

        private RecipeDto MapToDto(Recipe entity)
        {
            return new RecipeDto
            {
                Id = entity.Id,
                Title = entity.Title,
                CoverImg = entity.CoverImg,
                CoverSrc = entity.CoverSrc,
                Source = entity.Source,
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
                CoverImg = dto.CoverImg,
                CoverSrc = dto.CoverSrc,
                Source = dto.Source,
                Html = dto.Html,
                Delta = dto.Delta,
            };
        }
    }
}
