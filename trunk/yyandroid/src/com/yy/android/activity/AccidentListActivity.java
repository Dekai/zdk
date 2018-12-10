package com.yy.android.activity;

import java.lang.reflect.Type;
import java.util.ArrayList;
import java.util.List;

import org.apache.http.NameValuePair;
import org.apache.http.message.BasicNameValuePair;

import android.content.Intent;
import android.os.AsyncTask;
import android.view.KeyEvent;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.AdapterView;
import android.widget.AdapterView.OnItemClickListener;
import android.widget.AdapterView.OnItemSelectedListener;
import android.widget.Button;
import android.widget.ImageButton;
import android.widget.LinearLayout;
import android.widget.ListView;
import android.widget.Spinner;
import android.widget.TextView;

import com.google.gson.reflect.TypeToken;
import com.yy.android.R;
import com.yy.android.adapter.AccidentListAdapter;
import com.yy.android.adapter.CostApplyListAdapter;
import com.yy.android.util.Bimp;
import com.yy.android.util.JSONHttpClient;
import com.yy.android.vo.Accident;
import com.yy.android.vo.CostApply;
import com.yy.android.vo.SpinnerData;

public class AccidentListActivity extends MyBaseActivity implements OnItemClickListener, OnClickListener, OnItemSelectedListener {

	private List<Accident> dataList = new ArrayList<Accident>();
	private ListView listView;
	private AccidentListAdapter adapter;
	private Button btn_add, btn_return;
	private String loadAccident_API = Service_Address + "accident/getlist";

	@Override
	protected void setContentView() {
		setContentView(R.layout.accident_list);
	}

	@Override
	protected void findViewById() {
		listView = (ListView) findViewById(R.id.lv_cost_listview);
		progress_loading = (LinearLayout) findViewById(R.id.progress_loading);
		btn_return = (Button) findViewById(R.id.btn_back);
		btn_add = (Button) findViewById(R.id.btn_add);
		sp_project = (Spinner) findViewById(R.id.sp_project);
		emptyText = (TextView) findViewById(R.id.emptyText);
		ib_clock = (ImageButton) findViewById(R.id.ib_clock);
	}

	@Override
	protected void initialize() {
		listView.setOnItemClickListener(this);
		btn_add.setOnClickListener(this);
		btn_return.setOnClickListener(this);
		ib_clock.setOnClickListener(this);
		spCount = 1;
		initProjectSpinner(this);

		new LoadAccident().execute();
	}

	@Override
	public void onClick(View v) {
		final Intent intent = new Intent();
		switch (v.getId()) {
		case R.id.btn_back:
			Intent intent1 = new Intent(AccidentListActivity.this, WorkSpaceMainActivity.class);
			startActivity(intent1);
			AccidentListActivity.this.finish();
			break;
		case R.id.ib_clock:
			showDateSearchDialog();
			break;
		case R.id.btn_add:
			intent.setClass(this, AccidentActivity.class);
			startActivity(intent);
			finish();
			break;
		}
	}

	@Override
	public boolean onKeyDown(int keyCode, KeyEvent event) {

		if (keyCode == KeyEvent.KEYCODE_BACK) {

			Intent intent1 = new Intent(AccidentListActivity.this, WorkSpaceMainActivity.class);
			startActivity(intent1);
			AccidentListActivity.this.finish();

		}
		return true;
	}

	@Override
	public void onItemClick(AdapterView<?> arg0, View view, int position, long arg3) {
		Accident info = dataList.get(position);
		final Intent intent = new Intent();
		intent.setClass(this, AccidentActivity.class);
		intent.putExtra("accident", info);
		startActivity(intent);
		finish();
	}

	class LoadAccident extends AsyncTask<String, String, String> {
		@Override
		protected String doInBackground(String... params) {
			try {
				JSONHttpClient jsonHttpClient = new JSONHttpClient();
				List<NameValuePair> nameValuePairs = new ArrayList<NameValuePair>();

				SpinnerData selectItem = (SpinnerData) sp_project.getSelectedItem();
				nameValuePairs.add(new BasicNameValuePair("projectid", selectItem.getValue()));
				nameValuePairs.add(new BasicNameValuePair("startdate", startDateString));
				nameValuePairs.add(new BasicNameValuePair("enddate", endDateString));

				Type listType = new TypeToken<List<Accident>>() {
				}.getType();

				dataList = jsonHttpClient.GetList(loadAccident_API, nameValuePairs, Accident.class, listType);

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
					adapter = new AccidentListAdapter(AccidentListActivity.this, dataList);
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
			new LoadAccident().execute();
		}
	}

	@Override
	public void onNothingSelected(AdapterView<?> parent) {
		// TODO Auto-generated method stub

	}

	@Override
	protected void updateList() {
		new LoadAccident().execute();
	}

}
