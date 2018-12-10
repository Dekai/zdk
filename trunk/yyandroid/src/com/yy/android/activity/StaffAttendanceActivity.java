package com.yy.android.activity;

import java.util.ArrayList;
import java.util.Date;
import java.util.List;

import org.apache.http.NameValuePair;
import org.apache.http.message.BasicNameValuePair;

import android.app.Dialog;
import android.content.Context;
import android.os.AsyncTask;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.AdapterView;
import android.widget.AdapterView.OnItemClickListener;
import android.widget.AdapterView.OnItemSelectedListener;
import android.widget.Button;
import android.widget.CheckBox;
import android.widget.EditText;
import android.widget.LinearLayout;
import android.widget.LinearLayout.LayoutParams;
import android.widget.ListView;
import android.widget.Spinner;
import android.widget.TextView;
import android.widget.Toast;

import com.google.gson.Gson;
import com.google.gson.GsonBuilder;
import com.google.gson.JsonArray;
import com.yy.android.R;
import com.yy.android.adapter.StaffAttendanceAdapter;
import com.yy.android.util.DateUtil;
import com.yy.android.util.JSONHttpClient;
import com.yy.android.vo.EmpAttendance;
import com.yy.android.vo.Employee;
import com.yy.android.vo.EmployeeAttendance;

public class StaffAttendanceActivity extends MyBaseActivity implements OnItemClickListener, OnClickListener, OnItemSelectedListener {
	private TextView attendance_tv, absense_tv, tv_enrollStatus;
	private EmpAttendance empAttendance;
	private ListView listView;
	private StaffAttendanceAdapter adapter;
	private Button btn_enroll, btn_return, btn_date;
	private CheckBox cb;
	private int attendanceNum = 0;
	private int absenceNum = 0;
	private String loadAttendance_API = Service_Address + "employeeattendace/getlist";
	private String enroll_API = Service_Address + "employeeattendace/enroll";
	private Employee info;
	private String operation;

	@Override
	protected void setContentView() {
		setContentView(R.layout.staff_attendance);
	}

	@Override
	protected void findViewById() {
		attendance_tv = (TextView) findViewById(R.id.attendance_num);
		absense_tv = (TextView) findViewById(R.id.absense_num);
		listView = (ListView) findViewById(R.id.user_listview);
		btn_enroll = (Button) findViewById(R.id.staff_enroll_btn);
		progress_loading = (LinearLayout) findViewById(R.id.progress_loading);
		btn_return = (Button) findViewById(R.id.btn_back);
		btn_date = (Button) findViewById(R.id.btn_date);
		sp_project = (Spinner) findViewById(R.id.sp_project);
		emptyText = (TextView) findViewById(R.id.emptyText);
		tv_enrollStatus = (TextView) findViewById(R.id.tv_enrollStatus);
	}

	@Override
	protected void initialize() {
		listView.setOnItemClickListener(this);
		btn_return.setOnClickListener(this);
		btn_date.setOnClickListener(this);
		btn_enroll.setOnClickListener(this);
		btn_date.setText(format(calendar.getTime()));
		spCount = 1;
		initProjectSpinner(this);

		new LoadAttendance().execute();
	}

	class LoadAttendance extends AsyncTask<String, String, String> {
		@Override
		protected String doInBackground(String... params) {
			try {
				JSONHttpClient jsonHttpClient = new JSONHttpClient();
				List<NameValuePair> nameValuePairs = new ArrayList<NameValuePair>();
				nameValuePairs.add(new BasicNameValuePair("projectId", String.valueOf(getSelectedProjectId())));
				nameValuePairs.add(new BasicNameValuePair("date", btn_date.getText().toString()));

				empAttendance = jsonHttpClient.Get(loadAttendance_API, nameValuePairs, EmpAttendance.class);
			} catch (Exception e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			}
			return null;
		}

		@Override
		protected void onPreExecute() {
			super.onPreExecute();
			LayoutParams loadLps = new LayoutParams(LayoutParams.MATCH_PARENT, 0);
			loadLps.weight = 5;
			listView.setLayoutParams(loadLps);
			showAnim();
		}

		@Override
		protected void onPostExecute(String s) {
			stopAnim();
			runOnUiThread(new Runnable() {
				@Override
				public void run() {
					operation = "Update";
					// updateUI(operation);
					updateUI();
				}
			});
		}
	}

	public void updateUI() {
		attendanceNum = Integer.valueOf(empAttendance.getAttendanceNum());
		absenceNum = Integer.valueOf(empAttendance.getAbsenceNum());
		attendance_tv.setText(empAttendance.getAttendanceNum());
		absense_tv.setText(empAttendance.getAbsenceNum());
		if (empAttendance.isNew()) {
			tv_enrollStatus.setText("未记录");
			btn_enroll.setText("新增考勤");
		} else {
			tv_enrollStatus.setText("已记录");
			btn_enroll.setText("修改考勤");
		}
		adapter = new StaffAttendanceAdapter(StaffAttendanceActivity.this, empAttendance.getEmpList(), empAttendance.isNew());
		listView.setAdapter(adapter);
	}

