package com.yy.android.activity;

import java.lang.reflect.Field;
import java.lang.reflect.Type;
import java.math.BigDecimal;
import java.text.DateFormat;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.Date;
import java.util.List;

import org.apache.http.NameValuePair;
import org.apache.http.message.BasicNameValuePair;

import android.app.Activity;
import android.app.AlertDialog;
import android.app.Dialog;
import android.app.ProgressDialog;
import android.content.Context;
import android.content.DialogInterface;
import android.os.AsyncTask;
import android.os.Bundle;
import android.os.StrictMode;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.Window;
import android.view.animation.Animation;
import android.view.animation.AnimationUtils;
import android.widget.AdapterView.OnItemSelectedListener;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.ImageButton;
import android.widget.ImageView;
import android.widget.LinearLayout;
import android.widget.RelativeLayout;
import android.widget.Spinner;
import android.widget.SpinnerAdapter;
import android.widget.TextView;
import android.widget.Toast;

import com.google.gson.reflect.TypeToken;
import com.yy.android.R;
import com.yy.android.util.DateUtil;
import com.yy.android.util.JSONHttpClient;
import com.yy.android.util.JudgeDate;
import com.yy.android.util.ProgressBar;
import com.yy.android.util.ScreenInfo;
import com.yy.android.util.WheelMain;
import com.yy.android.vo.EquimentInfo;
import com.yy.android.vo.LoginUser;
import com.yy.android.vo.Project;
import com.yy.android.vo.Right;
import com.yy.android.vo.SpinnerData;
import com.yy.android.vo.UserRole;
import com.yy.android.vo.WorkFlow;

public abstract class MyBaseActivity extends Activity {
	protected Calendar calendar = Calendar.getInstance();
	protected String dateFormatString = "yyyy-MM-dd";
	protected DateFormat dateFormat = new SimpleDateFormat(dateFormatString);
	private WheelMain wheelMain;
	protected Animation animation;
	protected ImageView loding_iv;
	protected RelativeLayout rl_loading;
	protected LinearLayout progress_loading;
	// protected String Service_Address = "http://192.168.1.3/";
	public static String Service_Address = "http://192.168.96.35/";
	protected String loadProject_API = Service_Address + "project/getlist";
	protected String loadCostType_API = Service_Address + "datadicinfo/getlist";
	protected List<Project> projectList = new ArrayList<Project>();
	protected Spinner sp_project;
	protected Spinner sp_cost, sp_costStatus, sp_costType, sp_equimentType, sp_equiment_hireType, sp_equiment, sp_projectStatus;
	protected static List<SpinnerData> projectSPList = new ArrayList<SpinnerData>();
	protected static List<SpinnerData> projectStatusSPList = new ArrayList<SpinnerData>();
	protected static List<SpinnerData> costSPList = new ArrayList<SpinnerData>();
	protected static List<SpinnerData> costStatusList = new ArrayList<SpinnerData>();
	protected static List<SpinnerData> costTypeList = new ArrayList<SpinnerData>();
	protected static List<SpinnerData> equimentTypeList = new ArrayList<SpinnerData>();
	protected static List<SpinnerData> equimentHireTypeList = new ArrayList<SpinnerData>();
	protected static List<SpinnerData> equimentInfoSPList = new ArrayList<SpinnerData>(); // zzp
	protected List<EquimentInfo> equimentInfoList = new ArrayList<EquimentInfo>();// zzp
	protected int spCount, initSpCount = 0; // for prematurely execute

	protected Context childActivity;
	protected OnItemSelectedListener childListener;
	protected int loginUserId;
	protected AlertDialog mAlertDialog;
	protected ProgressBar progressBar;
	protected TextView emptyText;
	protected String projectId;
	protected String costTypeId, costStatusId, projectCostTypeId, projectStatusId, equimentTypeId, equimentHireTypeId, equimentId;
	protected String startDateString, endDateString;
	protected String typeCode;
	protected ImageButton ib_clock;
	protected String emptyDateText = "未定";
	protected static LoginUser loginUser;
	protected boolean isStartEmpty = false, isEndEmpty = false;
	protected String AuditTask = "F_Audit";
	protected String CostApplyTask = "CostApply";
	// Constant value
	protected int OtherCost = 106;
	protected int NonProjectId = 0;

