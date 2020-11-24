using System;
using System.Collections.Generic;
using System.Text;
using FirebirdSql.Data.FirebirdClient;

namespace CsvToFbdb
{
    class FBDBController
    {
        public FBDBController(string user, string password, string database)
        {
            var fbCon = new FbConnectionStringBuilder();
            fbCon.UserID = user;
            fbCon.Password = password;
            fbCon.Database = database;
            fbCon.ServerType = 0;
            fb = new FbConnection(fbCon.ToString());
        }
        private FbConnection fb;
        public bool TransferProducts(List<Product> list)
        {
            fb.Open();
            var fbt = fb.BeginTransaction();
            foreach(var p in list)
            {
                Console.WriteLine(p.ToString());
                var insertSQL = new FbCommand($"INSERT INTO BARCODES (ID, UPCEAN, NAME, CATEGORYID, CATEGORYNAME, BRANDID, BRANDNAME) VALUES ({p.ID}, {p.UPCEAN}, '{protectQuote(p.Name)}', {p.CategoryID}, '{protectQuote(p.CategoryName)}', {p.BrandID}, '{protectQuote(p.BrandName)}');", fb, fbt);
                insertSQL.ExecuteNonQuery();
                insertSQL.Dispose();
            }
            fbt.Commit();
            fb.Close();
            return true;
        }
        private string protectQuote(string s)
        {
            string res = "";
            for(int i = 0; i < s.Length; i++)
            {
                if(s[i] == '\'')
                {
                    res += '\'';
                }
                res += s[i];
            }
            return res;
        }
    }
}
