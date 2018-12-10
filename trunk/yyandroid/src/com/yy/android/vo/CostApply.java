package com.yy.android.vo;

import java.io.Serializable;
import java.util.Date;

public class CostApply implements Serializable {
	private static final long serialVersionUID = 1L;
	private int F_ID;
	private String F_ApplyTitle;
	private int F_ProjectID;
	private int F_ApplyType;
	private float F_ApplyAmount;
	private Date F_ApplyDate;
	private int F_OperatorID;
	private Date F_OperateTime;
	private boolean F_IsDelete;
	private String F_ApplyDescription;
	private int F_WF_StateID;
	private String CostIDs;
	private String ProjectName;
	private String Operator;
	private String ApplyState;
	public String FromState;
	public String ToState;

	public int getF_WF_StateID() {
		return F_WF_StateID;
	}

	public void setF_WF_StateID(int f_WF_StateID) {
		F_WF_StateID = f_WF_StateID;
	}

	public String getFromState() {
		return FromState;
	}

	public void setFromState(String fromState) {
		FromState = fromState;
	}

	public String getToState() {
		return ToState;
	}

	public void setToState(String toState) {
		ToState = toState;
	}

	public String getApplyState() {
		return ApplyState;
	}

	public void setApplyState(String applyState) {
		ApplyState = applyState;
	}

	public String getProjectName() {
		return ProjectName;
	}

	public void setProjectName(String projectName) {
		ProjectName = projectName;
	}

	public String getOperator() {
		return Operator;
	}

	public void setOperator(String operator) {
		Operator = operator;
	}

	public String getCostIDs() {
		return CostIDs;
	}

	public void setCostIDs(String costIDs) {
		CostIDs = costIDs;
	}

	public int getF_ID() {
		return F_ID;
	}

	public void setF_ID(int in_F_ID) {
		F_ID = in_F_ID;
	}

	public String getF_ApplyTitle() {
		return F_ApplyTitle;
	}

	public void setF_ApplyTitle(String in_F_ApplyTitle) {
		F_ApplyTitle = in_F_ApplyTitle;
	}

	public int getF_ProjectID() {
		return F_ProjectID;
	}

	public void setF_ProjectID(int in_F_ProjectID) {
		F_ProjectID = in_F_ProjectID;
	}

	public int getF_ApplyType() {
		return F_ApplyType;
	}

	public void setF_ApplyType(int in_F_ApplyType) {
		F_ApplyType = in_F_ApplyType;
	}

	public float getF_ApplyAmount() {
		return F_ApplyAmount;
	}

	public void setF_ApplyAmount(float in_F_ApplyAmount) {
		F_ApplyAmount = in_F_ApplyAmount;
	}

	public Date getF_ApplyDate() {
		return F_ApplyDate;
	}

	public void setF_ApplyDate(Date in_F_ApplyDate) {
		F_ApplyDate = in_F_ApplyDate;
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

	public String getF_ApplyDescription() {
		return F_ApplyDescription;
	}

	public void setF_ApplyDescription(String in_F_ApplyDescription) {
		F_ApplyDescription = in_F_ApplyDescription;
	}

}
