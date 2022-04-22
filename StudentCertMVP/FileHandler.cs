﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCertMVP
{
    internal class FileHandler
    {
        public string studentFileDir { get; set; }
        public string mainDirectory { get; set; }

        /// <summary>
        /// Constructor. Requires a root directory to be provided to begin parsing student files
        /// </summary>
        /// <param name="mainDirectory">root directory</param>
        public FileHandler(string mainDirectory)
        {
            this.mainDirectory = mainDirectory;
        }

        /// <summary>
        /// parses root directory for filename that contain a matching student Id
        /// </summary>
        /// <param name="studentId">student ID to parse</param>
        /// <returns>filepath of students file</returns>
        public string getFilePath(string studentId)
        {
            string result = string.Empty;
            foreach (string fileName in Directory.GetDirectories(mainDirectory))
            {
                if (fileName.Contains(studentId))
                {
                    this.studentFileDir = fileName;
                    result = fileName;
                    break;//save processing time break when file is found
                }
            }

            return result;
        }
        /// <summary>
        /// parses student file for degree program tracker filepaths
        /// </summary>
        /// <returns>list of all program trackers</returns>
        /// <exception cref="Exception">exception is thrown if there is no studentFileDir stored in the parameters</exception>
        public List<string> getExcelFilePaths()
        {
            List<string> result = new List<string>();
            if (this.studentFileDir != null)
            {              
                foreach (string fileName in Directory.GetFiles(studentFileDir))
                {
                    if (fileName.Contains(".xlsx"))
                    {
                        result.Add(fileName);
                    }
                }
            }
            else
            {
                throw new Exception("ERROR: FileHandler object does not contain a student file directory. student ID must be provided before" +
                    "searching for program trackers");
            }
            return result;
        }
    }
}
