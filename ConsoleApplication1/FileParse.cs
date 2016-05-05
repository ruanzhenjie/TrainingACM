using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace CSharpIOTest
{
    class FileParse
    {
        private string filePath;//文件路径
        private string fileName;//文件名
        private string fileContent;//文件内容

        public FileParse()
        {
            filePath = string.Empty;
            fileName = string.Empty;
            fileContent = string.Empty;
        }

        public FileParse(string file)
        {
            filePath = file;
        }

        public string FilePath
        {
            set { filePath = value; }
            get { return filePath; }
        }

        public string FileName
        {
            set { fileName = value; }
            get { return fileName; }
        }

        public string FileContent
        {
            set { fileContent = value; }
            get
            {
                if (File.Exists(filePath))
                {
                    FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                    StreamReader sr = new StreamReader(fs);
                    return sr.ReadToEnd();
                }
                else
                {
                    System.Console.WriteLine("file is empty.\r\n");
                    return string.Empty;
                }
            }
        }
    }
}