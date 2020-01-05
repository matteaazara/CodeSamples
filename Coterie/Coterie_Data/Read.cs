using Coterie_Models.Extensions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coterie_Data
{
    public class Read
    {
        private static string _factorsFolder = ConfigurationManager.AppSettings["FactorsFolder"];

        public static decimal StateFactor(string state)
        {
            decimal factor = 0;
                        
            try
            {
                string stateFactorFile = Path.Combine(_factorsFolder, "StateFactors.txt");

                using (StreamReader sr = new StreamReader(stateFactorFile))
                {
                    string currentLine;

                    while(!string.IsNullOrEmpty(currentLine = sr.ReadLine()))
                    {
                        string[] parts = currentLine.Split('|');
                        if (parts.Count() < 2) continue;
                        var key = parts[0];
                        if(key.ToUpper() == state.ToUpper())
                        {
                            factor =  parts[1].ToDecimal();
                            break;
                        }
                    }
                }
            }catch(Exception exception)
            {
                //Log Error
                //Raise Alert
            }

            return factor;
        }

        public static decimal BusinessFactor(string business)
        {
            decimal factor = 1;

            try
            {
                string stateFactorFile = Path.Combine(_factorsFolder, "BusinessFactors.txt");

                using (StreamReader sr = new StreamReader(stateFactorFile))
                {
                    string currentLine;

                    while (!string.IsNullOrEmpty(currentLine = sr.ReadLine()))
                    {
                        string[] parts = currentLine.Split('|');
                        if (parts.Count() < 2) continue;
                        var key = parts[0];
                        if (key.ToUpper() == business.ToUpper())
                        {
                            factor = parts[1].ToDecimal();
                            break;
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                //Log Error
                //Raise Alert
            }

            return factor;
        }
    }
}
