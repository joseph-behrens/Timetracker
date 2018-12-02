using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TimeTracker.Controllers;
using TimeTracker.Data;

namespace TimeTracker.Test
{
    [TestClass]
    public class TaskTests
    {
        [TestMethod]
        public void TestTaskEmptyConstructor()
        {
            Task _testTask = new Task();
            Assert.IsNotNull(_testTask);
        }

        [TestMethod]
        public void TestTaskPrimaryConstructor()
        {
            Task _testTask = new Task(1, "this was a fun task", "05:04:03");
            Assert.AreEqual(_testTask.ProjectId, 1);
        }

        [TestMethod]
        public void TestTaskDatetimeConstructor()
        {
            Task _testTask = new Task(1, "this was a fun task", "05:04:03", "Tuesday");
            Assert.AreEqual(_testTask.DateOfEntry, "Tuesday");
        }

        [TestMethod]
        public void TestGetTaskId()
        {
            Task _testTask = new Task();
            _testTask.Id = 42;
            int _taskId = _testTask.Id;
            Assert.AreEqual(_taskId, 42);
        }

        [TestMethod]
        public void TestTaskGetNotes()
        {
            Task _testTask = new Task(1, "this was a fun task", "05:04:03");
            Assert.AreEqual(_testTask.Notes, "this was a fun task");
        }

        [TestMethod]
        public void TestTaskGetProject()
        {
            Task _testTask = new Task(1, "this was a fun task", "05:04:03");
            Project _testProject = new Project("cool proj", 525252);
            _testTask.Project = _testProject;
            Assert.AreEqual(_testTask.Project.Name, "cool proj");
        }

        [TestMethod]
        public void TestTaskGetTimeSpent()
        {
            Task _testTask = new Task(1, "this was a fun task", "05:04:03");
            Assert.AreEqual(_testTask.TimeSpent, "05:04:03");
        }

        [TestMethod]
        public void TestGetTasks()
        {
            DatabaseHelper.InitialiseDb();
            Task _testTask = new Task(1, "this was a fun task", "05:04:03");
            TaskController.AddTask(_testTask);
            Assert.IsNotNull(TaskController.GetTasks());
            TaskController.DeleteTask(_testTask);
        }
    }
}
