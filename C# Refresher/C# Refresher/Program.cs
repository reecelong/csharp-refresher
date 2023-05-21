
internal class Program
{
    private static void Main(string[] args)
    {
        //Collections 
        //Types of Collections:
        // Dictionary<TKey,TValue>
        // List<T>
        // Queue<T>
        // SortedList<TKey,TValue>
        // Stack<T>
        var potatoes1 = new List<string>();
        potatoes1.Add("russet");
        potatoes1.Add("yukon_gold");
        potatoes1.Add("red");
        potatoes1.Add("white");
        potatoes1.Add("fingerling");

        foreach (var potato in potatoes1)
        {
            Console.Write(potato + " ");
        }
        Console.WriteLine();

        var potatoes2 = new List<string> { "russet", "yukon_gold", "red", "white", "fingerling" };
        potatoes2.Remove("yukon_gold");

        for (var i = 0; i < potatoes2.Count; i++)
        {
            Console.Write(potatoes2[i] + " ");
        }
        Console.WriteLine();




        //Assignment compatibility
        string str = "potato";
        object obj = str;




        //Covariance
        // An object that is instantiated with a more derived type argument
        // is assigned to an object instantiated with a less derived type argument.
        // Assignment compatibility is preserved.
        IEnumerable<string> strings = new List<string>();
        IEnumerable<object> objects = strings;




        //Contravariance
        // An object that is instantiated with a less derived type argument
        // is assigned to an object instantiated with a more derived type argument.
        // Assignment compatibility is reversed.
        static void SetObject(object o) { }
        Action<object> actObject = SetObject;
        Action<string> actString = actObject;




        //LINQ (Language-Integrated Query)
        // Data source
        string[] potatoCollection = { "russet", "yukon_gold", "red", "white", "fingerling" };

        // Query creation
        IEnumerable<string> potatoQuery =
            from potato in potatoCollection
            where potato != "russet"
            select potato;

        // Query execution (deferred)
        foreach (string p in potatoQuery)
        {
            Console.Write(p + " ");
        }
        Console.WriteLine();

        // Query execution (immediate - aggregate)
        int potatoCount = potatoQuery.Count();
        Console.Write(potatoCount + " ");
        Console.WriteLine();

        // Query execution (immediate - query)
        List<string> potatoQuery2 =
            (from potato in potatoCollection
             where potato != "red"
             select potato).ToList();

        foreach (string p in potatoQuery2)
        {
            Console.Write(p + " ");
        }
        Console.WriteLine();




        //Polymorphism
        PotatoClass potatoClass = new PotatoClass();
        potatoClass.Bake();
        potatoClass.Mash();
        potatoClass.Eat();
    
        PotatoClass derivedPotatoClass = new DerivedPotatoClass();
        derivedPotatoClass.Bake();
        derivedPotatoClass.Mash();
        derivedPotatoClass.Eat();
    }
}




//Polymorphism
class PotatoClass
{
    public virtual void Bake() 
    {
        Console.Write("Bake it!");
        Console.WriteLine();
    }
    public virtual void Mash() 
    {
        Console.Write("Mash it!");
        Console.WriteLine();
    }
    public virtual void Eat() 
    {
        Console.Write("Mmmmmm!");
        Console.WriteLine();
    }
}

class DerivedPotatoClass : PotatoClass
{
    public override void Eat() 
    {
        Console.Write("Delicious!");
        Console.WriteLine();
    }
}