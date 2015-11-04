namespace Arrowgene.StepFiles.Test
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Model;
    using PolePosition.Test;
    using Read;

    [TestClass]
    public class ReadFileTest : TestBase
    {
        private const string SIM_FILE_BANYA = "101 - Ignition Starts - Banya.sm";
        private const string SIM_FILE_RENAISSANCE = "Renaissance.sm";

        [TestMethod]
        [DeploymentItem(@"..\..\TestFiles\")]
        public void CanReadFile()
        {
            StepFileReader reader = new StepFileReader();
            StepFile stepFile = reader.Read(SIM_FILE_RENAISSANCE);

            base.TestContext.WriteLine(stepFile.Artist);

            Assert.IsNotNull(stepFile);
        }
    }
}