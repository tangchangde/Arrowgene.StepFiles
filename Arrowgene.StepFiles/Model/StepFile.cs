namespace Arrowgene.StepFiles.Model
{
    /// <summary>
    /// A model for all the data within a sim file. Sim files contain multiple difficulties,
    /// each can be of a different game mode.Meta data that is not specific to a difficulty
    /// is modelled here.
    /// </summary>
    public class StepFile
    {
        public string Artist { get; set; }
        public string BPM { get; set; }
        public string Credit { get; set; }
        public string Genre { get; set; }
        public string Offset { get; set; }
        public string SampleStart { get; set; }
        public string Title { get; set; }
    }
}
