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
        [TestMethod]
        [TestCategory("Fare")]
        public void GivenMultipleRidesShouldReturnAggregateTotalFare()
        {
           // double expected = 60;
            Ride[] rides = { new Ride(2.0, 5), new Ride(0.1, 1) };
            InvoiceGenerator invoiceGenerator = new InvoiceGenerator(RideType.PREMIUM);

            InvoiceSummary expected=new InvoiceSummary(rides.Length,30);
            //Generating Summary for rides
            InvoiceSummary actual = invoiceGenerator.CalculateFare(rides);
            Assert.AreEqual(actual, expected);
            //expected.Equals(actual);
        }    
    }
}
