using ConsoleApp.Models;
using Newtonsoft.Json;

namespace ConsoleApp.Services;
public class MenuService
{
    public List<Contact> contacts = new List<Contact>();
    public FileService file = new FileService();
    public string FilePath { get; set; } = null!;

    public void WelcomeMenu()
    {

        try
        {
            var json = JsonConvert.DeserializeObject<Dictionary<string, List<Contact>>>(file.Read(FilePath))!;
            contacts = json["contacts"];
        }
        catch
        {

        }

        Console.Clear();
        Console.WriteLine("Address book");
        Console.WriteLine("1. Create new contact");
        Console.WriteLine("2. Delete contact");
        Console.WriteLine("3. Show contact");
        Console.WriteLine("4. Show all contacts");
        Console.Write("Please select one of the options above:");
        var option = Console.ReadLine();

        switch(option)
        {
            case "1": OptionOne(); break;
            case "2": OptionTwo(); break;
            case "3": OptionThree(); break;
            case "4": OptionFour(); break;
        }
    }

    private void OptionOne()
    {
        Console.Clear();
        Console.WriteLine("Create new contact");

        Contact contact = new Contact();

        Console.Write("Enter firstname: ");
        contact.FirstName = Console.ReadLine() ?? "";
        Console.Write("Enter lastname: ");
        contact.LastName = Console.ReadLine() ?? "";
        Console.Write("Enter email: ");
        contact.Email = Console.ReadLine() ?? "";
        Console.Write("Enter phonenumber: ");
        contact.PhoneNumber = Console.ReadLine() ?? "";
        Console.Write("Enter address: ");
        contact.Address = Console.ReadLine() ?? "";

        contacts.Add(contact);
        file.Save(FilePath, JsonConvert.SerializeObject(new { contacts }));

        Console.WriteLine("");
        Console.WriteLine("Press any key to return to the home page.");
        Console.ReadKey();
    }
    private void OptionTwo()
    {
        Console.Clear();
        Console.WriteLine("Delete contact");
        Console.Write("Enter the name of the contact you want to delete: ");

        var name = Console.ReadLine();
        //var answer = Console.ReadLine();
        var response = contacts.Find(contact => contact.FirstName == name);

        while (response == null)
        {
            Console.Clear();
            Console.Write("There is no contact with that name in you address book. \nPlease try again: ");
            name = Console.ReadLine();
            response = contacts.Find(x => x.FirstName == name);
        }
        Console.Clear();
        Console.WriteLine("Are you sure you want to delete " + response.FirstName + " from your address book?");
        Console.Write("Enter y for yes if you're sure and n for no: ");
        var answer = Console.ReadLine();
        while (answer != "y" && answer != "n")
        {
            Console.Clear();
            Console.WriteLine("You can only enter y or n. Please try again.");
            Console.Write("Enter y for yes if you're sure and n for no: ");
            answer = Console.ReadLine();
        }
        if (answer == "y")
        {
            Console.Clear();
            contacts.RemoveAll(contact => contact.FirstName! == response.FirstName);
            file.Save(FilePath, JsonConvert.SerializeObject(new { contacts }));
            Console.WriteLine(response.FirstName + " has been deleted.");
            Console.WriteLine("Press any key to return to the home page.");
            Console.ReadKey();
        }
        else if (answer == "n")
        {
            WelcomeMenu();
        }

    }
    private void OptionThree()
    {
        Console.Clear();
        Console.WriteLine("Show a contact");
        Console.WriteLine();
        Console.Write("Enter the name of the contact you're looking for: ");

        var name = Console.ReadLine();
        if (name != null)
        {
            var response = contacts.Find(contact => contact.FirstName == name);

            while (response == null)
            {
                Console.Clear();
                Console.Write("There is no contact with that name in you address book. \nPlease try again: ");
                name = Console.ReadLine();
                response = contacts.Find(x => x.FirstName == name);
            }
            Console.Clear();
            Console.WriteLine("First name: " + response.FirstName! +
                  "\nLast name: " + response.LastName +
                  "\nEmail: " + response.Email +
                  "\nPhone number: " + response.PhoneNumber +
                  "\nAddress: " + response.Address
                );
            Console.WriteLine("");
            Console.WriteLine("Press any key to return to the home page.");
            Console.ReadKey();

        }
    }
    private void OptionFour()
    {
        Console.Clear();
        Console.WriteLine("Show all contacts");
        Console.WriteLine();

        contacts!.ForEach(contact => Console.WriteLine("Name: " + contact.FirstName + " " + contact.LastName + "  " + "Email: " + contact.Email + "\n"));

        Console.WriteLine("");
        Console.WriteLine("Press any key to return to the home page.");
        Console.ReadKey();
    }
}