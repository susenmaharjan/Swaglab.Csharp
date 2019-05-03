using OpenQA.Selenium;

namespace Swaglab.BAL
{
    public class Login
    {
        private readonly IWebDriver _webDriver;

        private readonly IWebElement _act;
        private readonly IWebElement _username;
        private readonly IWebElement _password;

        public Login(IWebDriver webDriver)
        {
            _webDriver = webDriver;
            _act = _webDriver.FindElement(By.ClassName("btn_action"));
            _username = _webDriver.FindElement(By.Id("user-name"));
            _password = _webDriver.FindElement(By.Id("password"));
        }

        public void SetUsername(string username)
        {
            _username.SendKeys(username);
        }

        public void SetPassword(string password)
        {
            _password.SendKeys(password);
        }

        public void LoginClick()
        {
            _act.Click();
        }
    }
}
