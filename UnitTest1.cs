using Microsoft.Analytics.Interfaces;
using Microsoft.Analytics.Interfaces.Streaming;
using Microsoft.Analytics.Types.Sql;
using Microsoft.Analytics.UnitTest;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using lab13;
using ClassLibrary10;
using ClassLibraryForHashTable;

namespace Testsfor13
{
    [TestClass]
    public class UnitTest1
    {
        public UnitTest1()
        {
            //
            // TODO: Add constructor logic here
            //
        }

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
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void JournalEntry_ToString_ReturnsFormattedString()
        {
            // Arrange
            var entry = new JournalEntry("MyCollection", "Add", "NewObject");

            // Act
            var result = entry.ToString();

            // Assert
            Assert.AreEqual("КОЛЛЕКЦИЯ: MyCollection. ТИП ИЗМЕНЕНИЯ: Add. ОБЪЕКТ: NewObject", result);
        }
        [TestMethod]
        public void Journal_AddEntry_UpdatesJournal()
        {
            // Arrange
            var journal = new Journal();
            var args = new CollectionHandlerEventArgs("Add", "NewObject");

            // Act
            journal.WrireRecord(null, args);

            // Assert
            Assert.AreEqual(1, journal.GetHashCode());
        }

        [TestMethod]

        public void GetItem()
        {
            MyObservableCollection<BankCard> coll = new MyObservableCollection<BankCard>(8);
            BankCard m = new BankCard(11,"mmm", DateTime.MaxValue, 11);
            coll.Add(m);
            BankCard m1 = coll[m.Name];
            Assert.AreEqual(m1, m);
        }

        [TestMethod]
        public void SetItem()
        {
            MyObservableCollection<BankCard> coll = new MyObservableCollection<BankCard>(8);
            BankCard m = new BankCard(11, "mmm", DateTime.MaxValue, 11);
            coll.Add(m);
            BankCard m2 = new BankCard(12, "mmm1", DateTime.MinValue, 12);
            coll[m.Name] = m2;
            Assert.IsNull(coll.FindName(m.Name));
            Assert.IsNotNull(coll.FindName(m2.Name));
        }
        [TestMethod]
        public void JournalEntryToString()
        {
            JournalEntry j = new JournalEntry("coll", "Äîáàâëåíèå", "item");
            Assert.AreEqual("ÊÎËËÅÊÖÈß: coll. ÒÈÏ ÈÇÌÅÍÅÍÈß: Äîáàâëåíèå. ÎÁÚÅÊÒ: item", j.ToString());
        }
        [TestMethod]
        public void MyObservableCollection_AddItem_IncreasesCount()
        {
            // Arrange
            var collection = new MyObservableCollection<BankCard>(6);
            BankCard deb2 = new BankCard();
            // Act
            collection.Add(deb2);

            // Assert
            Assert.AreEqual(1, collection.Count);
        }

        [TestMethod]
        public void MyObservableCollection_RemoveItem_DecreasesCount()
        {
            // Arrange
            var collection = new MyObservableCollection<BankCard>(6);
            BankCard deb2 = new BankCard();

            // Act
            collection.Remove(deb2);

            // Assert
            Assert.AreEqual(0, collection.Count);
        }






    }
    }
