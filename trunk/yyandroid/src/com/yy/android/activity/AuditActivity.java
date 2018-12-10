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
import android.widget.ImageButton;
import android.widget.LinearLayout;
import android.widget.ListView;
import android.widget.TextView;

import com.google.gson.reflect.TypeToken;
import com.yy.android.R;
import com.yy.android.activity.MyBaseActivity.CostTypeEnum;
import com.yy.android.adapter.AuditAdapter;
import com.yy.android.adapter.ExpatriateAdapter;
import com.yy.android.util.JSONHttpClient;
import com.yy.android.vo.Audit;
import com.yy.android.vo.ExpatriateAttendance;
import com.yy.android.vo.SpinnerData;

public class AuditActivity extends MyBaseActivity implements OnItemClickListener, OnClickListener, OnItemSelectedListener {

	private List<Audit> dataList = new ArrayList<Audit>();
	private ListView listView;
	private AuditAdapter adapter;
	private Button btn_return;
	private AuditTypeEnum auditType;
	private String loadAudit_API = Service_Address  + "audit/getlist";

	@Override
	protected void setContentView() {
		setContentView(R.layout.audit);
	}

	@Override
	protected void findViewById() {
		listView = (ListView) findViewById(R.id.worker_listview);
		progress_loading = (LinearLayout) findViewById(R.id.progress_loading);
		btn_return = (Button) findViewById(R.id.btn_back);
		emptyText = (TextView) findViewById(R.id.emptyText);
		ib_clock = (ImageButton) findViewById(R.id.ib_clock);
	}

	@Override
	protected void initialize() {
		listView.setEmptyView(emptyText);
		listView.setOnItemClickListener(this);
		btn_return.setOnClickListener(this);
		ib_clock.setOnClickListener(this);

		auditType = (AuditTypeEnum) getIntent().getSerializableExtra("AuditType");
		new LoadAudit().execute();
	}

	@Override
	public void onClick(View v) {
		final Intent intent = new Intent();
		switch (v.getId()) {
		case R.id.btn_back:
			finish();
			break;
		case R.id.ib_clock:
			showDateSearchDialog();
			break;
		}
	}

	@Override
	public void onItemClick(AdapterView<?> arg0, View view, int position, long arg3) {
		Audit info = dataList.get(position);

		final Intent intent = new Intent();
		intent.setClass(this, AddAuditActivity.class);
		intent.putExtra("itemData", info);
		intent.putExtra("AuditType", auditType);
		startActivity(intent);
		finish();
	}

	class LoadAudit extends AsyncTask<String, String, String> {
		@Override
		protected String doInBackground(String... params) {
			try {
				JSONHttpClient jsonHttpClient = new JSONHttpClient();
				List<NameValuePair> nameValuePairs = new ArrayList<NameValuePair>();

				nameValuePairs.add(new BasicNameValuePair("startdate", startDateString));
				nameValuePairs.add(new BasicNameValuePair("enddate", endDateString));
				nameValuePairs.add(new BasicNameValuePair("audittype", String.valueOf(auditType.ordinal())));
				nameValuePairs.add(new BasicNameValuePair("stateID", getFromState(AuditTask)));
				
				Type listType = new TypeToken<List<Audit>>() {
				}.getType();

				List<Audit> returnList = jsonHttpClient.GetList(loadAudit_API, nameValuePairs, Audit.class, listType);
				dataList.clear();
				dataList.addAll(returnList);

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
					adapter = new AuditAdapter(AuditActivity.this, dataList);
					listView.setAdapter(adapter);
					if (dataList.size() == 0) {
						emptyText.setVisibility(View.VISIBLE);
					}
				}
			});
		}
	}

	@Override
	public void onItemSelected(AdapterView<?> parent, View view, int position, long id) {
		int index = parent.getSelectedItemPosition();
		new LoadAudit().execute();
	}

	@Override
	public void onNothingSelected(AdapterView<?> parent) {
		// TODO Auto-generated method stub

	}

	@Override
	protected void updateList() {
		new LoadAudit().execute();

	}

}
