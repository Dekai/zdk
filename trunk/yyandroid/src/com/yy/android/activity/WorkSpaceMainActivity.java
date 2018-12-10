package com.yy.android.activity;

import java.util.ArrayList;
import java.util.List;

import android.content.Intent;
import android.support.v4.view.ViewPager;
import android.support.v4.view.ViewPager.OnPageChangeListener;
import android.view.LayoutInflater;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.AdapterView;
import android.widget.AdapterView.OnItemClickListener;
import android.widget.GridView;
import android.widget.ImageView;
import android.widget.TextView;

import com.yy.android.R;
import com.yy.android.adapter.MainGridViewAdapter;
import com.yy.android.adapter.MyPagerAdapter;
import com.yy.android.constants.MainFinal;
import com.yy.android.util.UpdateManager;
import com.yy.android.vo.ViewPagerBean;

public class WorkSpaceMainActivity extends MyBaseActivity implements OnItemClickListener, OnClickListener, OnPageChangeListener {

	// private ImageView btnImgSvc, btnImgUpload;
	private ViewPager viewpager;
	MyPagerAdapter viewPagerAdt;
	private List<View> listvp;
	private View view1;
	private View view2;
	private GridView gridview1;
	private GridView gridview2;
	private MainGridViewAdapter gridviewAdt1;
	private MainGridViewAdapter gridviewAdt2;
	private TextView tv;

	private ImageView ImageView;

	@Override
	public void findViewById() {
		// btnImgSvc = (ImageView) findViewById(R.id.btn_img_svc);
		// btnImgUpload = (ImageView) findViewById(R.id.btn_img_upload);

		viewpager = (ViewPager) findViewById(R.id.act_main_viewpager);
		ImageView = (ImageView) findViewById(R.id.tab);
	}

	@Override
	protected void setContentView() {
		setContentView(R.layout.activity_main);

	}

	@Override
	protected void initialize() {
		// btnImgSvc.setOnClickListener(this);
		// btnImgUpload.setOnClickListener(this);
	
		initProjectSpinner(null);
		UpdateVersion();
	}
	
	private void UpdateVersion(){
		
		UpdateManager manager = new UpdateManager(WorkSpaceMainActivity.this);
		// ����������
		manager.checkUpdate();

	}

	@Override
	protected void buildPorjectSpinner() {
		
		List<ViewPagerBean> allBeans =MainFinal.getAllbeans();
		if (allBeans.size() > 8) {

			view1 = LayoutInflater.from(this).inflate(R.layout.first_main_gridview, null);
			view2 = LayoutInflater.from(this).inflate(R.layout.second_main_gridview, null);

			gridview1 = (GridView) view1.findViewById(R.id.first_main_gridview);
			gridview2 = (GridView) view2.findViewById(R.id.second_main_gridview);
			listvp = new ArrayList<View>();

			gridviewAdt1 = new MainGridViewAdapter(this, 1);
			gridviewAdt2 = new MainGridViewAdapter(this, 2);
			gridview1.setAdapter(gridviewAdt1);
			gridview2.setAdapter(gridviewAdt2);

			listvp.add(view1);
			listvp.add(view2);
			viewPagerAdt = new MyPagerAdapter(listvp);
			viewpager.setAdapter(viewPagerAdt);

			// 为GridView设置上item点击事件
			gridview1.setOnItemClickListener(this);
			gridview2.setOnItemClickListener(this);
		} else {
			view1 = LayoutInflater.from(this).inflate(R.layout.first_main_gridview, null);

			gridview1 = (GridView) view1.findViewById(R.id.first_main_gridview);
			listvp = new ArrayList<View>();

			gridviewAdt1 = new MainGridViewAdapter(this, allBeans);
			gridview1.setAdapter(gridviewAdt1);

			listvp.add(view1);
			viewPagerAdt = new MyPagerAdapter(listvp);
			viewpager.setAdapter(viewPagerAdt);

			// 为GridView设置上item点击事件
			gridview1.setOnItemClickListener(this);
			ImageView.setVisibility(View.GONE);
		}
		viewpager.setOnPageChangeListener(this);
		
		
		
	}
	
	@Override
	public boolean onCreateOptionsMenu(Menu menu) {
		// Inflate the menu; this adds items to the action bar if it is present.
		getMenuInflater().inflate(R.menu.main, menu);
		return true;
	}

