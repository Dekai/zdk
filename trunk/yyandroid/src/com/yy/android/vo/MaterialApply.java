package com.yy.android.vo;

import java.io.Serializable;
import java.util.Date;

public class MaterialApply implements Serializable {
	private static final long serialVersionUID = 1L;
	private int F_ID;
	private int F_ProjectID;
	private String F_Materials;
	private int F_ApplyCount;
	private String F_Description;
	private boolean F_IsDelete;
	private int F_OperatorID;
	private Date F_OperateTime = new Date();
	private Date F_ApplyDate;
	private String ProjectName;
	private String Operator;

	public String getOperator() {
		return Operator;
	}

	public void setOperator(String operator) {
		Operator = operator;
	}

	public Date getF_ApplyDate() {
		return F_ApplyDate;
	}

	public void setF_ApplyDate(Date f_ApplyDate) {
		F_ApplyDate = f_ApplyDate;
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

	public String getF_Materials() {
		return F_Materials;
	}

	public void setF_Materials(String in_F_Materials) {
		F_Materials = in_F_Materials;
	}

	public int getF_ApplyCount() {
		return F_ApplyCount;
	}

	public void setF_ApplyCount(int in_F_ApplyCount) {
		F_ApplyCount = in_F_ApplyCount;
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