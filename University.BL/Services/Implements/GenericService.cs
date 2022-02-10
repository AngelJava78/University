using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.BL.Repositories;

namespace University.BL.Services.Implements
{
    public class GenericService<TEntity> : IGenericService<TEntity> where TEntity : class
    {
        public readonly IGenericRepository<TEntity> repository;
        public GenericService(IGenericRepository<TEntity> repository)
        {
            this.repository = repository;
        }
        public async Task Delete(int id)
        {
            await repository.Delete(id);
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await repository.GetAll();
        }

        public async Task<TEntity> GetById(int id)
        {
            return await repository.GetById(id);
        }

        public async Task<TEntity> Insert(TEntity entity)
        {
            return await  repository.Insert(entity);
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            return await repository.Update(entity);
        }
    }
}
