namespace SeleniumNUnit;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

public class Heroku
{
    IWebDriver driver;
    IAlert? alert;
    private readonly string baseUrl = "https://the-internet.herokuapp.com/javascript_alerts";
    
    [SetUp]
    public void Setup()
    {
        driver = new ChromeDriver(@"/Users/Bery/Downloads/chromedriver-mac-arm64/chromedriver");
        driver.Navigate().GoToUrl(baseUrl);
    }
    
    [Test]
    public void ConfirmTest()
    {   
        // click JS confirm
        driver.FindElement(By.XPath("//button[@onclick='jsConfirm()']")).Click();
        alert = driver.SwitchTo().Alert();
        alert.Accept();
        // assert confirm has been clicked
        Assert.That(driver.FindElement(By.Id("result")).Text,Is.EqualTo("You clicked: Ok"));
    }

    [Test]
    public void PromptTest()
    {   
        // click JS Prompt and input value
        driver.FindElement(By.XPath("//button[@onclick='jsPrompt()']")).Click();
        alert = driver.SwitchTo().Alert();
        alert.SendKeys("input test abc");
        alert.Accept();
        // assert message that has been inputed in alert JS
        Assert.That(driver.FindElement(By.Id("result")).Text,Is.EqualTo("You entered: input test abc"));
    }

    [Test]
    public void PromptTestNull()
    {   
        // click JS Prompt and cancel
        driver.FindElement(By.XPath("//button[@onclick='jsPrompt()']")).Click();
        alert = driver.SwitchTo().Alert();
        alert.SendKeys("input test abc");
        alert.Dismiss();
        // assert message that cancel has been clicked
        Assert.That(driver.FindElement(By.Id("result")).Text,Is.EqualTo("You entered: null"));
    }

    [TearDown]
    public void TearDown()
    {
        driver.Quit();
    }
}