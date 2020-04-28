using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.ObjectModel;

namespace KTW_VS_Selenium
{
    class WordPressPage : ChromeDriver
    {
        public void test_wp_page(string linkname)
        {
            FindElementByLinkText(linkname).Click();
            Thread.Sleep(TimeSpan.FromSeconds(3));
            FindElement(By.Id("colorbox")).Click();
            Thread.Sleep(TimeSpan.FromSeconds(7));
            FindElement(By.Id("colorbox")).Click();
            Thread.Sleep(TimeSpan.FromSeconds(3));
            ExecuteScript("document.getElementById('cboxOverlay').style.visibility='hidden';");
            ExecuteScript("document.getElementById('colorbox').style.visibility='hidden';");
            Thread.Sleep(TimeSpan.FromSeconds(2));
        }
    }
}
