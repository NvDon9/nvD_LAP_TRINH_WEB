using System.Text;
using Ex04.StudentManagement.Managers;
using Ex04.StudentManagement.Services;
using Ex04.StudentManagement.Views;


Console.OutputEncoding = Encoding.UTF8;

var service = new StudentService();
var view = new StudentConsoleView(service);
var menu = new MenuManager(view);

menu.Run();
