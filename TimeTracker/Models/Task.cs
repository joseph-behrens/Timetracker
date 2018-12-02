using System;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace TimeTracker
{
    [Table("Task")]
    public class Task
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [ForeignKey(typeof(Project))]
        public int ProjectId { get; set; }
        public string Notes { get; set; }
        public string TimeSpent { get; set; }
        public string DateOfEntry { get; set; } = DateTime.Now.ToString("yyyy/MM/dd hh:mm tt");

        [ManyToOne]
        public Project Project { get; set; }

        public Task()
        {

        }

        public Task (int _projectId, string _notes, string _timeSpent)
        {
            ProjectId = _projectId;
            Notes = _notes;
            TimeSpent = _timeSpent;
        }

        public Task(int _projectId, string _notes, string _timeSpent, string _dateOfEntry)
        {
            ProjectId = _projectId;
            Notes = _notes;
            TimeSpent = _timeSpent;
            DateOfEntry = _dateOfEntry;
        }
    }
}
