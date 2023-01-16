using SQLite;

namespace MauiFinanceApp.Models;

public class Budget
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTimeOffset End { get; set; }
    public DateTimeOffset Start { get; set; }
    public bool HasReachLimit { get; set; }
    public bool IsActive { get; set; }
    public decimal DedicatedAmount { get; set; }
    public int CardId { get; set; }
}

