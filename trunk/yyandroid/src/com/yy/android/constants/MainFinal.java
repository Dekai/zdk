package com.yy.android.constants;

import java.util.ArrayList;
import java.util.List;

import com.yy.android.R;
import com.yy.android.activity.MyBaseActivity;
import com.yy.android.vo.ViewPagerBean;

public class MainFinal {
	public static List<ViewPagerBean> allList;
	public static List<ViewPagerBean> list1;
	public static List<ViewPagerBean> list2;
	// 定义整型数组 即图片源 main1
	public static int[] mImageIds1 = { R.drawable.disk_sysclear_alert,// 员工考勤
			R.drawable.disk_phone_block,// 外雇人员登记
			R.drawable.disk_phone_exam_default,// 出场设备登记
			R.drawable.disk_anti_scan,// 工程费用
			R.drawable.disk_power_manager,// 非工程费用
			R.drawable.disk_privacy_protection,// 事故管理
			R.drawable.disk_program_manager,// 项目管理
			R.drawable.disk_secure_bak,// 物资申请
	};
	// 定义整型数组 即图片源 main2
	public static int[] mImageIds2 = { R.drawable.disk_flow_traffic,// 成品定价审批
			R.drawable.disk_secure_bak,// 运费定价审批
			R.drawable.disk_phone_anti_open,// 付款审批
			R.drawable.disk_app_market,// 工程费用审批
			R.drawable.disk_advertise_block,// 非工程费用审批
			R.drawable.qr_code,// 财务确认
			R.drawable.disk_use_tools,// 我的报账记录
	};
	// 主界面1GridViewItem名
	public static String[] itemName1 = { "员工考勤", "外雇人员登记", "出场设备登记", "工程费用", "非工程费用", "事故管理", "项目管理", "物资申请", };
	// 主界面2GridViewItem名
	public static String[] itemName2 = { "成品定价审批", "运费定价审批", "付款审批", "工程费用审批", "非工程费用审批", "财务审批", "我的报账记录", };

	// 主界面1GridViewItem名
	public static String[] rightCode1 = { "Mobile.StaffAttendance", "Mobile.WorkerAttendance", "Mobile.EquimentAttendance", "Mobile.ProjectCost",
			"Mobile.NonProjectCost", "Mobile.Accident", "Mobile.ProjectManagement", "Mobile.MaterialApply", };
	// 主界面2GridViewItem名
	public static String[] rightCode2 = { "Mobile.ProductAudit", "Mobile.FeeAudit", "Mobile.PaymentAudit", "Mobile.ProjectCostAudit",
			"Mobile.NonProjectCostAudit", "Mobile.FinanceConfirm", "Mobile.MyApply", };

	public static List<ViewPagerBean> getbeans1() {
		list1 = new ArrayList<ViewPagerBean>();
		for (int i = 0; i < itemName1.length; i++) {
			if (MyBaseActivity.checkUserRight(rightCode1[i])) {
				ViewPagerBean bean = new ViewPagerBean();
				bean.setRightCode(rightCode1[i]);
				bean.setName(itemName1[i]);
				bean.setId(mImageIds1[i]);
				list1.add(bean);
			}
		}
		return list1;

	}

	public static List<ViewPagerBean> getbeans2() {
		list2 = new ArrayList<ViewPagerBean>();
		for (int i = 0; i < itemName2.length; i++) {
			if (MyBaseActivity.checkUserRight(rightCode2[i])) {
				ViewPagerBean bean = new ViewPagerBean();
				bean.setRightCode(rightCode2[i]);
				bean.setName(itemName2[i]);
				bean.setId(mImageIds2[i]);
				list2.add(bean);
			}
		}
		return list2;

	}
	
	public static List<ViewPagerBean> getAllbeans() {
		allList = new ArrayList<ViewPagerBean>();
		allList.addAll(getbeans1());
		allList.addAll(getbeans2());
		return allList;

	}

}