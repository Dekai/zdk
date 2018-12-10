using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;


namespace Library.DALFactory
{
    public sealed class DataAccess
    {

        #region 基本应用
        private static readonly string AssemblyPath = "Library.SQLServerDAL";
        private static Dictionary<string, object> DataCache = new Dictionary<string, object>();
        private static object CreateObject(string AssemblyPath, string classNamespace)
        {
            object objType = null;
            if (DataCache.ContainsKey(classNamespace))
            {
                return DataCache[classNamespace];
            }
            else
            {
                try
                {
                    string root = AppDomain.CurrentDomain.BaseDirectory.ToString()+@"Lib\Library\"+ AssemblyPath + ".dll";                 
                    objType = Assembly.LoadFile(root).CreateInstance(classNamespace);
                    DataCache.Add(classNamespace, objType);// 写入缓存
                }
                catch (System.Exception ex)
                {
                    string str = ex.Message;// 记录错误日志
                }
            }
            return objType;
        }
        #endregion


        //public static IUserDAL CreateUserDAL()
        //{
        //    string ClassNamespace = AssemblyPath + ".UserDAL";
        //    object objType = CreateObject(AssemblyPath, ClassNamespace);
        //    return (IUserDAL)objType;
        //}


        /// <summary>
        /// 创建DataDicInfo数据层接口。
        /// </summary>
        public static Library.IDAL.IDataDicInfo CreateDataDicInfo()
        {

            string ClassNamespace = AssemblyPath + ".DataDicInfo";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Library.IDAL.IDataDicInfo)objType;
        }


