using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public List<Project> Valuations { get; set; }

        public Client() { }

        public Client(string _name)
        {
            Name = _name;
        }

        internal bool Exists()
        {
            Client _existingClient = DatabaseHelper.GetClientByName(Name);
            if (_existingClient != null)
            {
                Id = _existingClient.Id;
                return true;
            }
            return false;
        }
    }
}
