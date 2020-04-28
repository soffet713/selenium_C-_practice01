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
    class FunctionsPage : ChromeDriver
    {
        IDictionary<int, string> func_call = new Dictionary<int, string>()
            {
                { 0, "The Fibonacci Sequence" },
                { 1, "The Greatest Common Divisor" },
                { 2, "The Factorial Function" },
                { 3, "Check Prime" },
                { 4, "Display Primes" },
                { 5, "Reverse the String" },
                { 6, "フィボナッチ数列" },
                { 7, "最大公約数" },
                { 8, "階乗" },
                { 9, "素数の確認" },
                { 10, "素数の表示" },
                { 11, "文字を逆にする" }
            };

        public void test_func_single(int x, int num, string input_id, string compute, string reset, string top)
        {
            FindElement(By.XPath("//button[text()='" + func_call[x] + "']")).Click();
            Thread.Sleep(TimeSpan.FromSeconds(2));
            FindElementById(input_id).SendKeys(num.ToString());
            Thread.Sleep(TimeSpan.FromSeconds(2));
            FindElementById(compute).Click();
            ExecuteScript("window.scrollTo(0,document.body.scrollHeight)");
            Thread.Sleep(TimeSpan.FromSeconds(2));
            ExecuteScript("window.scrollTo(0,0)");
            Thread.Sleep(TimeSpan.FromSeconds(2));
            FindElementById(reset).Click();
            Thread.Sleep(TimeSpan.FromSeconds(2));
            FindElementById(top).Click();
        }

        public void test_func_dual(int y, int num1, int num2, string input1_id, string input2_id, string compute, string reset, string top)
        {
            FindElement(By.XPath("//button[text()='" + func_call[y] + "']")).Click();
            Thread.Sleep(TimeSpan.FromSeconds(2));
            FindElementById(input1_id).SendKeys(num1.ToString());
            FindElementById(input2_id).SendKeys(num2.ToString());
            Thread.Sleep(TimeSpan.FromSeconds(2));
            FindElementById(compute).Click();
            ExecuteScript("window.scrollTo(0,document.body.scrollHeight)");
            Thread.Sleep(TimeSpan.FromSeconds(2));
            ExecuteScript("window.scrollTo(0,0)");
            Thread.Sleep(TimeSpan.FromSeconds(2));
            FindElementById(reset).Click();
            Thread.Sleep(TimeSpan.FromSeconds(2));
            FindElementById(top).Click();
        }

        public void test_rev_string(int z, string strng, string strng_input, string rev_ltr, string orig_strng, string reset, string top, string rev_wrd = null, string rev_wrd_let = null)
        {
            FindElement(By.XPath("//button[text()='" + func_call[z] + "']")).Click();
            Thread.Sleep(TimeSpan.FromSeconds(2));
            FindElementById(strng_input).SendKeys(strng);
            Thread.Sleep(TimeSpan.FromSeconds(2));
            FindElementById(rev_ltr).Click();
            Thread.Sleep(TimeSpan.FromSeconds(5));
            if (rev_wrd != null) {
                FindElementById(rev_wrd).Click();
                Thread.Sleep(TimeSpan.FromSeconds(5));
            }
            if (rev_wrd_let != null)
            {
                FindElementById(rev_wrd_let).Click();
                Thread.Sleep(TimeSpan.FromSeconds(5));
            }
            FindElementById(orig_strng).Click();
            Thread.Sleep(TimeSpan.FromSeconds(5));
            FindElementById(reset).Click();
            Thread.Sleep(TimeSpan.FromSeconds(2));
            FindElementById(top).Click();
        }

        public void test_packing_list()
        {
            ReadOnlyCollection<IWebElement> packing_list_ps = FindElements(By.TagName("p"));
            ReadOnlyCollection<IWebElement> packing_list_buttons = FindElements(By.TagName("button"));

            int numbuttons = packing_list_buttons.Count;
            for (int i = 1; i < numbuttons; i++)
            {
                FindElementByXPath("//button[text()='" + packing_list_buttons[i].Text + "']").Click();
                Thread.Sleep(TimeSpan.FromSeconds(1));
            }

            int numps = packing_list_ps.Count;
            for (int a = 0; a < numps; a++)
            {
                packing_list_ps[a].Click();
                Thread.Sleep(TimeSpan.FromSeconds(1));
            }

            Thread.Sleep(TimeSpan.FromSeconds(2));
            SwitchTo().Alert().Accept();
        }
    }
}
