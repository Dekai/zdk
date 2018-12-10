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
import com.yy.android.adapter.MaterialApplyAdapter;
import com.yy.android.util.JSONHttpClient;
import com.yy.android.vo.MaterialApply;
import com.yy.android.vo.SpinnerData;

public class MaterialApplyActivity extends MyBaseActivity implements OnItemClickListener, OnClickListener, OnItemSelectedListener {

	private List<MaterialApply> dataList = new ArrayList<MaterialApply>();
	private ListView listView;
	private MaterialApplyAdapter adapter;
	private Button btn_add_cost, btn_return;

	private final String loadMaterialApply_API = Service_Address + "materialsapply/getlist";
	private CostTypeEnum costType;

	@Override
	protected void setContentView() {
		setContentView(R.layout.material_apply);
	}

	@Override
	protected void findViewById() {
		listView = (ListView) findViewById(R.id.cost_listview);
		btn_add_cost = (Button) findViewById(R.id.btn_add_cost);
		progress_loading = (LinearLayout) findViewById(R.id.progress_loading);
		btn_return = (Button) findViewById(R.id.btn_back);
		sp_project = (Spinner) findViewById(R.id.sp_project);
		emptyText = (TextView) findViewById(R.id.emptyText);
		ib_clock = (ImageButton) findViewById(R.id.ib_clock);
	}

	@Override
	protected void initialize() {
		listView.setOnItemClickListener(this);
		btn_return.setOnClickListener(this);
		btn_add_cost.setOnClickListener(this);
		ib_clock.setOnClickListener(this);
		spCount = 1;
		initProjectSpinner(this);
		new LoadMaterialApply().execute();

	}

	@Override
	public void onClick(View v) {
		final Intent intent = new Intent();
		switch (v.getId()) {
		case R.id.btn_back:
			finish();
			break;
		case R.id.btn_add_cost:
			intent.setClass(this, AddMaterialApplyActivity.class);
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
		MaterialApply info = dataList.get(position);

		final Intent intent = new Intent();
		intent.setClass(this, AddMaterialApplyActivity.class);
		intent.putExtra("materialapply", info);
		startActivity(intent);
	}

	class LoadMaterialApply extends AsyncTask<String, String, String> {
		@Override
		protected String doInBackground(String... params) {
			try {
				JSONHttpClient jsonHttpClient = new JSONHttpClient();
				List<NameValuePair> nameValuePairs = new ArrayList<NameValuePair>();
				SpinnerData selectItem = (SpinnerData) sp_project.getSelectedItem();
				nameValuePairs.add(new BasicNameValuePair("projectid", selectItem.getValue()));
				nameValuePairs.add(new BasicNameValuePair("startdate", startDateString));
				nameValuePairs.add(new BasicNameValuePair("enddate", endDateString));

				Type listType = new TypeToken<List<MaterialApply>>() {
				}.getType();

				dataList = jsonHttpClient.GetList(loadMaterialApply_API, nameValuePairs, MaterialApply.class, listType);

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
					adapter = new MaterialApplyAdapter(MaterialApplyActivity.this, dataList);
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
			new LoadMaterialApply().execute();
		}
	}

	@Override
	public void onNothingSelected(AdapterView<?> parent) {
		// TODO Auto-generated method stub

	}

	@Override
	protected void updateList() {
		// TODO Auto-generated method stub
		new LoadMaterialApply().execute();
	}
}
