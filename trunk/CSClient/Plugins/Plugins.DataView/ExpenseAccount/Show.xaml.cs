using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using DevExpress.Xpf.Core;
using Library.Controller;
using System.Data;
using System.Configuration;

namespace Plugins.DataView.ExpenseAccount
{
    /// <summary>
    /// Show.xaml 的交互逻辑
    /// </summary>
    public partial class Show : DXWindow
    {
        public Show()
        {
            InitializeComponent();
          
        }
        int RowIndex = 6;
        void Show_Loaded(DataTable list)
        {
            int i = 0;
           foreach(DataRow row in list.Rows)
            {
                i++;

                RowDefinition rd = new RowDefinition();
                rd.Height = new GridLength(30);
                grid.RowDefinitions.Add(rd);

               // 日期 用途 金额 备注
                //F_CostAmount,F_OtherCost,F_CostDate,,,,F_CostDescription,
                Border b1 = new Border();
                b1.SetValue(Grid.RowProperty, RowIndex);
                b1.SetValue(Grid.ColumnProperty, 0);
                b1.BorderBrush = new SolidColorBrush(Color.FromArgb(255,30,57,105));
                b1.BorderThickness = new Thickness(2, 1, 0, 0);
                TextBlock txt1 = new TextBlock();
                txt1.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                txt1.VerticalAlignment = System.Windows.VerticalAlignment.Center;
                txt1.Text = i.ToString();
                b1.Child = txt1;
                grid.Children.Add(b1);

                Border b2 = new Border();
                b2.SetValue(Grid.RowProperty, RowIndex);
                b2.SetValue(Grid.ColumnProperty, 1);
                b2.BorderBrush = new SolidColorBrush(Color.FromArgb(255, 30, 57, 105));
                b2.BorderThickness = new Thickness(1, 1, 0, 0);
                TextBlock txt2 = new TextBlock();
                txt2.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                txt2.VerticalAlignment = System.Windows.VerticalAlignment.Center;
                txt2.Text = DateTime.Parse(row["F_CostDate"].ToString()).ToString("yyyy/MM/dd") ;
                b2.Child = txt2;
                grid.Children.Add(b2);


                Border b3 = new Border();
                b3.SetValue(Grid.RowProperty, RowIndex);
                b3.SetValue(Grid.ColumnProperty, 2);
                b3.SetValue(Grid.ColumnSpanProperty, 4);
                b3.BorderBrush = new SolidColorBrush(Color.FromArgb(255, 30, 57, 105));
                b3.BorderThickness = new Thickness(1, 1, 0, 0);
                TextBlock txt3 = new TextBlock();
                txt3.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                txt3.VerticalAlignment = System.Windows.VerticalAlignment.Center;
                txt3.Text = row["OtherCost"].ToString();
                b3.Child = txt3;
                grid.Children.Add(b3);
               

                Border b4 = new Border();
                b4.SetValue(Grid.RowProperty, RowIndex);
                b4.SetValue(Grid.ColumnProperty, 6);
                b4.SetValue(Grid.ColumnSpanProperty, 3);
                b4.BorderBrush = new SolidColorBrush(Color.FromArgb(255, 30, 57, 105));
                b4.BorderThickness = new Thickness(1, 1, 0, 0);
                TextBlock txt4 = new TextBlock();
                txt4.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                txt4.VerticalAlignment = System.Windows.VerticalAlignment.Center;
                txt4.Text =  row["F_CostAmount"].ToString();
                b4.Child = txt4;
                grid.Children.Add(b4);


                Border b5 = new Border();
                b5.SetValue(Grid.RowProperty, RowIndex);
                b5.SetValue(Grid.ColumnProperty, 9);
                b5.SetValue(Grid.ColumnSpanProperty, 3);
                b5.BorderBrush = new SolidColorBrush(Color.FromArgb(255, 30, 57, 105));
                b5.BorderThickness = new Thickness(1, 1, 2, 0);
                TextBlock txt5 = new TextBlock();
                txt5.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                txt5.VerticalAlignment = System.Windows.VerticalAlignment.Center;
                txt5.Text = row["F_CostDescription"].ToString();
                b5.Child = txt5;
                grid.Children.Add(b5);
               

                // <Border  Grid.Row="6" Grid.Column="0"  BorderBrush="#1E3969" BorderThickness="2,1,0,0" >
                //    <TextBlock Text="1" HorizontalAlignment="Center"   VerticalAlignment="Center"></TextBlock>
                //</Border>
                //<Border  Grid.Row="6" Grid.Column="1"  BorderBrush="#1E3969" BorderThickness="1,1,0,0" >
                //    <TextBlock Text="" HorizontalAlignment="Center"   VerticalAlignment="Center"></TextBlock>
                //</Border>
                //<Border  Grid.Row="6" Grid.Column="2"  Grid.ColumnSpan="4" BorderBrush="#1E3969" BorderThickness="1,1,0,0" >
                //    <TextBlock Text="" HorizontalAlignment="Center"   VerticalAlignment="Center"></TextBlock>
                //</Border>
                //<Border  Grid.Row="6" Grid.Column="6"  Grid.ColumnSpan="3" BorderBrush="#1E3969" BorderThickness="1,1,0,0" >
                //    <TextBlock Text="" HorizontalAlignment="Center"   VerticalAlignment="Center"></TextBlock>
                //</Border>
                //<Border  Grid.Row="6" Grid.Column="9"  Grid.ColumnSpan="3" BorderBrush="#1E3969" BorderThickness="1,1,2,0" >
                //    <TextBlock Text="" HorizontalAlignment="Center"   VerticalAlignment="Center"></TextBlock>
                //</Border>
                RowIndex++;
              
            }
           int cCount = list.Rows.Count;
            last1.SetValue(Grid.RowProperty, 6 + cCount);
            last2.SetValue(Grid.RowProperty, 6 + cCount);

            last3.SetValue(Grid.RowProperty, 7 + cCount);
            last4.SetValue(Grid.RowProperty, 7 + cCount);
            last5.SetValue(Grid.RowProperty, 7 + cCount);



            last3name.SetValue(Grid.RowProperty, 7 + cCount);
            last4name.SetValue(Grid.RowProperty, 7 + cCount);
            last5name.SetValue(Grid.RowProperty, 7 + cCount);

        }