	@Override
	protected void onCreate(Bundle savedInstanceState) {

		super.onCreate(savedInstanceState);
		requestWindowFeature(Window.FEATURE_NO_TITLE);
		setContentView();
		findViewById();
		initialize();
		if (android.os.Build.VERSION.SDK_INT > 9) {
			StrictMode.ThreadPolicy policy = new StrictMode.ThreadPolicy.Builder().permitAll().build();
			StrictMode.setThreadPolicy(policy);
		}
	}

	protected String format(Date date) {
		String str = "";
		str = dateFormat.format(date);
		return str;
	}

	protected void ShowTimePicker(final Button btn_date) {
		ShowTimePicker(btn_date, true);
	}

	protected void ShowTimePicker(final Button btn_date, final boolean isUpdate) {
		LayoutInflater inflater = LayoutInflater.from(this);
		final View timepickerview = inflater.inflate(R.layout.timepicker, null);
		ScreenInfo screenInfo = new ScreenInfo(this);
		wheelMain = new WheelMain(timepickerview);
		wheelMain.screenheight = screenInfo.getHeight();
		String time = btn_date.getText().toString();
		Calendar calendar = Calendar.getInstance();
		if (JudgeDate.isDate(time, "yyyy-MM-dd")) {
			try {
				calendar.setTime(dateFormat.parse(time));
			} catch (ParseException e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			}
		}
		int year = calendar.get(Calendar.YEAR);
		int month = calendar.get(Calendar.MONTH);
		int day = calendar.get(Calendar.DAY_OF_MONTH);
		wheelMain.initDateTimePicker(year, month, day);
		new AlertDialog.Builder(this).setTitle("选择时间").setView(timepickerview).setPositiveButton("确定", new DialogInterface.OnClickListener() {
			@Override
			public void onClick(DialogInterface dialog, int which) {
				try {
					btn_date.setText(format(dateFormat.parse(wheelMain.getTime())));
				} catch (ParseException e) {
					// TODO Auto-generated catch block
					e.printStackTrace();
				}
				if (isUpdate)
					updateList();
			}
		}).setNegativeButton("清空", new DialogInterface.OnClickListener() {
			@Override
			public void onClick(DialogInterface dialog, int which) {
				btn_date.setText(emptyDateText);
			}
		}).show();
	}

	protected void ShowTimePickerBack(final Button btn_date, final boolean isUpdate) {
		LayoutInflater inflater = LayoutInflater.from(this);
		final View timepickerview = inflater.inflate(R.layout.timepicker, null);
		ScreenInfo screenInfo = new ScreenInfo(this);
		wheelMain = new WheelMain(timepickerview);
		wheelMain.screenheight = screenInfo.getHeight();
		String time = btn_date.getText().toString();
		Calendar calendar = Calendar.getInstance();
		if (JudgeDate.isDate(time, "yyyy-MM-dd")) {
			try {
				calendar.setTime(dateFormat.parse(time));
			} catch (ParseException e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			}
		}
		int year = calendar.get(Calendar.YEAR);
		int month = calendar.get(Calendar.MONTH);
		int day = calendar.get(Calendar.DAY_OF_MONTH);
		wheelMain.initDateTimePicker(year, month, day);
		new AlertDialog.Builder(this).setTitle("选择时间").setView(timepickerview).setPositiveButton("确定", new DialogInterface.OnClickListener() {
			@Override
			public void onClick(DialogInterface dialog, int which) {
				try {
					btn_date.setText(format(dateFormat.parse(wheelMain.getTime())));
				} catch (ParseException e) {
					// TODO Auto-generated catch block
					e.printStackTrace();
				}
				if (isUpdate)
					updateList();
			}
		}).setNegativeButton("取消", new DialogInterface.OnClickListener() {
			@Override
			public void onClick(DialogInterface dialog, int which) {
			}
		}).show();
	}

