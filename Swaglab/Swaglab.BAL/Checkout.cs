using OpenQA.Selenium;

namespace Swaglab.BAL
{
    public class Checkout
    {
        private readonly IWebDriver _webDriver;
        private IWebElement _firstName, _lastName, _postalCode;
        private IWebElement _sauceCard, _itemTotal, _tax, _total;

        public Checkout(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public void RedirectToStepOne()
        {
            _webDriver.FindElement(By.ClassName("checkout_button")).Click();
        }

        public void SetupStepOne()
        {
            _firstName = _webDriver.FindElement(By.Id("first-name"));
            _lastName = _webDriver.FindElement(By.Id("last-name"));
            _postalCode = _webDriver.FindElement(By.Id("postal-code"));
        }

        public void UpdateStepOne(string firstName, string lastName, string postalCode)
        {
            _firstName.SendKeys(firstName);
            _lastName.SendKeys(lastName);
            _postalCode.SendKeys(postalCode);
        }

        public void SubmitStepOne()
        {
            _postalCode.Click();
        }


        public void RedirectToStepTwo()
        {
            _webDriver.FindElement(By.ClassName("cart_button")).Click();
        }

        public void SetupStepTwo()
        {
            _sauceCard = _webDriver.FindElement(By.ClassName("summary_value_label"));
            _itemTotal = _webDriver.FindElement(By.ClassName("summary_subtotal_label"));
            _tax = _webDriver.FindElement(By.ClassName("summary_tax_label"));
            _total = _webDriver.FindElement(By.ClassName("summary_total_label"));
        }

        public string GetSauceCard()
        {
            return _sauceCard != null ? _sauceCard.GetAttribute("textContent") : string.Empty;
        }

        public string GetItemTotal()
        {
            return _itemTotal != null ? _itemTotal.GetAttribute("textContent") : string.Empty;
        }

        public string GetTax()
        {
            return _tax != null ? _tax.GetAttribute("textContent") : string.Empty;
        }

        public string GetTotal()
        {
            return _total != null ? _total.GetAttribute("textContent") : string.Empty;
        }

        public string CompleteCheckout()
        {
            _webDriver.FindElement(By.ClassName("cart_button")).Click();
            return _webDriver.FindElement(By.ClassName("complete-header")).GetAttribute("textContent");
        }
    }



}
