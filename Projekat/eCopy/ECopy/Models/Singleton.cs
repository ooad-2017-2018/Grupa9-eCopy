using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ECopy.Models
{
    public sealed class Singleton: HttpClient
    {
        private Singleton() { }
        private static Singleton client = new Singleton();
        public static Singleton getInstance()
        {
            return client;
        }
    }
}
