﻿using System;

namespace XFramework.WebSpider
{
    public interface ISpiderControl
    {
        string OutputPath { get; set; }
        string TargetUrl { get; set; }

        bool Filter(Uri uri);
        void Save(Uri uri, string buffer);
        void Log(Uri uri, string info);
    }
}