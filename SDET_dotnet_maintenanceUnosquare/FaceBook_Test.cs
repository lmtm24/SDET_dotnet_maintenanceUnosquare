using java.lang;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;


namespace lmtm24
{
    class FaceBook_Test
    {
        IWebDriver driver;
        public IWebDriver SetUpDriver()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            return driver;
        }

        public void Click(IWebElement element)
        {
            element.Click();
        }

        public void SendText(IWebElement element, string value)
        {
            element.SendKeys(value);            
            Console.WriteLine(element+":"+value);
        }

        public string GetText(IWebElement element)
        {
            string text = element.Text;
            return text;
        }

        public void AreEquals(string expected, string actual)    
        {
            Assert.AreEqual(expected, actual);          
                        
        }
     




        #region Login Locators
        By connect = By.CssSelector("._8eso");
        By email = By.XPath("//html[@id='facebook']//input[@id='email']");
        By password = By.XPath("//html[@id='facebook']//input[@id='pass']");
        By loginButton = By.XPath("//html[@id='facebook']//button[@id='u_0_b']");
        By fakeElement = By.XPath("//html[@id='facebook']//button[@id='fake']");
        #endregion

        
        static void Main(string[] args)
        {
            IWebDriver Browser;
            IWebElement element;
            FaceBook_Test face = new FaceBook_Test();
            Browser = face.SetUpDriver();
            Browser.Url = "https://www.facebook.com/";


            element = Browser.FindElement(face.connect);
            face.GetText(element);
            face.AreEquals("Connect with friends and the world around you on Facebook.", face.GetText(element));

            //
            //Console.Write();

            element = Browser.FindElement(face.email);
            face.SendText(element, "test@testing.com");

            element = Browser.FindElement(face.password);
            face.SendText(element,"Password");

            element = Browser.FindElement(face.loginButton);                      
            face.Click(element);

            try
            {
                element = Browser.FindElement(face.fakeElement);
                face.Click(element);
            }
            catch(NoSuchElementException) {
                Console.WriteLine("Element Not found :(");
            }
            







        }
    }
}
