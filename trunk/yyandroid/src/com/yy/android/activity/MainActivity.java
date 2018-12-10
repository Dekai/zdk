package com.yy.android.activity;

import android.app.Activity;
import android.content.Context;
import android.content.Intent;
import android.content.SharedPreferences;
import android.os.Bundle;

import com.yy.android.R;
import com.yy.android.util.ClassPathResource;

public class MainActivity extends Activity {

	/** Called when the activity is first created. */
	@Override
	public void onCreate(Bundle savedInstanceState) {
		// requestWindowFeature(Window.FEATURE_NO_TITLE);
		super.onCreate(savedInstanceState);
		setContentView(R.layout.wellcome);

		final Intent intent = new Intent(MainActivity.this, LoginActivity.class);
		intent.setFlags(Intent.FLAG_ACTIVITY_NEW_TASK);

		String url = ClassPathResource.get_url();
		if (url == null) {
			SharedPreferences user = getSharedPreferences("user_info", Context.MODE_WORLD_READABLE);
			String strurl = user.getString("url", "");
			if (strurl != null) {
				ClassPathResource.set_url(strurl.trim());
			}
		}

		new Thread(new Runnable() {

			@Override
			public void run() {
				// TODO Auto-generated method stub
				try {
					Thread.sleep(1000);
					getApplicationContext().startActivity(intent);
					overridePendingTransition(R.drawable.fade, R.drawable.hold);
					finish();
					// System.exit(0);
				} catch (InterruptedException e) {
					// TODO Auto-generated catch block
					e.printStackTrace();
				}

			}
		}).start();
	}

}
