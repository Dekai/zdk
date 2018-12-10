package com.yy.android.activity;

import android.content.Intent;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.os.AsyncTask;
import android.text.InputType;
import android.view.KeyEvent;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.AdapterView;
import android.widget.AdapterView.OnItemSelectedListener;
import android.widget.Button;
import android.widget.EditText;
import android.widget.LinearLayout;
import android.widget.Spinner;
import android.widget.TextView;
import android.widget.Toast;

import com.yy.android.R;
import com.yy.android.util.JSONHttpClient;
import com.yy.android.util.Res;
import com.yy.android.vo.ExpatriateAttendance;
import com.yy.android.vo.JsonResult;
import com.yy.android.vo.SpinnerData;

public class AddWorkerActivity extends MyBaseActivity implements OnClickListener, OnItemSelectedListener {
	private View parentView;
	private Button btn_add, btn_delete;
	private Button btn_back, btn_date;
	public static Bitmap bimap;
	private EditText et_worker_num, et_gt_num, et_pg_num, et_worker_des;
	private boolean isAdd = true;
	private int dataID;
	private TextView tv_title;

	private String addExpatriate_API = Service_Address + "expatriateattendace/create";
	private String updateExpatriate_API = Service_Address + "expatriateattendace/edit";

	@Override
	protected void setContentView() {
		Res.init(this);
		bimap = BitmapFactory.decodeResource(getResources(), R.drawable.icon_addpic_unfocused);
		parentView = getLayoutInflater().inflate(R.layout.add_worker, null);
		setContentView(parentView);
	}

	@Override
	protected void findViewById() {
		sp_project = (Spinner) findViewById(R.id.sp_project);
		et_gt_num = (EditText) findViewById(R.id.et_gt_num);
		et_pg_num = (EditText) findViewById(R.id.et_pg_num);
		et_worker_num = (EditText) findViewById(R.id.et_worker_num);
		btn_date = (Button) findViewById(R.id.btn_date);
		et_worker_des = (EditText) findViewById(R.id.et_worker_des);
		btn_back = (Button) findViewById(R.id.btn_back);
		btn_add = (Button) findViewById(R.id.btn_add_worker);
		btn_delete = (Button) findViewById(R.id.btn_delete);
		progress_loading = (LinearLayout) findViewById(R.id.progress_loading);
		tv_title = (TextView) findViewById(R.id.tv_title);
	}

	@Override
	protected void initialize() {
		btn_add.setOnClickListener(this);
		btn_back.setOnClickListener(this);
		btn_date.setOnClickListener(this);
		btn_delete.setOnClickListener(this);

		// Open digital input
		et_gt_num.setInputType(InputType.TYPE_CLASS_NUMBER);
		et_pg_num.setInputType(InputType.TYPE_CLASS_NUMBER);
		et_worker_num.setInputType(InputType.TYPE_CLASS_NUMBER);
		spCount = 1;
		Intent intent = getIntent();
		ExpatriateAttendance dataInfo = (ExpatriateAttendance) intent.getSerializableExtra("attendance");
		if (dataInfo != null) {
			dataID = dataInfo.getF_ID();
			initProjectSpinner(this, String.valueOf(dataInfo.getF_ProjectID()));
			et_gt_num.setText(String.valueOf(dataInfo.getF_GongTou()));
			et_pg_num.setText(String.valueOf(dataInfo.getF_PaGong()));
			et_worker_num.setText(String.valueOf(dataInfo.getF_Worker()));
			et_worker_des.setText(dataInfo.getF_Comments());
			btn_date.setText(dateFormat.format(dataInfo.getF_AttendanceDate()));
			tv_title.setText("修改外雇人员");
			btn_add.setText("修改外雇人员");
			btn_delete.setText("删除外雇人员");

			isAdd = false;
		} else {
			tv_title.setText("新增外雇人员");
			btn_add.setText("新增外雇人员");
			btn_delete.setText("返回人员列表");
			initProjectSpinner(this);
			btn_date.setText(format(calendar.getTime()));
		}

	}

