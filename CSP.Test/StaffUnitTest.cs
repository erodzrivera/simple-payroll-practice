using CSP.BL;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSP.BL.Tests
{
    [TestClass()]
    public class StaffUnitTest
    {
        [TestMethod()]
        public void CalculatePayTest()
        {
            // Arrange
            Staff newStaff = new Staff("John", 100.50f);
            newStaff.HoursWorked = 48;
            // Act
            newStaff.CalculatePay();
            var actualPay = 4824f;
            // Assert
            Assert.AreEqual(actualPay, newStaff.TotalPay);
        }
    }
}
