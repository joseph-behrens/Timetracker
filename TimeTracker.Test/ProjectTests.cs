using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TimeTracker.Controllers;
using TimeTracker.Data;

namespace TimeTracker.Test
{
    [TestClass]
    public class ProjectTests
    {
        [TestMethod]
        public void TestProjectEmptyConstructor()
        {
            Project _testProject = new Project();
            Assert.IsNotNull(_testProject);
        }

        [TestMethod]
        public void TestNewProjectNotNull()
        {
            Project _testProject = new Project("Test Project", 99999);
            Assert.IsNotNull(_testProject);
        }

        [TestMethod]
        public void TestProjectGetClientId()
        {
            Project _testProject = new Project("Test Project", 99999);
            Assert.AreEqual(_testProject.ClientId, 99999);
        }

        [TestMethod]
        public void TestProjectGetClient()
        {
            Client _testClient = new Client("Cool Client");
            Project _testProject = new Project("Test Project", 99999);
            _testProject.Client = _testClient;
            Assert.AreEqual(_testProject.Client.Name, "Cool Client");
        }

        [TestMethod]
        public void TestProjectGetName()
        {
            Project _testProject = new Project("Test Project", 99999);
            Assert.AreEqual(_testProject.Name, "Test Project");
        }

        [TestMethod]
        public void TestProjectGetId()
        {
            Project _testProject = new Project("Test Project", 99999);
            _testProject.Id = 32;
            Assert.AreEqual(_testProject.Id, 32);
        }

        [TestMethod]
        public void TestProjectExistsTrue()
        {
            DatabaseHelper.InitialiseDb();
            Project _testProject = new Project("Test Project", 99999);
            ProjectController.AddProject(_testProject);
            Assert.AreEqual(_testProject.Exists(), true);
            ProjectController.DeleteProject(_testProject);
        }

        [TestMethod]
        public void TestProjectExistsFalse()
        {
            Project _testProject = new Project("Test Project Yo", 99998);
            Assert.AreEqual(_testProject.Exists(), false);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void TestAddEmptyProject()
        {
            Project _testProject = null;
            ProjectController.AddProject(_testProject);
            _testProject.Exists();
        }

        [TestMethod]
        public void TestProjectWillNotAddDuplicate()
        {
            DatabaseHelper.InitialiseDb();
            Project _testProject = new Project("Test Project", 99999);
            ProjectController.AddProject(_testProject);
            ProjectController.AddProject(_testProject);
            ProjectController.DeleteProject(_testProject);
            Assert.AreEqual(_testProject.Exists(), false);
        }

        [TestMethod]
        public void TestGetProjectById()
        {
            DatabaseHelper.InitialiseDb();
            string _name = "Test Project asfasxcvdsfasd";
            Project _testProject = new Project(_name, 99999);
            ProjectController.AddProject(_testProject);
            int _id = ProjectController.GetProjectsByClientId(99999)[0].Id;
            Assert.AreEqual(ProjectController.GetProjectById(_id).Name, _name);
            ProjectController.DeleteProject(_testProject);
        }

        [TestMethod]
        public void TestGetProjectByMissingId()
        {
            DatabaseHelper.InitialiseDb();
            Assert.IsNull(ProjectController.GetProjectById(78787878));
        }

        [TestMethod]
        public void TestGetProjects()
        {
            DatabaseHelper.InitialiseDb();
            Project _testProject = new Project("Testing a project", 99999);
            ProjectController.AddProject(_testProject);
            Assert.IsNotNull(ProjectController.GetProjects());
            ProjectController.DeleteProject(_testProject);
        }
    }
}