	@Override
	public void onClick(View v) {
		switch (v.getId()) {
		case R.id.btn_back:
			Intent intent = new Intent();
			intent.setClass(AddWorkerActivity.this, WorkerActivity.class);
			startActivity(intent);
			finish();
			break;
		case R.id.btn_date:
			ShowTimePickerBack(btn_date, false);
			break;
		case R.id.btn_delete:
			if (isAdd) {
				finish();
			} else {
				new HandleExpatriateAttendance().execute("delete");
			}
			break;
		case R.id.btn_add_worker:
			boolean inputValidate = true;
			try {
				Float.parseFloat(et_gt_num.getText().toString());

			} catch (NumberFormatException e) {
				inputValidate = false;
				et_gt_num.setError("请以正确数字形式输入");
			}
			try {
				Float.parseFloat(et_pg_num.getText().toString());

			} catch (NumberFormatException e) {
				inputValidate = false;
				et_pg_num.setError("请以正确数字形式输入");
			}
			try {
				Float.parseFloat(et_worker_num.getText().toString());

			} catch (NumberFormatException e) {
				inputValidate = false;
				et_worker_num.setError("请以正确数字形式输入");
			}
			if (inputValidate) {
				new HandleExpatriateAttendance().execute();

			} else {
				Toast.makeText(AddWorkerActivity.this, "请填写正确信息", Toast.LENGTH_LONG).show();
			}
			break;
		}
	}

	@Override
	public boolean onKeyDown(int keyCode, KeyEvent event) {
		
		if (keyCode == KeyEvent.KEYCODE_BACK) {
			
			Intent intent1 = new Intent(AddWorkerActivity.this, WorkerActivity.class);
			startActivity(intent1);
		
			AddWorkerActivity.this.finish();
			
		}
		return true;
	}

	
	class HandleExpatriateAttendance extends AsyncTask<String, String, String> {
		@Override
		protected String doInBackground(String... params) {
			try {
				JSONHttpClient jsonHttpClient = new JSONHttpClient();
				ExpatriateAttendance pageData = GatherPageData();
				JsonResult result;
				if (params.length > 0 && params[0].equals("delete")) {
					pageData.setF_ID(dataID);
					pageData.setF_IsDelete(true);
					result = jsonHttpClient.PostObject(updateExpatriate_API, pageData, JsonResult.class);
				} else {
					if (isAdd) {
						result = jsonHttpClient.PostObject(addExpatriate_API, pageData, JsonResult.class);
					} else {
						pageData.setF_ID(dataID);
						result = jsonHttpClient.PostObject(updateExpatriate_API, pageData, JsonResult.class);
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
					// TODO: confirm and back to list
					Intent intent = new Intent();
					intent.setClass(AddWorkerActivity.this, WorkerActivity.class);
					startActivity(intent);
					finish();
				}
			});
		}
	}

	private ExpatriateAttendance GatherPageData() {
		ExpatriateAttendance pageData = new ExpatriateAttendance();

		pageData.setF_ProjectID(Integer.parseInt(((SpinnerData) sp_project.getSelectedItem()).getValue()));
		pageData.setF_GongTou(Integer.valueOf(et_gt_num.getText().toString()));
		pageData.setF_PaGong(Integer.valueOf(et_pg_num.getText().toString()));
		pageData.setF_Worker(Integer.valueOf(et_worker_num.getText().toString()));
		pageData.setF_AttendanceDate(GetBtnDate(btn_date));
		pageData.setF_Comments(et_worker_des.getText().toString());

		return pageData;
	}

	@Override
	public void onItemSelected(AdapterView<?> parent, View view, int position, long id) {
		if (initSpCount < spCount) {
			initSpCount++;
		} else {
			switch (view.getId()) {
			case R.id.sp_project:
				// storing string resources into Array
				// projects = getResources().getStringArray(R.array.project);
				//
				// Toast.makeText(getBaseContext(),
				// "You have selected project : " +
				// projects[index], Toast.LENGTH_SHORT).show();
				break;
			case R.id.sp_cost_type:
				// storing string resources into Array
				// projects = getResources().getStringArray(R.array.project);
				//
				// Toast.makeText(getBaseContext(), "You have selected cost: " +
				// costtypes[index], Toast.LENGTH_SHORT).show();
				break;
			}
		}
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