	protected Date GetBtnDate(Button btn_date) {
		if (btn_date.getText().toString().equals(emptyDateText)) {
			return null;
		} else {
			String time = btn_date.getText().toString();
			return DateUtil.getDate(time, dateFormatString);
		}
	}

	protected void showAnim() {
		animation = AnimationUtils.loadAnimation(this, R.anim.activity_translate_in);
		progress_loading.setVisibility(View.VISIBLE);
		if (emptyText != null)
			emptyText.setVisibility(View.INVISIBLE);
	}

	protected void stopAnim() {
		progress_loading.setVisibility(View.GONE);
	}

	protected void initProjectSpinner(OnItemSelectedListener child, String... values) {
		childActivity = (Context) child;
		childListener = child;
		if (values.length > 0) {
			projectId = values[0];
		}
		if (projectSPList.size() == 0) {
			new LoadProjects().execute();
		} else {
			buildPorjectSpinner();
		}
	}

	public void setSpinnerSelectedByValue(Spinner spinner, String value) {
		SpinnerAdapter apsAdapter = spinner.getAdapter(); // 得到SpinnerAdapter对象
		int k = apsAdapter.getCount();
		for (int i = 0; i < k; i++) {
			if (value.equals(apsAdapter.getItem(i).toString())) {
				spinner.setSelection(i, true);// 默认选中项
				break;
			}
		}
	}

	protected void buildPorjectSpinner() {
		if (sp_project != null) {
			ArrayAdapter<SpinnerData> adapter = new ArrayAdapter<SpinnerData>(childActivity, android.R.layout.simple_spinner_item, projectSPList);
			adapter.setDropDownViewResource(android.R.layout.select_dialog_singlechoice);
			sp_project.setAdapter(adapter);
			sp_project.setOnItemSelectedListener(childListener);

			if (projectId != null && !projectId.isEmpty()) {
				int k = adapter.getCount();
				for (int i = 0; i < k; i++) {
					if (projectId.equals(((SpinnerData) adapter.getItem(i)).getValue())) {
						sp_project.setSelection(i, true);// 默认选中项
						break;
					}
				}
			}
		}
	}

	protected int getSelectedProjectId() {
		return Integer.parseInt(((SpinnerData) sp_project.getSelectedItem()).getValue());
	}

	protected String getSelectedProjectText() {
		return ((SpinnerData) sp_project.getSelectedItem()).getText().toString();
	}

	protected void initCostSpinner(OnItemSelectedListener child, String... values) {
		childActivity = (Context) child;
		childListener = child;
		if (values.length > 0) {
			costTypeId = values[0];
		}
		if (costSPList.size() == 0) {
			new LoadDataTypes().execute("Cost_Type");
		} else {
			buildCostSpinner();
		}
	}

	protected void buildCostSpinner() {
		ArrayAdapter<SpinnerData> adapter = new ArrayAdapter<SpinnerData>(childActivity, android.R.layout.simple_spinner_item, costSPList);
		adapter.setDropDownViewResource(android.R.layout.select_dialog_singlechoice);
		sp_cost.setAdapter(adapter);
		sp_cost.setOnItemSelectedListener(childListener);

		if (costTypeId != null && !costTypeId.isEmpty()) {
			int k = adapter.getCount();
			for (int i = 0; i < k; i++) {
				if (costTypeId.equals(((SpinnerData) adapter.getItem(i)).getValue())) {
					sp_cost.setSelection(i, true);// 默认选中项
					break;
				}
			}
		}
	}

	protected int getSelectedCostId() {
		return Integer.parseInt(((SpinnerData) sp_cost.getSelectedItem()).getValue());
	}

