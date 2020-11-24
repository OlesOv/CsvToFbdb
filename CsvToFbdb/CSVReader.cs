using System;
using System.Collections.Generic;
using KBCsv;
using System.IO;

namespace CsvToFbdb
{
    public class CSVReader
    {
        string path;
        public CSVReader(string path)
        {
            this.path = path;
        }
        public List<Product> ReadProducts()
        {
            List<Product> res = new List<Product>();
            using (var streamReader = new StreamReader(path))
            using (var csvReader = new CsvReader(streamReader))
            {
                csvReader.ValueSeparator = '\t';
                csvReader.ReadHeaderRecord();

                while (csvReader.HasMoreRecords)
                {
                    var record = csvReader.ReadDataRecord();
                    res.Add(new Product(Convert.ToInt32(record["ID"]),
                        Convert.ToInt64(record["UPCEAN"]), record["Name"],
                        Convert.ToInt32(record["CategoryID"]), record["CategoryName"],
                        Convert.ToInt32(record["BrandID"]), record["BrandName"]));
                }
            }

            return res;
        }
    }
}
