namespace Arrowgene.StepFiles.Model
{
    using System.Collections.Generic;

    /// <summary>
    /// A model for all the data within a sim file. Sim files contain multiple difficulties,
    /// each can be of a different game mode.Meta data that is not specific to a difficulty
    /// is modelled here.
    /// </summary>
    public class StepFile
    {
        public StepFile()
        {
            this.Difficulties = new List<Difficulty>();
        }

        public string Artist { get; set; }
        public List<Beat> BPMs { get; set; }
        public List<Beat> Stops { get; set; }
        public string Credit { get; set; }
        public string Genre { get; set; }
        public string Offset { get; set; }
        public string SampleStart { get; set; }
        public string Title { get; set; }
        public int Id { get; set; }
        public string FileExtension { get; set; }
        public string Producer { get; set; }
        public string FileName { get; set; }

        public List<Difficulty> Difficulties { get; set; }
    }
}
