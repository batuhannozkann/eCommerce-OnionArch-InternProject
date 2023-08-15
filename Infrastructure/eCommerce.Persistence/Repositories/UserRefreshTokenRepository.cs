using eCommerce.Application.Repositories;
using eCommerce.Domain.Identity;
using eCommerce.Persistence.Contexts;
using eCommerce.Persistence.Repositories.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Persistence.Repositories
{
    public class UserRefreshTokenRepository : BaseRepository<UserRefreshToken>, IUserRefreshTokenRepository
    {
        public UserRefreshTokenRepository(eCommerceDbContext context) : base(context)
        {
        }
    }
}
