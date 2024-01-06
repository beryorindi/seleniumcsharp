namespace SeleniumTesting;

using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

public class ComputerDatabaseTest
{
    IWebDriver driver = null;
    private readonly string baseUrl = "https://computer-database.gatling.io/computers";
    
    [SetUp]
    public void Setup()
    {
        driver = new ChromeDriver(@"/Users/Bery/Downloads/chromedriver-mac-arm64/chromedriver");
    }
    
    [Test]
    public void CreateComputerTest()
    {   
        driver.Navigate().GoToUrl(baseUrl);
        driver.FindElement(By.Id("add")).Click();

        driver.FindElement(By.Id("name")).SendKeys("computer test abc");
        driver.FindElement(By.Id("introduced")).SendKeys("2023-12-12");
        SelectElement dropDownCompany = new SelectElement(driver.FindElement(By.Id("company")));
        dropDownCompany.SelectByValue("Netronics");
        driver.FindElement(By.Id("name")).SendKeys("computer test abc");
        driver.FindElement(By.CssSelector("button[type='submit']")).Click();
    }

    [TearDown]
    public void TearDown()
    {
        driver.Quit();
    }
}