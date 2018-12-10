package com.yy.android.vo;

import java.io.Serializable;
import java.util.Date;

public class ProjectCost implements Serializable {
	/**
	 * 
	 */
	private static final long serialVersionUID = 1L;
	private int F_ID;
	private int F_ProjectID;
	private String ProjectName;
	private int F_CostType;
	private float F_CostAmount;
	private String F_OtherCost;
	private Date F_CostDate;
	private int F_OperatorID;
	private Date F_OperateTime = new Date();
	private boolean F_IsDelete;
	private boolean isChecked;
	private boolean F_IsProjectCost;
	private String CostTypeName;
	private String F_CostDescription;
	private int F_ApplyID;

	public boolean isF_IsProjectCost() {
		return F_IsProjectCost;
	}

	public void setF_IsProjectCost(boolean f_IsProjectCost) {
		F_IsProjectCost = f_IsProjectCost;
	}

	public int getF_ApplyID() {
		return F_ApplyID;
	}

	public void setF_ApplyID(int f_ApplyID) {
		F_ApplyID = f_ApplyID;
	}

	public String getF_CostDescription() {
		return F_CostDescription;
	}

	public void setF_CostDescription(String f_CostDescription) {
		F_CostDescription = f_CostDescription;
	}

	public String getCostTypeName() {
		return CostTypeName;
	}

	public void setCostTypeName(String costTypeName) {
		CostTypeName = costTypeName;
	}

	public String getProjectName() {
		return ProjectName;
	}

	public void setProjectName(String projectName) {
		ProjectName = projectName;
	}

	public boolean isChecked() {
		return isChecked;
	}

	public void setChecked(boolean isChecked) {
		this.isChecked = isChecked;
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

	public int getF_CostType() {
		return F_CostType;
	}

	public void setF_CostType(int in_F_CostType) {
		F_CostType = in_F_CostType;
	}

	public float getF_CostAmount() {
		return F_CostAmount;
	}

	public void setF_CostAmount(float in_F_CostAmount) {
		F_CostAmount = in_F_CostAmount;
	}

	public String getF_OtherCost() {
		return F_OtherCost;
	}

	public void setF_OtherCost(String in_F_OtherCost) {
		F_OtherCost = in_F_OtherCost;
	}

	public Date getF_CostDate() {
		return F_CostDate;
	}

	public void setF_CostDate(Date in_F_CostDate) {
		F_CostDate = in_F_CostDate;
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
