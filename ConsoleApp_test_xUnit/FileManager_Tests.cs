using ConsoleApp.Services;
using Newtonsoft.Json;
using NuGet.Frameworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_test_xUnit
{
    public class FileManager_Tests
    {
        FileService fileService;
        MenuService menuService;

        string content;

        public FileManager_Tests()
        {
            // arrange
            fileService = new FileService();
            menuService = new MenuService();
            menuService.FilePath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\content.json";
            content = JsonConvert.SerializeObject(new { FirstName = "Anna", LastName = "Sateri" });
        }

        [Fact]
        public void Should_Create_a_File_With_Json_Content()
        {
            // act
            fileService.Save(menuService.FilePath, content);
            string result = fileService.Read(menuService.FilePath);

            // assert
            Assert.True(File.Exists(menuService.FilePath));
            Assert.Equal(result.Trim(), content);
        }
    }
}
