using System;

namespace ticketMaster
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.Clear();
      App app = new App();
      app.Setup();
      app.Run();
      Console.Clear();
      Console.WriteLine("Thanks for using Bug Tracker C# Edition!");
    }
  }
}
