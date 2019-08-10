using Microsoft.VisualStudio.TestTools.UnitTesting;
using ZbW.ProgrAdv.NugetTestat.Model;
using ZbW.ProgrAdv.NugetTestat.Services;

namespace ZbW.ProgAdv.NugetTestat.UnitTests
{
    [TestClass]
    public class InputValidationTest
    {
        [TestMethod]
        public void TestCustomerNumberIsValid()
        {
            //Arrange
            var customer = new Customer();
            customer.CustomerNumber = "CU12345";
            var inputValidation = new InputValidation(customer);

            //Act
            var isValidInput = inputValidation.HasValidCustomernumber();

            //Assert
            Assert.IsTrue(isValidInput);
        }

        [TestMethod]
        public void TestCustomerNumberIsNotValid()
        {
            //Arrange
            var customer = new Customer();
            customer.CustomerNumber = "12345";
            var inputValidation = new InputValidation(customer);

            //Act
            var isValidInput = inputValidation.HasValidCustomernumber();

            //Assert
            Assert.IsFalse(isValidInput);
        }

        [TestMethod]
        public void TestCustomerSwissPhoneNumberIsValid()
        {
            //Arrange
            var customer = new Customer();
            customer.CustomerCountry = new Country("Schweiz", @"^(0041|0|\+41)(\(0\))?([0-9]{2}\/?[0-9]{7})$");
            customer.PhoneNumber = "+41(0)754090000";
            var inputValidation = new InputValidation(customer);

            //Act
            var isValidInput = inputValidation.HasValidPhonenumber();

            //Assert
            Assert.IsTrue(isValidInput);
        }

        [TestMethod]
        public void TestCustomerSwissPhoneNumberIsNotValid()
        {
            //Arrange
            var customer = new Customer();
            customer.CustomerCountry = new Country("Schweiz", @"^(0041|0|\+41)(\(0\))?([0-9]{2}\/?[0-9]{7})$");
            customer.PhoneNumber = "75 409 00 00";
            var inputValidation = new InputValidation(customer);

            //Act
            var isValidInput = inputValidation.HasValidPhonenumber();

            //Assert
            Assert.IsFalse(isValidInput);
        }

        [TestMethod]
        public void TestCustomerGermanPhoneNumberIsValid()
        {
            //Arrange
            var customer = new Customer();
            customer.CustomerCountry = new Country("Deutschland", @"^(0049|0|\+49)(\(0\))?([0-9]{2}\/?[0-9]{8})$");
            customer.PhoneNumber = "+49(0)1701234567";
            var inputValidation = new InputValidation(customer);

            //Act
            var isValidInput = inputValidation.HasValidPhonenumber();

            //Assert
            Assert.IsTrue(isValidInput);
        }

        [TestMethod]
        public void TestCustomerGermanPhoneNumberIsNotValid()
        {
            //Arrange
            var customer = new Customer();
            customer.CustomerCountry = new Country("Schweiz", @"^(0041|0|\+41)(\(0\))?([0-9]{2}\/?[0-9]{7})$");
            customer.PhoneNumber = "+483012345678";
            var inputValidation = new InputValidation(customer);

            //Act
            var isValidInput = inputValidation.HasValidPhonenumber();

            //Assert
            Assert.IsFalse(isValidInput);
        }

        [TestMethod]
        public void TestCustomerLiechtensteinPhoneNumberIsValid()
        {
            //Arrange
            var customer = new Customer();
            customer.CustomerCountry = new Country("Liechtenstein", @"^(00423|\+423)(\/?[0-9]{3}\/?[0-9]{4})$");
            customer.PhoneNumber = "+4232396363";
            var inputValidation = new InputValidation(customer);

            //Act
            var isValidInput = inputValidation.HasValidPhonenumber();

            //Assert
            Assert.IsTrue(isValidInput);
        }

        [TestMethod]
        public void TestCustomerLiechtensteinPhoneNumberIsNotValid()
        {
            //Arrange
            var customer = new Customer();
            customer.CustomerCountry = new Country("Liechtenstein", @"^(00423|\+423)(\/?[0-9]{3}\/?[0-9]{4})$");
            customer.PhoneNumber = "002396363";
            var inputValidation = new InputValidation(customer);

            //Act
            var isValidInput = inputValidation.HasValidPhonenumber();

            //Assert
            Assert.IsFalse(isValidInput);
        }

        [TestMethod]
        public void TestCustomerMailIsValid()
        {
            //Arrange
            var customer = new Customer();
            customer.EMail = "hansruedi@hans.ch";
            var inputValidation = new InputValidation(customer);

            //Act
            var isValidInput = inputValidation.HasValidMailadress();

            //Assert
            Assert.IsTrue(isValidInput);
        }

        [TestMethod]
        public void TestCustomerMailIsNotValid()
        {
            //Arrange
            var customer = new Customer();
            customer.EMail = "@hans.ch";
            var inputValidation = new InputValidation(customer);

            //Act
            var isValidInput = inputValidation.HasValidMailadress();

            //Assert
            Assert.IsFalse(isValidInput);
        }

        [TestMethod]
        public void TestCustomerWebsiteIsValid()
        {
            //Arrange
            var customer = new Customer();
            customer.Url = "https://www.google.com";
            var inputValidation = new InputValidation(customer);

            //Act
            var isValidInput = inputValidation.HasValidWebsite();

            //Assert
            Assert.IsTrue(isValidInput);
        }

        [TestMethod]
        public void TestCustomerWebsiteIsNotValid()
        {
            //Arrange
            var customer = new Customer();
            customer.Url = "www.bddha.comm";
            var inputValidation = new InputValidation(customer);

            //Act
            var isValidInput = inputValidation.HasValidWebsite();

            //Assert
            Assert.IsFalse(isValidInput);
        }

        [TestMethod]
        public void TestCustomerPasswordIsValid()
        {
            //Arrange
            var customer = new Customer();
            customer.Password = "Hlal5-dwd935add";
            var inputValidation = new InputValidation(customer);

            //Act
            var isValidInput = inputValidation.HasValidPassword();

            //Assert
            Assert.IsTrue(isValidInput);
        }

        [TestMethod]
        public void TestCustomerPasswordIsNotValid()
        {
            //Arrange
            var customer = new Customer();
            customer.Password = "halloWelt";
            var inputValidation = new InputValidation(customer);

            //Act
            var isValidInput = inputValidation.HasValidPassword();

            //Assert
            Assert.IsFalse(isValidInput);
        }

    }
}