	@Override
	public boolean onOptionsItemSelected(MenuItem item) {
		// Handle action bar item clicks here. The action bar will
		// automatically handle clicks on the Home/Up button, so long
		// as you specify a parent activity in AndroidManifest.xml.
		int id = item.getItemId();
		if (id == R.id.action_settings) {
			return true;
		}
		return super.onOptionsItemSelected(item);
	}

	@Override
	public void onClick(View v) {
		Intent intent = new Intent();
		// switch (v.getId()) {
		// case R.id.btn_img_svc:
		// intent.setClass(MainActivity.this,
		// com.yy.android.activity.CallService.class);
		// startActivity(intent);
		// break;
		// case R.id.btn_img_upload:
		// intent.setClass(MainActivity.this,
		// com.yy.android.activity.ImageUpload.class);
		// startActivity(intent);
		// break;
		// default:
		// break;
		// }
	}

	@Override
	public void onPageScrollStateChanged(int arg0) {
		// TODO Auto-generated method stub

	}

	@Override
	public void onPageScrolled(int arg0, float arg1, int arg2) {
		// TODO Auto-generated method stub

	}

	@Override
	public void onPageSelected(int arg0) {
		// TODO Auto-generated method stub
		if (arg0 == 0) {

			ImageView.setImageDrawable(getResources().getDrawable(R.drawable.tab));
		} else {

			ImageView.setImageDrawable(getResources().getDrawable(R.drawable.tab1));
		}

	}

	@Override
	public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
		// TODO Auto-generated method stub
		tv = (TextView) view.findViewById(R.id.main_gridview_item_name);
		String text = tv.getText().toString();
		final Intent intent = new Intent();
		if (text.equals("员工考勤")) {
			intent.setClass(WorkSpaceMainActivity.this, StaffAttendanceActivity.class);
			startActivity(intent);

		} else if (text.equals("事故管理")) {
			intent.setClass(WorkSpaceMainActivity.this, AccidentListActivity.class);
			startActivity(intent);
			this.finish();
		} else if (text.equals("工程费用")) {
			intent.putExtra("isProjectCost", CostTypeEnum.project);
			intent.setClass(WorkSpaceMainActivity.this, CostActivity.class);
			startActivity(intent);
		} else if (text.equals("非工程费用")) {
			intent.putExtra("isProjectCost", CostTypeEnum.nonproject);
			intent.setClass(WorkSpaceMainActivity.this, CostActivity.class);
			startActivity(intent);
		} else if (text.equals("外雇人员登记")) {
			intent.setClass(WorkSpaceMainActivity.this, WorkerActivity.class);
			startActivity(intent);
		} else if (text.equals("工程费用审批")) {
			intent.putExtra("isProjectCost", CostTypeEnum.project);
			intent.setClass(WorkSpaceMainActivity.this, CostApplyActivity.class);
			startActivity(intent);
		} else if (text.equals("非工程费用审批")) {
			intent.putExtra("isProjectCost", CostTypeEnum.nonproject);
			intent.setClass(WorkSpaceMainActivity.this, CostApplyActivity.class);
			startActivity(intent);
		} else if (text.equals("我的报账记录")) {
			intent.setClass(WorkSpaceMainActivity.this, MyApplyActivity.class);
			startActivity(intent);
		} else if (text.equals("出场设备登记")) {
			intent.setClass(WorkSpaceMainActivity.this, EquimentActivity.class);
			startActivity(intent);
		} else if (text.equals("项目管理")) {
			intent.setClass(WorkSpaceMainActivity.this, ProjectActivity.class);
			startActivity(intent);
		} else if (text.equals("物资申请")) {
			intent.setClass(WorkSpaceMainActivity.this, MaterialApplyActivity.class);
			startActivity(intent);
		} else if (text.equals("财务审批")) {
			intent.setClass(WorkSpaceMainActivity.this, FinanceConfirmActivity.class);
			startActivity(intent);
		} else if (text.equals("成品定价审批")) {
			intent.putExtra("AuditType", AuditTypeEnum.audit_product);
			intent.setClass(WorkSpaceMainActivity.this, AuditActivity.class);
			startActivity(intent);
		} else if (text.equals("运费定价审批")) {
			intent.putExtra("AuditType", AuditTypeEnum.audit_fee);
			intent.setClass(WorkSpaceMainActivity.this, AuditActivity.class);
			startActivity(intent);
		} else if (text.equals("付款审批")) {
			intent.putExtra("AuditType", AuditTypeEnum.audit_payment);
			intent.setClass(WorkSpaceMainActivity.this, AuditActivity.class);
			startActivity(intent);
		}

	}

	@Override
	protected void updateList() {
		// TODO Auto-generated method stub

	}

}
