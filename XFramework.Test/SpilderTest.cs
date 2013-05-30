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
            m_spider.SpiderControl = new SpiderControl1();
            try
            {
                m_spider.Start();
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
            ThreadsCount = 20;
        }

        public string OutputPath { get; set; }

        public string TargetUrl { get; set; }

        public int ThreadsCount { get; set; }

        public bool Filter(Uri uri)
        {
            return uri.AbsolutePath.ToLower().Contains("product/");
        }

        public void Save(Uri uri, string buffer)
        {
            if (!Filter(uri))
            {
                return;
            }
            if (OutputPath == null)
            { return; }
            if (!Directory.Exists(OutputPath))
            {
                Directory.CreateDirectory(OutputPath);
            }
            string filename = Utility.ConvertFilename(uri, OutputPath);
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
