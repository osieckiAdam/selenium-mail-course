using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Linq;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using System;

namespace EndToEndMailCourse._07
{
    [TestFixture]
    public class Workshop07Tests
    {
        private string testUrl = "https://suvroc.github.io/selenium-mail-course/07/workshop.html";

        [Test]
        public void ShouldSelectAnswers()
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl(testUrl);

            var companySelectElement = driver.FindElement(By.Id("companySelect"));
            var carSelectElement = driver.FindElement(By.Id("carSelect"));
            
            #region TEST CODE
            var companySelect = new SelectElement(companySelectElement);
            var carSelect = new SelectElement(carSelectElement);
            var waiter = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

            companySelect.SelectByIndex(1);
            waiter.
                Until(ExpectedConditions.ElementToBeClickable(carSelectElement));
            carSelect.SelectByIndex(3);
            waiter.
                Until(ExpectedConditions.ElementExists(By.XPath("//*[@id=\"results\"]/a[5]")));


            #endregion

            Assert.AreEqual(driver.FindElements(By.ClassName("list-group-item")).Count(), 6);


            driver.Quit();
        }
    }
}
