using System;
using System.Threading;
using OpenQA.Selenium;
using System.Collections.ObjectModel;
using System.Windows.Forms;

namespace KTW_VS_Selenium
{
    public partial class Selenium_Web_Tests : Form
    {
        public Selenium_Web_Tests()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            test_projects_page();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            test_wordpress_page();
        }

        private void test_projects_page()
        {
            //Create a new instance of a Functions Page that inherits from the Chrome WebDriver

            FunctionsPage my_page = new FunctionsPage();
            my_page.Manage().Window.Maximize();
            my_page.Navigate().GoToUrl("http://killertechwolf.com/SeanProjects/Index.html");
            my_page.FindElement(By.Id("Bi_Functions")).Click();
            Thread.Sleep(TimeSpan.FromSeconds(5));
            bool eng_functions = true, jp_functions = false;
            var rand = new Random();
            my_page.FindElement(By.Id("eng_button")).Click();
            my_page.SwitchTo().Alert().SendKeys("Sean");
            my_page.SwitchTo().Alert().Accept();
            Thread.Sleep(TimeSpan.FromSeconds(3));


            //While on the English math functions page, go through each function and test its functionality

            while (eng_functions)
            {
                my_page.test_func_single(0, rand.Next(10, 102), "fibonacci1", "fib_compute", "fib_reset", "fib_top_return");
                Thread.Sleep(TimeSpan.FromSeconds(5));
                my_page.test_func_dual(1, rand.Next(1, 10000000), rand.Next(1, 10000000), "greatcomdiv1", "greatcomdiv2",
                                 "gcd_compute", "gcd_reset", "gcd_top_return");
                Thread.Sleep(TimeSpan.FromSeconds(5));
                my_page.test_func_single(2, rand.Next(1, 21), "factorialInput", "fact_compute", "fact_reset", "fact_top_return");
                Thread.Sleep(TimeSpan.FromSeconds(5));
                my_page.test_func_single(3, rand.Next(1, 1000000000), "primeNumberInput", "chkprime_compute", "chkprime_reset",
                                 "chkprime_top_return");
                Thread.Sleep(TimeSpan.FromSeconds(5));
                my_page.test_func_single(4, rand.Next(1, 1000), "numbprimesInput", "primedisp_compute", "primedisp_reset",
                                 "primedisp_top_return");
                Thread.Sleep(TimeSpan.FromSeconds(5));

                string test_string = "Testing automation with Selenium in Python";

                my_page.test_rev_string(5, test_string, "stringreverse1", "reverse_letters", "orig_string", "string_reset", "string_top_return", "reverse_words", "rev_words_letters");
                Thread.Sleep(TimeSpan.FromSeconds(3));
                jp_functions = eng_functions;
                eng_functions = false;
            }


            //On the top page, change the language to Japanese

            my_page.FindElementById("jp_lang").Click();
            my_page.SwitchTo().Alert().SendKeys("ショーン");
            my_page.SwitchTo().Alert().Accept();
            Thread.Sleep(TimeSpan.FromSeconds(3));

            //While on the Japanese functions page, iterate through each and test the functionality

            while (jp_functions)
            {
                my_page.test_func_single(6, rand.Next(10, 102), "fibonacciJ1", "fib_computeJ", "fib_resetJ", "fib_top_returnJ");
                Thread.Sleep(TimeSpan.FromSeconds(5));
                my_page.test_func_dual(7, rand.Next(1, 10000000), rand.Next(1, 10000000), "greatcomdivJ1", "greatcomdivJ2",
                                 "gcd_computeJ", "gcd_resetJ", "gcd_top_returnJ");
                Thread.Sleep(TimeSpan.FromSeconds(5));
                my_page.test_func_single(8, rand.Next(1, 21), "factorialJInput", "fact_computeJ", "fact_resetJ", "fact_top_returnJ");
                Thread.Sleep(TimeSpan.FromSeconds(5));
                my_page.test_func_single(9, rand.Next(1, 1000000000), "primeNumberJInput", "chkprime_computeJ", "chkprime_resetJ",
                                 "chkprime_top_returnJ");
                Thread.Sleep(TimeSpan.FromSeconds(5));
                my_page.test_func_single(10, rand.Next(1, 1000), "numbprimesJInput", "primedisp_computeJ", "primedisp_resetJ",
                                 "primedisp_top_returnJ");
                Thread.Sleep(TimeSpan.FromSeconds(5));

                string test_stringJ = "パイソンのプログラミング言語でSeleniumのテストスクリプトを勉強してる。";

                my_page.test_rev_string(11, test_stringJ, "stringreverse1J", "reverse_lettersJ", "orig_stringJ", "string_resetJ", "string_top_returnJ");
                Thread.Sleep(TimeSpan.FromSeconds(3));
                jp_functions = false;
            }

            my_page.FindElementByXPath("//button[text()='Projects Top']").Click();
            Thread.Sleep(TimeSpan.FromSeconds(3));
            my_page.FindElementById("Japan_Packing").Click();
            Thread.Sleep(TimeSpan.FromSeconds(3));
            my_page.test_packing_list();
            my_page.FindElementByXPath("//button[text()='Projects Top']").Click();
            Thread.Sleep(TimeSpan.FromSeconds(3));

            my_page.Close();
        }

        private void test_wordpress_page()
        {
            WordPressPage wp_page = new WordPressPage();
            wp_page.Manage().Window.Maximize();
            wp_page.Navigate().GoToUrl("http://www.killertechwolf.com/WordPressPages/Sean");
            Thread.Sleep(TimeSpan.FromSeconds(7));

            ReadOnlyCollection<IWebElement> vids = wp_page.FindElementsByXPath("//a[@class='popup cboxElement']");

            for (int i = 0; i < vids.Count; i++)
            {
                wp_page.test_wp_page(vids[i].Text);
            }

            wp_page.ExecuteScript("window.scrollTo(0,0)");
            Thread.Sleep(TimeSpan.FromSeconds(3));

            wp_page.Close();
        }

    }
}
