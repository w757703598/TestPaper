using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace TestPaper.Common
{
    public  class TestPaperHelper
    {
        public static void PaperAnalyze(Stream filestream )
        {
            using (StreamReader sr = new StreamReader(filestream))
            {
                while (!sr.EndOfStream)
                {
                    var temp= sr.ReadLine();
                }

            }
        }
    }
}