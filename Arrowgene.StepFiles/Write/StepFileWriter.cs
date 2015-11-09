namespace Arrowgene.StepFiles.Write
{
    using Arrowgene.StepFiles.Model;
    using System.Collections.Generic;
    using System.IO;
    using WriteImpl;

    public class StepFileWriter
    {
        private Dictionary<string, IStepFileWriter> stepFileWriter;

        public StepFileWriter()
        {
            stepFileWriter = new Dictionary<string, IStepFileWriter>();
            stepFileWriter.Add(".sm", new SimFileWriter());
        }

        public void AddWriter(string fileExtension, IStepFileWriter writer)
        {
            this.stepFileWriter.Add(fileExtension, writer);
        }

        public void Write(StepFile stepFile, string destiantionPath)
        {
            string fileExtension = Path.GetExtension(destiantionPath);

            if (this.stepFileWriter.ContainsKey(fileExtension))
            {
                this.stepFileWriter[fileExtension].Write(stepFile, destiantionPath);
            }
        }

    }
}