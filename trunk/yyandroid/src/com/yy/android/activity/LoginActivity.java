package com.yy.android.activity;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;

import org.apache.http.NameValuePair;
import org.apache.http.message.BasicNameValuePair;

import android.content.Context;
import android.content.Intent;
import android.content.SharedPreferences;
import android.graphics.drawable.Drawable;
import android.os.Bundle;
import android.view.KeyEvent;
import android.view.LayoutInflater;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.view.View.OnClickListener;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.CheckBox;
import android.widget.EditText;
import android.widget.ImageButton;
import android.widget.ImageView;
import android.widget.LinearLayout;
import android.widget.ListView;
import android.widget.PopupWindow;
import android.widget.RelativeLayout;
import android.widget.SimpleAdapter;
import android.widget.TextView;
import android.widget.Toast;

import com.yy.android.R;
import com.yy.android.database.DBHelper;
import com.yy.android.util.ClassPathResource;
import com.yy.android.util.JSONHttpClient;
import com.yy.android.vo.LoginUser;

public class LoginActivity extends MyBaseActivity implements OnClickListener {

	@Override
	protected void setContentView() {
		// TODO 自动生成的方法存根
		setContentView(R.layout.login);
		dbHelper = new DBHelper(this);
		mUserName = (EditText) findViewById(R.id.et_user);
		mPassword = (EditText) findViewById(R.id.txt_Pwd);
		btn_login = (Button) findViewById(R.id.btn_login);
		lay_more_pop = (LinearLayout) findViewById(R.id.lay_more_pop);
		btn_more_pop = (Button) findViewById(R.id.btn_more_pop);
		chk_remember = (CheckBox) findViewById(R.id.chk_remember);
		btn_login.setOnClickListener(this);
		btn_more_pop.setOnClickListener(this);
		lay_more_pop.setOnClickListener(this);
		RelativeLayout lay= (RelativeLayout) findViewById(R.id.Layout);
		lay.setOnClickListener(this);
		
		image_setting = (ImageView) findViewById(R.id.image_setting);
		image_exit = (ImageView) findViewById(R.id.image_exit);
		image_setting.setOnClickListener(this);
		image_exit.setOnClickListener(this);
		
		
		if(Service_Address == null){
			
			Intent intent = new Intent(LoginActivity.this,Setting.class);
			this.startActivity(intent);
			overridePendingTransition(R.drawable.fade, R.drawable.hold);
		}
	}


	private EditText mUserName;
	private EditText mPassword;
	private Button btn_login;
	private CheckBox chk_remember;
	private LinearLayout lay_more_pop;
	private Button btn_more_pop;
	private PopupWindow popView;
	private MyAdapter dropDownAdapter;
	private DBHelper dbHelper;
	
	private ImageView image_setting;
	private ImageView image_exit;

	@Override
	protected void findViewById() {
		// TODO 自动生成的方法存根

	}

	@Override
	protected void initialize() {
		// TODO 自动生成的方法存根

	}

	@Override
	protected void updateList() {
		// TODO 自动生成的方法存根

	}
	

	public  static String login_API = Service_Address + "loginuser/login";

	@Override
	public void onClick(View v) {

		switch (v.getId()) {

		case R.id.btn_login:// 登陆
			if ("".equals(mUserName.getText().toString().trim())) {
				String str1 = "请输入用户名/邮箱/手机号!";
				Toast.makeText(LoginActivity.this, str1, Toast.LENGTH_LONG)
						.show();
				return;

			} else if ("".equals(mPassword.getText().toString().trim())) {
				String str1 = "请输入密码!";
				Toast.makeText(LoginActivity.this, str1, Toast.LENGTH_LONG)
						.show();
				return;
			} else if (mUserName.getText().toString().indexOf(" ") >= 0
					|| (mPassword.getText().toString().indexOf(" ") >= 0)) {
				String str1 = "用户名或密码错误!";
				Toast.makeText(LoginActivity.this, str1, Toast.LENGTH_LONG)
						.show();
				return;
			}

			String userName = mUserName.getText().toString();
			String password = mPassword.getText().toString();
			if (chk_remember.isChecked()) {
				dbHelper.insertOrUpdate(userName, password, 1);
			} else {
				dbHelper.insertOrUpdate(userName, "", 0);
			}

			try {
				JSONHttpClient jsonHttpClient = new JSONHttpClient();

				List<NameValuePair> nameValuePairs = new ArrayList<NameValuePair>();
				nameValuePairs
						.add(new BasicNameValuePair("username", userName));
				nameValuePairs
						.add(new BasicNameValuePair("password", password));
				LoginUser user = jsonHttpClient.Get(login_API, nameValuePairs,
						LoginUser.class);
				//Store login user info in base activity
				setLoginUser(user);
				
				Intent intent = new Intent(LoginActivity.this,
						WorkSpaceMainActivity.class);
				Bundle bundle = new Bundle();
				bundle.putString("userid", String.valueOf(user.getF_UserID()));
				bundle.putString("roleid", String.valueOf(user.getF_RoleID()));
				intent.putExtras(bundle);
				startActivity(intent);
				overridePendingTransition(R.drawable.fade, R.drawable.hold);
			} catch (Exception ex) {

				Toast.makeText(this, "登陆失败,请重试!", Toast.LENGTH_LONG).show();

			} finally {

			}

			break;
		case R.id.btn_more_pop: // 录过账号
		case R.id.lay_more_pop: // 录过账号

			String[] names = dbHelper.queryAllUserName();
			if (names.length > 0) {
				initPopView(names);
				if (!popView.isShowing()) {
					popView.showAsDropDown(mUserName, 1, 1);
				} else {
					popView.dismiss();
				}
			} else {
				Toast.makeText(this, "无记录", Toast.LENGTH_LONG).show();
			}

			break;
		case R.id.image_setting: // 录过账号
			Intent intent = new Intent(LoginActivity.this,Setting.class);
			this.startActivity(intent);
			overridePendingTransition(R.drawable.fade, R.drawable.hold);
			break;
		case R.id.image_exit: // 录过账号
			finish();
			System.exit(0);
			break;
		default:
		
			break;

		}
	}

