using System;
using System.Configuration;
namespace Library.DBUtility
{
    
    public class ConStringTool
    {        
        /// <summary>
        /// 获取连接字符串
        /// </summary>
        public static string ConnectionString
        {           
            get 
            {
                
                string _connectionString =ConfigurationManager.ConnectionStrings["DBServer"].ConnectionString;       
                string ConStringEncrypt = ConfigurationManager.AppSettings["ConStringEncrypt"];
                if (ConStringEncrypt == "true")
                {
                    _connectionString = DESEncrypt.Decrypt(_connectionString);
                }
                return _connectionString; 
            }
        }


    }
}
