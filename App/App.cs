using System;
using ticketMaster.Models;

namespace ticketMaster
{
  public class App
  {
    private Handler Handler { get; set; }
    public bool TMRunning { get; set; }

    public void Setup()
    {
      // Comparing to console_library, I will not have anything to setup prior to running.
      Ticket TestTicket1 = new Ticket("Test Ticket Title", "Test Ticket Description", false);
      Ticket TestTicket2 = new Ticket("Test Title", "Test Description", true);

      Handler.Tickets.Add(TestTicket1);
      Handler.Tickets.Add(TestTicket2);
    }
    public void Run()
    {
      // Start the application and initialize the program looping
      Console.WriteLine("Welcome to Bug Tracker C#!");

      while (TMRunning)
      {
        DisplayMainMenu();
      }
    }

    public void DisplayMainMenu()
    {
      Handler.ViewTickets();
      Console.WriteLine("\nWhat would you like to do? (View / New / Delete / Quit)");
      ProcessInput();
    }

    public void ProcessInput()
    {
      string choice = Console.ReadLine().ToUpper();
      switch (choice)
      {
        case "VIEW":
        case "V":
          Handler.TicketDetails();
          break;
        case "NEW":
        case "N":
          Handler.CreateTicket();
          break;
        case "DELETE":
        case "D":
          Handler.DeleteTicket();
          break;
        case "QUIT":
        case "EXIT":
        case "Q":
          TMRunning = false;
          break;
        default:
          Console.WriteLine("Please enter view[V], new[N], delete[D], or quit[Q]");
          ProcessInput();
          break;
      }
    }
    public App()
    {
      Handler = new Handler();
      TMRunning = true;
    }
  }
}