        /// <summary>
        /// 创建DataDicType数据层接口。
        /// </summary>
        public static Library.IDAL.IDataDicType CreateDataDicType()
        {

            string ClassNamespace = AssemblyPath + ".DataDicType";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Library.IDAL.IDataDicType)objType;
        }


        /// <summary>
        /// 创建Employee数据层接口。
        /// </summary>
        public static Library.IDAL.IEmployee CreateEmployee()
        {

            string ClassNamespace = AssemblyPath + ".Employee";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Library.IDAL.IEmployee)objType;
        }


        /// <summary>
        /// 创建Equipment数据层接口。
        /// </summary>
        public static Library.IDAL.IEquipment CreateEquipment()
        {

            string ClassNamespace = AssemblyPath + ".Equipment";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Library.IDAL.IEquipment)objType;
        }

        /// 创建LoginUser数据层接口。
        /// </summary>
        public static Library.IDAL.ILoginUser CreateLoginUser()
        {

            string ClassNamespace = AssemblyPath + ".LoginUser";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Library.IDAL.ILoginUser)objType;
        }


        /// <summary>
        /// 创建Role数据层接口。
        /// </summary>
        public static Library.IDAL.IRole CreateRole()
        {

            string ClassNamespace = AssemblyPath + ".Role";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Library.IDAL.IRole)objType;
        }


        /// <summary>
        /// 创建Right数据层接口。
        /// </summary>
        public static Library.IDAL.IRight CreateRight()
        {

            string ClassNamespace = AssemblyPath + ".Right";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Library.IDAL.IRight)objType;
        }


        /// <summary>
        /// 创建Role_Right_Relation数据层接口。
        /// </summary>
        public static Library.IDAL.IRole_Right_Relation CreateRole_Right_Relation()
        {

            string ClassNamespace = AssemblyPath + ".Role_Right_Relation";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Library.IDAL.IRole_Right_Relation)objType;
        }

        /// <summary>
        /// 创建Base_Fare数据层接口。
        /// </summary>
        public static Library.IDAL.IBase_Fare CreateBase_Fare()
        {

            string ClassNamespace = AssemblyPath + ".Base_Fare";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Library.IDAL.IBase_Fare)objType;
        }


        /// <summary>
        /// 创建Base_Payment数据层接口。
        /// </summary>
        public static Library.IDAL.IBase_Payment CreateBase_Payment()
        {

            string ClassNamespace = AssemblyPath + ".Base_Payment";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Library.IDAL.IBase_Payment)objType;
        }


        /// <summary>
        /// 创建Base_Product数据层接口。
        /// </summary>
        public static Library.IDAL.IBase_Product CreateBase_Product()
        {

            string ClassNamespace = AssemblyPath + ".Base_Product";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Library.IDAL.IBase_Product)objType;
        }


        /// <summary>
        /// 创建WorkFlow_Templete数据层接口。
        /// </summary>
        public static Library.IDAL.IWorkFlow_Templete CreateWorkFlow_Templete()
        {

            string ClassNamespace = AssemblyPath + ".WorkFlow_Templete";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Library.IDAL.IWorkFlow_Templete)objType;
        }

        /// <summary>
        /// 创建Test_Field数据层接口。
        /// </summary>
        public static Library.IDAL.ITest_Field CreateTest_Field()
        {

            string ClassNamespace = AssemblyPath + ".Test_Field";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Library.IDAL.ITest_Field)objType;
        }


        /// <summary>
        /// 创建Test_Field_Templete数据层接口。
        /// </summary>
        public static Library.IDAL.ITest_Field_Templete CreateTest_Field_Templete()
        {

            string ClassNamespace = AssemblyPath + ".Test_Field_Templete";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Library.IDAL.ITest_Field_Templete)objType;
        }


        /// <summary>
        /// 创建Test_Table数据层接口。
        /// </summary>
        public static Library.IDAL.ITest_Table CreateTest_Table()
        {

            string ClassNamespace = AssemblyPath + ".Test_Table";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Library.IDAL.ITest_Table)objType;
        }


        /// <summary>
        /// 创建Test_Table_Templete数据层接口。
        /// </summary>
        public static Library.IDAL.ITest_Table_Templete CreateTest_Table_Templete()
        {

            string ClassNamespace = AssemblyPath + ".Test_Table_Templete";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Library.IDAL.ITest_Table_Templete)objType;
        }
        /// <summary>
        /// 创建Accident数据层接口。
        /// </summary>
        public static Library.IDAL.IAccident CreateAccident()
        {

            string ClassNamespace = AssemblyPath + ".Accident";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Library.IDAL.IAccident)objType;
        }


        /// <summary>
        /// 创建Project数据层接口。
        /// </summary>
        public static Library.IDAL.IProject CreateProject()
        {

            string ClassNamespace = AssemblyPath + ".Project";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Library.IDAL.IProject)objType;
        }

        /// <summary>
        /// 创建UploadImages数据层接口。
        /// </summary>
        public static Library.IDAL.IUploadImages CreateUploadImages()
        {

            string ClassNamespace = AssemblyPath + ".UploadImages";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Library.IDAL.IUploadImages)objType;
        }

        /// <summary>
        /// 创建EmployeeAttendace数据层接口。
        /// </summary>
        public static Library.IDAL.IEmployeeAttendace CreateEmployeeAttendace()
        {

            string ClassNamespace = AssemblyPath + ".EmployeeAttendace";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Library.IDAL.IEmployeeAttendace)objType;
        }


        /// <summary>
        /// 创建EquimentAttendace数据层接口。
        /// </summary>
        public static Library.IDAL.IEquimentAttendace CreateEquimentAttendace()
        {

            string ClassNamespace = AssemblyPath + ".EquimentAttendace";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Library.IDAL.IEquimentAttendace)objType;
        }


        /// <summary>
        /// 创建ExpatriateAttendace数据层接口。
        /// </summary>
        public static Library.IDAL.IExpatriateAttendace CreateExpatriateAttendace()
        {

            string ClassNamespace = AssemblyPath + ".ExpatriateAttendace";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Library.IDAL.IExpatriateAttendace)objType;
        }

        /// <summary>
        /// 创建ProjectCost数据层接口。
        /// </summary>
        public static Library.IDAL.IProjectCost CreateProjectCost()
        {

            string ClassNamespace = AssemblyPath + ".ProjectCost";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Library.IDAL.IProjectCost)objType;
        }


        /// <summary>
        /// 创建CostApply数据层接口。
        /// </summary>
        public static Library.IDAL.ICostApply CreateCostApply()
        {

            string ClassNamespace = AssemblyPath + ".CostApply";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Library.IDAL.ICostApply)objType;
        }

        /// <summary>
        /// 创建Audit数据层接口。
        /// </summary>
        public static Library.IDAL.IAudit CreateAudit()
        {
            string ClassNamespace = AssemblyPath + ".Audit";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Library.IDAL.IAudit)objType;
        }

        /// <summary>
        /// 创建Role_Workflow数据层接口。
        /// </summary>
        public static Library.IDAL.IRole_Workflow CreateRole_Workflow()
        {

            string ClassNamespace = AssemblyPath + ".Role_Workflow";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Library.IDAL.IRole_Workflow)objType;
        }
    }
}
