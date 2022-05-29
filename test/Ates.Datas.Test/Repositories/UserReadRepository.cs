namespace Ates.Datas.Test.Repositories;

using Ates.Datas.EntityFrameworkCore;
using Ates.Datas.Test.Models;
using Microsoft.EntityFrameworkCore;

internal class UserReadRepository : ReadRepository<User>
{
    public UserReadRepository(DbContext context) : base(context)
    {
    }
}
