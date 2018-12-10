package com.yy.android.database;

import android.provider.BaseColumns;

/**
 * Download by http://www.codefans.net
 * 2012-8-12
 */
public final class DBUser {

	public static final class User implements BaseColumns {
		public static final String USERNAME = "ems_user";
		public static final String PASSWORD = "ems_pwd";
		public static final String ISSAVED = "issaved";
	}

}
