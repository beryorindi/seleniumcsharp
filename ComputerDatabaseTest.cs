namespace SeleniumTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

public class ComputerDatabaseTest
{
    IWebDriver driver;
    private readonly string baseUrl = "https://computer-database.gatling.io/computers";
    
    [SetUp]
    public void Setup()
    {
        driver = new ChromeDriver(@"/Users/Bery/Downloads/chromedriver-mac-arm64/chromedriver");
        driver.Navigate().GoToUrl(baseUrl);
    }
    
    [Test]
    public void FilterComputerTest()
    {   
        // input value and filter
        driver.FindElement(By.Id("searchbox")).SendKeys("Altair");
        driver.FindElement(By.Id("searchsubmit")).Click();
        // verify list is filtered by inputted value
        Assert.That(driver.FindElement(By.XPath("//tbody/tr[1]/td/a")).Text,Is.EqualTo("Altair 8800"));
    }

    [Test]
    public void CreateComputerTest()
    {   
        // go to add new computer form
        driver.FindElement(By.Id("add")).Click();
        // fill in form
        driver.FindElement(By.Id("name")).SendKeys("test abc");
        driver.FindElement(By.Id("introduced")).SendKeys("2023-12-12");
        SelectElement dropDownCompany = new SelectElement(driver.FindElement(By.Id("company")));
        dropDownCompany.SelectByText("Netronics");
        driver.FindElement(By.CssSelector("input[type='submit']")).Click();
        // assert computer has been created 
        Assert.That(driver.FindElement(By.XPath("//div[@class='alert-message warning']")).Text,Is.EqualTo("Done ! Computer test abc has been created"));
    }

    [TearDown]
    public void TearDown()
    {
        driver.Quit();
    }
}