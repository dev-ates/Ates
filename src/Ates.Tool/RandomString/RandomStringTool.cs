namespace Ates.Tool.RandomString;
public class RandomStringTool : IRandomStringTool
{
    private readonly Random random = new(DateTime.Now.Millisecond);

    public String RandomString(Int32 length)
    {
        if (length < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(length));
        }

        const String chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        return new String(Enumerable.Repeat(chars, length)
            .Select(s => s[this.random.Next(s.Length)]).ToArray());
    }
}
