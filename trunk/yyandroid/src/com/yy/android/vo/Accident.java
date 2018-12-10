package com.yy.android.vo;

import java.io.Serializable;
import java.util.Date;

public class Accident implements Serializable {
	private static final long serialVersionUID = 1L;
	private int F_ID;
	private int F_ProjectID;
	private String F_AccidentName;
	private String F_Description;
	private Date F_AccidentDate;
	private int F_OperatorID;
	private Date F_OperateTime = new Date();
	private boolean F_IsDelete;
	private String ProjectName;
	private String Operator;

	public String getOperator() {
		return Operator;
	}

	public void setOperator(String operator) {
		Operator = operator;
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

	public String getF_AccidentName() {
		return F_AccidentName;
	}

	public void setF_AccidentName(String in_F_AccidentName) {
		F_AccidentName = in_F_AccidentName;
	}

	public String getF_Description() {
		return F_Description;
	}

	public void setF_Description(String in_F_Description) {
		F_Description = in_F_Description;
	}

	public Date getF_AccidentDate() {
		return F_AccidentDate;
	}

	public void setF_AccidentDate(Date in_F_AccidentDate) {
		F_AccidentDate = in_F_AccidentDate;
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

	public boolean isF_IsDelete() {
		return F_IsDelete;
	}

	public void setF_IsDelete(boolean in_F_IsDelete) {
		F_IsDelete = in_F_IsDelete;
	}

}
