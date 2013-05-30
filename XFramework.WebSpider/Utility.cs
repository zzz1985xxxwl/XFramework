using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace XFramework.WebSpider
{
    public class Utility
    {
        /// <summary>
        ///   This method will take a URI name, such ash /images/blank.gif
        ///   and convert it into the name of a file for local storage.
        ///   If the directory structure to hold this file does not exist, it
        ///   will be created by this method.
        /// </summary>
        /// <param name = "uri">The URI of the file about to be stored</param>
        /// <param name="outputPath"></param>
        /// <returns></returns>
        public static string ConvertFilename(Uri uri, string outputPath)
        {
            int index1;
            int index2;

            // add ending slash if needed
            if (outputPath[outputPath.Length - 1] != '\\')
            {
                outputPath = outputPath + "\\";
            }
            // strip the query if needed

            String path = uri.PathAndQuery;
            int queryIndex = path.IndexOf("?");
            if (queryIndex != -1)
                path = path.Substring(0, queryIndex);

            // see if an ending / is missing from a directory only

            int lastSlash = path.LastIndexOf('/');
            int lastDot = path.LastIndexOf('.');

            if (path[path.Length - 1] != '/')
            {
                if (lastSlash > lastDot)
                    path += "/index.html";
            }

            // determine actual filename		
            lastSlash = path.LastIndexOf('/');

            string filename = "";
            if (lastSlash != -1)
            {
                filename = path.Substring(1 + lastSlash);
                path = path.Substring(0, 1 + lastSlash);
                if (filename.Equals(""))
                    filename = "index.html";
            }


            // create the directory structure, if needed

            index1 = 1;
            do
            {
                index2 = path.IndexOf('/', index1);
                if (index2 != -1)
                {
                    String dirpart = path.Substring(index1, index2 - index1);
                    outputPath += dirpart;
                    outputPath += "\\";


                    Directory.CreateDirectory(outputPath);

                    index1 = index2 + 1;
                }
            } while (index2 != -1);

            // attach name			
            outputPath += filename;

            return outputPath;
        }

    }
}
