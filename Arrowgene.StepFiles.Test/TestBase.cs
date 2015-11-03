namespace PolePosition.Test
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Collection of Reusable Unit Test Methods
    /// </summary>
    public abstract class TestBase
    {
        /// <summary>
        /// TextContext will be set automatically by IDE.
        /// </summary>
        private TestContext testContextInstance;

        /// <summary>
        /// Gets or sets the test context which provides
        /// information about and functionality for the current test run.
        /// </summary>
        public TestContext TestContext { get { return testContextInstance; } set { testContextInstance = value; } }
    }
}