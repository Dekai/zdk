package com.yy.android.activity;

import java.util.Calendar;

import android.content.Intent;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.os.AsyncTask;
import android.view.KeyEvent;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.AdapterView;
import android.widget.AdapterView.OnItemSelectedListener;
import android.widget.Button;
import android.widget.EditText;
import android.widget.LinearLayout;
import android.widget.Spinner;
import android.widget.TextView;
import android.widget.Toast;

import com.yy.android.R;
import com.yy.android.activity.AddWorkerActivity.HandleExpatriateAttendance;
import com.yy.android.util.JSONHttpClient;
import com.yy.android.util.Res;
import com.yy.android.vo.JsonResult;
import com.yy.android.vo.ProjectCost;
import com.yy.android.vo.SpinnerData;

public class AddCostActivity extends MyBaseActivity implements OnClickListener, OnItemSelectedListener {
	private Calendar calendar = Calendar.getInstance();
	private View parentView;
	private Button btn_add, btn_delete;
	private Button btn_back, btn_date;
	public static Bitmap bimap;
	private EditText et_cost_amount, et_other_cost, et_cost_des;
	private TextView tv_cost_title, tv_cost_other;
	public boolean isAdd = true;
	private int dataID;
	private CostTypeEnum costType;
	private LinearLayout ll_costType, ll_otherCost, ll_project;

	private String addCost_API = Service_Address + "projectcost/create";
	private String updateCost_API = Service_Address + "projectcost/edit";

	@Override
	protected void setContentView() {
		Res.init(this);
		bimap = BitmapFactory.decodeResource(getResources(), R.drawable.icon_addpic_unfocused);
		parentView = getLayoutInflater().inflate(R.layout.add_cost, null);
		setContentView(parentView);
	}

	@Override
	protected void findViewById() {

		sp_project = (Spinner) findViewById(R.id.sp_project);
		sp_cost = (Spinner) findViewById(R.id.sp_cost_type);
		et_cost_amount = (EditText) findViewById(R.id.et_cost_amount);
		btn_date = (Button) findViewById(R.id.btn_date);
		et_cost_des = (EditText) findViewById(R.id.et_cost_des);
		et_other_cost = (EditText) findViewById(R.id.et_cost_other);
		tv_cost_title = (TextView) findViewById(R.id.tv_cost_title);
		tv_cost_other = (TextView) findViewById(R.id.tv_cost_other);
		btn_back = (Button) findViewById(R.id.btn_back);
		btn_add = (Button) findViewById(R.id.btn_add);
		btn_delete = (Button) findViewById(R.id.btn_delete);
		ll_costType = (LinearLayout) findViewById(R.id.ll_costType);
		ll_otherCost = (LinearLayout) findViewById(R.id.ll_otherCost);
		ll_project = (LinearLayout) findViewById(R.id.ll_project);
		progress_loading = (LinearLayout) findViewById(R.id.progress_loading);
	}

	@Override
	protected void initialize() {
		btn_add.setOnClickListener(this);
		btn_delete.setOnClickListener(this);
		btn_back.setOnClickListener(this);
		btn_date.setOnClickListener(this);
		spCount = 2;
		Intent intent = getIntent();
		ProjectCost dataInfo = (ProjectCost) intent.getSerializableExtra("projectcost");
		costType = (CostTypeEnum) getIntent().getSerializableExtra("isProjectCost");
		if (dataInfo != null) {
			dataID = dataInfo.getF_ID();
			if (costType.equals(CostTypeEnum.project)) {
				ll_project.setVisibility(View.VISIBLE);
				initProjectSpinner(this, String.valueOf(dataInfo.getF_ProjectID()));
				initCostSpinner(this, String.valueOf(dataInfo.getF_CostType()));
				if (dataInfo.getF_CostType() == OtherCost) {
					ll_otherCost.setVisibility(View.VISIBLE);
					tv_cost_other.setText("其他费用");
					et_other_cost.setText(dataInfo.getF_OtherCost());
				}
			} else {
				ll_project.setVisibility(View.GONE);
				ll_costType.setVisibility(View.GONE);
				ll_otherCost.setVisibility(View.VISIBLE);
				tv_cost_other.setText("费用名称");
				et_other_cost.setText(dataInfo.getF_OtherCost());
			}

			et_cost_amount.setText(String.valueOf(dataInfo.getF_CostAmount()));
			et_cost_des.setText(dataInfo.getF_CostDescription());
			btn_date.setText(dateFormat.format(dataInfo.getF_CostDate()));
			tv_cost_title.setText("修改费用");
			btn_add.setText("修改费用");
			btn_delete.setText("删除费用");

			isAdd = false;
		} else {

			if (costType.equals(CostTypeEnum.project)) {
				ll_project.setVisibility(View.VISIBLE);
				initCostSpinner(this);
				initProjectSpinner(this);
				tv_cost_other.setText("其他费用");
			} else {
				ll_project.setVisibility(View.GONE);
				ll_costType.setVisibility(View.GONE);
				ll_otherCost.setVisibility(View.VISIBLE);
				tv_cost_other.setText("费用名称");
			}

			btn_date.setText(format(calendar.getTime()));
			tv_cost_title.setText("新增费用");
			btn_add.setText("新增费用");
			btn_delete.setText("返回列表");
		}

		btn_date.setText(format(calendar.getTime()));
	}

