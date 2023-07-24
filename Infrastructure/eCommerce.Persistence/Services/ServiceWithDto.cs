using AutoMapper;
using eCommerce.Application.Repositories;
using eCommerce.Application.Services;
using eCommerce.Application.Utilities.Results;
using eCommerce.Domain.DTOs.Common;
using eCommerce.Domain.Entities;
using eCommerce.Domain.Entities.Common;
using eCommerce.Infrastructure.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Persistence.Services
{
    public class ServiceWithDto<Dto, T> : IServiceWithDto<Dto, T>
        where T:BaseEntity where Dto:BaseDto
    {
        private IMapper mapper;
        private IBaseRepository<T> baseRepository;

        public ServiceWithDto(IMapper mapper, IBaseRepository<T> baseRepository)
        {
            this.mapper = mapper;
            this.baseRepository = baseRepository;
        }

        public async Task<IDataResult<Dto>> AddAsync(Dto model)
        {
            T entity = mapper.Map<T>(model);
            await baseRepository.AddAsync(entity);
            return new SuccessDataResult<Dto>(model);
        }

        public Task<IDataResult<List<Dto>>> AddRangeAsync(List<Dto> model)
        {
            throw new NotImplementedException();
        }

        public IDataResult<IQueryable<Dto>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<Dto>> GetByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<Dto>> GetSingleAsync(Expression<Func<Dto, bool>> method)
        {
            throw new NotImplementedException();
        }

        public IDataResult<IQueryable<Dto>> GetWhere(Expression<Func<Dto, bool>> method)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<Dto>> Remove(long id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<Dto> Remove(Dto model)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Dto>> RemoveRange(List<int> ids)
        {
            throw new NotImplementedException();
        }

        public IDataResult<Dto> Update(Dto model)
        {
            throw new NotImplementedException();
        }
    }
}