	protected void initCostTypeSpinner(OnItemSelectedListener child, String... values) {
		childActivity = (Context) child;
		childListener = child;
		if (values.length > 0) {
			projectCostTypeId = values[0];
		}
		if (costTypeList.size() == 0) {
			// costTypeList.add(new SpinnerData("0", "全部"));
			costTypeList.add(new SpinnerData("1", "工程费用"));
			costTypeList.add(new SpinnerData("2", "非工程费用"));
		}
		buildCostTypeSpinner();

	}

	protected void buildCostTypeSpinner() {
		ArrayAdapter<SpinnerData> adapter = new ArrayAdapter<SpinnerData>(childActivity, android.R.layout.simple_spinner_item, costTypeList);
		adapter.setDropDownViewResource(android.R.layout.select_dialog_singlechoice);
		sp_costType.setAdapter(adapter);
		sp_costType.setOnItemSelectedListener(childListener);

		if (projectCostTypeId != null && !projectCostTypeId.isEmpty()) {
			int k = adapter.getCount();
			for (int i = 0; i < k; i++) {
				if (projectCostTypeId.equals(((SpinnerData) adapter.getItem(i)).getValue())) {
					sp_costType.setSelection(i, true);// 默认选中项
					break;
				}
			}
		}
	}

	protected int getCostTypeId() {
		return Integer.parseInt(((SpinnerData) sp_costType.getSelectedItem()).getValue());
	}

	protected void initProjectStatusSpinner(OnItemSelectedListener child, String... values) {
		childActivity = (Context) child;
		childListener = child;
		if (values.length > 0) {
			projectStatusId = values[0];
		}
		if (projectStatusSPList.size() == 0) {
			projectStatusSPList.add(new SpinnerData("0", "开启"));
			projectStatusSPList.add(new SpinnerData("1", "关闭"));
		}
		buildProjectStatusSpinner();

	}

	protected void buildProjectStatusSpinner() {
		ArrayAdapter<SpinnerData> adapter = new ArrayAdapter<SpinnerData>(childActivity, android.R.layout.simple_spinner_item, projectStatusSPList);
		adapter.setDropDownViewResource(android.R.layout.select_dialog_singlechoice);
		sp_projectStatus.setAdapter(adapter);
		sp_projectStatus.setOnItemSelectedListener(childListener);

		if (projectStatusId != null && !projectStatusId.isEmpty()) {
			int k = adapter.getCount();
			for (int i = 0; i < k; i++) {
				if (projectStatusId.equals(((SpinnerData) adapter.getItem(i)).getValue())) {
					sp_projectStatus.setSelection(i, true);// 默认选中项
					break;
				}
			}
		}
	}

	protected int getProjectStatusId() {
		return Integer.parseInt(((SpinnerData) sp_projectStatus.getSelectedItem()).getValue());
	}

	protected String getProjectStatus() {
		return ((SpinnerData) sp_projectStatus.getSelectedItem()).getValue();
	}

	protected void initEquimentHireTypeSpinner(OnItemSelectedListener child, String... values) {
		childActivity = (Context) child;
		childListener = child;
		if (values.length > 0) {
			equimentHireTypeId = values[0];
		}
		if (equimentHireTypeList.size() == 0) {
			equimentHireTypeList.add(new SpinnerData("0", "全部"));
			equimentHireTypeList.add(new SpinnerData("1", "本厂"));
			equimentHireTypeList.add(new SpinnerData("2", "外雇"));
		}
		buildEquimentHireTypeSpinner();

	}

	protected void buildEquimentHireTypeSpinner() {
		ArrayAdapter<SpinnerData> adapter = new ArrayAdapter<SpinnerData>(childActivity, android.R.layout.simple_spinner_item, equimentHireTypeList);
		adapter.setDropDownViewResource(android.R.layout.select_dialog_singlechoice);
		sp_equiment_hireType.setAdapter(adapter);
		sp_equiment_hireType.setOnItemSelectedListener(childListener);

		if (equimentHireTypeId != null && !equimentHireTypeId.isEmpty()) {
			int k = adapter.getCount();
			for (int i = 0; i < k; i++) {
				if (equimentHireTypeId.equals(((SpinnerData) adapter.getItem(i)).getValue())) {
					sp_equiment_hireType.setSelection(i, true);// 默认选中项
					break;
				}
			}
		}
	}

