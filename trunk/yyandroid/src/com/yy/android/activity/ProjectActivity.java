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
import com.yy.android.adapter.ProjectAdapter;
import com.yy.android.util.JSONHttpClient;
import com.yy.android.vo.Equiment;
import com.yy.android.vo.Project;
import com.yy.android.vo.SpinnerData;

public class ProjectActivity extends MyBaseActivity implements OnItemClickListener, OnClickListener, OnItemSelectedListener {

	private List<Project> dataList = new ArrayList<Project>();
	private ListView listView;
	private ProjectAdapter adapter;
	private Button btn_add_project, btn_return;

	private final String loadProject_API = Service_Address + "project/getlist";

	@Override
	protected void setContentView() {
		setContentView(R.layout.project);
	}

	@Override
	protected void findViewById() {
		listView = (ListView) findViewById(R.id.cost_listview);
		btn_add_project = (Button) findViewById(R.id.btn_add_project);
		progress_loading = (LinearLayout) findViewById(R.id.progress_loading);
		btn_return = (Button) findViewById(R.id.btn_back);
		emptyText = (TextView) findViewById(R.id.emptyText);
		ib_clock = (ImageButton) findViewById(R.id.ib_clock);
		sp_projectStatus = (Spinner) findViewById(R.id.sp_projectStatus);
	}

	@Override
	protected void initialize() {
		listView.setOnItemClickListener(this);
		btn_return.setOnClickListener(this);
		btn_add_project.setOnClickListener(this);
		ib_clock.setOnClickListener(this);
		
		initProjectStatusSpinner(this);
		new LoadProject().execute();

	}

	@Override
	public void onClick(View v) {
		final Intent intent = new Intent();
		switch (v.getId()) {
		case R.id.btn_back:
			finish();
			break;
		case R.id.btn_add_project:
			intent.setClass(this, AddProjectActivity.class);
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
		Project info = dataList.get(position);

		final Intent intent = new Intent();
		intent.setClass(this, AddProjectActivity.class);
		intent.putExtra("project", info);
		startActivity(intent);
		finish();
	}

	class LoadProject extends AsyncTask<String, String, String> {
		@Override
		protected String doInBackground(String... params) {
			try {
				JSONHttpClient jsonHttpClient = new JSONHttpClient();
				List<NameValuePair> nameValuePairs = new ArrayList<NameValuePair>();
				nameValuePairs.add(new BasicNameValuePair("startdate", startDateString));
				nameValuePairs.add(new BasicNameValuePair("enddate", endDateString));
				nameValuePairs.add(new BasicNameValuePair("projectStatus", getProjectStatus()));
				Type listType = new TypeToken<List<Project>>() {
				}.getType();

				dataList = jsonHttpClient.GetList(loadProject_API, nameValuePairs, Project.class, listType);

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
					adapter = new ProjectAdapter(ProjectActivity.this, dataList);
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
		new LoadProject().execute();
	}

	@Override
	public void onNothingSelected(AdapterView<?> parent) {
		// TODO Auto-generated method stub

	}

	@Override
	protected void updateList() {
		// TODO Auto-generated method stub
		new LoadProject().execute();
	}
}
