namespace Ates.Datas.Test.Repositories;

using Ates.Datas.Test.Models;
using Microsoft.EntityFrameworkCore;

internal class UserWriteRepository : WriteRepository<User>
{
    public UserWriteRepository(DbContext context) : base(context)
    {
    }
}
