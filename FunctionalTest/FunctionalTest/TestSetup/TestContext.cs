using FunctionalTest.Pages;

namespace FunctionalTest.TestSetup
{
    public class TestContext
    {
        private BasePage _currentPage;

        public BasePage CurrentPage
        {
            get
            {
                return _currentPage;

            }
            set { _currentPage = value; }
        }

        public T GetCurrentPageAs<T>() where T : BasePage
        {
            return CurrentPage as T;
        }
    }
}