	protected int getEquimentHireTypeId() {
		return Integer.parseInt(((SpinnerData) sp_equiment_hireType.getSelectedItem()).getValue());
	}

	// start*****************************zzp
	protected void initEquimentSpinner(OnItemSelectedListener child, String... values) {
		childActivity = (Context) child;
		childListener = child;
		if (values.length > 0) {
			equimentId = values[0];
		}
		if (equimentInfoSPList.size() == 0) {
			new LoadElementInfo().execute("Equiment");

		} else {
			buildEquimentSpinner();
		}
	}

	protected void buildEquimentSpinner() {
		ArrayAdapter<SpinnerData> adapter = new ArrayAdapter<SpinnerData>(childActivity, android.R.layout.simple_spinner_item, equimentInfoSPList);
		adapter.setDropDownViewResource(android.R.layout.select_dialog_singlechoice);
		sp_equiment.setAdapter(adapter);
		sp_equiment.setOnItemSelectedListener(childListener);

		if (equimentId != null && !equimentId.isEmpty()) {
			int k = adapter.getCount();
			for (int i = 0; i < k; i++) {
				if (equimentId.equals(((SpinnerData) adapter.getItem(i)).getValue())) {
					sp_equiment.setSelection(i, true);// 默认选中项
					break;
				}
			}
		}
	}

	protected int getEquimentId() {
		return Integer.parseInt(((SpinnerData) sp_equiment.getSelectedItem()).getValue());
	}

	// end*****************************zzp

	protected void initEquimentTypeSpinner(OnItemSelectedListener child, String... values) {
		childActivity = (Context) child;
		childListener = child;
		if (values.length > 0) {
			costTypeId = values[0];
		}
		if (equimentTypeList.size() == 0) {
			new LoadDataTypes().execute("Equiment_Type");
		} else {
			buildEquimentTypeSpinner();
		}
	}

	protected void buildEquimentTypeSpinner() {
		ArrayAdapter<SpinnerData> adapter = new ArrayAdapter<SpinnerData>(childActivity, android.R.layout.simple_spinner_item, equimentTypeList);
		adapter.setDropDownViewResource(android.R.layout.select_dialog_singlechoice);
		sp_equimentType.setAdapter(adapter);
		sp_equimentType.setOnItemSelectedListener(childListener);

		if (equimentTypeId != null && !equimentTypeId.isEmpty()) {
			int k = adapter.getCount();
			for (int i = 0; i < k; i++) {
				if (equimentTypeId.equals(((SpinnerData) adapter.getItem(i)).getValue())) {
					sp_equimentType.setSelection(i, true);// 默认选中项
					break;
				}
			}
		}
	}

	protected int getEquimentTypeId() {
		return Integer.parseInt(((SpinnerData) sp_equimentType.getSelectedItem()).getValue());
	}

	protected void initCostStatusSpinner(OnItemSelectedListener child, String... values) {
		childActivity = (Context) child;
		childListener = child;
		if (values.length > 0) {
			costStatusId = values[0];
		}
		if (costStatusList.size() == 0) {
			// costStatusList.add(new SpinnerData("0", "全部"));
			costStatusList.add(new SpinnerData("1", "未申请"));
			costStatusList.add(new SpinnerData("2", "已申请"));
		}
		buildCostStatusSpinner();

	}

	protected void buildCostStatusSpinner() {
		ArrayAdapter<SpinnerData> adapter = new ArrayAdapter<SpinnerData>(childActivity, android.R.layout.simple_spinner_item, costStatusList);
		adapter.setDropDownViewResource(android.R.layout.select_dialog_singlechoice);
		sp_costStatus.setAdapter(adapter);
		sp_costStatus.setOnItemSelectedListener(childListener);

		if (costStatusId != null && !costStatusId.isEmpty()) {
			int k = adapter.getCount();
			for (int i = 0; i < k; i++) {
				if (costStatusId.equals(((SpinnerData) adapter.getItem(i)).getValue())) {
					sp_costStatus.setSelection(i, true);// 默认选中项
					break;
				}
			}
		}
	}

