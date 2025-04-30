namespace DUODO.Models;
using SQLite;
using System.ComponentModel.DataAnnotations;

public class DuoDoItem
{
    [PrimaryKey, AutoIncrement]
    public int ID { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public bool IsCompleted { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? DueDate { get; set; }
    public string Priority { get; set; } // e.g., "High", "Medium", "Low"

}
