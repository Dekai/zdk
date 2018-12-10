package com.yy.android.activity;

import java.util.Calendar;

import android.content.Intent;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.os.AsyncTask;
import android.view.KeyEvent;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.Button;
import android.widget.EditText;
import android.widget.LinearLayout;
import android.widget.TextView;

import com.yy.android.R;
import com.yy.android.util.JSONHttpClient;
import com.yy.android.util.Res;
import com.yy.android.vo.JsonResult;
import com.yy.android.vo.Project;

public class AddProjectActivity extends MyBaseActivity implements OnClickListener {
	private Calendar calendar = Calendar.getInstance();
	private View parentView;
	private Button btn_add;
	private Button btn_back, btn_start_date, btn_end_date, btn_delete;
	public static Bitmap bimap;
	private EditText et_projectname, et_des;
	private TextView tv_title;
	public boolean isAdd = true, isDeleted = false;
	private int dataID;

	private String addProject_API = Service_Address + "project/create";
	private String updateProject_API = Service_Address + "project/edit";

	@Override
	protected void setContentView() {
		Res.init(this);
		bimap = BitmapFactory.decodeResource(getResources(), R.drawable.icon_addpic_unfocused);
		parentView = getLayoutInflater().inflate(R.layout.add_project, null);
		setContentView(parentView);
	}

	@Override
	protected void findViewById() {
		btn_start_date = (Button) findViewById(R.id.btn_start_date);
		btn_end_date = (Button) findViewById(R.id.btn_end_date);
		et_des = (EditText) findViewById(R.id.et_project_des);
		et_projectname = (EditText) findViewById(R.id.et_projectname);
		tv_title = (TextView) findViewById(R.id.tv_title);
		btn_back = (Button) findViewById(R.id.btn_back);
		btn_add = (Button) findViewById(R.id.btn_add);
		btn_delete = (Button) findViewById(R.id.btn_delete);
		progress_loading = (LinearLayout) findViewById(R.id.progress_loading);
	}

	@Override
	protected void initialize() {
		btn_add.setOnClickListener(this);
		btn_back.setOnClickListener(this);
		btn_start_date.setOnClickListener(this);
		btn_end_date.setOnClickListener(this);
		btn_delete.setOnClickListener(this);

		Intent intent = getIntent();
		Project dataInfo = (Project) intent.getSerializableExtra("project");
		if (dataInfo != null) {
			dataID = dataInfo.getF_ID();
			et_projectname.setText(dataInfo.getF_Name());
			btn_start_date.setText(dateFormat.format(dataInfo.getF_StartDate()));
			if (dataInfo.getF_EndDate() != null) {
				btn_end_date.setText(dateFormat.format(dataInfo.getF_EndDate()));
			} else {
				btn_end_date.setText(emptyDateText);
			}
			et_des.setText(dataInfo.getF_Description());
			tv_title.setText("修改项目");
			if (dataInfo.isF_IsDelete()) {
				isDeleted = true;
				btn_add.setText("开启项目");
				btn_delete.setText("返回列表");
			} else {
				isDeleted = false;
				btn_add.setText("修改项目");
				btn_delete.setText("关闭项目");
			}

			isAdd = false;
		} else {

			btn_start_date.setText(format(calendar.getTime()));
			btn_end_date.setText(emptyDateText);
			tv_title.setText("新增项目");
			btn_add.setText("新增项目");
			btn_delete.setText("返回列表");
		}
	}

	@Override
	public void onClick(View v) {
		switch (v.getId()) {
		case R.id.btn_back:
			Intent intent = new Intent();
			intent.setClass(AddProjectActivity.this, ProjectActivity.class);
			startActivity(intent);
			finish();
			break;
		case R.id.btn_start_date:
			ShowTimePickerBack(btn_start_date, false);
			break;
		case R.id.btn_end_date:
			ShowTimePicker(btn_end_date);
			break;
		case R.id.btn_add:
			new HandleProject().execute();
			break;
		case R.id.btn_delete:
			if (isAdd) {
				finish();
				break;
			} else {
				new HandleProject().execute("delete");
			}
			break;
		}
	}
	
	@Override
	public boolean onKeyDown(int keyCode, KeyEvent event) {
		
		if (keyCode == KeyEvent.KEYCODE_BACK) {
			
			Intent intent1 = new Intent(AddProjectActivity.this, ProjectActivity.class);
			startActivity(intent1);
		
			AddProjectActivity.this.finish();
			
		}
		return true;
	}

	class HandleProject extends AsyncTask<String, String, String> {
		@Override
		protected String doInBackground(String... params) {
			try {
				JSONHttpClient jsonHttpClient = new JSONHttpClient();
				JsonResult result;
				Project pageData = GatherPageData();
				if (params.length > 0 && params[0].equals("delete")) {
					pageData.setF_ID(dataID);
					pageData.setF_IsDelete(true);
					result = jsonHttpClient.PostObject(updateProject_API, pageData, JsonResult.class);
				} else {
					pageData.setF_IsDelete(false);
					if (isAdd) {
						result = jsonHttpClient.PostObject(addProject_API, pageData, JsonResult.class);
					} else {
						pageData.setF_ID(dataID);
						result = jsonHttpClient.PostObject(updateProject_API, pageData, JsonResult.class);
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
					// Update global project list
					new LoadProjects().execute();

					Intent intent = new Intent();
					intent.setClass(AddProjectActivity.this, ProjectActivity.class);
					startActivity(intent);
					finish();
				}
			});
		}
	}

	private Project GatherPageData() {
		Project pageData = new Project();
		pageData.setF_Name(et_projectname.getText().toString());
		pageData.setF_StartDate(GetBtnDate(btn_start_date));
		pageData.setF_EndDate(GetBtnDate(btn_end_date));
		pageData.setF_Description(et_des.getText().toString());
		pageData.setF_OperatorID(getOperatorId());

		return pageData;
	}

	@Override
	protected void updateList() {
		// TODO Auto-generated method stub

	}

}