	@Override
	public void onItemClick(AdapterView<?> arg0, View view, int position, long arg3) {
		info = empAttendance.getEmpList().get(position);
		cb = (CheckBox) view.findViewById(R.id.staff_attendance_cb);
		if (info.isF_IsAttendance()) {
			// checked
			cb.setChecked(false);
			info.setF_IsAttendance(false);
			info.setChecked(false);
			absenceNum++;
			if (attendanceNum > 0) {
				attendanceNum--;
			}
			AbsentDialog dialog = new AbsentDialog(StaffAttendanceActivity.this);
			dialog.show();
		} else {
			// unchecked
			attendanceNum++;
			if (absenceNum > 0) {
				absenceNum--;
			}
			cb.setChecked(true);
			info.setF_IsAttendance(true);
			info.setChecked(true);
		}

		attendance_tv.setText(String.valueOf(attendanceNum));
		absense_tv.setText(String.valueOf(absenceNum));
		/*
		 * disable update previous attendance if (empAttendance.isNew()) { cb =
		 * (CheckBox) view.findViewById(R.id.staff_attendance_cb); if
		 * (info.isChecked()) { // checked cb.setChecked(false);
		 * info.setChecked(false); absenceNum++; if (attendanceNum > 0) {
		 * attendanceNum--; } AbsentDialog dialog = new
		 * AbsentDialog(StaffAttendanceActivity.this); dialog.show(); } else {
		 * // unchecked attendanceNum++; if (absenceNum > 0) { absenceNum--; }
		 * cb.setChecked(true); info.setChecked(true); }
		 * 
		 * attendance_tv.setText(String.valueOf(attendanceNum));
		 * absense_tv.setText(String.valueOf(absenceNum)); } else {
		 * Toast.makeText(StaffAttendanceActivity.this, "之前考勤不能修改",
		 * Toast.LENGTH_SHORT).show(); }
		 */
	}

	class EnrollEmpTask extends AsyncTask<String, String, String> {
		@Override
		protected String doInBackground(String... params) {
			try {
				JSONHttpClient jsonHttpClient = new JSONHttpClient();
				List<NameValuePair> nameValuePairs = new ArrayList<NameValuePair>();
				nameValuePairs.add(new BasicNameValuePair("isNew", String.valueOf(empAttendance.isNew())));

				List<EmployeeAttendance> empAttList = new ArrayList<EmployeeAttendance>();
				for (Employee emp : empAttendance.getEmpList()) {
					EmployeeAttendance ea = new EmployeeAttendance();
					if (!empAttendance.isNew())
						ea.setF_ID(emp.getF_ID());// Update, assign item id
					ea.setF_EmployeeID(emp.getF_ID());
					ea.setF_ProjectID(getSelectedProjectId());
					ea.setF_OperatorID(getOperatorId());
					ea.setF_AttendanceDate(GetBtnDate(btn_date));
					ea.setF_OperateTime(new Date());
					ea.setF_IsAttendence(emp.isF_IsAttendance());
					if (!emp.isChecked()) {
						ea.setF_AbenceComment(emp.getAbsent_Comments());
					}
					empAttList.add(ea);
				}

				Gson gson = new GsonBuilder().create();
				JsonArray myCustomArray = gson.toJsonTree(empAttList).getAsJsonArray();
				String result = jsonHttpClient.PostObjectArrayWithParams(enroll_API, myCustomArray, nameValuePairs);

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
			stopAnim();
			runOnUiThread(new Runnable() {
				@Override
				public void run() {
					showAlertDialog("考勤登记", "考勤登记成功！");
					new LoadAttendance().execute();
				}
			});
		}
	}

	@Override
	public void onClick(View v) {
		// TODO Auto-generated method stub
		switch (v.getId()) {
		case R.id.btn_back:
			finish();
			break;
		case R.id.staff_enroll_btn:
			if (attendanceNum > 0) {
				new EnrollEmpTask().execute();
			} else {
				Toast.makeText(StaffAttendanceActivity.this, "请确认是否都缺勤？", Toast.LENGTH_SHORT).show();
			}
			break;
		case R.id.btn_date:
			ShowTimePickerBack(btn_date, true);
			break;
		}
	}

	@Override
	protected void updateList() {
		Date selectedDate = GetBtnDate(btn_date);
		Date currentDate = DateUtil.getCurrentDate();
		if (selectedDate.getTime() > currentDate.getTime()) {
			showAlertDialog("日期选择", "不能对当前日期后面时间进行考勤，请重新选择。");
		} else if (selectedDate.getTime() < currentDate.getTime()) {
			new LoadAttendance().execute();
		} else {
			new LoadAttendance().execute();
		}
	}

	class AbsentDialog extends Dialog {
		EditText commentsTxt;

		public AbsentDialog(Context context) {
			super(context);
			// TODO Auto-generated constructor stub
		}

		protected void onCreate(Bundle savedInstanceState) {
			super.onCreate(savedInstanceState);

			setContentView(R.layout.absent_dialog);
			setTitle("缺勤原因");

			TextView empTxt = (TextView) findViewById(R.id.et_emp);
			empTxt.setText(info.getF_Name());
			TextView dateTxt = (TextView) findViewById(R.id.et_date);
			dateTxt.setText(btn_date.getText().toString());
			commentsTxt = (EditText) findViewById(R.id.et_absent_des);
			commentsTxt.setText(info.getAbsent_Comments());

			Button buttonYes = (Button) findViewById(R.id.btn_ok);
			buttonYes.setOnClickListener(new Button.OnClickListener() {
				public void onClick(View v) {
					info.setAbsent_Comments(commentsTxt.getText().toString());
					dismiss();

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

	@Override
	public void onItemSelected(AdapterView<?> parent, View view, int position, long id) {
		if (initSpCount < spCount) {
			initSpCount++;
		} else {
			new LoadAttendance().execute();
		}
	}

	@Override
	public void onNothingSelected(AdapterView<?> parent) {
		// TODO Auto-generated method stub

	}

}