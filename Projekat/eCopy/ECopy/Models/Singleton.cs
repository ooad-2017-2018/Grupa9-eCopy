using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ECopy.Models
{
    public sealed class SingletonFizickoLice 
    {
        private static IMobileServiceTable<Models.FizickoLice> tabelaFizickoLice = App.MobileService.GetTable<Models.FizickoLice>();
        private SingletonFizickoLice() { }
        //private static SingletonFizickoLice client = new SingletonFizickoLice();
        public static IMobileServiceTable<Models.FizickoLice> getInstance()
        {
            return tabelaFizickoLice;
        }
    }
}
