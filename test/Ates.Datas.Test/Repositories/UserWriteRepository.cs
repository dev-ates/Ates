namespace Ates.Datas.Test.Repositories;

using Ates.Datas.EntityFrameworkCore;
using Ates.Datas.Test.Models;
using Microsoft.EntityFrameworkCore;
using System;

internal class UserWriteRepository : WriteRepository<User, Guid>
{
    public UserWriteRepository(DbContext context) : base(context)
    {
    }
}
