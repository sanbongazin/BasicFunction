using System;
using System.Data.SqlClient;

namespace BasicFunction
{
    public static class SQLFunction
    {
        private static string ConnString=@"Data Source = 127.0.0.1/SQLEXPRESS; Initial Catalog = Brito.mdf; Integrated Security = True";
        private static SqlConnection con;
        private static SqlCommand cmd;
        private static SqlDataReader dr;

        //SQLサーバーへの接続
        public static void SQLConnection(){
            con = new SqlConnection();
            cmd= new SqlCommand();

            con.ConnectionString = ConnString;
            try
            {
                con.Open();
                Console.WriteLine("Connected");
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);   
            }
        }

        //テーブル作成用メソッド.
        public static void SQLTableMake() { }
        
        public static void SQLAdmit() { }


        //これに関してはパーツ固定なのでテーブルしてもデフォルトで可能と思われる。
        public static void SQLRanking(){}

        //テーブル指定のプロパティが必要
        public static void SQLSearch(string serchWord){

            try
            {

                SQLConnection();
                cmd.CommandText = @"SELECT * FROM Products LIKE '%" + serchWord + @"%'";
                cmd.CommandType = System.Data.CommandType.Text;

                cmd.Connection = con;
                dr = cmd.ExecuteReader();

            }
            catch(Exception e) {
            }

        }

        public static void SQLSearch(string serchWord,string serchCategory){
            try
            {

                SQLConnection();
                cmd.CommandText = @"SELECT * FROM Products LIKE '%" + serchWord + @"%'";
                cmd.CommandType = System.Data.CommandType.Text;

                cmd.Connection = con;
                dr = cmd.ExecuteReader();

            }
            catch (Exception e)
            {
            }
        }



        public static void SQLSearch(string serchWord, string serchCategory, string serchMaker){}


    }


}