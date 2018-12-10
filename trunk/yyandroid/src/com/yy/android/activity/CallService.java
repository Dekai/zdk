package com.yy.android.activity;

import java.util.ArrayList;
import java.util.Date;
import java.util.List;

import org.apache.http.NameValuePair;
import org.apache.http.message.BasicNameValuePair;

import android.app.ProgressDialog;
import android.os.AsyncTask;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.Button;
import android.widget.EditText;

import com.yy.android.R;
import com.yy.android.util.JSONHttpClient;
import com.yy.android.vo.EmployeeAttendance;
import com.yy.android.vo.User;

public class CallService extends MyBaseActivity implements OnClickListener {

	private Button btnCallService;
	private int userId = 0;
	//	private final String Service_Address = "http://192.168.97.115/user/details";
	private final String Service_Address = "http://192.168.1.100/employeeattendace/enroll";
	private EditText editTxtId, editTxtName, editTxtDepart;

	@Override
	protected void setContentView() {
		setContentView(R.layout.call_service);
	}

	@Override
	protected void findViewById() {
		btnCallService = (Button) findViewById(R.id.btnCallSvc);
		editTxtId = (EditText) findViewById(R.id.editTxt_Id);
		editTxtName = (EditText) findViewById(R.id.editTxt_Name);
		editTxtDepart = (EditText) findViewById(R.id.editTxt_Depart);
	}

	@Override
	protected void initialize() {
		btnCallService.setOnClickListener(this);
	}

	@Override
	public void onClick(View v) {
//		Intent intent = new Intent();
		if (v.getId() == R.id.btnCallSvc) {
			userId = Integer.parseInt(editTxtId.getText().toString());
			new LoadUserDetail().execute(); 
		}
	}

	class LoadUserDetail extends AsyncTask<String, String, String> {
		ProgressDialog progressDialog;

		@Override
		protected void onPreExecute() {
			super.onPreExecute(); // To change body of overridden methods use
									// File | Settings | File Templates.
			progressDialog = new ProgressDialog(CallService.this);
			progressDialog.setMessage("Loading User Details. Please wait...");
			progressDialog.show();
		}

		@Override
		protected void onPostExecute(String s) {
			progressDialog.dismiss();
		}

		@Override
		protected String doInBackground(String... params) {
			List<NameValuePair> args = new ArrayList<NameValuePair>();
			List<EmployeeAttendance> empAttList = new ArrayList<EmployeeAttendance>();
			EmployeeAttendance ea = new EmployeeAttendance();
			ea.setF_EmployeeID(2);
			ea.setF_ProjectID(1);
			ea.setF_OperatorID(2);
			ea.setF_AttendanceDate(new Date());
			ea.setF_OperateTime(new Date());
			empAttList.add(ea);
			EmployeeAttendance ea1 = new EmployeeAttendance();
			ea1.setF_EmployeeID(2);
			ea1.setF_ProjectID(1);
			ea1.setF_OperatorID(2);
			ea1.setF_AttendanceDate(new Date());
			ea1.setF_OperateTime(new Date());
			empAttList.add(ea1);
			EmployeeAttendance ea2 = new EmployeeAttendance();
			ea2.setF_EmployeeID(2);
			ea2.setF_ProjectID(1);
			ea2.setF_OperatorID(2);
			ea2.setF_AttendanceDate(new Date());
			ea2.setF_OperateTime(new Date());
			empAttList.add(ea2);
//			args.add(new BasicNameValuePair("Attendaces", empAttList);
			args.add(new BasicNameValuePair(User.User_ID, String
					.valueOf(userId)));
			JSONHttpClient jsonHttpClient = new JSONHttpClient();
			final User user = jsonHttpClient.Get(Service_Address,args,
					User.class);

			runOnUiThread(new Runnable() {
				@Override
				public void run() {
					if (user != null) {
						editTxtId.setText(String.valueOf(user.getId()));
						editTxtName.setText(user.getUserName());
						editTxtDepart.setText(user.getDepartmentName());
					}
				}
			});
			return null; // To change body of implemented methods use File |
							// Settings | File Templates.
		}
	}

	@Override
	protected void updateList() {
		// TODO Auto-generated method stub
		
	}
}
