namespace Arrowgene.StepFiles.Read.ReadImpl
{
    using Arrowgene.StepFiles.Model;
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class SimFileReader : IStepFileReader
    {
        private const int HASHTAG = 35;
        private const int COLON = 58;
        private const int SEMICOLON = 59;

        private const string NOTE_KEY = "NOTES";

        public SimFileReader()
        {

        }

        public StepFile Read(string filePath)
        {
            // A .sm file is primarily composed of two major sections: the header, and the chart data. The .sm file format is mostly a key/value store, though the actual note and chart data is a bit more complex.

            StepFile stepFile = new StepFile();
            Dictionary<string, string> simFileMetaEntries = new Dictionary<string, string>();
            List<string> simNoteEntries = new List<string>();
            byte[] bytes = null;

            using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                if (fileStream.Length > Int32.MaxValue)
                {
                    throw new FileLoadException(string.Format("File size {0}bytes exceeds maximum length of {0}bytes", fileStream.Length, Int32.MaxValue), filePath);
                }

                int length = (int)fileStream.Length;
                bytes = new byte[length];
                fileStream.Read(bytes, 0, length);
            }

            if (bytes != null)
            {
                using (MemoryStream stream = new MemoryStream(bytes))
                {
                    int symbol;
                    while ((symbol = stream.ReadByte()) >= 0)
                    {
                        if (symbol == HASHTAG)
                        {
                            string key = this.ReadTillChar(stream, COLON);
                            string value = this.ReadTillChar(stream, SEMICOLON);
                            if (key == NOTE_KEY)
                            {
                                simNoteEntries.Add(value);
                            }
                            else
                            {
                                simFileMetaEntries.Add(key, value);
                            }
                        }
                    }
                }
            }

            this.ParseMeta(simFileMetaEntries, stepFile);
            this.ParseNotes(simNoteEntries, stepFile);

            return stepFile;
        }

        private string ReadTillChar(MemoryStream stream, int character)
        {
            string readCharacters = string.Empty;
            int symbol;
            while ((symbol = stream.ReadByte()) >= 0 && symbol != character)
            {
                readCharacters += (char)symbol;
            }
            return readCharacters;
        }

        private void ParseMeta(Dictionary<string, string> simFileMetaEntries, StepFile stepFile)
        {
            // Header Tags
            // The header tags are song - specific and are shared between all charts. Most header tags follow the format #TAG:VALUE;, though some tags have their own format.

            // Sets the primary title of the song.
            if (simFileMetaEntries.ContainsKey("TITLE"))
            {
                stepFile.Title = simFileMetaEntries["TITLE"];
            }

            // Sets the subtitle of the song.
            if (simFileMetaEntries.ContainsKey("SUBTITLE"))
            {
            }

            // Sets the artist of the song.
            if (simFileMetaEntries.ContainsKey("ARTIST"))
            {
                stepFile.Artist = simFileMetaEntries["ARTIST"];
            }

            // Sets the transliterated primary title of the song, used when ShowNativeLanguage = 0.
            if (simFileMetaEntries.ContainsKey("TITLETRANSLIT"))
            {
            }

            // Sets the transliterated subtitle of the song, used when ShowNativeLanguage = 0.
            if (simFileMetaEntries.ContainsKey("SUBTITLETRANSLIT"))
            {
            }

            // Sets the transliterated artist of the song, used when ShowNativeLanguage = 0.
            if (simFileMetaEntries.ContainsKey("ARTISTTRANSLIT"))
            {
            }

            // Sets the genre of the song.
            if (simFileMetaEntries.ContainsKey("GENRE"))
            {
                stepFile.Genre = simFileMetaEntries["GENRE"];
            }

            // Define's the simfile's origin (author or pack/mix).
            if (simFileMetaEntries.ContainsKey("CREDIT"))
            {
                stepFile.Credit = simFileMetaEntries["CREDIT"];
            }

            // Sets the path to the banner image for the song. Banner images are typically rectangular, with common sizes being 256x80(DDR), 418x164(ITG), and 512x160(2x DDR).
            if (simFileMetaEntries.ContainsKey("BANNER"))
            {
            }

            // Sets the path to the background image for the song. Background images are typically 640x480 or greater in resolution.
            if (simFileMetaEntries.ContainsKey("BACKGROUND"))
            {
            }

            // Sets the path to the lyrics file to use. (todo: explain.lrc format ?)
            if (simFileMetaEntries.ContainsKey("LYRICSPATH"))
            {
            }

            // Sets the path to the CD Title, a small image meant to show the origin of the song.The recommended size is around 64x48, though a number of people ignore this and make big stupid ones for some dumb reason.
            if (simFileMetaEntries.ContainsKey("CDTITLE"))
            {
            }

            // Sets the path to the music file for this song.
            if (simFileMetaEntries.ContainsKey("MUSIC"))
            {
            }

            // Sets the offset between the beginning of the song and the beginning of the notes.
            if (simFileMetaEntries.ContainsKey("OFFSET"))
            {
                stepFile.Offset = simFileMetaEntries["OFFSET"];
            }

            // Sets the BPMs for this song. BPMS are defined in the format Beat=BPM, with each value separated by a comma.
            if (simFileMetaEntries.ContainsKey("BPMS"))
            {
                stepFile.BPM = simFileMetaEntries["BPMS"];
            }

            // Sets the stops for this song. Stops are defined in the format Beat=Seconds, with each value separated by a comma.
            if (simFileMetaEntries.ContainsKey("STOPS"))
            {
               // TODO How to handle?
            }

            // Sets the start time of the song sample used on ScreenSelectMusic.
            if (simFileMetaEntries.ContainsKey("SAMPLESTART"))
            {
                stepFile.SampleStart = simFileMetaEntries["SAMPLESTART"];
            }

            // Sets the length of the song sample used on ScreenSelectMusic.
            if (simFileMetaEntries.ContainsKey("SAMPLELENGTH"))
            {
            }

            // This can be used to override the BPM shown on ScreenSelectMusic.This tag supports three types of values:
            // A number by itself(e.g. #DISPLAYBPM:180;) will show a static BPM.
            // Two numbers in a range(e.g. #DISPLAYBPM:90-270;) will show a BPM that changes between two values.
            // An asterisk(#DISPLAYBPM:*;) will show a BPM that randomly changes.
            if (simFileMetaEntries.ContainsKey("DISPLAYBPM"))
            {
            }

            // Determines if the song is selectable under normal conditions.
            // Valid values are YES and NO.
            if (simFileMetaEntries.ContainsKey("SELECTABLE"))
            {
            }

            // Defines the background changes for this song. 
            // The format for each change is as follows: Beat = BGAnim =? float =? int =? int =? int.
            if (simFileMetaEntries.ContainsKey("BGCHANGES"))
            {
            }

            // Defines the foreground changes for this song. 
            // Format is the same as #BGCHANGES.
            if (simFileMetaEntries.ContainsKey("FGCHANGES"))
            {
            }
        }