        private void btnPrint_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            PrintDialog dialog = new PrintDialog();
            if (dialog.ShowDialog() == true)
            {
                dialog.PrintVisual(vvs, "报销单");
            }
        }

        internal void LoadData(System.Data.DataRow row)
        {
          
            if (row["F_ApplyAmount"] != null)
            {
                // "    " +
                txtDate.Text = DateTime.Parse(row["F_ApplyDate"].ToString()).Year + " 年 " + DateTime.Parse(row["F_ApplyDate"].ToString()).Month + " 月 " + DateTime.Parse(row["F_ApplyDate"].ToString()).Day + " 日";

                txtBigName.Text = MoneyToUpper(row["F_ApplyAmount"].ToString());

                string money = double.Parse(row["F_ApplyAmount"].ToString()).ToString();
                string[] moneys = money.Split('.');

                Char[] m1 = moneys[0].ToCharArray();
                if (m1.Length - 1 >= 0)
                {
                    txtmoney1.Text = m1[m1.Length - 1].ToString();
                }
                if (m1.Length - 2 >= 0)
                {
                    txtmoney2.Text = m1[m1.Length - 2].ToString();
                }
                if (m1.Length - 3 >= 0)
                {
                    txtmoney3.Text = m1[m1.Length - 3].ToString();
                }
                if (m1.Length - 4 >= 0)
                {
                    txtmoney4.Text = m1[m1.Length - 4].ToString();
                }
                if (m1.Length - 5 >= 0)
                {
                    txtmoney5.Text = m1[m1.Length - 5].ToString();
                }
                if (m1.Length - 6 >= 0)
                {
                    txtmoney6.Text = m1[m1.Length - 6].ToString();
                }

                if (moneys.Length >= 2 && !string.IsNullOrEmpty(moneys[1]))
                {
                    Char[] m2 = moneys[1].ToCharArray();
                    if (m2.Length >= 1)
                    {
                        txtmoney01.Text = m2[0].ToString();
                    }
                    if (m2.Length >= 2)
                    {
                        txtmoney02.Text = m2[1].ToString();
                    }
                }
            }
            //if (row["F_Name"] != null)
            //{
            //    txtdepartment.Text = MoneyToUpper(row["F_Name"].ToString());
            //}

            if (row["F_OperatorID"] != null)
            {
                Library.Model.Employee pmodel = SystemManager.Instance.Services.EmployeeService.GetModel(int.Parse(row["F_OperatorID"].ToString()));
                txtuser.Text = pmodel.F_Name;
                last5name.Text = pmodel.F_Name;
            }

            last3name.Text = SystemManager.Instance.Services.EmployeeService.GetRoleToUserName(ConfigurationManager.AppSettings["总经理"]);
            last4name.Text = SystemManager.Instance.Services.EmployeeService.GetRoleToUserName(ConfigurationManager.AppSettings["财务"]);
        
         
            DataTable list = SystemManager.Instance.Services.ProjectCostService.GetAppList(row["F_ID"].ToString());

            Show_Loaded(list);


        }


