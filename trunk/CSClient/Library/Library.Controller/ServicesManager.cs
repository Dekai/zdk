using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Library.BLL;

namespace Library.Controller
{
    public class ServicesManager
    {
        public ServicesManager()
        {
            DataDicInfoService = new DataDicInfoService();
            DataDicTypeService = new DataDicTypeService();
            EmployeeService = new EmployeeService();
            EquipmentService = new EquipmentService();


            LoginUserService = new LoginUserService();
            RightService = new RightService();
            Role_Right_RelationService = new Role_Right_RelationService();
            RoleService = new RoleService();


            Base_FareService = new Base_FareService();
            Base_PaymentService = new Base_PaymentService();
            Base_ProductService = new Base_ProductService();
            WorkFlow_TempleteService = new WorkFlow_TempleteService();


            Test_Table_TempleteService = new Test_Table_TempleteService();
            Test_TableService = new Test_TableService();
            Test_Field_TempleteService = new Test_Field_TempleteService();
            Test_FieldService = new Test_FieldService();

            ProjectService = new ProjectService();
            AccidentService = new AccidentService();
            UploadImagesService = new UploadImagesService();

            EmployeeAttendaceService = new EmployeeAttendaceService();
            EquimentAttendaceService = new EquimentAttendaceService();
            ExpatriateAttendaceService = new ExpatriateAttendaceService();
            ProjectCostService = new ProjectCostService();
            CostApplyService = new CostApplyService();

                AuditService = new AuditService();
             Role_WorkflowService = new Role_WorkflowService();
        }
        public Role_WorkflowService Role_WorkflowService;
        public DataDicInfoService DataDicInfoService;
        public DataDicTypeService DataDicTypeService;
        public EmployeeService EmployeeService;
        public EquipmentService EquipmentService;

        public LoginUserService LoginUserService;
        public RightService RightService;
        public Role_Right_RelationService Role_Right_RelationService;
        public RoleService RoleService;

        public Base_FareService Base_FareService;
        public Base_PaymentService Base_PaymentService;
        public Base_ProductService Base_ProductService;
        public WorkFlow_TempleteService WorkFlow_TempleteService;


        public Test_Table_TempleteService Test_Table_TempleteService;
        public Test_TableService Test_TableService;
        public Test_Field_TempleteService Test_Field_TempleteService;
        public Test_FieldService Test_FieldService;

        public ProjectService ProjectService;
        public AccidentService AccidentService;
        public UploadImagesService UploadImagesService;

        public EmployeeAttendaceService EmployeeAttendaceService;
        public EquimentAttendaceService EquimentAttendaceService;
        public ExpatriateAttendaceService ExpatriateAttendaceService;
        public ProjectCostService ProjectCostService;
        
        public CostApplyService CostApplyService;
        public AuditService AuditService;

        

    }
}
