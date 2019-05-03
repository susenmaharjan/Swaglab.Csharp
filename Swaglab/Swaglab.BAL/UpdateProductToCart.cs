using System.Collections;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;

namespace Swaglab.BAL
{
    public class UpdateProductToCart
    {
        private readonly IWebDriver _webDriver;
        private readonly List <IWebElement>_productBtn;

        public UpdateProductToCart(IWebDriver webDriver)
        {
            _webDriver = webDriver;
            _productBtn = _webDriver.FindElements(By.ClassName("btn_inventory")).ToList();
        }

        public void AddProductToCartByIndex(int index)
        {
            _productBtn[index].Click();
        }

        public void RemoveProductFromCartByIndex(int index)
        {
            _productBtn[index].Click();
        }
    }
}
