using SQLite;
using SQLiteNetExtensions.Attributes;
using TimeTracker.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTracker
{
    [Table("Project")]
    public class Project
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [ForeignKey(typeof(Client))]
        public int ClientId { get; set; }
        public string Name { get; set; }
        
        [ManyToOne]
        public Client Client { get; set; }


        public Project() { }

        public Project(string _name, int _clientId)
        {
            Name = _name;
            ClientId = _clientId;
        }

        internal bool Exists()
        {
            Project _existingProject = DatabaseHelper.GetProjectByName(Name);
            if (_existingProject != null && _existingProject.ClientId == ClientId)
            {
                return true;
            }
            return false;
        }
    }
}
