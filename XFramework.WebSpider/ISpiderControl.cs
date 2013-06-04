using System;

namespace XFramework.WebSpider
{
    public interface ISpiderControl
    {
        string TargetUrl { get; set; }
        int ThreadsCount { get; set; }

        bool Filter(Uri uri);
        void Save(Uri uri, string buffer);
        void Log(Uri uri, string info);
    }
}