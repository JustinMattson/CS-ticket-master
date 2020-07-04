using System;
using System.Collections.Generic;

namespace ticketMaster.Models
{
  public class Handler
  {
    public List<Ticket> Tickets { get; set; }

    public void ViewTickets()
    {
      var colorOriginal = ConsoleColor.White;
      Console.ForegroundColor = ConsoleColor.Blue;
      Console.WriteLine("...reports in Blue are marked completed.");
      Console.ForegroundColor = colorOriginal;
      Console.WriteLine("\n Number          Title");
      Console.WriteLine(" --------------------------------");
      int ticketCount = 1;

      List<Ticket> tickets = Tickets;
      foreach (var ticket in tickets)
      {
        if (ticket.Completed)
        {
          Console.ForegroundColor = ConsoleColor.Blue;
          // ticketCount--;
        }
        if (!ticket.Completed)
        {
          Console.ForegroundColor = colorOriginal;
          Console.WriteLine($"Ticket: {ticketCount} - {ticket.Title}");
        }
        else
        {
          Console.WriteLine($"Ticket: {ticketCount} - {ticket.Title}");
        }
        ticketCount++;
        Console.ForegroundColor = ConsoleColor.White;
      }
    }
    public void TicketDetails()
    {
      Console.Clear();
      ViewTickets();
      Console.WriteLine("\nWhich ticket would you like to view?");
      // Throws error if trying to convert a string to an int
      int choice = 0;
      Int32.TryParse(Console.ReadLine(), out choice);
      while (choice < 1 || choice > Tickets.Count)
      {
        Console.WriteLine("Please enter a valid ticket number");
        Int32.TryParse(Console.ReadLine(), out choice);
      }
      List<Ticket> tickets = Tickets;
      Ticket detail = tickets[choice - 1];
      Console.Clear();
      Console.WriteLine($"You entered {choice}");
      Console.ForegroundColor = ConsoleColor.Green;
      Console.WriteLine($"\nTitle:       {detail.Title}");
      Console.WriteLine($"Description: {detail.Description}");
      Console.WriteLine($"Completed:   {detail.Completed}");
      Console.ForegroundColor = ConsoleColor.White;
      Console.WriteLine("\nToggle completed status? [Y/N]");
      Console.WriteLine("  Select [d] to delete or [q] to exit");
      string update = Console.ReadLine().ToUpper();
      switch (update)
      {
        case "YES":
        case "Y":
          detail.Completed = !detail.Completed;
          TicketDetails();
          break;
        case "NO":
        case "N":
          Console.WriteLine("Completed status unchanged.");
          TicketDetails();
          break;
        case "DELETE":
        case "D":
          DeleteTicket();
          break;
        case "Q":
          Console.Clear();
          break;
        default:
          Console.WriteLine("Invalid input, try again [Y/N]:");
          break;
      }
    }

    public void CreateTicket()
    {
      Console.WriteLine("\nEnter Ticket Title:");
      string title = Console.ReadLine();
      Console.WriteLine("\nEnter Ticket Description:");
      string description = Console.ReadLine();

      Ticket newTicket = new Ticket(title, description, false);
      Tickets.Add(newTicket);
    }

    public void DeleteTicket()
    {
      List<Ticket> tickets = Tickets;
      Console.Clear();
      ViewTickets();
      Console.WriteLine("\nWhich ticket would you like to delete?");
      int choice = 0;
      Int32.TryParse(Console.ReadLine(), out choice);
      while (choice < 1 || choice > Tickets.Count)
      {
        Console.WriteLine("Please enter a valid ticket number");
        Int32.TryParse(Console.ReadLine(), out choice);
      }
      Console.ForegroundColor = ConsoleColor.Red;
      Console.WriteLine("Are you sure you want to delete this ticket? This cannot be undone. [Y/N]");
      Console.ForegroundColor = ConsoleColor.White;
      string answer = Console.ReadLine().ToUpper();
      if (answer == "Y")
      {
        Tickets.RemoveAt(choice - 1);
      }
      else
      {
        Console.WriteLine("Delete Aborted!");
      }
    }
    public Handler()
    {
      Tickets = new List<Ticket>();
    }
  }
}