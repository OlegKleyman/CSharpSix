namespace SharpSix
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Threading.Tasks;

    using NUnit.Framework;

    [TestFixture]
    public class SharpTests
    {
        [Test]
        public void OldProperties()
        {
            var sharp = new OldSharp();

            Assert.That(sharp.Name, Is.EqualTo("NoName"));

            sharp = new OldSharp("Omego2K");

            Assert.That(sharp.Name, Is.EqualTo("Omego2K"));

            Assert.That(sharp.Greeting, Is.EqualTo("Hello Omego2K"));
        }

        [Test]
        public void NewProperties()
        {
            var sharp = new NewSharp();

            Assert.That(sharp.Name, Is.EqualTo("NoName"));

            sharp = new NewSharp("Omego2K");

            Assert.That(sharp.Name, Is.EqualTo("Omego2K"));

            Assert.That(sharp.Greeting, Is.EqualTo("Hello Omego2K"));
        }

        [Test]
        public void OldMethod()
        {
            var sharp = new OldSharp();
            var product = sharp.GetPercentage(10, 50);
            Assert.That(product, Is.EqualTo(20));
        }

        [Test]
        public void NewMethod()
        {
            var sharp = new NewSharp();
            var product = sharp.GetPercentage(10, 50);
            Assert.That(product, Is.EqualTo(20));
        }

        [Test]
        public void OldStatics()
        {
            var sharp = new OldSharp();
            var root = sharp.GetSquareRoot(16);

            Assert.That(root, Is.EqualTo(4));
        }

        [Test]
        public void NewStatics()
        {
            var sharp = new NewSharp();
            var root = sharp.GetSquareRoot(16);

            Assert.That(root, Is.EqualTo(4));
        }

        [Test]
        public void OldNullCheck()
        {
            var sharp = new OldSharp();
            var address = sharp.GetCustomerStreetAddressById(1);

            Assert.That(address, Is.EqualTo("4 Crinan St."));

            address = sharp.GetCustomerStreetAddressById(2);

            Assert.That(address, Is.Null);

            address = sharp.GetCustomerStreetAddressById(3);

            Assert.That(address, Is.Null);
        }

        [Test]
        public void NewNullCheck()
        {
            var sharp = new NewSharp();
            var address = sharp.GetCustomerStreetAddressById(1);

            Assert.That(address, Is.EqualTo("4 Crinan St."));

            address = sharp.GetCustomerStreetAddressById(2);

            Assert.That(address, Is.Null);

            address = sharp.GetCustomerStreetAddressById(3);

            Assert.That(address, Is.Null);
        }

        [Test]
        public void OldStringFormatting()
        {
            var sharp = new OldSharp();
            var message = sharp.GetExceptionMessage(ErrorSeverity.Low);

            Assert.That(message, Is.EqualTo("A Low error has occurred"));
        }

        [Test]
        public void NewStringFormatting()
        {
            var sharp = new NewSharp();
            var message = sharp.GetExceptionMessage(ErrorSeverity.Low);

            Assert.That(message, Is.EqualTo("A Low error has occurred"));
        }

        [Test]
        public void OldNameToStringHandling()
        {
            var sharp = new OldSharp();
            var ex = Assert.Throws<ArgumentNullException>(() => sharp.SortString(null));

            Assert.That(ex.ParamName, Is.EqualTo("target"));
        }

        [Test]
        public void NewNameToStringHandling()
        {
            var sharp = new NewSharp();
            var ex = Assert.Throws<ArgumentNullException>(() => sharp.SortString(null));

            Assert.That(ex.ParamName, Is.EqualTo("target"));
        }

        [Test]
        public void OldIndexInitializers()
        {
            var sharp = new OldSharp();

            var dictionary = sharp.GetProducts();

            Assert.That(dictionary[Guid.Parse("00000000-0000-0000-0000-000000000001")], Is.EqualTo("Book"));
            Assert.That(dictionary[Guid.Parse("00000000-0000-0000-0000-000000000002")], Is.EqualTo("Magazine"));
            Assert.That(dictionary[Guid.Parse("00000000-0000-0000-0000-000000000003")], Is.EqualTo("The blue stuff"));
        }

        [Test]
        public void NewIndexInitializers()
        {
            var sharp = new NewSharp();

            var dictionary = sharp.GetProducts();

            Assert.That(dictionary[Guid.Parse("00000000-0000-0000-0000-000000000001")], Is.EqualTo("Book"));
            Assert.That(dictionary[Guid.Parse("00000000-0000-0000-0000-000000000002")], Is.EqualTo("Magazine"));
            Assert.That(dictionary[Guid.Parse("00000000-0000-0000-0000-000000000003")], Is.EqualTo("The blue stuff"));
        }

        [Test]
        public void OldExceptionFiltering()
        {
            var sharp = new OldSharp();

            var customer = sharp.GetCustomerById(0, false);

            Assert.That(customer, Is.Null);

            Assert.Throws<ArgumentException>(() => customer = sharp.GetCustomerById(0, true));
        }

        [Test]
        public void NewExceptionFiltering()
        {
            var sharp = new NewSharp();

            var customer = sharp.GetCustomerById(0, false);

            Assert.That(customer, Is.Null);

            Assert.Throws<ArgumentException>(() => customer = sharp.GetCustomerById(0, true));
        }

        [Test]
        public async Task OldAwaitInCatchFinallyBlocks()
        {
            var sharp = new OldSharp();

            var customer = await sharp.GetCustomerByIdAsync(-1);

            Assert.That(customer, Is.Null);
        }

        [Test]
        public async Task NewAwaitInCatchFinallyBlocks()
        {
            var sharp = new NewSharp();

            var customer = await sharp.GetCustomerByIdAsync(-1);

            Assert.That(customer, Is.Null);
        }

        [Test]
        public void OldExtensionMethodCollectionInitializers()
        {
            var sharp = new OldSharp();

            var customerIdList = sharp.GetCustomerIds();
            
            Assert.That(customerIdList.Count, Is.EqualTo(3));
            Assert.That(customerIdList.First.Value, Is.EqualTo(1));
            Assert.That(customerIdList.First.Next.Value, Is.EqualTo(2));
            Assert.That(customerIdList.Last.Value, Is.EqualTo(3));
        }

        [Test]
        public void NewExtensionMethodCollectionInitializers()
        {
            var sharp = new NewSharp();

            var customerIdList = sharp.GetCustomerIds();

            Assert.That(customerIdList.Count, Is.EqualTo(3));
            Assert.That(customerIdList.First.Value, Is.EqualTo(1));
            Assert.That(customerIdList.First.Next.Value, Is.EqualTo(2));
            Assert.That(customerIdList.Last.Value, Is.EqualTo(3));
        }
    }
}
