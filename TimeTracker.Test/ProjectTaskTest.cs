using Microsoft.VisualStudio.TestTools.UnitTesting;
using TimeTracker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTracker.Tests
{
    [TestClass()]
    public class ProjectTaskTests
    {
        [TestMethod()]
        public void ProjectTaskTestNotNull()
        {
            ProjectTask testTask = new ProjectTask("Test Title", "Test Notes", "03:00:00");
            Assert.IsNotNull(testTask);
        }

        [TestMethod()]
        public void ProjectTaskTestNoProps()
        {
            ProjectTask testTask = new ProjectTask();
            Assert.IsNotNull(testTask);
        }

        [TestMethod()]
        public void ProjectTaskTestTitle()
        {
            ProjectTask testTask = new ProjectTask("Test Title", "Test Notes", "03:00:00");
            Assert.AreEqual("Test Title", testTask.ProjectTitle);
        }

        [TestMethod()]
        public void ProjectTaskTestNotes()
        {
            ProjectTask testTask = new ProjectTask("Test Title", "Test Notes", "03:00:00");
            Assert.AreEqual("Test Notes", testTask.ProjectNotes);
        }

        [TestMethod()]
        public void ProjectTaskTestTimeSpent()
        {
            ProjectTask testTask = new ProjectTask("Test Title", "Test Notes", "03:00:00");
            Assert.AreEqual("03:00:00", testTask.TimeSpent);
        }

        [TestMethod()]
        public void ProjectTaskTestDateOfEntry()
        {
            ProjectTask testTask = new ProjectTask("Test Title", "Test Notes", "03:00:00");
            Assert.IsNotNull(testTask.DateOfEntry);
        }
    }
}