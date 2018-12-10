package com.yy.android.vo;

import java.io.Serializable;
import java.util.Date;

public class ExpatriateAttendance implements Serializable {
	/**
	 * 
	 */
	private static final long serialVersionUID = 1L;
	private int F_ID;
	private int F_ProjectID;
	private Date F_AttendanceDate;
	private int F_GongTou;
	private int F_Worker;
	private int F_PaGong;
	private String F_Comments;
	private String ProjectName;
	private int F_OperatorID;
	private boolean F_IsDelete;
	private Date F_OperateTime = new Date();

	public boolean isF_IsDelete() {
		return F_IsDelete;
	}

	public void setF_IsDelete(boolean f_IsDelete) {
		F_IsDelete = f_IsDelete;
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

	public Date getF_AttendanceDate() {
		return F_AttendanceDate;
	}

	public void setF_AttendanceDate(Date in_F_AttendanceDate) {
		F_AttendanceDate = in_F_AttendanceDate;
	}

	public int getF_GongTou() {
		return F_GongTou;
	}

	public void setF_GongTou(int in_F_GongTou) {
		F_GongTou = in_F_GongTou;
	}

	public int getF_Worker() {
		return F_Worker;
	}

	public void setF_Worker(int in_F_Worker) {
		F_Worker = in_F_Worker;
	}

	public int getF_PaGong() {
		return F_PaGong;
	}

	public void setF_PaGong(int in_F_PaGong) {
		F_PaGong = in_F_PaGong;
	}

	public String getF_Comments() {
		return F_Comments;
	}

	public void setF_Comments(String in_F_Comments) {
		F_Comments = in_F_Comments;
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
