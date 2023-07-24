using eCommerce.Application.Repositories;
using eCommerce.Application.Services;
using eCommerce.Application.Utilities.Results;
using eCommerce.Infrastructure.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Persistence.Services
{
    public class Service<T> : IService<T>
        where T:class
        
    {
        private readonly IBaseRepository<T> baseRepository;

        public async Task<IDataResult<T>> AddAsync(T model)
        {
            await baseRepository.AddAsync(model);
            return new SuccessDataResult<T>(model);
        }

        public async Task<IDataResult<List<T>>> AddRangeAsync(List<T> model)
        {
            await baseRepository.AddRangeAsync(model);
            return new SuccessDataResult<List<T>>(model);
        }

        public IDataResult<IQueryable<T>> GetAll()
        {
            return new SuccessDataResult<IQueryable<T>>(baseRepository.GetAll());
        }

        public async Task<IDataResult<T>> GetByIdAsync(long id)
        {
            return new SuccessDataResult<T>(await baseRepository.GetByIdAsync(id));
        }

        public async Task<IDataResult<T>> GetSingleAsync(Expression<Func<T, bool>> method)
        {
            return new SuccessDataResult<T>(await baseRepository.GetSingleAsync(method));
        }

        public IDataResult<IQueryable<T>> GetWhere(Expression<Func<T, bool>> method)
        {
            return new SuccessDataResult<IQueryable<T>>(baseRepository.GetWhere(method));
        }

        public async Task<IDataResult<T>> Remove(long id)
        {
            var entity = await baseRepository.GetByIdAsync(id);
            baseRepository.Remove(entity);
            return new SuccessDataResult<T>(entity);
        }

        public IDataResult<T> Remove(T model)
        {
            baseRepository.Remove(model);
            return new SuccessDataResult<T>(model);
        }

        public IDataResult<List<T>> RemoveRange(List<T> datas)
        {
            baseRepository.RemoveRange(datas);
            return new SuccessDataResult<List<T>>(datas);
        }

        public Task<int> SaveAsync()
        {
            throw new NotImplementedException();
        }

        public IDataResult<T> Update(T model)
        {
            baseRepository.Update(model);
            return new SuccessDataResult<T>(model);
        }
    }
}
