package com.yy.android.vo;

public class User {
	private int Id;
	private String UserName;
	private String DepartmentName;
	private boolean Checked = true;

	public boolean isChecked() {
		return Checked;
	}

	public void setChecked(boolean checked) {
		Checked = checked;
	}

	public int getId() {
		return Id;
	}

	public void setId(int id) {
		Id = id;
	}

	public String getUserName() {
		return UserName;
	}

	public void setUserName(String userName) {
		UserName = userName;
	}

	public String getDepartmentName() {
		return DepartmentName;
	}

	public void setDepartmentName(String department) {
		DepartmentName = department;
	}
	
    public static final String User_ID = "Id";
    public static final String User_NAME = "UserName";
    public static final String User_DEPART = "Department";
}
