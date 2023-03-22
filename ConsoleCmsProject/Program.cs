using ConsoleCmsProject.Services;

var main = new MenuService();

while (true)
{
    Console.Clear();
    Console.WriteLine("Errand management");
    Console.WriteLine("");
    Console.WriteLine("1. Create new errand");
    Console.WriteLine("2. Show all errands");
    Console.WriteLine("3. Show one specific errand");
    Console.WriteLine("4. Comment/change status on a specific errand");
    Console.WriteLine("5. Update customer information on an errand");
    Console.WriteLine("6. Delete an errand");
    Console.WriteLine("");
    Console.Write("Choose an option: ");

    switch (Console.ReadLine())
    {
        case "1":
            Console.Clear();
            await main.CreateNewErrandAsync();
            break;

        case "2":
            Console.Clear();
            await main.ListAllErrandsAsync();
            break;

        case "3":
            Console.Clear();
            await main.ListSpecficErrandAsync();
            break;

        case "4":
            Console.Clear();
            await main.CommentSpecficErrandAsync();
            break;

        case "5":
            Console.Clear();
            await main.UpdateSpecficErrandAsync();
            break;

        case "6":
            Console.Clear();
            await main.DeleteSpecficErrandAsync();
            break;
    }

    Console.WriteLine("\nPress any key to continue.");
    Console.ReadKey();
}