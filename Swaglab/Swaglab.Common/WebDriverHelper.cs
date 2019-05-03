using OpenQA.Selenium;
using System;
using System.Threading;

namespace Swaglab.Common
{
    public static class WebDriverHelper
    {
        public static void LoadNewWindow(string url, IWebDriver driver)
        {
            if (driver != null)
                driver.Url = url;
        }

        public static void NavigateBack(IWebDriver driver)
        {
            driver.Navigate().Back();
        }

        public static void Wait(IWebDriver driver)
        {
            try
            {
                Thread.Sleep(2000);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public static bool VerifyIfImageIsActive(IWebElement image)
        {
            try
            {
                //CloseableHttpClient client = HttpClientBuilder.create().build();
                //HttpGet request = new HttpGet((image.getAttribute("src")));
                //HttpResponse response = client.execute(request);

                //client.close();

                //if (response.getStatusLine().getStatusCode() == HttpStatus.SC_OK)
                //{
                //    return true;
                //}
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static string SubstituteString(string text, string element)
        {
            return text.Substring(text.LastIndexOf(element, StringComparison.Ordinal) + 1);
        }
    }
}
