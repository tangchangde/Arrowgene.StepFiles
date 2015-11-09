namespace Arrowgene.StepFiles.Test
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Model;
    using PolePosition.Test;
    using Read;
    using System.IO;
    using Write;

    [TestClass]
    public class SimFileTest : TestBase
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


        [TestMethod]
        [DeploymentItem(@"..\..\TestFiles\")]
        public void CanWriteFile()
        {
            StepFileReader reader = new StepFileReader();
            StepFile stepFile = reader.Read(SIM_FILE_RENAISSANCE);


            string testFileName = "test.sm";

            StepFileWriter writer = new StepFileWriter();
            writer.Write(stepFile, testFileName);


            Assert.IsTrue(File.Exists(testFileName));
        }




    }
}