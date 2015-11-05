namespace Arrowgene.StepFiles.Model
{
    using System.Collections.Generic;

    /// <summary>
    /// A model for a single difficulty in a sim file. Contains step data, and meta data
    /// specific to the difficulty.
    /// </summary>
    public class Difficulty
    {
        public Difficulty()
        {
            this.Measures = new List<Measure>();
            this.Level = 0;
        }

        public int Level { get; set; }
        public List<Measure> Measures { get; set; }
    }
}
