using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        private IWebDriver driver = new OpenQA.Selenium.Chrome.ChromeDriver();

        //Тестируем открытие сайта
        [TestMethod]
        public void Open_Site()
        {
            driver.Navigate().GoToUrl("https://careers.veeam.ru/vacancies"); //переходим на сайт
            driver.Manage().Window.Maximize(); //Разворачиваем во весь экран
        }

        //Тестируем выбор отдела на сайте
        [TestMethod]
        public void Choose_Department()
        {
            Open_Site();
           driver.FindElement(By.XPath("//button[text()='Все отделы']")).Click(); //нажимвем на кнопку для выбора отдела
            driver.FindElement(By.XPath("//a[text()='Разработка продуктов']")).Click(); //Выбираем отдел "Разработка продуктов"
        }

        //Тестируем выбор языка на сайте
        [TestMethod]
        public void Choose_Language()
        {
            Open_Site();
            Choose_Department();
            driver.FindElement(By.XPath("//button[text()='Все языки']")).Click(); //нажимвем на кнопку для выбора языка
            driver.FindElement(By.XPath("//label[text()='Английский']")).Click(); //Выбираем язык "Английский"
        }

        [TestMethod]
        public void Comparasion()
        {
            Open_Site();
            Choose_Department();
            Choose_Language();
            int expected_result = 4;
            int result = driver.FindElements(By.XPath("//a[text()='Подробнее']")).Count;
            Assert.AreEqual(expected_result, result);
        }
    }
}
