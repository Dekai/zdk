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
import android.widget.AdapterView.OnItemClickListener;
import android.widget.AdapterView.OnItemSelectedListener;
import android.widget.Button;
import android.widget.FrameLayout;
import android.widget.LinearLayout;
import android.widget.ListView;
import android.widget.Spinner;
import android.widget.TextView;

import com.google.gson.reflect.TypeToken;
import com.yy.android.R;
import com.yy.android.activity.MyApplyActivity.LoadCostApply;
import com.yy.android.activity.MyBaseActivity.CostTypeEnum;
import com.yy.android.adapter.CostApplyListAdapter;
import com.yy.android.util.JSONHttpClient;
import com.yy.android.vo.CostApply;
import com.yy.android.vo.SpinnerData;

public class FinanceConfirmActivity extends MyBaseActivity implements OnItemClickListener, OnClickListener, OnItemSelectedListener {

	private List<CostApply> dataList = new ArrayList<CostApply>();
	private ListView listView;
	private CostApplyListAdapter adapter;
	private Button btn_return, btn_date;
	private FrameLayout fl_project;
	private CostTypeEnum costType = CostTypeEnum.project;
	private boolean isProjectCost = true;
	private String loadCostApply_API = Service_Address + "costapply/getlist";

	@Override
	protected void setContentView() {
		setContentView(R.layout.finance_confirm_list);
	}

	@Override
	protected void findViewById() {
		listView = (ListView) findViewById(R.id.cost_listview);
		progress_loading = (LinearLayout) findViewById(R.id.progress_loading);
		btn_return = (Button) findViewById(R.id.btn_back);
		sp_project = (Spinner) findViewById(R.id.sp_project);
		sp_costType = (Spinner) findViewById(R.id.sp_costType);
		emptyText = (TextView) findViewById(R.id.emptyText);
		fl_project = (FrameLayout) findViewById(R.id.project_spn_fl);

	}

	@Override
	protected void initialize() {
		listView.setOnItemClickListener(this);
		btn_return.setOnClickListener(this);
		spCount = 2;
		initProjectSpinner(this);
		initCostTypeSpinner(this);

		new LoadCostApply().execute();
	}

	@Override
	public void onClick(View v) {
		final Intent intent = new Intent();
		switch (v.getId()) {
		case R.id.btn_back:
			finish();
			break;
		case R.id.btn_date:
			ShowTimePicker(btn_date);
			break;
		}
	}

	@Override
	public void onItemClick(AdapterView<?> arg0, View view, int position, long arg3) {
		CostApply info = dataList.get(position);
		final Intent intent = new Intent();
		intent.setClass(this, CostDetailActivity.class);
		intent.putExtra("costapply", info);
		intent.putExtra("showType", "FinanceConfirm");
		intent.putExtra("isProjectCost", costType);
		startActivity(intent);
	}

	class LoadCostApply extends AsyncTask<String, String, String> {
		@Override
		protected String doInBackground(String... params) {
			try {
				JSONHttpClient jsonHttpClient = new JSONHttpClient();
				List<NameValuePair> nameValuePairs = new ArrayList<NameValuePair>();
				int costTypeId = getCostTypeId();
				if (isProjectCost) {
					SpinnerData selectItem = (SpinnerData) sp_project.getSelectedItem();
					nameValuePairs.add(new BasicNameValuePair("projectid", selectItem.getValue()));
				} else {
					nameValuePairs.add(new BasicNameValuePair("projectid", String.valueOf(NonProjectId)));
				}
				nameValuePairs.add(new BasicNameValuePair("startdate", startDateString));
				nameValuePairs.add(new BasicNameValuePair("enddate", endDateString));
				if (costTypeId > 0) {
					nameValuePairs.add(new BasicNameValuePair("applyType", String.valueOf(costTypeId)));
				}

				Type listType = new TypeToken<List<CostApply>>() {
				}.getType();

				dataList = jsonHttpClient.GetList(loadCostApply_API, nameValuePairs, CostApply.class, listType);

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
					if (dataList == null || dataList.size() == 0) {
						emptyText.setVisibility(View.VISIBLE);
						if (adapter == null) {
							return;
						}
						adapter.listInfo.clear();
						adapter.notifyDataSetChanged();
						return;
					}
					adapter = new CostApplyListAdapter(FinanceConfirmActivity.this, dataList, "MyApply");
					listView.setAdapter(adapter);

				}
			});
		}
	}

	@Override
	public void onItemSelected(AdapterView<?> parent, View view, int position, long id) {
		if (initSpCount < spCount) {
			initSpCount++;
		} else {
			if (((Spinner) view.getParent()).getId() == R.id.sp_costType) {
				if (getCostTypeId() == 2) {
					isProjectCost = false;
					costType = CostTypeEnum.nonproject;
					fl_project.setVisibility(View.GONE);
					new LoadCostApply().execute();
				} else {
					isProjectCost = true;
					costType = CostTypeEnum.project;
					fl_project.setVisibility(View.VISIBLE);
					new LoadCostApply().execute();
				}
			} else {
				new LoadCostApply().execute();
			}
		}
	}

	@Override
	public void onNothingSelected(AdapterView<?> parent) {
		// TODO Auto-generated method stub

	}

	@Override
	protected void updateList() {
		new LoadCostApply().execute();
	}

}