	public static final int MENU_HELP = 1;
	public static final int MENU_SET = 2;
	public static final int MENU_EXIT = 3;

	@Override
	public boolean onCreateOptionsMenu(Menu menu) {// 创建系统功能菜单
		// TODO Auto-generated method stub
		menu.add(Menu.NONE, MENU_HELP, 1, "帮助").setIcon(R.drawable.menu_findkey);
		menu.add(Menu.NONE, MENU_SET, 2, "设置").setIcon(R.drawable.menu_setting);
		menu.add(Menu.NONE, MENU_EXIT, 3, "退出").setIcon(android.R.drawable.btn_plus);
		return super.onCreateOptionsMenu(menu);
	}

	@Override
	public boolean onOptionsItemSelected(MenuItem item) {
		// TODO Auto-generated method stub
		switch (item.getItemId()) {
		case MENU_HELP:
			// Intent intent1 = new Intent(this,Help.class);
			// this.startActivity(intent1);
			// overridePendingTransition(R.drawable.fade, R.drawable.hold);
			break;
		case MENU_SET:
			// Intent intent = new Intent(this,Setting.class);
			// this.startActivity(intent);
			// overridePendingTransition(R.drawable.fade, R.drawable.hold);
			break;
		case MENU_EXIT:
			finish();
			break;
		}
		return super.onOptionsItemSelected(item);
	}

	private long exitTime = 0;

	@Override
	public boolean onKeyDown(int keyCode, KeyEvent event) {
		if (keyCode == KeyEvent.KEYCODE_BACK
				&& event.getAction() == KeyEvent.ACTION_DOWN) {
			if ((System.currentTimeMillis() - exitTime) > 2000) {
				Toast.makeText(getApplicationContext(), "再按一次退出程序",
						Toast.LENGTH_SHORT).show();
				exitTime = System.currentTimeMillis();
			} else {
				finish();
				System.exit(0);
			}
			return true;

		} else if (keyCode == KeyEvent.KEYCODE_MENU) {

			// do something
		} else if (keyCode == KeyEvent.KEYCODE_HOME) {

			// 这里操作是没有返回结果的
		}

		return super.onKeyDown(keyCode, event);
	}

	private void initPopView(String[] usernames) {
		List<HashMap<String, Object>> list = new ArrayList<HashMap<String, Object>>();
		for (int i = 0; i < usernames.length; i++) {
			HashMap<String, Object> map = new HashMap<String, Object>();
			map.put("name", usernames[i]);
			map.put("drawable", R.drawable.xicon);
			list.add(map);
		}
		dropDownAdapter = new MyAdapter(this, list, R.layout.dropdown_item,
				new String[] { "name", "drawable" }, new int[] { R.id.textview,
						R.id.delete });
		ListView listView = new ListView(this);
		listView.setAdapter(dropDownAdapter);
		listView.setDivider(getResources().getDrawable(R.drawable.gray));
		listView.setDividerHeight(1);

		popView = new PopupWindow(listView, mPassword.getWidth() - 2,
				ViewGroup.LayoutParams.WRAP_CONTENT, true);
		popView.setFocusable(true);
		popView.setOutsideTouchable(true);
		Drawable d = getResources().getDrawable(android.R.color.white);
		popView.setBackgroundDrawable(d);

	}

	class MyAdapter extends SimpleAdapter {

		private List<HashMap<String, Object>> data;

		public MyAdapter(Context context, List<HashMap<String, Object>> data,
				int resource, String[] from, int[] to) {
			super(context, data, resource, from, to);
			this.data = data;
		}

		@Override
		public int getCount() {
			return data.size();
		}

		@Override
		public Object getItem(int position) {
			return position;
		}

		@Override
		public long getItemId(int position) {
			return position;
		}

		@Override
		public View getView(final int position, View convertView,
				ViewGroup parent) {

			ViewHolder holder;
			if (convertView == null) {
				holder = new ViewHolder();
				convertView = LayoutInflater.from(LoginActivity.this).inflate(
						R.layout.dropdown_item, null);
				holder.btn = (ImageButton) convertView
						.findViewById(R.id.delete);
				holder.tv = (TextView) convertView.findViewById(R.id.textview);
				convertView.setTag(holder);
			} else {
				holder = (ViewHolder) convertView.getTag();
			}
			holder.tv.setText(data.get(position).get("name").toString());
			holder.tv.setOnClickListener(new View.OnClickListener() {

				@Override
				public void onClick(View v) {
					String[] usernames = dbHelper.queryAllUserName();
					mUserName.setText(usernames[position]);
					mPassword.setText(dbHelper
							.queryPasswordByName(usernames[position]));
					popView.dismiss();
				}
			});
			holder.btn.setOnClickListener(new View.OnClickListener() {

				@Override
				public void onClick(View v) {
					String[] usernames = dbHelper.queryAllUserName();
					if (usernames.length > 0) {
						dbHelper.delete(usernames[position]);
					}
					String[] newusernames = dbHelper.queryAllUserName();
					if (newusernames.length > 0) {
						popView.dismiss();
						initPopView(newusernames);
						popView.showAsDropDown(mUserName, 1, 1);
					} else {
						if (popView != null) {
							popView.dismiss();
							popView = null;
						}
					}
				}
			});
			return convertView;
		}
	}

	class ViewHolder {
		private TextView tv;
		private ImageButton btn;
	}

}