       public  string MoneyToUpper(string strAmount)
        {
            string functionReturnValue =null;
            bool IsNegative =false; // 是否是负数
            if (strAmount.Trim().Substring(0, 1) =="-")
            {
                // 是负数则先转为正数
                strAmount = strAmount.Trim().Remove(0, 1);
                IsNegative =true;
            }
            string strLower =null;
            string strUpart =null;
            string strUpper =null;
            int iTemp =0;
            // 保留两位小数 123.489→123.49　　123.4→123.4
            strAmount = Math.Round(double.Parse(strAmount), 2).ToString();
            if (strAmount.IndexOf(".") >0)
            {
                if (strAmount.IndexOf(".") == strAmount.Length -2)
                {
                    strAmount = strAmount +"0";
                }
            }
            else
            {
                strAmount = strAmount +".00";
            }
            strLower = strAmount;
            iTemp =1;
            strUpper ="";
            while (iTemp <= strLower.Length)
            {
                switch (strLower.Substring(strLower.Length - iTemp, 1))
                {
                    case ".":
                        strUpart ="圆";
                        break;
                    case "0":
                        strUpart ="零";
                        break;
                    case "1":
                        strUpart ="壹";
                        break;
                    case "2":
                        strUpart ="贰";
                        break;
                    case "3":
                        strUpart ="叁";
                        break;
                    case "4":
                        strUpart ="肆";
                        break;
                    case "5":
                        strUpart ="伍";
                        break;
                    case "6":
                        strUpart ="陆";
                        break;
                    case "7":
                        strUpart ="柒";
                        break;
                    case "8":
                        strUpart ="捌";
                        break;
                    case "9":
                        strUpart ="玖";
                        break;
                }

                switch (iTemp)
                {
                    case 1:
                        strUpart = strUpart +"分";
                        break;
                    case 2:
                        strUpart = strUpart +"角";
                        break;
                    case 3:
                        strUpart = strUpart +"";
                        break;
                    case 4:
                        strUpart = strUpart +"";
                        break;
                    case 5:
                        strUpart = strUpart +"拾";
                        break;
                    case 6:
                        strUpart = strUpart +"佰";
                        break;
                    case 7:
                        strUpart = strUpart +"仟";
                        break;
                    case 8:
                        strUpart = strUpart +"万";
                        break;
                    case 9:
                        strUpart = strUpart +"拾";
                        break;
                    case 10:
                        strUpart = strUpart +"佰";
                        break;
                    case 11:
                        strUpart = strUpart +"仟";
                        break;
                    case 12:
                        strUpart = strUpart +"亿";
                        break;
                    case 13:
                        strUpart = strUpart +"拾";
                        break;
                    case 14:
                        strUpart = strUpart +"佰";
                        break;
                    case 15:
                        strUpart = strUpart +"仟";
                        break;
                    case 16:
                        strUpart = strUpart +"万";
                        break;
                    default:
                        strUpart = strUpart +"";
                        break;
                }

                strUpper = strUpart + strUpper;
                iTemp = iTemp +1;
            }

            strUpper = strUpper.Replace("零拾", "零");
            strUpper = strUpper.Replace("零佰", "零");
            strUpper = strUpper.Replace("零仟", "零");
            strUpper = strUpper.Replace("零零零", "零");
            strUpper = strUpper.Replace("零零", "零");
            strUpper = strUpper.Replace("零角零分", "整");
            strUpper = strUpper.Replace("零分", "整");
            strUpper = strUpper.Replace("零角", "零");
            strUpper = strUpper.Replace("零亿零万零圆", "亿圆");
            strUpper = strUpper.Replace("亿零万零圆", "亿圆");
            strUpper = strUpper.Replace("零亿零万", "亿");
            strUpper = strUpper.Replace("零万零圆", "万圆");
            strUpper = strUpper.Replace("零亿", "亿");
            strUpper = strUpper.Replace("零万", "万");
            strUpper = strUpper.Replace("零圆", "圆");
            strUpper = strUpper.Replace("零零", "零");

            // 对壹圆以下的金额的处理
            if (strUpper.Substring(0, 1) =="圆")
            {
                strUpper = strUpper.Substring(1, strUpper.Length -1);
            }
            if (strUpper.Substring(0, 1) =="零")
            {
                strUpper = strUpper.Substring(1, strUpper.Length -1);
            }
            if (strUpper.Substring(0, 1) =="角")
            {
                strUpper = strUpper.Substring(1, strUpper.Length -1);
            }
            if (strUpper.Substring(0, 1) =="分")
            {
                strUpper = strUpper.Substring(1, strUpper.Length -1);
            }
            if (strUpper.Substring(0, 1) =="整")
            {
                strUpper ="零圆整";
            }
            functionReturnValue = strUpper;

            if (IsNegative ==true)
            {
                return"负"+ functionReturnValue;
            }
            else
            {
                return functionReturnValue;
            }
        }
    }
}
