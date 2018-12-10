package com.yy.android.activity;

import java.lang.reflect.Type;
import java.util.ArrayList;
import java.util.List;

import org.apache.http.NameValuePair;
import org.apache.http.message.BasicNameValuePair;

import android.content.Intent;
import android.os.AsyncTask;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.AdapterView;
import android.widget.AdapterView.OnItemSelectedListener;
import android.widget.Button;
import android.widget.LinearLayout;
import android.widget.ListView;
import android.widget.TextView;

import com.google.gson.reflect.TypeToken;
import com.yy.android.R;
import com.yy.android.activity.MyBaseActivity.CostTypeEnum;
import com.yy.android.adapter.CostApplyDetailAdapter;
import com.yy.android.util.JSONHttpClient;
import com.yy.android.vo.CostApply;
import com.yy.android.vo.JsonResult;
import com.yy.android.vo.ProjectCost;

public class ConfirmDetailActivity extends MyBaseActivity implements OnClickListener, OnItemSelectedListener {

	private List<ProjectCost> dataList = new ArrayList<ProjectCost>();
	private ListView listView;
	private CostApplyDetailAdapter adapter;
	private Button btn_reject, btn_return, btn_date, btn_approve, btn_delete, btn_btm_back;
	private TextView tv_apply_cost, tv_operator, tv_apply_date, tv_title;
	private CostApply dataInfo;
	private LinearLayout ll_myapply, ll_costapply;
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
		String showType = paramintent.getStringExtra("showType");
		costType = (CostTypeEnum) getIntent().getSerializableExtra("isProjectCost");
		if (showType.equals("MyApply")) {
			tv_title.setText("我的报账明细");
			ll_myapply.setVisibility(View.VISIBLE);
			ll_costapply.setVisibility(View.GONE);
		} else if (showType.equals("CostApply")) {
			tv_title.setText("工程费用审批");
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
			intent.setClass(ConfirmDetailActivity.this, FinanceConfirmActivity.class);
			startActivity(intent);
			finish();
			break;
		case R.id.btn_reject:
			new HandleCostApply().execute("reject");
			break;
		case R.id.btn_approve:
			new HandleCostApply().execute("approve");
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
					adapter = new CostApplyDetailAdapter(ConfirmDetailActivity.this, dataList, costType);
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

				nameValuePairs.add(new BasicNameValuePair("id", String.valueOf(dataInfo.getF_ID())));
				nameValuePairs.add(new BasicNameValuePair("operation", operation));
				// TODO: use real id
				nameValuePairs.add(new BasicNameValuePair("operatorId", getOperator()));

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
