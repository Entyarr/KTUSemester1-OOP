using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lab4.Exercises.Lines
{
    class InOut
    {
        //------------------------------------------------------------ 
        /** Finds the ordinal number of the longest line. 
          @param fin – name of data file  
          returns the ordinal number of the longest line*/
        public static int LongestLine(string fin)
        {
            int No = -1;
            int length = 0;
            using (StreamReader reader = new StreamReader(fin, Encoding.UTF8))
            {
                string line;
                
                int lineNo = 0;
                while ((line = reader.ReadLine()) != null)
                {
                    if (line.Length > length)
                    {
                        length = line.Length;
                        No = lineNo;
                    }
                    lineNo++;
                }
            }
            return length;
        }
        //-------------------------------------------------------

        //---------------------------------------------------------------- 
        /** Removes the line of the given ordinal number. 
            @param fin – name of data file  
            @param fout – name of result file  
            @param No – the ordinal number of the longest line  */
        public static void RemoveLine(string fin, string fout, int No)
        {
            using (StreamReader reader = new StreamReader(fin, Encoding.UTF8))
            {
                string line;
                int lineNo = 0;
                using (var writer = File.CreateText(fout))
                {
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (No != line.Length)
                        {
                            writer.WriteLine(line);
                        }
                        lineNo++;
                    }
                }
            }
        }
    }
}
