namespace ticketMaster.Models
{
  public class Ticket
  {
    public string Title { get; set; }
    public string Description { get; set; }
    public bool Completed { get; set; }

    public Ticket(string title, string description, bool completed = false)
    {
      Title = title;
      Description = description;
      Completed = completed;
    }
  }
}