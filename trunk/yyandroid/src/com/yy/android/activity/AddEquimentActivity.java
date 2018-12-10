package com.yy.android.activity;

import java.util.Calendar;

import android.content.Intent;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.os.AsyncTask;
import android.view.KeyEvent;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.AdapterView;
import android.widget.AdapterView.OnItemSelectedListener;
import android.widget.Button;
import android.widget.EditText;
import android.widget.LinearLayout;
import android.widget.RadioButton;
import android.widget.RadioGroup;
import android.widget.RadioGroup.OnCheckedChangeListener;
import android.widget.Spinner;
import android.widget.TextView;

import com.yy.android.R;
import com.yy.android.util.JSONHttpClient;
import com.yy.android.util.Res;
import com.yy.android.vo.Equiment;
import com.yy.android.vo.JsonResult;
import com.yy.android.vo.SpinnerData;

public class AddEquimentActivity extends MyBaseActivity implements OnClickListener, OnItemSelectedListener {
	private Calendar calendar = Calendar.getInstance();
	private View parentView;
	private Button btn_add;
	private Button btn_back, btn_date, btn_delete;
	public static Bitmap bimap;
	private EditText et_equiment_amount, et_equimentname, et_des;
	private TextView tv_cost_title;
	public boolean isAdd = true;
	private int dataID;
	private LinearLayout ll_equimentType, ll_hire, ll_elementcount;
	private RadioGroup radioGroup_equiment;
	private RadioButton radio_corp, radio_hire;

	private String addEquiment_API = Service_Address + "equimentattendace/create";
	private String updateEquiment_API = Service_Address + "equimentattendace/edit";

	@Override
	protected void setContentView() {
		Res.init(this);
		bimap = BitmapFactory.decodeResource(getResources(), R.drawable.icon_addpic_unfocused);
		parentView = getLayoutInflater().inflate(R.layout.add_equiment, null);
		setContentView(parentView);
	}

	@Override
	protected void findViewById() {
		sp_project = (Spinner) findViewById(R.id.sp_project);
		sp_equiment = (Spinner) findViewById(R.id.sp_equiment);
		et_equiment_amount = (EditText) findViewById(R.id.et_equiment_amount);
		btn_date = (Button) findViewById(R.id.btn_date);
		et_des = (EditText) findViewById(R.id.et_equiment_des);
		et_equimentname = (EditText) findViewById(R.id.et_equimentname);
		tv_cost_title = (TextView) findViewById(R.id.tv_cost_title);
		btn_back = (Button) findViewById(R.id.btn_back);
		btn_add = (Button) findViewById(R.id.btn_add);
		btn_delete = (Button) findViewById(R.id.btn_delete);
		ll_equimentType = (LinearLayout) findViewById(R.id.ll_equimentType);
		ll_hire = (LinearLayout) findViewById(R.id.ll_hire);
		ll_elementcount = (LinearLayout) findViewById(R.id.ll_elementcount);
		progress_loading = (LinearLayout) findViewById(R.id.progress_loading);
		radioGroup_equiment = (RadioGroup) findViewById(R.id.radioGroup_equiment);
		radio_corp = (RadioButton) findViewById(R.id.radio_corp);
		radio_hire = (RadioButton) findViewById(R.id.radio_hire);
	}

