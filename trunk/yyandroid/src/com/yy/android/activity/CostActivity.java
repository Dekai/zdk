package com.yy.android.activity;

import java.lang.reflect.Type;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;

import org.apache.http.NameValuePair;
import org.apache.http.message.BasicNameValuePair;

import android.app.Dialog;
import android.content.Context;
import android.content.Intent;
import android.os.AsyncTask;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.AdapterView;
import android.widget.AdapterView.OnItemClickListener;
import android.widget.AdapterView.OnItemLongClickListener;
import android.widget.AdapterView.OnItemSelectedListener;
import android.widget.Button;
import android.widget.CheckBox;
import android.widget.EditText;
import android.widget.FrameLayout;
import android.widget.ImageButton;
import android.widget.LinearLayout;
import android.widget.ListView;
import android.widget.Spinner;
import android.widget.TextView;
import android.widget.Toast;

import com.google.gson.reflect.TypeToken;
import com.yy.android.R;
import com.yy.android.adapter.CostAdapter;
import com.yy.android.util.JSONHttpClient;
import com.yy.android.vo.CostApply;
import com.yy.android.vo.JsonResult;
import com.yy.android.vo.ProjectCost;
import com.yy.android.vo.SpinnerData;

public class CostActivity extends MyBaseActivity implements OnItemClickListener, OnClickListener, OnItemSelectedListener, OnItemLongClickListener {

	private List<ProjectCost> costList = new ArrayList<ProjectCost>();
	private ListView listView;

	private Button btn_add_cost, btn_return, btn_apply_cost;
	private CheckBox cb;
	private TextView tv_total_cost, tv_apply_cost, tv_costTitle, tv_project_left;
	private float totalCost = 0f, applyCost = 0f;

	private final String loadCost_API = Service_Address + "projectcost/getlist";
	private final String applyCost_API = Service_Address + "costapply/create";
	private String applyDescription;
	private String applyTitle;
	private Date btnDate;
	private CostTypeEnum costType;
	private LinearLayout ll_btns;
	private FrameLayout fl_project;
	private boolean callResult = true;

	@Override
	protected void setContentView() {
		setContentView(R.layout.cost);
	}

	@Override
	protected void findViewById() {
		listView = (ListView) findViewById(R.id.cost_listview);
		btn_add_cost = (Button) findViewById(R.id.btn_add_cost);
		progress_loading = (LinearLayout) findViewById(R.id.progress_loading);
		btn_return = (Button) findViewById(R.id.btn_back);
		sp_project = (Spinner) findViewById(R.id.sp_project);
		sp_costStatus = (Spinner) findViewById(R.id.sp_costStatus);
		btn_apply_cost = (Button) findViewById(R.id.btn_apply_cost);
		tv_total_cost = (TextView) findViewById(R.id.tv_total_cost);
		tv_apply_cost = (TextView) findViewById(R.id.tv_apply_cost);
		tv_costTitle = (TextView) findViewById(R.id.tv_costTitle);
		emptyText = (TextView) findViewById(R.id.emptyText);
		tv_project_left = (TextView) findViewById(R.id.tv_project_left);
		ib_clock = (ImageButton) findViewById(R.id.ib_clock);
		ll_btns = (LinearLayout) findViewById(R.id.ll_btns);
		fl_project = (FrameLayout) findViewById(R.id.project_spn_fl);
	}

	@Override
	protected void initialize() {
		listView.setOnItemClickListener(this);
		listView.setOnItemLongClickListener(this);
		btn_return.setOnClickListener(this);
		btn_add_cost.setOnClickListener(this);
		btn_apply_cost.setOnClickListener(this);
		ib_clock.setOnClickListener(this);

		initProjectSpinner(this);
		initCostStatusSpinner(this);
		spCount = 2;
		costType = (CostTypeEnum) getIntent().getSerializableExtra("isProjectCost");
		if (costType.equals(CostTypeEnum.project)) {
			tv_costTitle.setText("工程费用登记");
			tv_project_left.setText("项目:");
			fl_project.setVisibility(View.VISIBLE);
		} else {
			tv_costTitle.setText("非工程费用登记");
			tv_project_left.setText("申请状态:");
			fl_project.setVisibility(View.GONE);
		}
		new LoadCost().execute();

	}

	@Override
	public void onClick(View v) {
		final Intent intent = new Intent();
		switch (v.getId()) {
		case R.id.btn_back:
			intent.setClass(CostActivity.this, WorkSpaceMainActivity.class);
			startActivity(intent);
			finish();
			break;
		case R.id.btn_add_cost:
			intent.putExtra("isProjectCost", costType);
			intent.setClass(this, AddCostActivity.class);
			startActivity(intent);
			finish();
			break;
		case R.id.btn_apply_cost:
			ApplyCostDialog dialog = new ApplyCostDialog(CostActivity.this);
			dialog.show();
			break;
		case R.id.ib_clock:
			showDateSearchDialog();
			break;
		}
	}

