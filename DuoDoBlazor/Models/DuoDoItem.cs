namespace DuoDoBlazor.Models;

public class DuoDoItem
{
    public string Task { get; set; }
    public bool IsDone { get; set; } = false;
    public DateTime CreatedAt { get; set; }
    public DateTime? DueDate { get; set; }

    public DuoDoItem()
    {
        CreatedAt = DateTime.Now;
    }
}
