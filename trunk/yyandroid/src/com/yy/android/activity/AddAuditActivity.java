package com.yy.android.activity;

import java.util.ArrayList;
import java.util.List;

import org.apache.http.NameValuePair;
import org.apache.http.message.BasicNameValuePair;

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
import com.yy.android.activity.MyBaseActivity.AuditTypeEnum;
import com.yy.android.util.JSONHttpClient;
import com.yy.android.util.Res;
import com.yy.android.vo.Audit;
import com.yy.android.vo.ExpatriateAttendance;
import com.yy.android.vo.JsonResult;
import com.yy.android.vo.SpinnerData;

public class AddAuditActivity extends MyBaseActivity implements OnClickListener, OnItemSelectedListener {
	private View parentView;
	private Button btn_approve, btn_delete;
	private Button btn_reject, btn_date;
	public static Bitmap bimap;
	private EditText et_name, et_money;
	private TextView tv_title, et_des;
	private AuditTypeEnum AuditType;
	private Audit dataInfo;

	private String updateAudit_API = Service_Address + "audit/edit";

	@Override
	protected void setContentView() {
		Res.init(this);
		bimap = BitmapFactory.decodeResource(getResources(), R.drawable.icon_addpic_unfocused);
		parentView = getLayoutInflater().inflate(R.layout.add_audit, null);
		setContentView(parentView);
	}

	@Override
	protected void findViewById() {
		et_name = (EditText) findViewById(R.id.et_name);
		et_money = (EditText) findViewById(R.id.et_money);
		btn_date = (Button) findViewById(R.id.btn_date);
		et_des = (TextView) findViewById(R.id.tv_des);
		btn_reject = (Button) findViewById(R.id.btn_reject);
		btn_approve = (Button) findViewById(R.id.btn_approve);
		progress_loading = (LinearLayout) findViewById(R.id.progress_loading);
		tv_title = (TextView) findViewById(R.id.tv_title);
	}

	@Override
	protected void initialize() {
		btn_approve.setOnClickListener(this);
		btn_reject.setOnClickListener(this);
		btn_date.setOnClickListener(this);

		// Open digital input
		et_money.setInputType(InputType.TYPE_CLASS_NUMBER);

		Intent intent = getIntent();
		dataInfo = (Audit) intent.getSerializableExtra("itemData");
		AuditType = (AuditTypeEnum) getIntent().getSerializableExtra("AuditType");
		if (dataInfo != null) {
			et_name.setText(dataInfo.getF_Name());
			et_money.setText(String.valueOf(dataInfo.getF_Money()));
			et_des.setText(dataInfo.getF_Content());
			btn_date.setText(dateFormat.format(dataInfo.getF_Date()));

		} else {
			btn_date.setText(format(calendar.getTime()));
		}

	}

	@Override
	public void onClick(View v) {
		switch (v.getId()) {
		case R.id.btn_back:
			Intent intent = new Intent();
			intent.setClass(AddAuditActivity.this, AuditActivity.class);
			startActivity(intent);
			finish();
			break;
		case R.id.btn_date:
			ShowTimePickerBack(btn_date, false);
			break;
		case R.id.btn_reject:
			new HandleAudit().execute("reject");
			break;
		case R.id.btn_approve:
			new HandleAudit().execute("approve");

			break;
		}
	}

	@Override
	public boolean onKeyDown(int keyCode, KeyEvent event) {
		
		if (keyCode == KeyEvent.KEYCODE_BACK) {
			
			Intent intent1 = new Intent(AddAuditActivity.this, AuditActivity.class);
			startActivity(intent1);
		
			AddAuditActivity.this.finish();
			
		}
		return true;
	}
	
	class HandleAudit extends AsyncTask<String, String, String> {
		@Override
		protected String doInBackground(String... params) {
			try {
				JSONHttpClient jsonHttpClient = new JSONHttpClient();
				List<NameValuePair> nameValuePairs = new ArrayList<NameValuePair>();
				String operation = params[0];
				Audit pageData = GatherPageData();
				if (operation.equals("approve")) {
					pageData.setF_WF_StateID(getToState(AuditTask, true));
				} else {
					pageData.setF_WF_StateID(getToState(AuditTask, false));
				}

				nameValuePairs.add(new BasicNameValuePair("operatorId", getOperator()));
				nameValuePairs.add(new BasicNameValuePair("fromState", getFromState(AuditTask)));
				nameValuePairs.add(new BasicNameValuePair("toState", getToState(AuditTask, true)));
				nameValuePairs.add(new BasicNameValuePair("auditType", AuditType.name()));
				JsonResult result = jsonHttpClient.PostObjectWithParams(updateAudit_API, nameValuePairs, pageData, JsonResult.class);

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
					intent.setClass(AddAuditActivity.this, AuditActivity.class);
					startActivity(intent);
					finish();
				}
			});
		}
	}

	private Audit GatherPageData() {
		Audit pageData = new Audit();

		pageData.setF_ID(dataInfo.getF_ID());
		pageData.setF_Name(et_name.getText().toString());
		pageData.setF_Money(Float.valueOf(et_money.getText().toString()));
		pageData.setF_Date(GetBtnDate(btn_date));
		pageData.setF_Content(et_des.getText().toString());
		pageData.setF_UserID(getOperatorId());

		return pageData;
	}

	@Override
	public void onItemSelected(AdapterView<?> parent, View view, int position, long id) {
		int index = parent.getSelectedItemPosition();
		switch (view.getId()) {
		case R.id.sp_project:
			// storing string resources into Array
			// projects = getResources().getStringArray(R.array.project);
			//
			// Toast.makeText(getBaseContext(), "You have selected project : " +
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

	@Override
	public void onNothingSelected(AdapterView<?> parent) {
		// TODO Auto-generated method stub

	}

	@Override
	protected void updateList() {
		// TODO Auto-generated method stub

	}

}
