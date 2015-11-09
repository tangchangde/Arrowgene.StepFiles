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

        public int Duration { get; set; }
        public int Level { get; set; }
        public List<Measure> Measures { get; set; }


        public int GetNoteCount()
        {
            int count = 0;
            foreach (Measure measure in Measures)
            {
                foreach (Line line in measure.Lines)
                {
                    foreach (Step step in line.Steps)
                    {
                        if (step.StepType != StepType.None)
                        {
                            count++;
                        }
                    }
                }
            }
            return count;
        }



    }
}
