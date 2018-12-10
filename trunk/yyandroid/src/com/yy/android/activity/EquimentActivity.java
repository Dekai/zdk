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
import android.widget.Spinner;
import android.widget.TextView;

import com.google.gson.reflect.TypeToken;
import com.yy.android.R;
import com.yy.android.adapter.EquimentAdapter;
import com.yy.android.util.JSONHttpClient;
import com.yy.android.vo.Equiment;
import com.yy.android.vo.SpinnerData;

public class EquimentActivity extends MyBaseActivity implements OnItemClickListener, OnClickListener, OnItemSelectedListener {

	private List<Equiment> dataList = new ArrayList<Equiment>();
	private ListView listView;
	private EquimentAdapter adapter;
	private Button btn_add_cost, btn_return;

	private final String loadEquiment_API = Service_Address + "equimentattendace/getlist";
	private CostTypeEnum costType;

	@Override
	protected void setContentView() {
		setContentView(R.layout.equiment);
	}

	@Override
	protected void findViewById() {
		listView = (ListView) findViewById(R.id.cost_listview);
		btn_add_cost = (Button) findViewById(R.id.btn_add_cost);
		progress_loading = (LinearLayout) findViewById(R.id.progress_loading);
		btn_return = (Button) findViewById(R.id.btn_back);
		sp_project = (Spinner) findViewById(R.id.sp_project);
		sp_equiment_hireType = (Spinner) findViewById(R.id.sp_equiment_hireType);
		emptyText = (TextView) findViewById(R.id.emptyText);
		ib_clock = (ImageButton) findViewById(R.id.ib_clock);
	}

	@Override
	protected void initialize() {
		listView.setOnItemClickListener(this);
		btn_return.setOnClickListener(this);
		btn_add_cost.setOnClickListener(this);
		ib_clock.setOnClickListener(this);
		spCount = 2;
		initProjectSpinner(this);
		initEquimentHireTypeSpinner(this);
		new LoadEquiment().execute();

	}

	@Override
	public void onClick(View v) {
		final Intent intent = new Intent();
		switch (v.getId()) {
		case R.id.btn_back:
			finish();
			break;
		case R.id.btn_add_cost:
			intent.putExtra("isProjectCost", costType);
			intent.setClass(this, AddEquimentActivity.class);
			startActivity(intent);
			finish();
			break;
		case R.id.ib_clock:
			showDateSearchDialog();
			break;
		}
	}

	@Override
	public void onItemClick(AdapterView<?> arg0, View view, int position, long arg3) {
		Equiment info = dataList.get(position);

		final Intent intent = new Intent();
		intent.setClass(this, AddEquimentActivity.class);
		intent.putExtra("equiment", info);
		startActivity(intent);
		finish();
	}

	class LoadEquiment extends AsyncTask<String, String, String> {
		@Override
		protected String doInBackground(String... params) {
			try {
				JSONHttpClient jsonHttpClient = new JSONHttpClient();
				List<NameValuePair> nameValuePairs = new ArrayList<NameValuePair>();
				int equimentHireTypeId = getEquimentHireTypeId();
				SpinnerData selectItem = (SpinnerData) sp_project.getSelectedItem();
				nameValuePairs.add(new BasicNameValuePair("projectid", selectItem.getValue()));
				nameValuePairs.add(new BasicNameValuePair("startdate", startDateString));
				nameValuePairs.add(new BasicNameValuePair("enddate", endDateString));
				if (equimentHireTypeId == 1) {
					nameValuePairs.add(new BasicNameValuePair("ishire", "false"));
				} else if (equimentHireTypeId == 2) {
					nameValuePairs.add(new BasicNameValuePair("ishire", "true"));
				}

				Type listType = new TypeToken<List<Equiment>>() {
				}.getType();

				dataList = jsonHttpClient.GetList(loadEquiment_API, nameValuePairs, Equiment.class, listType);

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
					adapter = new EquimentAdapter(EquimentActivity.this, dataList);
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
		if (initSpCount < spCount) {
			initSpCount++;
		} else {
			new LoadEquiment().execute();
		}
	}

	@Override
	public void onNothingSelected(AdapterView<?> parent) {
		// TODO Auto-generated method stub

	}

	@Override
	protected void updateList() {
		// TODO Auto-generated method stub
		new LoadEquiment().execute();
	}
}
