package com.yy.android.util;

import java.util.regex.Matcher;
import java.util.regex.Pattern;

import com.yy.android.activity.LoginActivity;
import com.yy.android.activity.MyBaseActivity;

public class ClassPathResource {

	private static String _url = null;
	public static String get_url() {
		if (_url != null) {
			String url = "http://" + _url + "/";
			return url;
		} else {
			return _url;
		}
	}
	public static void set_url(String url) {
		
		_url = url;
		MyBaseActivity.Service_Address = get_url();
		LoginActivity.login_API =  get_url()+ "loginuser/login";
	}
	
	
	private static String _Email = null;
	public static String get_Email() {
			return _Email;
	}
	public static void set_Email(String Email) {

		_Email = Email;
	}

	/**
	 * 
	 * @param mobiles
	 * @return
	 */
	public static boolean isMobileNO(String mobiles) {
		Pattern p = Pattern
				.compile("^((13[0-9])|(15[^4,\\D])|(18[0,5-9]))\\d{8}$");
		Matcher m = p.matcher(mobiles);
		return m.matches();
	}

	/**
	 * 
	 * @param email
	 * @return
	 */
	public static boolean isEmail(String email) {
		String str = "^([a-zA-Z0-9]*[-_]?[a-zA-Z0-9]+)*@([a-zA-Z0-9]*[-_]?[a-zA-Z0-9]+)+[\\.][A-Za-z]{2,3}([\\.][A-Za-z]{2})?$";
		Pattern p = Pattern.compile(str);
		Matcher m = p.matcher(email);
		return m.matches();
	}
	
	public static String getString(String text ,int length){
		
		if(text == null || "".equals(text)) return "";
		
		if(text.length() > length){
			
			return text.substring(0, length)+"...";
		}
		return text;
		
	}
	

}
