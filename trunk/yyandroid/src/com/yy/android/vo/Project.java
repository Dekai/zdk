package com.yy.android.vo;

import java.io.Serializable;
import java.util.Date;

public class Project implements Serializable{
	private static final long serialVersionUID = 1L;
	private int F_ID;
	private String F_Name;
	private Date F_StartDate;
	private Date F_EndDate;
	private String F_Description;
	private boolean F_IsDelete;
	private int F_OperatorID;
	private Date F_OperateTime = new Date();

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

	public Date getF_StartDate() {
		return F_StartDate;
	}

	public void setF_StartDate(Date in_F_StartDate) {
		F_StartDate = in_F_StartDate;
	}

	public Date getF_EndDate() {
		return F_EndDate;
	}

	public void setF_EndDate(Date in_F_EndDate) {
		F_EndDate = in_F_EndDate;
	}

	public String getF_Description() {
		return F_Description;
	}

	public void setF_Description(String in_F_Description) {
		F_Description = in_F_Description;
	}

	public boolean isF_IsDelete() {
		return F_IsDelete;
	}

	public void setF_IsDelete(boolean in_F_IsDelete) {
		F_IsDelete = in_F_IsDelete;
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
