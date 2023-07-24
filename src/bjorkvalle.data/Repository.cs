//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace bjorkvalle.logic
//{
//    public interface IRepository<T> where T : class
//    {
//        IQueryable<T> GetAll();
//        Task<T> GetByIdAsync(int id);
//        Task<T> CreateAsync(T entity);
//        Task<IEnumerable<T>> CreateBatchAsync(IEnumerable<T> entities);
//        Task<T> UpdateAsync(T oldEntity, T newEntity);
//        Task<T> DeleteAsync(int id);
//        Task<IEnumerable<T>> DeleteBatchAsync(IEnumerable<T> entities);
//    }

//    public class Repository<T> : IRepository<T> where T : class
//    {
//        private readonly DatabaseHandler _db;
//        //private readonly DbSet<T> _entities;

//        //public Repository(SDPSContext context)
//        //{
//        //    _context = context;
//        //    _entities = context.Set<T>();
//        //}

//        public IQueryable<T> GetAll()
//        {
//            return _entities;
//        }

//        public async Task<T> GetByIdAsync(int id)
//        {
//            var entity = await _entities.FindAsync(id);
//            return entity;
//        }

//        public async Task<T> CreateAsync(T entity)
//        {
//            if (entity == null)
//                throw new ArgumentNullException("entity");

//            await _entities.AddAsync(entity);
//            await _context.SaveChangesAsync();

//            return entity;
//        }

//        public async Task<IEnumerable<T>> CreateBatchAsync(IEnumerable<T> entities)
//        {
//            if (entities == null)
//                throw new ArgumentNullException("entity");

//            await _entities.AddRangeAsync(entities);
//            await _context.SaveChangesAsync();

//            return _entities;
//        }

//        public async Task<T> UpdateAsync(T oldEntity, T newEntity)
//        {
//            if (oldEntity == null || newEntity == null)
//                throw new ArgumentNullException("entity");

//            _context.Entry(oldEntity).CurrentValues.SetValues(newEntity);
//            await _context.SaveChangesAsync();

//            return oldEntity;
//        }

//        public async Task<T> DeleteAsync(int id)
//        {
//            var entity = await _entities.FindAsync(id);

//            if (entity == null)
//                throw new ArgumentNullException("entity");

//            _entities.Remove(entity);
//            await _context.SaveChangesAsync();

//            return entity;
//        }

//        public async Task<IEnumerable<T>> DeleteBatchAsync(IEnumerable<T> entities)
//        {
//            if (entities == null)
//                throw new ArgumentNullException("entity");

//            _entities.RemoveRange(entities);
//            await _context.SaveChangesAsync();

//            return entities;
//        }
//    }
//}