	protected int getCostStatusId() {
		return Integer.parseInt(((SpinnerData) sp_costStatus.getSelectedItem()).getValue());
	}

	class LoadProjects extends AsyncTask<String, String, String> {
		@Override
		protected String doInBackground(String... params) {
			try {
				JSONHttpClient jsonHttpClient = new JSONHttpClient();
				List<NameValuePair> nameValuePairs = new ArrayList<NameValuePair>();
				nameValuePairs.add(new BasicNameValuePair("projectStatus", "0"));
				Type listType = new TypeToken<List<Project>>() {
				}.getType();

				projectList = jsonHttpClient.GetList(loadProject_API, nameValuePairs, Project.class, listType);

			} catch (Exception e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			}
			return null;
		}

		@Override
		protected void onPreExecute() {
			super.onPreExecute();
		}

		@Override
		protected void onPostExecute(String s) {
			runOnUiThread(new Runnable() {
				@Override
				public void run() {
					if (projectList == null)
						return;
					projectSPList.clear();
					for (Project proj : projectList) {
						SpinnerData c = new SpinnerData(String.valueOf(proj.getF_ID()), proj.getF_Name());
						projectSPList.add(c);
					}
					buildPorjectSpinner();
				}
			});
		}
	}

	protected String loadequipment_API = Service_Address + "equipment/getlist";

	class LoadElementInfo extends AsyncTask<String, String, String> {
		@Override
		protected String doInBackground(String... params) {
			try {
				JSONHttpClient jsonHttpClient = new JSONHttpClient();
				List<NameValuePair> nameValuePairs = new ArrayList<NameValuePair>();
				Type listType = new TypeToken<List<EquimentInfo>>() {
				}.getType();

				equimentInfoList = jsonHttpClient.GetList(loadequipment_API, nameValuePairs, EquimentInfo.class, listType);

			} catch (Exception e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			}
			return null;
		}

		@Override
		protected void onPreExecute() {
			super.onPreExecute();
		}

		@Override
		protected void onPostExecute(String s) {
			runOnUiThread(new Runnable() {
				@Override
				public void run() {
					for (EquimentInfo proj : equimentInfoList) {
						SpinnerData c = new SpinnerData(String.valueOf(proj.getF_ID()), proj.getF_Name());
						equimentInfoSPList.add(c);
					}
					buildEquimentSpinner();
				}
			});
		}
	}

