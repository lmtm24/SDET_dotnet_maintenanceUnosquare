using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnoSquare_Maintenance
{
    class Program
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
        }

        #region Google Locators
        By GoogleSearchBar = By.XPath("//form[@id='tsf']//div[@class='A8SBwf']//div[@class='a4bIc']/input[@role='combobox']");
        By GoogleSearIcon = By.XPath("/html//form[@id='tsf']//div[@class='A8SBwf']/div[@class='FPdoLc tfB0Bf']/center/input[@name='btnK']");
        By UnoSquareGoogleResult = By.XPath("/html//div[@id='rso']//div//a[@href='https://www.unosquare.com/']");
        By GoogleOutSearchResult = By.XPath("//form[@id='tsf']/div[2]");
        #endregion

        #region UnoSquare Locators
        By UnoSquareServicesMenu = By.XPath("//div[@id='navbarSupportedContent']/ul[@class='navbar-nav']//a[@href='/Services']");
        By PracticeAreas = By.XPath("//div[@id='navbarSupportedContent']/ul[@class='navbar-nav']//a[@href='/PracticeAreas']");
        By ContactUs = By.XPath("//div[@id='navbarSupportedContent']/ul[@class='navbar-nav']//a[@href='/ContactUs']");
        #endregion 
        static void Main(string[] args)
        {
            IWebDriver Browser;
            IWebElement element;
            Program program = new Program();
            Browser = program.SetUpDriver();
            Browser.Url = "https://www.google.com";

            element = Browser.FindElement(program.GoogleSearchBar);

            program.SendText(element, "Unosquare");

            element = Browser.FindElement(program.GoogleOutSearchResult);

            program.Click(element);

            element = Browser.FindElement(program.GoogleSearIcon);                      

            program.Click(element);

            element = Browser.FindElement(program.UnoSquareGoogleResult);

            program.Click(element);

            element = Browser.FindElement(program.UnoSquareServicesMenu);

            program.Click(element);

            element = Browser.FindElement(program.PracticeAreas);

            program.Click(element);

            element = Browser.FindElement(program.ContactUs);

            program.Click(element);





        }
    }
}
