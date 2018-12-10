package com.yy.android.vo;

public class Employee {
	private int F_ID;
	private String F_Name;
	private String F_Mobile;
	private int F_IsDelete;
	private String Absent_Comments;
	private boolean F_IsAttendence;
	
	public boolean isF_IsAttendance() {
		return F_IsAttendence;
	}

	public void setF_IsAttendance(boolean f_IsAttendence) {
		F_IsAttendence = f_IsAttendence;
	}

	public String getAbsent_Comments() {
		return Absent_Comments;
	}

	public void setAbsent_Comments(String absent_Comments) {
		Absent_Comments = absent_Comments;
	}

	private boolean Checked = true;

	public boolean isChecked() {
		return Checked;
	}

	public void setChecked(boolean checked) {
		Checked = checked;
	}

	public int getF_ID() {
		return F_ID;
	}

	public void setF_ID(int in_F_ID) {
		F_ID = in_F_ID;
	}

	public String getF_Name() {
		return F_Name;
	}

	public void setF_Name(String in_F_Name) {
		F_Name = in_F_Name;
	}

	public String getF_Mobile() {
		return F_Mobile;
	}

	public void setF_Mobile(String in_F_Mobile) {
		F_Mobile = in_F_Mobile;
	}

	public int getF_IsDelete() {
		return F_IsDelete;
	}

	public void setF_IsDelete(int in_F_IsDelete) {
		F_IsDelete = in_F_IsDelete;
	}

}
