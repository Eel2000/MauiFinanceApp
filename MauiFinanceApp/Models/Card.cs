using SQLite;

namespace MauiFinanceApp.Models;

public class Card
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public decimal Amount { get; set; }
    public bool IsActive { get; set; }
    public DateTimeOffset ExpiryDate { get; set; } = DateTimeOffset.Now.AddYears(5);
    public bool IsSelected { get; set; }=false;
    public  string Number { get; set; }
    public  string Name { get; set; }
}