	class ApplyCost extends AsyncTask<String, String, String> {
		@Override
		protected String doInBackground(String... params) {
			try {
				JSONHttpClient jsonHttpClient = new JSONHttpClient();
				List<NameValuePair> nameValuePairs = new ArrayList<NameValuePair>();

				CostApply postData = new CostApply();

				if (costType.equals(CostTypeEnum.project)) {
					postData.setF_ProjectID(getSelectedProjectId());
				} else {
					postData.setF_ProjectID(NonProjectId);
				}
				postData.setF_ApplyType(costType.ordinal());
				postData.setF_ApplyTitle(applyTitle);
				postData.setF_ApplyAmount(applyCost);
				postData.setF_ApplyDescription(applyDescription);
				postData.setF_ApplyDate(btnDate);
				postData.setF_OperatorID(getOperatorId());
				postData.setF_OperateTime(new Date());
				postData.setF_WF_StateID(getToStateID(CostApplyTask, true));

				String IDs = "";
				for (ProjectCost data : costList) {
					if (data.isChecked()) {
						IDs += data.getF_ID() + ",";
					}
				}
				nameValuePairs.add(new BasicNameValuePair("costIDs", IDs.substring(0, IDs.length() - 1)));
				nameValuePairs.add(new BasicNameValuePair("fromState", getFromState(CostApplyTask)));
				nameValuePairs.add(new BasicNameValuePair("toState", getToState(CostApplyTask, true)));
				JsonResult result = jsonHttpClient.PostObjectWithParams(applyCost_API, nameValuePairs, postData, JsonResult.class);

				if (result.type == 0) {
					String errorMsg = result.message;
					callResult = false;
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
			stopAnim();
			runOnUiThread(new Runnable() {
				@Override
				public void run() {
					if (callResult) {
						new LoadCost().execute();
					} else {
						showAlertDialog("费用申请错误", "本项目今天已经申请过,当天不能重复申请。");
					}
				}
			});
		}
	}

	@Override
	public void onItemClick(AdapterView<?> arg0, View view, int position, long arg3) {
		ProjectCost info = costList.get(position);
		/*
		 * if (getCostStatusId() == 2) { // Toast.makeText(CostActivity.this,
		 * "已申请费用不能重复申请", // Toast.LENGTH_LONG).show(); } else { // cb =
		 * (CheckBox) view.findViewById(R.id.cb_cost); // if (info.isChecked())
		 * { // // checked // cb.setChecked(false); // info.setChecked(false);
		 * // applyCost -= info.getF_CostAmount(); // // } else { // //
		 * unchecked // applyCost += info.getF_CostAmount(); // //
		 * cb.setChecked(true); // info.setChecked(true); // } // // applyCost =
		 * formatFloat(applyCost); // //
		 * tv_total_cost.setText(String.valueOf(totalCost)); //
		 * tv_apply_cost.setText(String.valueOf(applyCost));
		 * 
		 * }
		 */
		if (getCostStatusId() == 2) {
			Toast.makeText(CostActivity.this, "已申请费用不能修改", Toast.LENGTH_LONG).show();

		} else {

			final Intent intent = new Intent();
			intent.setClass(this, AddCostActivity.class);
			intent.putExtra("isProjectCost", costType);
			intent.putExtra("projectcost", info);
			startActivity(intent);
			finish();
		}
	}

	class LoadCost extends AsyncTask<String, String, String> {
		@Override
		protected String doInBackground(String... params) {
			try {
				JSONHttpClient jsonHttpClient = new JSONHttpClient();
				List<NameValuePair> nameValuePairs = new ArrayList<NameValuePair>();
				int costStatusId = getCostStatusId();
				SpinnerData selectItem = (SpinnerData) sp_project.getSelectedItem();
				nameValuePairs.add(new BasicNameValuePair("applyType", String.valueOf(costType.ordinal())));

				if (costType.equals(CostTypeEnum.project)) {
					nameValuePairs.add(new BasicNameValuePair("projectid", selectItem.getValue()));
				} else {
					nameValuePairs.add(new BasicNameValuePair("projectid", String.valueOf(NonProjectId)));
				}

				if (costStatusId == 1) {
					nameValuePairs.add(new BasicNameValuePair("costStatus", "no"));
				} else if (costStatusId == 2) {
					nameValuePairs.add(new BasicNameValuePair("costStatus", "yes"));
				}

				nameValuePairs.add(new BasicNameValuePair("startdate", startDateString));
				nameValuePairs.add(new BasicNameValuePair("enddate", endDateString));

				Type listType = new TypeToken<List<ProjectCost>>() {
				}.getType();

				costList = jsonHttpClient.GetList(loadCost_API, nameValuePairs, ProjectCost.class, listType);

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
					CostAdapter adapter = new CostAdapter(CostActivity.this, costList, getCostStatusId(), costType);
					adapter.MyOnCheckedChangeListener = new lvButtonListener();
					listView.setAdapter(adapter);

					if (costList.size() == 0) {
						emptyText.setVisibility(View.VISIBLE);
					}

					initTotalCost(costList);
				}
			});
		}
	}