	@Override
	public void onClick(View v) {
		switch (v.getId()) {
		case R.id.btn_back:
			Intent intent = new Intent();
			intent.putExtra("isProjectCost", costType);
			intent.setClass(AddCostActivity.this, CostActivity.class);
			startActivity(intent);
			finish();
			break;
		case R.id.btn_delete:
			if (isAdd) {
				finish();
			} else {
				new HandleCost().execute("delete");
			}
			break;
		case R.id.btn_date:
			ShowTimePickerBack(btn_date, false);
			break;
		case R.id.btn_add:
			boolean inputValidate = true;
			if (costType.equals(CostTypeEnum.nonproject) && et_other_cost.getText().toString().length() == 0) {
				et_other_cost.setError("请输入费用名称");
				inputValidate = false;
			}
			try {
				Float.parseFloat(et_cost_amount.getText().toString());

			} catch (NumberFormatException e) {
				inputValidate = false;
				et_cost_amount.setError("请以正确数字形式输入");
			}

			if (inputValidate) {
				new HandleCost().execute();

			} else {
				Toast.makeText(AddCostActivity.this, "请填写正确信息", Toast.LENGTH_LONG).show();
			}
			break;
		}
	}

	@Override
	public boolean onKeyDown(int keyCode, KeyEvent event) {

		if (keyCode == KeyEvent.KEYCODE_BACK) {

			Intent intent1 = new Intent(AddCostActivity.this, CostActivity.class);
			intent1.putExtra("isProjectCost", costType);
			startActivity(intent1);

			AddCostActivity.this.finish();

		}
		return true;
	}

	class HandleCost extends AsyncTask<String, String, String> {
		@Override
		protected String doInBackground(String... params) {
			try {
				JSONHttpClient jsonHttpClient = new JSONHttpClient();
				ProjectCost pageData = GatherPageData();
				JsonResult result;
				if (params.length > 0 && params[0].equals("delete")) {
					pageData.setF_ID(dataID);
					pageData.setF_IsDelete(true);
					result = jsonHttpClient.PostObject(updateCost_API, pageData, JsonResult.class);
				} else {
					if (isAdd) {
						result = jsonHttpClient.PostObject(addCost_API, pageData, JsonResult.class);
					} else {
						pageData.setF_ID(dataID);
						result = jsonHttpClient.PostObject(updateCost_API, pageData, JsonResult.class);
					}
				}
				if (result.type == 0) {
					// Json call failed
					String errorMsg = result.message;
				}
			} catch (Exception e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			}
			return null;
		}

		@Override
		protected void onPreExecute() {
			super.onPreExecute();
			showAnim();
		}

		@Override
		protected void onPostExecute(String s) {
			runOnUiThread(new Runnable() {
				@Override
				public void run() {
					stopAnim();
					// TODO: confirm and back to list
					Intent intent = new Intent();
					intent.putExtra("isProjectCost", costType);
					intent.setClass(AddCostActivity.this, CostActivity.class);
					startActivity(intent);
					finish();
				}
			});
		}
	}

	private ProjectCost GatherPageData() {
		ProjectCost pageData = new ProjectCost();

		if (costType.equals(CostTypeEnum.project)) {
			pageData.setF_CostType(getSelectedCostId());
			pageData.setF_ProjectID(Integer.parseInt(((SpinnerData) sp_project.getSelectedItem()).getValue()));
			pageData.setF_CostType(Integer.parseInt(((SpinnerData) sp_cost.getSelectedItem()).getValue()));
		} else {
			pageData.setF_ProjectID(NonProjectId);
		}
		pageData.setF_CostAmount((Float.valueOf(et_cost_amount.getText().toString())));
		pageData.setF_CostDate(GetBtnDate(btn_date));
		pageData.setF_OtherCost(et_other_cost.getText().toString());
		pageData.setF_CostDescription(et_cost_des.getText().toString());
		if (costType.equals(CostTypeEnum.project)) {
			pageData.setF_IsProjectCost(true);
		} else {
			pageData.setF_IsProjectCost(false);
		}
		pageData.setF_OperatorID(getOperatorId());
		return pageData;
	}

	@Override
	public void onItemSelected(AdapterView<?> parent, View view, int position, long id) {
		if (initSpCount < spCount) {
			initSpCount++;
		} else {
			if (parent != null) {
				switch (parent.getId()) {
				case R.id.sp_project:
					// storing string resources into Array
					// projects =
					// getResources().getStringArray(R.array.project);
					//
					// Toast.makeText(getBaseContext(),
					// "You have selected project : " +
					// projects[index], Toast.LENGTH_SHORT).show();
					break;
				case R.id.sp_cost_type:
					int costId = getSelectedCostId();
					if (costId == OtherCost) {
						// ll_costType.setVisibility(View.GONE);
						ll_otherCost.setVisibility(View.VISIBLE);
					} else {
						// ll_costType.setVisibility(View.VISIBLE);
						ll_otherCost.setVisibility(View.GONE);
					}
					break;
				}
			}
		}
	}

	@Override
	public void onNothingSelected(AdapterView<?> parent) {
		// TODO Auto-generated method stub

	}

	@Override
	protected void updateList() {
		// TODO Auto-generated method stub

	}

}
