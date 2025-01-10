namespace Lab1
{
    static void Main(string[] args)
    {
        Book book = new Book("MINHDEptrai", 1000, 3, "MINH204");
        book.Sellcopy(1);
    }
    public class Publication
        {
            public string title { get; set; }
            public int price { get; set; }
            public int copies { get; set; }
        public Publication(string title, int price, int copies)
        {
            this.title = title;
            this.price = price;
            this.copies = copies;
        }
        public void Sellcopy()
        {
            Console.WriteLine("minhdeptrai");
        }
    }
    class Book : Publication
    {
        public string author;
        public Book(string title, int price, int copies, string author) : base(title, price, copies)
        {
            this.author = author;
            this.title = title;
            this.price = price;
            this.copies = copies;
        }
        public void OrderCopy()
        {

        }
    }
    public class Magazine : Publication 
    {
        public int OrderQty;
        public int CurrIssue;
        public Magazine(string title, int price, int copies, int OrderQty,int CurrIssue) : base(title, price, copies)
        {
            this.OrderQty = OrderQty;
            this.CurrIssue = CurrIssue;
            this.title = title;
            this.price = price;
            this.copies = copies;
        }
        
    }

}
