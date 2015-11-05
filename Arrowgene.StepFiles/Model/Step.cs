namespace Arrowgene.StepFiles.Model
{
    /// <summary>
    /// A model for a single step of any orientation, type, game mode or timing.
    /// </summary>
    public class Step
    {
        public Step()
        {
            this.Index = 0;
            this.StepType = StepType.None;
        }

        public int Index { get; set; }
        public StepType StepType { get; set; }
    }
}
