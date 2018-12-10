using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Library.Model;


namespace Library.Controller
{
    public sealed class SystemManager
    {
        private  SystemManager()
        {
            Services = new ServicesManager();

        }

        public static SystemManager Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new SystemManager();
                   
                }
                return _Instance;
            }
        }
        private static SystemManager _Instance;


        public LoginUser CurrentUser
        {
            get;
            set;
        }

        public List<string> RightCodeList
        {
            get;
            set;
        }

        public ServicesManager Services { get; set; }
    }
}
