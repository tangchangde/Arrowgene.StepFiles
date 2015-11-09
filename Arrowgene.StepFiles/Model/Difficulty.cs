namespace Arrowgene.StepFiles.Model
{
    using System.Collections.Generic;

    /// <summary>
    /// A model for a single difficulty in a step file. 
    /// Contains step data, and meta data specific to the difficulty.
    /// </summary>
    public class Difficulty
    {
        public Difficulty(StepFile stepFile)
        {
            this.StepFile = stepFile;
            this.Measures = new List<Measure>();
            this.Level = 0;
            this.ChartType = ChartType.None;
        }

        public StepFile StepFile { get; private set; }
        public int Level { get; set; }
        public ChartType ChartType { get; set; }
        public List<Measure> Measures { get; set; }

        public bool IsValid()
        {
            bool isValid = true;

    

            foreach (Measure measure in this.Measures)
            {
                if (!measure.IsValid())
                {
                    isValid = false;
                    break;
                }
            }

            return isValid;
        }
    }
}