	class lvButtonListener implements OnClickListener {

		@Override
		public void onClick(View v) {
			int position = Integer.valueOf(v.getTag().toString());
			ProjectCost info = costList.get(position);
			cb = (CheckBox) v;
			if (info.isChecked()) {
				// checked
				cb.setChecked(false);
				info.setChecked(false);
				applyCost -= info.getF_CostAmount();

			} else {
				// unchecked
				applyCost += info.getF_CostAmount();

				cb.setChecked(true);
				info.setChecked(true);
			}

			applyCost = formatFloat(applyCost);

			tv_total_cost.setText(String.valueOf(totalCost));
			tv_apply_cost.setText(String.valueOf(applyCost));
		}

	}

	private void initTotalCost(List<ProjectCost> costList) {
		totalCost = 0;
		applyCost = 0;
		for (ProjectCost cost : costList) {
			totalCost += cost.getF_CostAmount();
		}
		applyCost = totalCost;
		tv_total_cost.setText(String.valueOf(totalCost));
		tv_apply_cost.setText(String.valueOf(totalCost));
	}

	@Override
	public void onNothingSelected(AdapterView<?> parent) {
		// TODO Auto-generated method stub

	}

	@Override
	protected void updateList() {
		// TODO Auto-generated method stub
		new LoadCost().execute();
	}

	class ApplyCostDialog extends Dialog {
		EditText commentsTxt;
		EditText applyTitle;
		Button btn_date;
		LinearLayout ll_project;

		public ApplyCostDialog(Context context) {
			super(context);
			// TODO Auto-generated constructor stub
		}

		protected void onCreate(Bundle savedInstanceState) {
			super.onCreate(savedInstanceState);

			setContentView(R.layout.apply_cost_dialog);
			setTitle("报销申请信息");

			TextView amountTxt = (TextView) findViewById(R.id.et_amount);
			amountTxt.setText(String.valueOf(applyCost));
			applyTitle = (EditText) findViewById(R.id.et_title);
			applyTitle.setText(CostActivity.this.applyTitle);
			commentsTxt = (EditText) findViewById(R.id.et_apply_des);
			commentsTxt.setText(CostActivity.this.applyDescription);

			ll_project = (LinearLayout) findViewById(R.id.ll_project);
			if (costType.equals(CostTypeEnum.project)) {
				ll_project.setVisibility(View.VISIBLE);
				TextView projectTxt = (TextView) findViewById(R.id.et_project);
				projectTxt.setText(getSelectedProjectText());
			} else {
				ll_project.setVisibility(View.GONE);
			}

			btn_date = (Button) findViewById(R.id.btn_date);
			btn_date.setText(format(calendar.getTime()));
			btn_date.setOnClickListener(new View.OnClickListener() {
				public void onClick(View v) {
					ShowTimePicker(btn_date);
				}
			});

			Button buttonYes = (Button) findViewById(R.id.btn_ok);
			buttonYes.setOnClickListener(new Button.OnClickListener() {
				public void onClick(View v) {
					CostActivity.this.applyDescription = commentsTxt.getText().toString();
					CostActivity.this.applyTitle = applyTitle.getText().toString();
					CostActivity.this.btnDate = GetBtnDate(btn_date);
					dismiss();
					new ApplyCost().execute();

				}
			});
			Button buttonNo = (Button) findViewById(R.id.btn_cancel);
			buttonNo.setSingleLine(true);
			buttonNo.setOnClickListener(new Button.OnClickListener() {

				public void onClick(View v) {
					// TODO Auto-generated method stub
					dismiss();

				}
			});
		}

		// called when this dialog is dismissed
		protected void onStop() {
			Log.d("TAG", "+++++++++++++++++++++++++++");
		}
	}

	@Override
	public void onItemSelected(AdapterView<?> parent, View view, int position, long id) {

		if (initSpCount < spCount) {
			initSpCount++;
		} else {
			if (getCostStatusId() == 1) {
				ll_btns.setVisibility(View.VISIBLE);
			} else if (getCostStatusId() == 2) {
				ll_btns.setVisibility(View.GONE);
			}
			new LoadCost().execute();
		}
	}

	@Override
	public boolean onItemLongClick(AdapterView<?> parent, View view, int position, long id) {
		if (getCostStatusId() == 2) {
			Toast.makeText(CostActivity.this, "已申请费用不能修改", Toast.LENGTH_LONG).show();
			return false;
		} else {
			ProjectCost info = costList.get(position);
			final Intent intent = new Intent();
			intent.setClass(this, AddCostActivity.class);
			intent.putExtra("isProjectCost", costType);
			intent.putExtra("projectcost", info);
			startActivity(intent);
			return false;
		}
	}
}
