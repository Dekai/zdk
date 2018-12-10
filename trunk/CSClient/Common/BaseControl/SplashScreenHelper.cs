using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Xpf.Core;
using DevExpress.MailClient.Xpf.Helpers;

namespace BaseControl
{
    public class SplashScreenHelper
    {

        static SplashScreenHelper instance = null;
        public static SplashScreenHelper Instance
        {
            get
            {
                if (instance == null)
                    instance = new SplashScreenHelper();

                return instance;
            }
        }

        SplashScreenHelper() { }

        WaitIndicator indicator = new WaitIndicator();

      
        public void ShowSplashScreen()
        {
            if (!DXSplashScreen.IsActive)
            {
                DXSplashScreen.Show<SplashWindow>();
              
            }
        }

        public void HideSplashScreen()
        {
            if (DXSplashScreen.IsActive)
            {
                DXSplashScreen.Close();
             
            }
        }
    }
}
