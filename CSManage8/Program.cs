namespace CSBasic8
{
    class Program
    {
        class Dummy : IDisposable
        {
            public void Dispose()
            {
                Console.WriteLine("리소스가 해제되었습니다.");
            }
        }
        class Product : IComparable
        {
            public string Name { get; set; }
            public int Price { get; set; }

            public int CompareTo(object obj)
            {
                return Price.CompareTo((obj as Product).Price);
            }

            public override string ToString()
            {
                return Name + " : " + Price + "원";
            }
        }
        static void Main(string[] args)
        {
            // IComparable
            List<Product> list = new List<Product>()
            {
                  new Product() { Name="고구마", Price=1500},
	@@ -39,6 +47,14 @@ static void Main(string[] args)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();

            // IDisposable
            using (Dummy d = new Dummy())
            {
                Console.WriteLine("뭔가 했습니다.");
            }
        }
    }
}