namespace Arrowgene.StepFiles.Read
{
    using Model;
    using Arrowgene.StepFiles;
    using System.Collections.Generic;
    using System.IO;
    using ReadImpl;

    /// <summary>
    /// Reader to read different stepfiles and create an object,
    /// that can then be used for further processing. 
    /// (e.g. write it as an different stepfile format to disk)
    /// </summary>
    public class StepFileReader
    {
        private Dictionary<string, IStepFileReader> stepFileReader;

        /// <summary>
        /// Creates a new instance of the Class.
        /// </summary>
        public StepFileReader()
        {
            stepFileReader = new Dictionary<string, IStepFileReader>();
            stepFileReader.Add(".sm", new SimFileReader());
        }

        /// <summary>
        /// Add your own reader implemention.
        /// If you add a reader for an already existing file extension, 
        /// then the previous reader will be replaced by the newly provided one.
        /// </summary>
        /// <param name="fileExtension"></param>
        /// <param name="reader"></param>
        public void AddReader(string fileExtension, IStepFileReader reader)
        {
            if (this.stepFileReader.ContainsKey(fileExtension))
            {
                this.stepFileReader[fileExtension] = reader;
            }
            else
            {
                this.stepFileReader.Add(fileExtension, reader);
            }
        }

        /// <summary>
        /// Returns a list of registered file extensions the reader can handle.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> GetSupportedExtensions()
        {
            return this.stepFileReader.Keys;
        }

        /// <summary>
        /// Reads a file from the given path and 
        /// creates an <see cref="StepFile"/> object with the appropriate reader implementation.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public StepFile Read(string filePath)
        {
            StepFile stepFile = null;

            string fileExtension = Path.GetExtension(filePath);

            if (this.stepFileReader.ContainsKey(fileExtension))
            {
                stepFile = this.stepFileReader[fileExtension].Read(filePath);
            }

            return stepFile;
        }
    }
}