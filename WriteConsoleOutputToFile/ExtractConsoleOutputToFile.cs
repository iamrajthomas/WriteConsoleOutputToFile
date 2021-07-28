//  -------------------------------------------------------------------------
//  <copyright file="ExtractConsoleOutputToFile.cs"  author="Rajesh Thomas | iamrajthomas" >
//      Copyright (c) 2021 All Rights Reserved.
//  </copyright>
// 
//  <summary>
//       ExtractConsoleOutputToFile is a dedicated class for Extracting Console Output To File
//  </summary>
//  -------------------------------------------------------------------------

namespace WriteConsoleOutputToFile
{
    using System;
    using System.IO;
    using System.Text;

    /// <summary>
    /// ExtractConsoleOutputToFile Class
    /// </summary>
    public class ExtractConsoleOutputToFile : TextWriter
    {
        #region Fields  
        private Encoding encoding = Encoding.UTF8;
        private StreamWriter streamWriter;
        private TextWriter console;
        #endregion

        #region Properties  
        /// <summary>
        /// Encoding Property
        /// </summary>
        public override Encoding Encoding
        {
            get
            {
                return encoding;
            }
        }
        #endregion

        #region Constructors  
        /// <summary>
        /// ExtractConsoleOutputToFile Constructor
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="console"></param>
        /// <param name="encoding"></param>
        public ExtractConsoleOutputToFile(string filePath = "Output.txt", TextWriter console = null, Encoding encoding = null)
        {
            if (encoding != null)
            {
                this.encoding = encoding;
            }
            this.console = console ?? Console.Out;
            this.streamWriter = new StreamWriter(filePath, false, this.encoding);
            this.streamWriter.AutoFlush = true;
        }
        #endregion

        #region Overrides  
        /// <summary>
        /// Write Method
        /// </summary>
        /// <param name="value"></param>
        public override void Write(string value)
        {
            Console.SetOut(console);
            Console.Write(value);
            Console.SetOut(this);

            if (this.streamWriter.BaseStream != null)
                this.streamWriter.Write(value);
        }

        /// <summary>
        /// WriteLine Method
        /// </summary>
        /// <param name="value"></param>
        public override void WriteLine(string value)
        {
            Console.SetOut(console);
            Console.WriteLine(value);

            if (this.streamWriter.BaseStream != null)
                this.streamWriter.WriteLine(value);
            Console.SetOut(this);
        }

        /// <summary>
        /// Flush
        /// </summary>
        public override void Flush()
        {
            this.streamWriter.Flush();
        }

        /// <summary>
        /// Close
        /// </summary>
        public override void Close()
        {
            this.streamWriter.Close();
        }
        #endregion

        #region IDisposable  
        /// <summary>
        /// Dispose
        /// </summary>
        new public void Dispose()
        {
            this.streamWriter.Flush();
            this.streamWriter.Close();
            this.streamWriter.Dispose();
            base.Dispose();
        }

        #endregion
    }
}
