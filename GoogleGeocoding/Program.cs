using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;
using System.IO;
using System.Diagnostics;
using edu.stanford.nlp.ie.crf;
using FuzzyString;

namespace GoogleGeocoding
{
    class Program
    {
        static void Main(string[] args)
        {

            
        }

        public void Test ()
        {
            string addsFilePath = @"C:\Users\moreaus\Desktop\Dev\adds.csv";
            string[] lines = File.ReadAllLines(addsFilePath, Encoding.GetEncoding("iso-8859-1"));

            // Path to the folder with classifiers models
            string jarRoot = @"C:\Affaires\01-Developpement\GoogleGeocoding\stanford-ner-2015-12-09";
            string classifiersDirecrory = jarRoot + @"\classifiers";

            // Loading 3 class classifier model
            //CRFClassifier classifier = CRFClassifier.getClassifierNoExceptions(classifiersDirecrory + @"\english.all.3class.distsim.crf.ser.gz");

            foreach (string line in lines)
            {
                string description = line.Split(';')[0];

                //var classified = classifier.classifyToCharacterOffsets(description).toArray();

                //for (int i = 0; i < classified.Length; i++)
                //{

                //}
                List<FuzzyStringComparisonOptions> opts = new List<FuzzyStringComparisonOptions>();
                opts.Add(FuzzyStringComparisonOptions.UseLevenshteinDistance);

                Debug.WriteLine(FuzzyString.ComparisonMetrics.ApproximatelyEquals(description, "Rue Saint Honoré", opts, FuzzyStringComparisonTolerance.Normal));

                //var s1 = "Good afternoon Rajat Raina, how are you today?";
                //Debug.WriteLine("{0}\n", classifier.classifyToString(s1));

                //var s2 = "I go to school at Stanford University, which is located in California.";
                //Debug.WriteLine("{0}\n", classifier.classifyWithInlineXML(s2));

                //Debug.WriteLine("{0}\n", classifier.classifyToString(s2, "xml", true));

                //string zipCode = line.Split(';')[4];
                //GeocodingResponses responses = new GeocodingResponses(zipCode + " - " + Description);
                //if (responses.results.Count != 0)
                //{
                //    Debug.WriteLine(zipCode + " - " + Description + " _ " + responses.status + "_" + responses.results.FirstOrDefault().formatted_address);
                //}
                //else
                //{
                //    Debug.WriteLine(responses.status);
                //}

                //System.Threading.Thread.Sleep(100);
            }
            // string address = "123 something st, somewhere";
        }
    }
}
