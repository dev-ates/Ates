namespace Ates.Datas.Test.Models;

using System;

public class User : IEntity<Guid>
{
    public Guid Id
    {
        get; set;
    }

    public String Username
    {
        get; set;
    } = null!;

    public String Name
    {
        get; set;
    } = null!;

    public String Surname
    {
        get; set;
    } = null!;
}
