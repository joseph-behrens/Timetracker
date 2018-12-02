using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TimeTracker.Controllers;
using TimeTracker.Data;

namespace TimeTracker.Test
{
    [TestClass]
    public class ClientTests
    {
        [TestMethod]
        public void TestClientEmptyConstructor()
        {
            Client _testClient = new Client();
            Assert.IsNotNull(_testClient);
        }

        [TestMethod]
        public void TestClientConstructor()
        {
            Client _testClient = new Client("Fancy Pants Client");
            Assert.AreEqual(_testClient.Name, "Fancy Pants Client");
        }

        [TestMethod]
        public void TestClientSetId()
        {
            Client _testClient = new Client();
            _testClient.Id = 909090;
            Assert.AreEqual(_testClient.Id, 909090);
        }

        [TestMethod]
        public void TestClientSetName()
        {
            Client _testClient = new Client();
            _testClient.Name = "So Cool";
            Assert.AreEqual(_testClient.Name, "So Cool");
        }

        [TestMethod]
        public void TestClientExistsTrue()
        {
            DatabaseHelper.InitialiseDb();
            Client _testClient = new Client("Fancy Pants Client");
            ClientController.AddClient(_testClient);
            Assert.AreEqual(_testClient.Exists(), true);
            ClientController.DeleteProject(_testClient);
        }

        [TestMethod]
        public void TestClientExistsFalse()
        {
            Client _testClient = new Client("Test Client Yo");
            Assert.AreEqual(_testClient.Exists(), false);
        }

        [TestMethod]
        public void TestClientGetProjects()
        {
            Client _testClient = new Client("Test Client Yo");
            Project _testProject = new Project();
            _testProject.Name = "Cool proj";
            List<Project> _projectList = new List<Project>();
            _projectList.Add(_testProject);
            _testClient.Projects = _projectList;
            Assert.AreEqual(_testClient.Projects[0].Name, "Cool proj");
        }

        [TestMethod]
        public void TestGetClients()
        {
            DatabaseHelper.InitialiseDb();
            Client _testClient = new Client("Add me to the list");
            ClientController.AddClient(_testClient);
            Assert.IsNotNull(ClientController.GetClients());
            ClientController.DeleteProject(_testClient);
        }

        [TestMethod]
        public void TestGetClientById()
        {
            DatabaseHelper.InitialiseDb();
            Client _testClient = new Client("Add me to the list");
            ClientController.AddClient(_testClient);
            int _clientId = ClientController.GetClientByName("Add me to the list").Id;
            Assert.AreEqual(ClientController.GetClientById(_clientId).Name, "Add me to the list");
            ClientController.DeleteProject(_testClient);
        }

        [TestMethod]
        public void TestGetClientByBadId()
        {
            Assert.IsNull(ClientController.GetClientById(546465464));
        }
    }
}
