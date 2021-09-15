using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CSBasic11
{
    class Program
    {
        class Product
        {
            public string Name { get; set; }
            public int Price { get; set; }
            public override string ToString()
            {
                return Name + ":" + Price + "원";
            }
        }
        static void Main(string[] args)
        {
            string url = "http://www.kma.go.kr/wid/queryDFSRSS.jsp?zone=1150061500";
            XElement xElement = XElement.Load(url);
            var xmlQuery = from item in xElement.Descendants("data") 
                           select new
                           {
                               no = item.Element("seq").Value,
                               hour = item.Element("hour").Value,
                               day = item.Element("day").Value,
                               temp = item.Element("temp").Value,
                               wdKor = item.Element("wdKor").Value,
                               wfKor = item.Element("wfKor").Value,
                               tmn = item.Element("tmn").Value,
                               tmx = item.Element("tmx").Value

                           };

            foreach (var item in xmlQuery)
            {
                Console.WriteLine(
                    item.hour + "\t" + item.hour+"\t"+item.day+"\t"
                    + item.temp + "\t"+ item.wdKor + "\t"
                    + item.wfKor + "\t" + item.tmn + "\t"
                    + item.tmx + "\t"
                    );
            }

            List < Product > products = new List<Product>()
            {
                new Product() {Name = "고구마", Price = 5000},
                new Product() {Name = "사과", Price = 4000},
                new Product() {Name = "감자", Price = 3000},
                new Product() {Name = "옥수수", Price = 2000},
                new Product() {Name = "호박", Price = 1000},
                new Product() {Name = "수박", Price = 8700},
                new Product() {Name = "배", Price = 900},
                new Product() {Name = "딸기", Price = 3000},
            };
            var output3 = from item in products
                          where item.Price > 1500
                          orderby item.Name ascending
                          select item;

            foreach(var item in output3)
            {
                Console.WriteLine(item);
            }

            List<int> input = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            List<int> output = new List<int>();

            output = (from item in input 
                      where item % 2 == 0 
                      orderby item descending
                      select item).ToList();

            /*foreach(var item in input)
            {
                if(item%2==0)
                {
                    output.Add(item);
                }
            }*/

            foreach(var item in output)
            {
                Console.WriteLine(item);
            }

            var output2 = from item in input
                          where item % 2 == 0
                          select new
                          {
                              A = item *2,
                              B = item * item,
                              C = 100
                          };

            foreach(var item in output2)
            {
                Console.WriteLine(item.A + " / " + item.B + "/" + item.C);
            }
        }
    }
}
