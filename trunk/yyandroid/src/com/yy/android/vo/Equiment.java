package com.yy.android.vo;

import java.io.Serializable;
import java.util.Date;

public class Equiment implements Serializable {
	private static final long serialVersionUID = 1L;
	private int F_ID;
	private int F_ProjectID;
	private boolean F_IsHired;
	private boolean F_IsDelete;
	private int F_EquimentID;
	private String F_EquimentName;
	private int F_EquimentCount;
	private Date F_AttendanceDate;
	private int F_OperatorID;
	private Date F_OperateTime = new Date();;
	private String ProjectName;
	private String Name;
	private String F_Description;

	public boolean isF_IsDelete() {
		return F_IsDelete;
	}

	public void setF_IsDelete(boolean f_IsDelete) {
		F_IsDelete = f_IsDelete;
	}

	public String getName() {
		return Name;
	}

	public void setName(String name) {
		Name = name;
	}

	public String getF_Description() {
		return F_Description;
	}

	public void setF_Description(String f_Description) {
		F_Description = f_Description;
	}

	public String getProjectName() {
		return ProjectName;
	}

	public void setProjectName(String projectName) {
		ProjectName = projectName;
	}

	public int getF_ID() {
		return F_ID;
	}

	public void setF_ID(int in_F_ID) {
		F_ID = in_F_ID;
	}

	public int getF_ProjectID() {
		return F_ProjectID;
	}

	public void setF_ProjectID(int in_F_ProjectID) {
		F_ProjectID = in_F_ProjectID;
	}

	public boolean isF_IsHired() {
		return F_IsHired;
	}

	public void setF_IsHired(boolean in_F_IsHired) {
		F_IsHired = in_F_IsHired;
	}

	public int getF_EquimentID() {
		return F_EquimentID;
	}

	public void setF_EquimentID(int in_F_EquimentID) {
		F_EquimentID = in_F_EquimentID;
	}

	public String getF_EquimentName() {
		return F_EquimentName;
	}

	public void setF_EquimentName(String in_F_EquimentName) {
		F_EquimentName = in_F_EquimentName;
	}

	public int getF_EquimentCount() {
		return F_EquimentCount;
	}

	public void setF_EquimentCount(int in_F_EquimentCount) {
		F_EquimentCount = in_F_EquimentCount;
	}

	public Date getF_AttendanceDate() {
		return F_AttendanceDate;
	}

	public void setF_AttendanceDate(Date in_F_AttendanceDate) {
		F_AttendanceDate = in_F_AttendanceDate;
	}

	public int getF_OperatorID() {
		return F_OperatorID;
	}

	public void setF_OperatorID(int in_F_OperatorID) {
		F_OperatorID = in_F_OperatorID;
	}

	public Date getF_OperateTime() {
		return F_OperateTime;
	}

	public void setF_OperateTime(Date in_F_OperateTime) {
		F_OperateTime = in_F_OperateTime;
	}

}
