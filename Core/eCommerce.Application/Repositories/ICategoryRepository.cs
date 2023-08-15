using eCommerce.Application.Utilities.Results;
using eCommerce.Domain.DTOs.Categories;
using eCommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Application.Repositories
{
    public interface ICategoryRepository:IBaseRepositoryNoTracking<Category>
    {
        List<Category> GetAllWithProduct();
    }
}
