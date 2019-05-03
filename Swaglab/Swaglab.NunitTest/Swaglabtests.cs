using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Swaglab.BAL;
using Swaglab.Common;

namespace Swaglab.NunitTest
{
    [TestFixture]
    public class Swaglabtests
    {
        private static IWebDriver _webDriver;

        [OneTimeSetUp]
        public void SetUp()
        {
            _webDriver = new ChromeDriver(@"D:\\Susen\\Selenium drivers");
            _webDriver.Manage().Window.Maximize();
            WebDriverHelper.LoadNewWindow("https://www.saucedemo.com", _webDriver);
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            if (_webDriver != null)
            {
                _webDriver.Close();
                _webDriver.Quit();
            }
        }

        [Test, Order(1)]
        public void LoginTest()
        {
            var page = new Login(_webDriver);

            page.SetUsername("standard_user");
            page.SetPassword("secret_sauce");

            page.LoginClick();
            WebDriverHelper.Wait(_webDriver);
        }

        [Test, Order(2)]
        public void CheckIfImagesAreLoaded()
        {

        }

        [Test, Order(3)]
        public void SortPrice()
        {
            var page = new SortProduct(_webDriver);

            page.SelectItemByVisibleText("Name (Z to A)");
            WebDriverHelper.Wait(_webDriver);

            page.SelectItemByIndex(3);
            WebDriverHelper.Wait(_webDriver);
        }

        [Test, Order(4)]
        public void AddProductsToCart()
        {
            var page = new UpdateProductToCart(_webDriver);

            page.AddProductToCartByIndex(1);
            page.AddProductToCartByIndex(2);

            WebDriverHelper.Wait(_webDriver);
        }

        [Test, Order(5)]
        public void RemoveProductsFromCart()
        {
            var page = new UpdateProductToCart(_webDriver);
            page.RemoveProductFromCartByIndex(1);
            WebDriverHelper.Wait(_webDriver);
        }

        [Test, Order(6)]
        public void RedirectToShoppingCart()
        {
            _webDriver.FindElement(By.ClassName("shopping_cart_link")).Click();
            WebDriverHelper.Wait(_webDriver);
        }

        [Test, Order(7)]
        public void CheckoutCart()
        {
            var page = new Checkout(_webDriver);

            page.RedirectToStepOne();

            WebDriverHelper.Wait(_webDriver);
        }

        [Test, Order(8)]
        public void CheckoutStepOne()
        {
            var page = new Checkout(_webDriver);

            WebDriverHelper.Wait(_webDriver);
            page.SetupStepOne();

            page.UpdateStepOne("Susen", "Maharjan", "97701");
            WebDriverHelper.Wait(_webDriver);

            page.SubmitStepOne();
            WebDriverHelper.Wait(_webDriver);
        }

        [Test, Order(9)]
        public void CheckoutStepTwo()
        {
            var page = new Checkout(_webDriver);

            page.RedirectToStepTwo();

            page.SetupStepTwo();

            string sauceCardId = WebDriverHelper.SubstituteString(page.GetSauceCard(), "#");
            string itemTotalValue = WebDriverHelper.SubstituteString(page.GetItemTotal(), "$");
            string taxValue = WebDriverHelper.SubstituteString(page.GetTax(), "$");
            string totalValue = WebDriverHelper.SubstituteString(page.GetTotal(), "$");

            Assert.AreEqual("31337", sauceCardId);
            Assert.AreEqual("15.99", itemTotalValue);
            Assert.AreEqual("1.28", taxValue);
            Assert.AreEqual("17.27", totalValue);

            WebDriverHelper.Wait(_webDriver);
        }

        [Test, Order(10)]
        public void CompleteCheckout()
        {
            var page = new Checkout(_webDriver);
            string result = page.CompleteCheckout();

            Assert.AreEqual("THANK YOU FOR YOUR ORDER", result);

            WebDriverHelper.Wait(_webDriver);
        }
    }
}
