using System.Collections.Generic;

namespace Arrowgene.StepFiles.Model
{
    /// <summary>
    /// A model for a single line in a step chart. Contains several steps, the number
    /// depending on what game mode the line is for. There is a line at every fraction
    /// of a beat.
    /// </summary>
    public class Line
    {
        public Line()
        {
            this.Steps = new List<Step>();
            this.Index = 0;
        }

        public int Index { get; set; }
        public List<Step> Steps { get; set; }
    }
}