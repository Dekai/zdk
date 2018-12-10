package com.yy.android.activity;

import java.lang.reflect.Type;
import java.util.ArrayList;
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
import android.widget.AdapterView.OnItemSelectedListener;
import android.widget.Button;
import android.widget.EditText;
import android.widget.LinearLayout;
import android.widget.ListView;
import android.widget.TextView;

import com.google.gson.reflect.TypeToken;
import com.yy.android.R;
import com.yy.android.activity.CostActivity.ApplyCost;
import com.yy.android.activity.MyBaseActivity.CostTypeEnum;
import com.yy.android.adapter.CostApplyDetailAdapter;
import com.yy.android.util.JSONHttpClient;
import com.yy.android.vo.CostApply;
import com.yy.android.vo.JsonResult;
import com.yy.android.vo.ProjectCost;

public class CostDetailActivity extends MyBaseActivity implements OnClickListener, OnItemSelectedListener {

	private List<ProjectCost> dataList = new ArrayList<ProjectCost>();
	private ListView listView;
	private CostApplyDetailAdapter adapter;
	private Button btn_reject, btn_return, btn_date, btn_approve, btn_delete, btn_btm_back;
	private TextView tv_apply_cost, tv_operator, tv_apply_date, tv_title;
	private CostApply dataInfo;
	private LinearLayout ll_myapply, ll_costapply;
	private String operation, operatorType, operationDescription, showType;
	private CostTypeEnum costType;

	private String handleCostApply_API = Service_Address + "costapply/handle";
	private final String loadCost_API = Service_Address + "projectcost/getlist";

	@Override
	protected void setContentView() {
		setContentView(R.layout.cost_detail);
	}

	@Override
	protected void findViewById() {
		listView = (ListView) findViewById(R.id.cost_listview);
		btn_reject = (Button) findViewById(R.id.btn_reject);
		btn_return = (Button) findViewById(R.id.btn_back);
		btn_btm_back = (Button) findViewById(R.id.btn_btm_back);
		btn_delete = (Button) findViewById(R.id.btn_delete);
		btn_approve = (Button) findViewById(R.id.btn_approve);
		tv_apply_cost = (TextView) findViewById(R.id.tv_apply_cost);
		tv_operator = (TextView) findViewById(R.id.tv_operator);
		tv_apply_date = (TextView) findViewById(R.id.tv_apply_date);
		tv_title = (TextView) findViewById(R.id.tv_title);
		progress_loading = (LinearLayout) findViewById(R.id.progress_loading);
		emptyText = (TextView) findViewById(R.id.emptyText);
		ll_myapply = (LinearLayout) findViewById(R.id.ll_myapply);
		ll_costapply = (LinearLayout) findViewById(R.id.ll_costapply);
	}

	@Override
	protected void initialize() {
		btn_return.setOnClickListener(this);
		btn_reject.setOnClickListener(this);
		btn_approve.setOnClickListener(this);
		btn_delete.setOnClickListener(this);
		btn_btm_back.setOnClickListener(this);

		Intent paramintent = getIntent();
		dataInfo = (CostApply) paramintent.getSerializableExtra("costapply");
		costType = (CostTypeEnum) getIntent().getSerializableExtra("isProjectCost");
		showType = paramintent.getStringExtra("showType");
		if (showType.equals("MyApply")) {
			tv_title.setText("我的报账明细");
			ll_myapply.setVisibility(View.VISIBLE);
			ll_costapply.setVisibility(View.GONE);
		} else if (showType.equals("CostApply")) {
			operatorType = "Manager";
			tv_title.setText("工程费用审批");
			btn_approve.setText("批准申请");
			btn_reject.setText("驳回申请");
			ll_myapply.setVisibility(View.GONE);
			ll_costapply.setVisibility(View.VISIBLE);
		} else if (showType.equals("FinanceConfirm")) {
			operatorType = "Finance";
			btn_approve.setText("财务确认");
			btn_reject.setText("财务驳回");
			tv_title.setText("财务确认");
			ll_myapply.setVisibility(View.GONE);
			ll_costapply.setVisibility(View.VISIBLE);
		}
		tv_operator.setText(getOperator());
		tv_apply_cost.setText(String.valueOf(dataInfo.getF_ApplyAmount()));
		tv_operator.setText(dataInfo.getOperator());
		tv_apply_date.setText(format(dataInfo.getF_ApplyDate()));

		new LoadCost().execute();

	}

