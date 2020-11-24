using System;
using System.Collections.Generic;
using System.Text;

namespace CsvToFbdb
{
    public class Product
    {
        public Product(int ID, long UPCEAN, string Name, int CategoryID, string CategoryName, int BrandID, string BrandName)
        {
            this.ID = ID;
            this.UPCEAN = UPCEAN;
            this.Name = Name;
            this.CategoryID = CategoryID;
            this.CategoryName = CategoryName;
            this.BrandID = BrandID;
            this.BrandName = BrandName;
        }
        public int ID { get; }
        public long UPCEAN { get; }
        public string Name { get; }
        public int CategoryID { get; }
        public string CategoryName { get; }
        public int BrandID { get; }
        public string BrandName { get; }
        public override string ToString()
        {
            return $"{ID}, {UPCEAN}, {Name}, {CategoryID}, {CategoryName}, {BrandID}, {BrandName}";
        }
    }
}
