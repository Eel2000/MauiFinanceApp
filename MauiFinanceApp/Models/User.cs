using System.ComponentModel.DataAnnotations;
using SQLite;

namespace MauiFinanceApp.Models
{
    public class User
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