	@Override
	public void onClick(View v) {
		final Intent intent = new Intent();
		switch (v.getId()) {
		case R.id.btn_back:
			intent.putExtra("isProjectCost", costType);
			if (showType.equals("MyApply")) {
				intent.setClass(CostDetailActivity.this, MyApplyActivity.class);
			} else if (showType.equals("CostApply")) {
				intent.setClass(CostDetailActivity.this, CostApplyActivity.class);
			} else if (showType.equals("FinanceConfirm")) {
				intent.setClass(CostDetailActivity.this, FinanceConfirmActivity.class);
			}
			startActivity(intent);
			finish();
			break;
		case R.id.btn_reject:
			operation = "reject";
			new HandleCostDialog(CostDetailActivity.this).show();
			break;
		case R.id.btn_approve:
			operation = "approve";
			new HandleCostDialog(CostDetailActivity.this).show();
			break;
		case R.id.btn_delete:
			new HandleCostApply().execute("delete");
			break;
		case R.id.btn_btm_back:
			finish();
			break;
		case R.id.btn_date:
			ShowTimePicker(btn_date);
			break;
		}
	}

	class HandleCostDialog extends Dialog {
		EditText commentsTxt;
		EditText applyTitle;
		Button btn_date;

		public HandleCostDialog(Context context) {
			super(context);
			// TODO Auto-generated constructor stub
		}

		protected void onCreate(Bundle savedInstanceState) {
			super.onCreate(savedInstanceState);

			setContentView(R.layout.handle_cost_dialog);
			if (operation.equals("approve")) {
				setTitle("批准申请备注");
			} else if (operation.equals("reject")) {
				setTitle("驳回申请备注");
			}

			TextView amountTxt = (TextView) findViewById(R.id.et_amount);
			amountTxt.setText(String.valueOf(dataInfo.getF_ApplyAmount()));
			applyTitle = (EditText) findViewById(R.id.et_title);
			applyTitle.setText(dataInfo.getF_ApplyTitle());
			commentsTxt = (EditText) findViewById(R.id.et_apply_des);
			TextView projectTxt = (TextView) findViewById(R.id.et_project);
			projectTxt.setText(dataInfo.getProjectName());
			btn_date = (Button) findViewById(R.id.btn_date);
			btn_date.setText(format(calendar.getTime()));

			Button buttonYes = (Button) findViewById(R.id.btn_ok);
			buttonYes.setOnClickListener(new Button.OnClickListener() {
				public void onClick(View v) {
					CostDetailActivity.this.operationDescription = commentsTxt.getText().toString();
					dismiss();
					new HandleCostApply().execute(operation, operatorType);

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

	class LoadCost extends AsyncTask<String, String, String> {
		@Override
		protected String doInBackground(String... params) {
			try {
				JSONHttpClient jsonHttpClient = new JSONHttpClient();
				List<NameValuePair> nameValuePairs = new ArrayList<NameValuePair>();

				nameValuePairs.add(new BasicNameValuePair("applyid", String.valueOf(dataInfo.getF_ID())));

				Type listType = new TypeToken<List<ProjectCost>>() {
				}.getType();

				dataList = jsonHttpClient.GetList(loadCost_API, nameValuePairs, ProjectCost.class, listType);

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
					adapter = new CostApplyDetailAdapter(CostDetailActivity.this, dataList, costType);
					listView.setAdapter(adapter);
				}
			});
		}
	}

	class HandleCostApply extends AsyncTask<String, String, String> {
		@Override
		protected String doInBackground(String... params) {
			try {
				JSONHttpClient jsonHttpClient = new JSONHttpClient();
				List<NameValuePair> nameValuePairs = new ArrayList<NameValuePair>();
				String operation = params[0];
				String userType = params[1];

				nameValuePairs.add(new BasicNameValuePair("id", String.valueOf(dataInfo.getF_ID())));
				nameValuePairs.add(new BasicNameValuePair("operation", operation));
				nameValuePairs.add(new BasicNameValuePair("operatorId", getOperator()));
				nameValuePairs.add(new BasicNameValuePair("fromState", getFromState(CostApplyTask)));
				nameValuePairs.add(new BasicNameValuePair("description", operationDescription));
				if (operation.equals("reject")) {
					nameValuePairs.add(new BasicNameValuePair("toState", getToState(CostApplyTask, false)));
				} else if (operation.equals("approve")) {
					nameValuePairs.add(new BasicNameValuePair("toState", getToState(CostApplyTask, true)));
				}

				JsonResult result;
				result = jsonHttpClient.PostParams(handleCostApply_API, nameValuePairs, JsonResult.class);

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
					// TODO: Promote operation result
					showAlertDialog("工程费用审批", "成功");
				}
			});
		}
	}

	@Override
	public void onItemSelected(AdapterView<?> parent, View view, int position, long id) {
		int index = parent.getSelectedItemPosition();
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
