using System;
using System.Data.SqlClient;

namespace BasicFunction
{
    public static class SQLFunction
    {
        private static string ConnString = @"server=localhost;database=burito;uid=sa;pwd=P@ssw0rd!;";//@"Data Source = 127.0.0.1/SQLEXPRESS; Initial Catalog = Brito.mdf; Integrated Security = True";

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
        public static void SQLSearch(string serchWord ,string DBName){

            try
            {

                SQLConnection();
                cmd.CommandText = "SELECT * FROM "+DBName+" WHERE ProdsName LIKE N'%" + serchWord + "%'";
                cmd.CommandType = System.Data.CommandType.Text;

                cmd.Connection = con;
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Console.WriteLine(dr["ProdsName"].ToString() + ":"+dr["Category1"].ToString());
                }
                dr.Close();
                con.Close();

            }
            catch(Exception e) {
                Console.WriteLine(e.Message);
            }

        }

        public static SqlDataReader SQLSearch(string serchWord, string DBName, string serchCategoryName, string serchCategory){
            try
            {

                SQLConnection();
                cmd.CommandText = "SELECT * FROM " + DBName + " WHERE "+ serchCategoryName+" IN (SELECT "+serchCategoryName+ "=N"+ "'" + serchCategory + "'" + " WHERE ProdsName LIKE N'%" + serchWord + "%')";
                cmd.CommandType = System.Data.CommandType.Text;

                cmd.Connection = con;
                dr = cmd.ExecuteReader();

                while(dr.Read()) {
                    Console.WriteLine(dr["ProdsName"].ToString()+dr["Category1"].ToString());
                }
                dr.Close();
                con.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return dr;
        }



        public static void SQLSearch(string serchWord, string DBName, string serchCategoryName, string serchCategory, string serchMaker){}


    }


}