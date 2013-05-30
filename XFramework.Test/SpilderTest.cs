using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using NUnit.Framework;
using XFramework.WebSpider;

namespace XFramework.Test
{
    [TestFixture]
    public class SpilderTest
    {
        [Test]
        public void Test()
        {
            var m_spider = new Spider();
            m_spider.OutputPath = @"D:\temp\";
            var targetUrl = "http://www.wj1973.com/";
            int threads = 20;
            try
            {
                m_spider.Start(new Uri(targetUrl), threads);
            }
            catch (UriFormatException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
        }
    }

    public class SpiderControl1 : ISpiderControl
    {
        public SpiderControl1()
        {
            OutputPath = @"D:\temp\";
            TargetUrl = "http://www.wj1973.com/";
        }

        public string OutputPath { get; set; }

        public string TargetUrl { get; set; }

        public bool Filter(Uri uri)
        {
            return true;
        }

        public void Save(Uri uri, string buffer)
        {
            if (OutputPath == null)
                return;

            string filename = convertFilename(m_uri);
            StreamWriter outStream = new StreamWriter(filename);
            outStream.Write(buffer);
            outStream.Close();
        }

        public void Log(Uri uri, string info)
        {
            throw new NotImplementedException();
        }
    }
}
