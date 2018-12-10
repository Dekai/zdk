package com.yy.android.activity;

import android.app.Activity;
import android.content.Context;
import android.content.SharedPreferences;
import android.content.SharedPreferences.Editor;
import android.os.Bundle;
import android.view.View;
import android.view.Window;
import android.widget.Button;
import android.widget.EditText;

import com.yy.android.R;
import com.yy.android.util.ClassPathResource;

/** 注册界面activity */
public class Setting extends Activity implements android.view.View.OnClickListener {

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		// TODO Auto-generated method stub
		super.onCreate(savedInstanceState);
		requestWindowFeature(Window.FEATURE_NO_TITLE);
		setContentView(R.layout.settingdialog);
		initView();
	}

	private void initView() {

		SharedPreferences user = getSharedPreferences("user_info", 0);
		String strurl = user.getString("url", "");
		EditText txt_ip = (EditText) this.findViewById(R.id.txt_ip);
		txt_ip.setText(strurl);
		Button btn_save = (Button) this.findViewById(R.id.btn_save);
		btn_save.setOnClickListener(this);
		Button btn_cancel = (Button) this.findViewById(R.id.btn_cancel);
		btn_cancel.setOnClickListener(this);
	}

	@Override
	public void onClick(View v) {
		switch (v.getId()) {
		case R.id.btn_save:
			EditText txt_ip = (EditText) this.findViewById(R.id.txt_ip);
			String url = txt_ip.getText().toString();
			SharedPreferences sharedPreferences = getSharedPreferences("user_info", Context.MODE_WORLD_READABLE);
			Editor editor = sharedPreferences.edit();
			editor.putString("url", url);
			editor.commit();
			ClassPathResource.set_url(url);

			break;
		case R.id.btn_cancel:

			break;
		}
		finish();

	}

}
