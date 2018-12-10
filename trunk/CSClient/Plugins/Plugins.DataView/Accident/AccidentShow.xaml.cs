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
using System.Data;
using DevExpress.Xpf.Core;
using Library.Controller;
using System.Configuration;
using System.Net;
using BaseControl.DataPager;
using BaseControl;
using Library.Model;
using System.IO;

namespace Plugins.DataView.Accident
{
    /// <summary>
    /// AccidentShow.xaml 的交互逻辑
    /// </summary>
    public partial class AccidentShow : DXWindow
    {
        public AccidentShow()
        {
            InitializeComponent();
        }
        List<PageButton> ll = new List<PageButton>();
        public void LoadData(DataRow row)
        {
            txtF_AccidentName.Text = row["F_AccidentName"].ToString();
            txtF_Description.Text = row["F_Description"].ToString();
            txtF_AccidentDate.Text = DateTime.Parse(row["F_AccidentDate"].ToString()).ToString("yyyy年MM月dd日");
            txtF_OperateTime.Text = row["F_OperatorName"].ToString();


            string id = row["F_ID"].ToString();

            List<Library.Model.UploadImages> modellist = SystemManager.Instance.Services.UploadImagesService.GetModelList("F_AccidentID=" + id + " and F_IsDelete=0");


            int index = 0;
            foreach (Library.Model.UploadImages image in modellist)
            {

                index++;
                PageButton btn = new PageButton();
                btn.PageIndex = index.ToString();
                btn.Obj = image;
                btn.Margin = new Thickness(5, 0, 0, 0);
                btn.MouseLeftButtonDown += (sender, e) =>
                {
                    try
                    {
                        SplashScreenHelper.Instance.ShowSplashScreen();
                        PageButton btntemp = sender as PageButton;
                        string uri = "http://" + ConfigurationManager.AppSettings["httpurl"] + "/uploadimages/" + (btntemp.Obj as UploadImages).F_ImagePath;
                        WebClient wc = new WebClient();
                        using (var ms = new MemoryStream(wc.DownloadData(uri)))
                        {
                            BitmapImage image1 = new BitmapImage();
                            image1.BeginInit();
                            image1.CacheOption = BitmapCacheOption.OnLoad;
                            image1.StreamSource = ms;
                            image1.EndInit();
                            img.Source = image1;
                        }
                        Point centerPoint = e.GetPosition(root);
                        this.sfr.CenterX = centerPoint.X;
                        this.sfr.CenterY = centerPoint.Y;
                        sfr.ScaleX =1;
                        sfr.ScaleY =1; 
                    }
                    finally
                    {
                        SplashScreenHelper.Instance.HideSplashScreen();
                    }
                };
                BtnPanels.Children.Add(btn);
                ll.Add(btn);
            }

            if (ll.Count > 0)
            {
              
              //  string s = "http://" + ConfigurationManager.AppSettings["httpurl"] + "/uploadimages/" + (ll[0].Obj as UploadImages).F_ImagePath;
              //  img.Source = new BitmapImage(new Uri(s));

                string uri = "http://" + ConfigurationManager.AppSettings["httpurl"] + "/uploadimages/" + (ll[0].Obj as UploadImages).F_ImagePath;
                WebClient wc = new WebClient();
                try
                {
                    using (var ms = new MemoryStream(wc.DownloadData(uri)))
                    {
                        BitmapImage image = new BitmapImage();
                        image.BeginInit();
                        image.CacheOption = BitmapCacheOption.OnLoad;
                        image.StreamSource = ms;
                        image.EndInit();
                        img.Source = image;
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show("照片丢失！" + ex.Message);
                }


            }
        }


      private void img_MouseWheel(object sender, MouseWheelEventArgs e)  
        {  
            Point centerPoint = e.GetPosition(root);  
            this.sfr.CenterX = centerPoint.X;  
            this.sfr.CenterY = centerPoint.Y;  
            if (sfr.ScaleX < 0.3 && sfr.ScaleY < 0.3 && e.Delta < 0)  
            {  
                return;  
            }  
            sfr.ScaleX += (double)e.Delta / 3500;  
            sfr.ScaleY += (double)e.Delta / 3500;  
        }

  
      private void img_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
      {
      
      }

      private void img_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
      {
     

      }

      private void img_MouseMove(object sender, MouseEventArgs e)
      {
        

   
      }

  


    }
}
