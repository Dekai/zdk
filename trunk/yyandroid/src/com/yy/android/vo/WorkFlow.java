package com.yy.android.vo;

public class WorkFlow {
	private int F_ID;
	private String F_LinkTask;
	private String F_StateID;
	private String F_StateName;
	private int F_StateType;
	private String F_Next_StateID;
	private String F_Back_StateID;

	public int getF_ID() {
		return F_ID;
	}

	public void setF_ID(int in_F_ID) {
		F_ID = in_F_ID;
	}

	public String getF_LinkTask() {
		return F_LinkTask;
	}

	public void setF_LinkTask(String in_F_LinkTask) {
		F_LinkTask = in_F_LinkTask;
	}

	public String getF_StateID() {
		return F_StateID;
	}

	public void setF_StateID(String in_F_StateID) {
		F_StateID = in_F_StateID;
	}

	public String getF_StateName() {
		return F_StateName;
	}

	public void setF_StateName(String in_F_StateName) {
		F_StateName = in_F_StateName;
	}

	public int getF_StateType() {
		return F_StateType;
	}

	public void setF_StateType(int in_F_StateType) {
		F_StateType = in_F_StateType;
	}

	public String getF_Next_StateID() {
		return F_Next_StateID;
	}

	public void setF_Next_StateID(String in_F_Next_StateID) {
		F_Next_StateID = in_F_Next_StateID;
	}

	public String getF_Back_StateID() {
		return F_Back_StateID;
	}

	public void setF_Back_StateID(String in_F_Back_StateID) {
		F_Back_StateID = in_F_Back_StateID;
	}

}