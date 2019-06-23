using System;
using BasicFunction;

namespace BasicFunctions
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            //SQLFunction.SQLConnection();
            SQLFunction.SQLSearch("放課後","dbo.ProductDB");
            Console.WriteLine();

            var dr = SQLFunction.SQLSearch("放課後", "dbo.ProductDB","Category1","紅茶");


            while (dr.Read())
            {
                Console.WriteLine(dr["ProdsName"].ToString() + dr["Category1"].ToString());
            }
           
        }
    }
}
