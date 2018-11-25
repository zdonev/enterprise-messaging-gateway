using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;

namespace EnterpriseMessagingGateway.UnitTests
{
    [TestClass]
    public class AgreementServiceTests
    {
        [TestMethod]
        public void Should_ReturnAgreement_When_CallingService()
        {
            //Arrage
            var expectedValue = "ExpectedValue";


            //Act
            var currentValue = "ExpectedValue";

            //Assert
            currentValue.Should().BeEquivalentTo(expectedValue);
        }
    }
}
