namespace Ates.Datas.Test;

using Ates.Datas.Test.Contexts;
using Ates.Datas.Test.Models;
using Ates.Datas.Test.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

public class UserWriteRepositoryTest : IDisposable
{
    private UserWriteRepository db = null!;

    public UserWriteRepositoryTest()
    {
        var context = new TestDbContext();
        _ = context.Database.EnsureDeleted();
        _ = context.Database.EnsureCreated();
        this.RefreshDbAndContext();
    }


    [Theory]
    [MemberData(nameof(GetUserInsertDatas))]
    public async Task Insert_User(User user)
    {
        await this.db.Insert(user);
        var resultCommit = await this.db.Commit();

        Assert.Equal(1, resultCommit);
        Assert.NotEqual(Guid.Empty, user.Id);
    }

    [Fact]
    public async Task Insert_Null()
    {
        _ = await Assert.ThrowsAsync<ArgumentNullException>(async () => await this.db.Insert(null!));

        var resultCommit = await this.db.Commit();

        Assert.Equal(0, resultCommit);
    }

    [Fact]
    public async Task Delete_User()
    {
        var user = new User()
        {
            Name = "DeleteName",
            Surname = "DeleteSurname",
            Username = "DeleteUsername",
        };

        await this.Insert_User(user);

        this.RefreshDbAndContext();

        await this.db.Delete(user);

        var resultCommit = await this.db.Commit();

        Assert.Equal(1, resultCommit);

    }

    [Fact]
    public async Task Delete_Null()
    {
        _ = await Assert.ThrowsAsync<ArgumentNullException>(async () => await this.db.Delete(null!));

        var resultCommit = await this.db.Commit();

        Assert.Equal(0, resultCommit);
    }

    [Fact]
    public async Task Update_User()
    {
        var user = new User()
        {
            Name = "UpdateName",
            Surname = "UpdateSurname",
            Username = "UpdateUsername",
        };

        await this.Insert_User(user);

        this.RefreshDbAndContext();

        var uUser = new User()
        {
            Id = new Guid(user.Id.ToString()),
            Name = "updated",
            Surname = "updated",
            Username = "updated",
        };

        await this.db.Update(uUser);

        var resultCommit = await this.db.Commit();

        Assert.Equal(1, resultCommit);
    }

    public static IEnumerable<Object[]> GetUserInsertDatas()
    {
        yield return new Object[] { new User { Name = "Name 1", Surname = "Surname 1", Username = "Username 1" } };
        yield return new Object[] { new User { Name = "Name2", Surname = "Surname2", Username = "Username2" } };
        yield return new Object[] { new User { Name = "Name3", Surname = "Surname 3", Username = "Username3" } };
    }

    private void RefreshDbAndContext()
    {
        var context = new TestDbContext();
        this.db = new(context);
    }

    public void Dispose()
    {
        var context = new TestDbContext();
        _ = context.Database.EnsureDeleted();
        _ = context.Database.EnsureCreated();
    }
}