using CabInvoiceGenerator1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CabInvoiceGenerator1TestProject
{
    [TestClass]
    public class CabInvoiceGeneratorTestClass
    {
        [TestMethod]
        public void GivenDistanceAndTimeShouldReturnTotalFare()
        {
            //AA methadology
            //Arrange
            InvoiceGenerator invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            double distance = 5;
            int time = 6;
            double expected = 56;
            //Act
            double actual = invoiceGenerator.CalculateFare(distance, time);
            //Assert
            Assert.AreEqual(expected, actual);
        }     
    }
}
