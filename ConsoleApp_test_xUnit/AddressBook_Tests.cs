using ConsoleApp.Models;
using ConsoleApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_test_xUnit
{
    public class AddressBook_Tests
    {
        private MenuService menuService;
        Contact contact;

        public AddressBook_Tests()
        {
            // arrange
            menuService = new MenuService();
            contact = new Contact();
        }

        [Fact]
        public void Should_Add_Contact_To_List()
        {
            menuService.contacts.Add(contact);
            menuService.contacts.Add(contact);

            // assert
            Assert.Equal(2, menuService.contacts.Count);

        }


        [Fact]
        public void Should_Remove_Contact_From_List()
        {
            // arrange 
            menuService.contacts.Add(contact);
            menuService.contacts.Add(contact);

            // act
            menuService.contacts.Remove(contact);

            // assert
            Assert.Single(menuService.contacts);
        }
    }
}
