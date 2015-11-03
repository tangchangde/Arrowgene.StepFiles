namespace Arrowgene.StepFiles.Write
{
    using Arrowgene.StepFiles.Model;
    public interface IStepFileWriter
    {
        void Write(StepFile stepFile, string destinationPath);
    }
}
