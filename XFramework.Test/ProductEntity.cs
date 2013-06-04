using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Bson;

namespace XFramework.Test
{
    public class ProductEntity
    {
        public ObjectId Id { get; set; }
        public string Url { get; set; }
        public string Detail { get; set; }
    }
}
