using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Swaglab.BAL
{
    public class SortProduct
    {
        private readonly IWebDriver _webDriver;
        private SelectElement _dropDownList;

        public SortProduct(IWebDriver webDriver)
        {
            _webDriver = webDriver;

            _dropDownList = new SelectElement(_webDriver.FindElement(By.ClassName("product_sort_container")));
        }

        public void SelectItemByVisibleText(string text)
        {
            _dropDownList.SelectByText(text);
        }

        public void SelectItemByIndex(int index)
        {
            _dropDownList.SelectByIndex(index);
        }
    }
}
