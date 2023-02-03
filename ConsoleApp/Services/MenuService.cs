using ConsoleApp.Interfaces;
using ConsoleApp.Models;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ConsoleApp.Services;
internal class MenuService
{
    private List<IContact> contacts = new List<IContact>();
    //private List<IBaseEmployee> employees = new List<IBaseEmployee>();
    private FileService file = new FileService();

    public string FilePath { get; set; } = null!;

    public void WelcomeMenu()
    {

        //try
        //{
        //    contacts = JsonConvert.DeserializedObject<List<IContact>>(file.Read(FilePath))!;
        //}
        //catch
        //{

        //}

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
        file.Save(FilePath, JsonConvert.SerializeObject(new { contact }));

        Console.WriteLine("");
        Console.WriteLine("Press any key to return to the home page.");
        Console.ReadKey();
    }
    private void OptionTwo()
    {
        Console.Clear();
        Console.WriteLine("Delete contact");

        Contact contact = new Contact();

        Console.Clear();
        Console.WriteLine("Show all contacts");
        Console.WriteLine();

        contacts!.ForEach(contact => Console.WriteLine("Name: " + contact.FirstName + "" + contact.LastName + "" + "Email: " + contact.Email));

        contacts.Remove(contact);
        file.Save(FilePath, JsonConvert.SerializeObject(new { contact }));

        Console.WriteLine("");
        Console.WriteLine("Press any key to return to the home page.");
        Console.ReadKey();
    }
    private void OptionThree()
    {
        Console.Clear();
        Console.WriteLine("Show contact");
        Console.WriteLine();

        contacts!.ForEach(contact => Console.WriteLine("Name: " + contact.FirstName + "" + contact.LastName + "" + "Email: " + contact.Email));

        Console.WriteLine("");
        Console.WriteLine("Press any key to return to the home page.");
        Console.ReadKey();
    }
    private void OptionFour()
    {
        Console.Clear();
        Console.WriteLine("Show all contacts");
        Console.WriteLine();

        contacts!.ForEach(contact => Console.WriteLine("Name: " + contact.FirstName + "" + contact.LastName + "" + "Email: " + contact.Email));

        Console.WriteLine("");
        Console.WriteLine("Press any key to return to the home page.");
        Console.ReadKey();
    }
}