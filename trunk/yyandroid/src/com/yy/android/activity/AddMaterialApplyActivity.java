package com.yy.android.activity;

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
import android.widget.Spinner;
import android.widget.TextView;

import com.yy.android.R;
import com.yy.android.util.JSONHttpClient;
import com.yy.android.util.Res;
import com.yy.android.vo.JsonResult;
import com.yy.android.vo.MaterialApply;

public class AddMaterialApplyActivity extends MyBaseActivity implements OnClickListener, OnItemSelectedListener {
	private View parentView;
	private Button btn_add;
	private Button btn_back, btn_date, btn_delete;
	public static Bitmap bimap;
	private EditText et_material_amount, et_material_name, et_des;
	private TextView tv_cost_title;
	public boolean isAdd = true;
	private int dataID;

	private String addMaterailApply_API = Service_Address + "materialsapply/create";
	private String updateMaterailApply_API = Service_Address + "materialsapply/edit";

	@Override
	protected void setContentView() {
		Res.init(this);
		bimap = BitmapFactory.decodeResource(getResources(), R.drawable.icon_addpic_unfocused);
		parentView = getLayoutInflater().inflate(R.layout.add_material_apply, null);
		setContentView(parentView);
	}

	@Override
	protected void findViewById() {
		sp_project = (Spinner) findViewById(R.id.sp_project);
		et_material_amount = (EditText) findViewById(R.id.et_material_amount);
		btn_date = (Button) findViewById(R.id.btn_date);
		et_des = (EditText) findViewById(R.id.et_equiment_des);
		et_material_name = (EditText) findViewById(R.id.et_material_name);
		tv_cost_title = (TextView) findViewById(R.id.tv_cost_title);
		btn_back = (Button) findViewById(R.id.btn_back);
		btn_add = (Button) findViewById(R.id.btn_add);
		btn_delete = (Button) findViewById(R.id.btn_delete);
		progress_loading = (LinearLayout) findViewById(R.id.progress_loading);
	}

	@Override
	protected void initialize() {
		btn_add.setOnClickListener(this);
		btn_back.setOnClickListener(this);
		btn_date.setOnClickListener(this);
		btn_delete.setOnClickListener(this);
		spCount = 1;

		Intent intent = getIntent();
		MaterialApply dataInfo = (MaterialApply) intent.getSerializableExtra("materialapply");
		if (dataInfo != null) {
			dataID = dataInfo.getF_ID();

			et_material_name.setText(dataInfo.getF_Materials());
			initProjectSpinner(this, String.valueOf(dataInfo.getF_ProjectID()));
			et_material_amount.setText(String.valueOf(dataInfo.getF_ApplyCount()));
			et_des.setText(dataInfo.getF_Description());
			btn_date.setText(dateFormat.format(dataInfo.getF_ApplyDate()));
			tv_cost_title.setText("修改物资申请");
			btn_add.setText("修改申请");
			btn_delete.setText("删除申请");

			isAdd = false;
		} else {
			initProjectSpinner(this);
			btn_date.setText(format(calendar.getTime()));
			tv_cost_title.setText("新增物资申请");
			btn_add.setText("新增申请");
			btn_delete.setText("返回列表");
			btn_date.setText(format(calendar.getTime()));
		}

	}

	@Override
	public void onClick(View v) {
		switch (v.getId()) {
		case R.id.btn_back:
			Intent intent = new Intent();
			intent.setClass(AddMaterialApplyActivity.this, MaterialApplyActivity.class);
			startActivity(intent);
			finish();
			break;
		case R.id.btn_date:
			ShowTimePickerBack(btn_date, false);
			break;
		case R.id.btn_add:
			new HandleMaterialApply().execute();
			break;
		case R.id.btn_delete:
			if (isAdd) {
				finish();
				break;
			} else {
				new HandleMaterialApply().execute("delete");
			}
			break;
		}
	}

	@Override
	public boolean onKeyDown(int keyCode, KeyEvent event) {
		
		if (keyCode == KeyEvent.KEYCODE_BACK) {
			
			Intent intent1 = new Intent(AddMaterialApplyActivity.this, MaterialApplyActivity.class);
			startActivity(intent1);
		
			AddMaterialApplyActivity.this.finish();
			
		}
		return true;
	}
	
	class HandleMaterialApply extends AsyncTask<String, String, String> {
		@Override
		protected String doInBackground(String... params) {
			try {
				JSONHttpClient jsonHttpClient = new JSONHttpClient();
				JsonResult result;
				MaterialApply pageData = GatherPageData();
				if (params.length > 0 && params[0].equals("delete")) {
					pageData.setF_ID(dataID);
					pageData.setF_IsDelete(true);
					result = jsonHttpClient.PostObject(updateMaterailApply_API, pageData, JsonResult.class);
				} else {
					if (isAdd) {
						result = jsonHttpClient.PostObject(addMaterailApply_API, pageData, JsonResult.class);
					} else {
						pageData.setF_ID(dataID);
						result = jsonHttpClient.PostObject(updateMaterailApply_API, pageData, JsonResult.class);
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
					intent.setClass(AddMaterialApplyActivity.this, MaterialApplyActivity.class);
					startActivity(intent);
					finish();
				}
			});
		}
	}

	private MaterialApply GatherPageData() {
		MaterialApply pageData = new MaterialApply();

		pageData.setF_Materials(et_material_name.getText().toString());
		pageData.setF_ApplyCount(Integer.parseInt(et_material_amount.getText().toString()));
		pageData.setF_ProjectID(getSelectedProjectId());
		pageData.setF_ApplyDate(GetBtnDate(btn_date));
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
