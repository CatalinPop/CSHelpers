using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperClasses
{
    public class SettingsFile
    {

        public string[] Lines;

        public void ReadFile(string filepath)
        {
            Lines = File.ReadAllLines(filepath);
        }

        public string GetParameter(string parameterName)
        {
            foreach (string s in Lines)
            {
                if (!s.StartsWith("//"))
                {
                    if (s.Contains(parameterName))
                    {
                        return s.Split(new char[] { '=' })[1].TrimStart(new char[] { ' ' });
                    }
                }
            }

            return "";
        }

    }
}
