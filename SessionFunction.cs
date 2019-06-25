using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BasicFunction
{
    public static class SessionFunction
    {
        public static List<Session> OrederList = new List<Session>(); 
        public static OrderWrite(){
            int r = 0;
            foreach(var s in TextBoxList){
                if(s.Text!= null){
                    Session[LabelList[r]] = s.Text;
                    OrederList = Session[LabelList[r]];
                }
            r++;
            }
        }

        public static OrderToTable(){
            //テーブル作成処理を行う。
            //OrderListを読み出して、その読み出しを行なった際にLabelListなどの読み出しを行うことで
            //機能の実現を目指す.
                       //一列目の設定。この数を調整すると列の数を設定できる
            string[] TableColum = new string[] { "お気に入り", "商品画像", "商品名", "単価", "数量", "単位", "合計価格" };
            int[] TableColumSize = new int[] { 100, 200, 200, 200, 200, 100, 200 };


            TableRow tableRow;
            TableCell tableCell;

            tableRow = new TableRow();

            //1列目の自動生成
            int i = 0;
            foreach (var s in TableColum)
            {
                tableCell = new TableCell();
                tableCell.Text = s;
                tableCell.Width = TableColumSize[i];
                tableCell.Font.Size = 14;
                tableCell.BackColor = Color.Orange;
                tableCell.ForeColor = Color.White;
                tableRow.Cells.Add(tableCell);
                i++;
            }
            table.CssClass = "test";
            table.Rows.Add(tableRow);

            foreach(var s in OrederList)
            {
                tableRow = new TableRow();
                int j = 0;

                foreach (var s in TableColum)
                {
                    tableCell = new TableCell();
                    if (j == 0)
                    {

                        CheckBox checkbox = new CheckBox();
                        checkbox.CheckedChanged += new EventHandler(checkbox_Checked);
                        checkbox.ID = idCount.ToString();
                        tableCell.Width = TableColumSize[j];
                        tableCell.Controls.Add(checkbox);
                        checkbox.AutoPostBack = true;
                        FavoriteIDList.Add(idCount.ToString());

                    }
                    else if (j == 1)
                    {
                        System.Web.UI.WebControls.Image image = new System.Web.UI.WebControls.Image();
                        tableCell.Controls.Add(image);
                        tableCell.Width = TableColumSize[j];
                        image.ImageUrl = "~/yukari.jpg";
                        image.Width = 120;
                    }
                    else if (j == 2)
                    {
                        tableCell.Width = TableColumSize[j];
                        tableCell.Text = LabelList[r];
                    }
                    else if (j == 3)
                    {
                        tableCell.Width = TableColumSize[j];
                        tableCell.Text = PriceList[r];
                    }
                    else if (j == 4)
                    {
                        tableCell.Width = TableColumSize[j];
                        TextBox textBox = new TextBox();
                        tableCell.Controls.Add(textBox);
                        textBox.Text = OrederList[r];
                    }
                    else if (j == 5)
                    {
                        //選んである数もリストで組まないといけなさそう
                        tableCell.Width = TableColumSize[j];
                        DropDownList droplist = new DropDownList();
                        droplist.Items.Add("本");
                        droplist.Items.Add("ケース");
                        tableCell.Controls.Add(droplist);
                        droplist.SelectedIndex = DropDownIndexList[r].SelectedIndex;
                    }
                    else
                    {
                        if(DropDownIndexList[r].SelectedIndex==0){
                        tableCell.Text = (PriceList[r]*OrederList[r]).ToString();
                        }else{
                            tableCell.Text = (PriceList[r]*OrederList[r]*24).ToString();
                        }
                        tableRow.Cells.Add(tableCell);
                    }
                    j++;

                    tableRow.Cells.Add(tableCell);

                }
                idCount++;
                table.Rows.Add(tableRow);

            }
        }
    }
}