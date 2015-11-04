namespace Arrowgene.StepFiles.Model
{
    using System.Collections.Generic;

    /// <summary>
    /// A model for all the data contained within a single measure of a step chart. A measure
    /// is equivalent to a musical measure in the song: contains a set number of beats, and
    /// step lines for each beat step(or fraction of a beat).
    /// </summary>
    public class Measure
    {
        public Measure()
        {
            this.Lines = new List<Line>();
        }

        public List<Line> Lines { get; set; }
    }
}