	class LoadDataTypes extends AsyncTask<String, String, String> {
		@Override
		protected String doInBackground(String... params) {
			try {
				typeCode = params[0];
				JSONHttpClient jsonHttpClient = new JSONHttpClient();
				List<NameValuePair> nameValuePairs = new ArrayList<NameValuePair>();
				nameValuePairs.add(new BasicNameValuePair("typeCode", typeCode));

				Type listType = new TypeToken<List<SpinnerData>>() {
				}.getType();

				if (typeCode.equals("Cost_Type")) {
					costSPList = jsonHttpClient.GetList(loadCostType_API, nameValuePairs, SpinnerData.class, listType);
				} else if (typeCode.equals("Equiment_Type")) {
					equimentTypeList = jsonHttpClient.GetList(loadCostType_API, nameValuePairs, SpinnerData.class, listType);
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
		}

		@Override
		protected void onPostExecute(String s) {
			runOnUiThread(new Runnable() {
				@Override
				public void run() {
					if (typeCode.equals("Cost_Type")) {
						buildCostSpinner();
					} else if (typeCode.equals("Equiment_Type")) {
						buildEquimentTypeSpinner();
					}
				}
			});
		}
	}

	public float formatFloat(float input) {
		BigDecimal b = new BigDecimal(input);
		return b.setScale(2, BigDecimal.ROUND_HALF_UP).floatValue();
	}

	protected abstract void setContentView();

	protected abstract void findViewById();

	protected abstract void initialize();

	/***
	 * Update list for time change
	 */
	protected abstract void updateList();

	public void setAlertDialogIsClose(DialogInterface pDialog, Boolean pIsClose) {
		try {
			Field field = pDialog.getClass().getSuperclass().getDeclaredField("mShowing");
			field.setAccessible(true);
			field.set(pDialog, pIsClose);
		} catch (Exception e) {
			e.printStackTrace();
		}
	}

	protected AlertDialog showAlertDialog(String TitleID, String Message) {
		mAlertDialog = new AlertDialog.Builder(this).setTitle(TitleID).setMessage(Message).show();
		return mAlertDialog;
	}

	protected AlertDialog showAlertDialog(int pTitelResID, String pMessage, DialogInterface.OnClickListener pOkClickListener) {
		String title = getResources().getString(pTitelResID);
		return showAlertDialog(title, pMessage, pOkClickListener, null, null);
	}

	protected AlertDialog showAlertDialog(String pTitle, String pMessage, DialogInterface.OnClickListener pOkClickListener,
			DialogInterface.OnClickListener pCancelClickListener, DialogInterface.OnDismissListener pDismissListener) {
		mAlertDialog = new AlertDialog.Builder(this).setTitle(pTitle).setMessage(pMessage).setPositiveButton(android.R.string.ok, pOkClickListener)
				.setNegativeButton(android.R.string.cancel, pCancelClickListener).show();
		if (pDismissListener != null) {
			mAlertDialog.setOnDismissListener(pDismissListener);
		}
		return mAlertDialog;
	}

	protected AlertDialog showAlertDialog(String pTitle, String pMessage, String pPositiveButtonLabel, String pNegativeButtonLabel,
			DialogInterface.OnClickListener pOkClickListener, DialogInterface.OnClickListener pCancelClickListener,
			DialogInterface.OnDismissListener pDismissListener) {
		mAlertDialog = new AlertDialog.Builder(this).setTitle(pTitle).setMessage(pMessage).setPositiveButton(pPositiveButtonLabel, pOkClickListener)
				.setNegativeButton(pNegativeButtonLabel, pCancelClickListener).show();
		if (pDismissListener != null) {
			mAlertDialog.setOnDismissListener(pDismissListener);
		}
		return mAlertDialog;
	}

	protected ProgressDialog showProgressDialog(int pTitelResID, String pMessage, DialogInterface.OnCancelListener pCancelClickListener) {
		String title = getResources().getString(pTitelResID);
		return showProgressDialog(title, pMessage, pCancelClickListener);
	}

	protected ProgressDialog showProgressDialog(String pTitle, String pMessage, DialogInterface.OnCancelListener pCancelClickListener) {
		mAlertDialog = ProgressDialog.show(this, pTitle, pMessage, true, true);
		mAlertDialog.setOnCancelListener(pCancelClickListener);
		return (ProgressDialog) mAlertDialog;
	}

	public enum ProjectStatusEnum {
		open, close;
	}

	public enum CostTypeEnum {
		all, project, nonproject;
	}

	public enum AuditTypeEnum {
		audit_product, audit_payment, audit_fee;
	}

	public enum EquimentEnum {
		corp, hire;
	}

	public void setLoginUser(LoginUser loginUser) {
		this.loginUser = loginUser;
	}

	public LoginUser getLoginUser() {
		if (loginUser == null) {
			Toast.makeText(this, "没有登录信息", Toast.LENGTH_SHORT).show();
		}
		return loginUser;
	}

	public String getOperator() {
		return String.valueOf(getOperatorId());
	}

	public int getOperatorId() {
		return getLoginUser().getF_UserID();
	}

	public UserRole getLoginUserRole() {
		return getLoginUser().getUserRole();
	}

	public List<Right> getLoginUserRights() {
		return getLoginUserRole().getRights();
	}

	public String getStateID(String task) {
		return getWorkFlow(task).getF_StateID();
	}

	public WorkFlow getWorkFlow(String task) {
		WorkFlow workFlow = new WorkFlow();
		for (WorkFlow wf : getLoginUser().getUserRole().WorkFlows) {
			if (wf.getF_LinkTask().equals(task)) {
				workFlow = wf;
				break;
			}
		}
		return workFlow;
	}

	public int getFromStateID(String task) {
		return getWorkFlow(task).getF_ID();
	}

	public String getFromState(String task) {
		return String.valueOf(getWorkFlow(task).getF_ID());
	}

	public String getToState(String task, boolean isNext) {
		String toState;
		if (isNext) {
			toState = getWorkFlow(task).getF_Next_StateID();
		} else {
			toState = getWorkFlow(task).getF_Back_StateID();
		}
		return toState;
	}

	public int getToStateID(String task, boolean isNext) {
		return Integer.valueOf(getToState(task, isNext));
	}

	public static boolean checkUserRight(String rightCode) {
		boolean isOK = false;
		for (Right right : loginUser.getUserRole().getRights()) {
			if (right.getF_Code().equals(rightCode)) {
				isOK = true;
				break;
			}
		}
		return isOK;
	}

	protected void showDateSearchDialog() {
		DateSearchDialog dialog = new DateSearchDialog(this);
		dialog.show();
		// et_startDate=(EditText)dialog.findViewById(R.id.et_start);
		// startDate = et_startDate.getText().toString();
		// et_endDate=(EditText)dialog.findViewById(R.id.et_end);
		// endDate = et_endDate.getText().toString();
	}

	class DateSearchDialog extends Dialog {
		Button startDate;
		Button endDate;

		public DateSearchDialog(Context context) {
			super(context);
			// TODO Auto-generated constructor stub
		}

		protected void onCreate(Bundle savedInstanceState) {
			super.onCreate(savedInstanceState);

			setContentView(R.layout.date_range_dialog);
			setTitle("查询时间选择");

			startDate = (Button) findViewById(R.id.btn_date_start);
			startDate.setOnClickListener(new View.OnClickListener() {

				@Override
				public void onClick(View v) {
					ShowTimePicker(startDate, false);

				}
			});
			if (isStartEmpty) {
				startDate.setText(emptyDateText);
			} else {
				if (startDateString == null || startDateString.equals("")) {
					startDate.setText(format(calendar.getTime()));
				} else {
					startDate.setText(startDateString);
				}
			}
			endDate = (Button) findViewById(R.id.btn_date_end);
			endDate.setOnClickListener(new View.OnClickListener() {

				@Override
				public void onClick(View v) {
					ShowTimePicker(endDate, false);

				}
			});
			if (isEndEmpty) {
				endDate.setText(emptyDateText);
			} else {
				if (endDateString == null || endDateString.equals("")) {
					endDate.setText(format(calendar.getTime()));
				} else {
					endDate.setText(endDateString);
				}
			}
			Button buttonYes = (Button) findViewById(R.id.btn_ok);
			buttonYes.setOnClickListener(new Button.OnClickListener() {
				public void onClick(View v) {
					if (GetBtnDate(startDate) != null) {
						if (GetBtnDate(startDate).equals(emptyDateText)) {
							startDateString = null;
							isStartEmpty = true;
						} else {
							startDateString = startDate.getText().toString();
							isStartEmpty = false;
						}
					} else {
						startDateString = null;
						isStartEmpty = true;
					}
					if (GetBtnDate(endDate) != null) {
						if (GetBtnDate(endDate).equals(emptyDateText)) {
							endDateString = null;
							isEndEmpty = true;
						} else {
							endDateString = endDate.getText().toString();
							isEndEmpty = false;
						}
					} else {
						endDateString = null;
						isEndEmpty = true;
					}
					if (GetBtnDate(startDate) != null && GetBtnDate(endDate) != null) {
						if (GetBtnDate(startDate).getTime() > GetBtnDate(endDate).getTime()) {
							showAlertDialog("日期选择", "开始日期不能大于结束日期，请重新选择。");
							return;
						}
					}
					dismiss();
					updateList();
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

}
