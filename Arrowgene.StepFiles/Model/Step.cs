namespace Arrowgene.StepFiles.Model
{
    /// <summary>
    /// A model for a single step of any orientation, type, game mode or timing.
    /// </summary>
    public class Step
    {
        public Step(StepFile stepFile)
        {
            this.StepFile = stepFile;
            this.Index = 0;
            this.StepType = StepType.None;
        }

        public StepFile StepFile { get; private set; }
        public int Index { get; set; }
        public StepType StepType { get; set; }

        public bool IsValid()
        {
            bool isValid = true;
            return isValid;
        }
    }
}
