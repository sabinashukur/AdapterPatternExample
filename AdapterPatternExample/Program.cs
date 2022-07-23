namespace AdapterPatternExample;

interface IBird
{
    public void Fly();
    public void MakeSound();
}
class Sparrow : IBird
{
    // this a concrete implementation of bird
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
    // this is a concrete implementation of bird
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
    // our target interface, toyducks don't fly they just make squeaking sound
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
    // We need to implement the interface our client expects to use.
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
       
        Console.WriteLine("Sparrow...");
        sparrow.Fly();
        sparrow.MakeSound();
        Console.WriteLine("Parrot...");
        parrot.Fly();
        parrot.MakeSound();
        IToyDuck toyDuck = new PlasticToyDuck();
        // We wrap a bird in a birdAdapter so that it behaves like toy duck
        IToyDuck birdAdapter1 = new BirdAdapter(sparrow);
        IToyDuck birdAdapter2 = new BirdAdapter(parrot);
        Console.WriteLine("ToyDuck...");
        toyDuck.Squeak();
        Console.WriteLine("BirdAdapter...");
        // Here toy duck is behaving like a bird 
        birdAdapter1.Squeak();
        birdAdapter2.Squeak();
    }

}