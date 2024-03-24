// See https://aka.ms/new-console-template for more information
using System.Diagnostics.Contracts;
using System.Security.Cryptography;

class Program
{
    private static void Main(string[] args)
    {
        SayaTubeVideo video = new SayaTubeVideo("Tutorial Design by Contract - Nicholas Xavier");
        for (int i = 0; i < 10000000; i++)
        {
            video.IncreasePLayCount(1);
        }
        video.PrintVideoDetails();
    }
}
class SayaTubeVideo
{
    private int id;
    private string title;
    private int PlayCount;

    public SayaTubeVideo(string title)
    {
        Contract.Requires(title != null && title.Length <= 100, "Judul video memiliki panjang maksimal 100 karakter dan tidak berupa null");
        this.id = RandomNumber();
        this.title = title;
        this.PlayCount = 0;
    }

    private int RandomNumber()
    {
        Random random = new Random();
        return random.Next(00000, 99999);
    }

    public void IncreasePLayCount (int count)
    {
        Contract.Requires(count > 0 && count <= 10000000, "Input penambahan Play Count 10000000");
        Contract.Requires(PlayCount <= int.MaxValue - count, "Play Count melebihi jumlah");
        try
        {
            checked
            {
                PlayCount += count;
            }
        }
        catch (OverflowException)
        {
            Console.WriteLine("Penambahan play count melebihi batas");
        }
    }
    public void PrintVideoDetails()
    {
        Console.WriteLine("ID : " + this.id);
        Console.WriteLine("Title : " + this.title);
        Console.WriteLine("Play Count :" + this.PlayCount);
    }
}
