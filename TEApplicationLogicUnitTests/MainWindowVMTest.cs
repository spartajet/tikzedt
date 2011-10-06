﻿using TikzEdt.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Windows.Input;
using TikzEdt;
using System.Windows;
using System.Windows.Controls;

namespace TEApplicationLogicUnitTests
{
    
    
    /// <summary>
    ///This is a test class for MainWindowVMTest and is intended
    ///to contain all MainWindowVMTest Unit Tests
    ///</summary>
    [TestClass()]
    public class MainWindowVMTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion
        
        /// <summary>
        /// This test performs several standard activities regarding files
        ///</summary>
        [TestMethod()]
        [DeploymentItem("TEApplicationLogic.dll")]
        public void StdFileHandlingTest()
        {
            MainWindowVM_Accessor target = new MainWindowVM_Accessor(); 
            // To execute commands, we need to take a detour and bind them in a dummy
            StackPanel dummy = new StackPanel();
            dummy.CommandBindings.Add(target.SaveAsCommandBinding);
            dummy.CommandBindings.Add(target.NewCommandBinding);
            dummy.CommandBindings.Add(target.SaveCommandBinding);
            dummy.CommandBindings.Add(target.OpenCommandBinding);

            // create a new file 
            ApplicationCommands.New.Execute(null, dummy);
            GlobalUI.LastMessage = "";
            GlobalUI.MockResult = MessageBoxResult.Cancel;
            // create a new file again, the file was not changed, so the use should not be asked to save
            ApplicationCommands.New.Execute(null, dummy);
            Assert.AreEqual(GlobalUI.LastMessage, "");
            // now change the file a bit
            target.TheDocument.Document.Insert(0, "hallo Welt");
            string oldText = target.TheDocument.Document.Text;
            // try to override again
            ApplicationCommands.New.Execute(null, dummy);
            // now a messagebox must have been shown, and the file contents should be unchanged
            Assert.IsTrue(GlobalUI.LastMessage != "");
            Assert.AreEqual(target.TheDocument.Document.Text, oldText);

            // Now save the file to a temp file


        }

        /// <summary>
        ///A test for OpenCommandHandler
        ///</summary>
        [TestMethod()]
        [DeploymentItem("TEApplicationLogic.dll")]
        public void OpenCommandHandlerTest()
        {
            MainWindowVM_Accessor target = new MainWindowVM_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            ExecutedRoutedEventArgs e = null; // TODO: Initialize to an appropriate value
            target.OpenCommandHandler(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }
    }
}