	@Override
	protected void initialize() {
		btn_add.setOnClickListener(this);
		btn_back.setOnClickListener(this);
		btn_date.setOnClickListener(this);
		btn_delete.setOnClickListener(this);
		radioGroup_equiment.setOnCheckedChangeListener(new OnCheckedChangeListener() {

			@Override
			public void onCheckedChanged(RadioGroup group, int checkedId) {
				int radioButtonId = group.getCheckedRadioButtonId();
				RadioButton rb = (RadioButton) AddEquimentActivity.this.findViewById(radioButtonId);
				if (radioButtonId == R.id.radio_hire) {
					ll_equimentType.setVisibility(View.GONE);
					ll_elementcount.setVisibility(View.VISIBLE);
					ll_hire.setVisibility(View.VISIBLE);
					et_equiment_amount.setText("1");
				} else {
					ll_hire.setVisibility(View.GONE);
					ll_equimentType.setVisibility(View.VISIBLE);
					ll_elementcount.setVisibility(View.GONE);
					et_equiment_amount.setText("1");
					AddEquimentActivity.this.initEquimentSpinner(AddEquimentActivity.this);
				}
			}
		});
		spCount = 2;
		Intent intent = getIntent();
		Equiment dataInfo = (Equiment) intent.getSerializableExtra("equiment");
		if (dataInfo != null) {
			dataID = dataInfo.getF_ID();
			if (dataInfo.isF_IsHired()) {
				radio_hire.setChecked(true);
				ll_equimentType.setVisibility(View.GONE);
				ll_hire.setVisibility(View.VISIBLE);
				et_equimentname.setText(dataInfo.getF_EquimentName());
			} else {
				radio_corp.setChecked(true);
				ll_hire.setVisibility(View.GONE);
				ll_equimentType.setVisibility(View.VISIBLE);
				// initEquimentTypeSpinner(this,
				// String.valueOf(dataInfo.getF_EquimentID()));
				initEquimentSpinner(this, String.valueOf(dataInfo.getF_EquimentID()));
			}

			initProjectSpinner(this, String.valueOf(dataInfo.getF_ProjectID()));
			et_equiment_amount.setText(String.valueOf(dataInfo.getF_EquimentCount()));
			et_des.setText(dataInfo.getF_Description());
			btn_date.setText(dateFormat.format(dataInfo.getF_AttendanceDate()));
			tv_cost_title.setText("修改设备登记");
			btn_add.setText("修改登记");
			btn_delete.setText("删除登记");

			isAdd = false;
		} else {

			initProjectSpinner(this);
			initEquimentSpinner(this);
			btn_date.setText(format(calendar.getTime()));
			tv_cost_title.setText("新增设备登记");
			btn_add.setText("新增登记");
			btn_delete.setText("返回列表");
			btn_date.setText(format(calendar.getTime()));
		}

	}

	@Override
	public void onClick(View v) {
		Intent intent = new Intent();
		switch (v.getId()) {
		case R.id.btn_back:
			intent.setClass(AddEquimentActivity.this, EquimentActivity.class);
			startActivity(intent);
			finish();
			break;
		case R.id.btn_date:
			ShowTimePickerBack(btn_date, false);
			break;
		case R.id.btn_add:
			new HandleEquiment().execute();
			break;
		case R.id.btn_delete:
			if (isAdd) {
				intent.setClass(AddEquimentActivity.this, EquimentActivity.class);
				startActivity(intent);
				finish();
				break;
			} else {
				new HandleEquiment().execute("delete");
			}
			break;
		}
	}

	@Override
	public boolean onKeyDown(int keyCode, KeyEvent event) {

		if (keyCode == KeyEvent.KEYCODE_BACK) {

			Intent intent = new Intent();
			intent.setClass(AddEquimentActivity.this, EquimentActivity.class);
			startActivity(intent);
			finish();

		}
		return true;
	}

	class HandleEquiment extends AsyncTask<String, String, String> {
		@Override
		protected String doInBackground(String... params) {
			try {
				JSONHttpClient jsonHttpClient = new JSONHttpClient();
				JsonResult result;
				Equiment pageData = GatherPageData();
				if (params.length > 0 && params[0].equals("delete")) {
					pageData.setF_ID(dataID);
					pageData.setF_IsDelete(true);
					result = jsonHttpClient.PostObject(updateEquiment_API, pageData, JsonResult.class);
				} else {
					if (isAdd) {
						result = jsonHttpClient.PostObject(addEquiment_API, pageData, JsonResult.class);
					} else {
						pageData.setF_ID(dataID);
						result = jsonHttpClient.PostObject(updateEquiment_API, pageData, JsonResult.class);
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
					intent.setClass(AddEquimentActivity.this, EquimentActivity.class);
					startActivity(intent);
					finish();
				}
			});
		}
	}

	private Equiment GatherPageData() {
		Equiment pageData = new Equiment();
		int radioId = radioGroup_equiment.getCheckedRadioButtonId();
		if (radioId == R.id.radio_hire) {
			pageData.setF_IsHired(true);
			pageData.setF_EquimentName(et_equimentname.getText().toString());
		} else {
			pageData.setF_EquimentID(getEquimentId());
		}
		pageData.setF_EquimentCount(Integer.parseInt(et_equiment_amount.getText().toString()));
		pageData.setF_ProjectID(getSelectedProjectId());
		pageData.setF_AttendanceDate(GetBtnDate(btn_date));
		pageData.setF_Description(et_des.getText().toString());
		pageData.setF_OperatorID(getOperatorId());

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
				int costId = getSelectedCostId();
				if (costId == OtherCost) {
					ll_equimentType.setVisibility(View.GONE);
					ll_hire.setVisibility(View.VISIBLE);
				} else {
					ll_equimentType.setVisibility(View.VISIBLE);
					ll_hire.setVisibility(View.GONE);
				}
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