        private void ParseNotes(List<string> simNoteEntries, StepFile stepFile)
        {
            /*
            # NOTES
            The Notes tag contains the following information:

            Chart type (e.g.dance - single)
            Description / author
            Difficulty(one of Beginner, Easy, Medium, Hard, Challenge, Edit)
            Numerical meter
            Groove radar values, generated by the program
            and finally, the note data itself.
            The first five values are postfixed with a colon.Groove radar values are separated with commas.

            Note data itself is a bit more complex; there's one character for every possible playable column in a chart type. Note types (e.g. 4th, 8th, etc.) are determined by how many rows exist before the comma (which separates measures).

            Note Values
            These are the standard note values:

            0 – No note
            1 – Normal note
            2 – Hold head
            3 – Hold / Roll tail
            4 – Roll head
            M – Mine
            Later versions of StepMania accept other note values which may not work in older versions:

            K – Automatic keysound
            L – Lift note
            F – Fake note
            Non - Standard Tags
            You might run into some .sm files with some non - standard tags.Though these aren't supported by StepMania, they're good to know.
            */
        }




    }
}

/*
Mine: A note that you are not meant to hit. In fact, if you are holding the key corresponding to its column when it passes the target, it will explode and lower your life and score dramatically. In ITG and in noteskins that do not alter it, looks like a rotating metal circle with a flashing red center, but many alternate graphics exist.
Mines are often used, not to make a file harder, but to make it visually more interesting. See Mine Theory.
A dense column of mines can be playfully referred to as a mine hold, and if accidentally hit will result in failing fast. Mines on all columns is a mine wall. Mines roughly uniformly injected around notes is called a mine field.
Stepmania and ITG are (as far as I know) the only games implementing mines.

BPM: Beats per minute, or a measure of how fast the song is. To find the BPM, use Mixmeister BPM Analyzer on the song and round to the nearest whole number. If it reports the wrong number or if the song is made of multiple BPMs, time it using This page and use the nearest 'right sounding' number, and adjusting if you see it go off later. If a song has a speed up, slowdown or 'drifting' BPM, use low rates and trial and error to ensure every beat is on sync.
BPM change: A change in the BPM mid chart. Mandatory if the song changes BPM, but it can also be used to create BPM gimmicks where BPM changes are used to change the speed of the chart (and of anything that animates) in a way that either increases difficulty or is expressive and visually pleasing.
BPM gimmicks can easily be made by using the stepmania editor's 'expand/compress' tools which are accessed by making a selection by holding shift and moving then accessing the menu under enter. (Please ensure that the chart is valid before saving! There are some bugs.)

Stop: A pause in the chart that lasts a certain number of milliseconds. Because it is expressed in milliseconds and not fractions of beats, it will be a tiny amount offsync with most bpms and you will need to make adjustments manually if lots of stops are used so that you do not get drift. They are very rarely used for syncing and mostly used for BPM gimmicks.

BPM gimmicks involving stops can easily be made by using the stepmania editor's 'convert beats to pause' tool which is accessed by making a selection by holding shift and moving then accessing the menu under enter. (Please ensure the chart is valid before saving! There are some bugs.)
If you need to calculate a stop by hand, perform this calculation:
Length of one beat = 60/BPM
Length of half a beat = length of one beat /2
Length of one third of a beat = length of one beat /3
et cetera. Most bpms will give you a number that has more decimal places than three; to ensure your chart does not drift, manually edit some of the stops in the .sm so that, on average, they add up to the rest of the number. For instance, if you have many 0.33333... length stops, make every third one 0.334. (Reload from disk after you do this to save your changes.)
If you place a stop on a triplet fraction of a beat (such as 0.33333... or 0.66666...) please manually edit the .sm and add 1 to the last digit, i.e. to make it 0.334 or 0.667, then reload from disk. Why? If you do not, on some versions of Stepmania (e.g. 3.9), the stop (which is at 0.333) will be considered to be before the note (which is at 0.33333...). Most people would expect the stop to take 

*/
