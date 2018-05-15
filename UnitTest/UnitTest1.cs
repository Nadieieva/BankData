using System;
using System.Collections.Generic;
using System.Linq;
using BankData.Models;
using BankDb;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var dbService = new BankService();
            dbService.InsertInitialData();

            
            using (var context = new BankContext())
            {
                var client = context.Clients.FirstOrDefault(c => c.FirstName == "Anastasia");
                Assert.AreEqual("Petrova", client.LastName);
            }
        }

        [TestMethod]
        public void TestRecalculateBalance()
        {
            var bankService = new BankService();

            bankService.RecalculateCardBalance("6578421056841245");
            bankService.RecalculateCardBalance("9870213456751204");

            using (var context = new BankContext())
            {
                
                var card_1 = context.Cards.SingleOrDefault(c => c.CardID == "6578421056841245");
                var card_2 = context.Cards.SingleOrDefault(c => c.CardID == "9870213456751204");

                Assert.AreEqual(293.51M, card_1.Ballance);
                Assert.AreEqual(1800.4M, card_2.Ballance);
            }
        }
    }
}
