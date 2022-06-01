namespace Ates.Datas.Test.Repositories;

using Ates.Datas.EntityFrameworkCore;
using Ates.Datas.Test.Models;
using Microsoft.EntityFrameworkCore;
using System;

internal class UserReadRepository : ReadRepository<User, Guid>
{
    public UserReadRepository(DbContext context) : base(context)
    {
    }
}
