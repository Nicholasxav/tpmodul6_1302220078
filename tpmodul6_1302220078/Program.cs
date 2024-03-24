// See https://aka.ms/new-console-template for more information
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
        this.PlayCount = count;
    }
    public void PrintVideoDetails()
    {
        Console.WriteLine("ID : " + this.id);
        Console.WriteLine("Title : " + this.title);
        Console.WriteLine("Play Count :" + this.PlayCount);
    }
}
