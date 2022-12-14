using MauiFinanceApp.Enums;
using SQLite;

namespace MauiFinanceApp.Models;

public class Operation
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public OperationType OperationType { get; set; }
    public decimal Amount { get; set; }
    public int CardId { get; set; }
    public DateTimeOffset OperationDate { get; set; }
    public string beneficiary { get; set; }
    public bool IsDeleted { get; set; }
}

