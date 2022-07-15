namespace AdapterPatternExample;

interface IBird
{
    public void Fly();
    public void MakeSound();
}
class Sparrow : IBird
{
    // a concrete implementation of bird
    public void Fly()
    {
        Console.WriteLine(" Sparrow is Flying");
    }
    public void MakeSound()
    {
        Console.WriteLine("Sparrow Chirp Chirp");
    }
}
class Parrot : IBird
{
    // a concrete implementation of bird
    public void Fly()
    {
        Console.WriteLine("Parrot is Flying");
    }
    public void MakeSound()
    {
        Console.WriteLine("Parrot Chirp Chirp");
    }
}

interface IToyDuck
{
    // target interface,toyducks dont fly they just make squeaking sound
    public void Squeak();
}
class PlasticToyDuck : IToyDuck
{
    public void Squeak()
    {
        Console.WriteLine("PlasticToyDuck Squeak");
    }
}
class BirdAdapter : IToyDuck
{
    public IBird bird;
    public BirdAdapter(IBird bird)
    {
        this.bird = bird;
    }
    public void Squeak()
    {
        bird.MakeSound();
    }
}

class Program
{
    static void Main(string[] args)
    {
        var sparrow = new Sparrow();
        var parrot = new Parrot();
        var toyDuck = new PlasticToyDuck();
        var birdAdapter1 = new BirdAdapter(sparrow);
        var birdAdapter2 = new BirdAdapter(parrot);
        Console.WriteLine("Sparrow...");
        sparrow.Fly();
        sparrow.MakeSound();
        Console.WriteLine("Parrot...");
        parrot.Fly();
        parrot.MakeSound();
        Console.WriteLine("ToyDuck...");
        toyDuck.Squeak();
        Console.WriteLine("BirdAdapter...");
        birdAdapter1.Squeak();
        birdAdapter2.Squeak();
    }

}