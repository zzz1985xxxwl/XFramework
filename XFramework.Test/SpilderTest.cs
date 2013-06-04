using System;
using MongoDB.Driver;
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
            TargetUrl = "http://www.wj1973.com/";
            ThreadsCount = 20;
        }

        public string TargetUrl { get; set; }

        public int ThreadsCount { get; set; }

        public bool Filter(Uri uri)
        {
            return uri.AbsolutePath.ToLower().Contains("product/");
        }

        public void Save(Uri uri, string buffer)
        {
            if (!Filter(uri)||string.IsNullOrEmpty(buffer))
            {
                return;
            }
            const string connectionString = "mongodb://localhost";
            var client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("test");
            var collection = database.GetCollection<ProductEntity>("Product");

            var entity = new ProductEntity {Url = uri.ToString(), Detail = buffer};
            collection.Insert(entity);
            //const string outputPath = @"D:\temp\";
            //if (!Filter(uri))
            //{
            //    return;
            //}
            //if (!Directory.Exists(outputPath))
            //{
            //    Directory.CreateDirectory(outputPath);
            //}
            //string filename = Utility.ConvertFilename(uri, outputPath);
            //StreamWriter outStream = new StreamWriter(filename);
            //outStream.Write(buffer);
            //outStream.Close();
        }

        public void Log(Uri uri, string info)
        {
            Console.WriteLine(info);
        }
    }
}