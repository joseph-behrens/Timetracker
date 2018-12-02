using SQLite;
using SQLiteNetExtensions.Attributes;
using System.Collections.Generic;
using TimeTracker.Controllers;
using TimeTracker.Data;

namespace TimeTracker
{
    [Table("Client")]
    public class Client
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(64)]
        public string Name { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<Project> Projects { get; set; }


        public Client() { }

        public Client(string _name)
        {
            Name = _name;
        }

        public bool Exists()
        {
            Client _existingClient = ClientController.GetClientByName(Name);
            if (_existingClient != null)
            {
                Id = _existingClient.Id;
                return true;
            }
            return false;
        }
    }
}
