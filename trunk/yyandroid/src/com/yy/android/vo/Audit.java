package com.yy.android.vo;

import java.io.Serializable;
import java.util.Date;

public class Audit implements Serializable {
	private static final long serialVersionUID = 8446360717274878127L;
	private int F_ID;
	private String F_Name;
	private String F_Content;
	private float F_Money;
	private Date F_Time = new Date();
	private String F_WF_StateID;
	private int F_UserID;
	private boolean F_IsDelete;
	private Date F_Date;
	private String Operator;
	private int F_Type;

	public int getF_Type() {
		return F_Type;
	}

	public void setF_Type(int f_Type) {
		F_Type = f_Type;
	}

	public String getOperator() {
		return Operator;
	}

	public void setOperator(String operator) {
		Operator = operator;
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

	public String getF_Content() {
		return F_Content;
	}

	public void setF_Content(String in_F_Content) {
		F_Content = in_F_Content;
	}

	public float getF_Money() {
		return F_Money;
	}

	public void setF_Money(float in_F_Money) {
		F_Money = in_F_Money;
	}

	public Date getF_Time() {
		return F_Time;
	}

	public void setF_Time(Date in_F_Time) {
		F_Time = in_F_Time;
	}

	public String getF_WF_StateID() {
		return F_WF_StateID;
	}

	public void setF_WF_StateID(String in_F_WF_StateID) {
		F_WF_StateID = in_F_WF_StateID;
	}

	public int getF_UserID() {
		return F_UserID;
	}

	public void setF_UserID(int in_F_UserID) {
		F_UserID = in_F_UserID;
	}

	public boolean isF_IsDelete() {
		return F_IsDelete;
	}

	public void setF_IsDelete(boolean in_F_IsDelete) {
		F_IsDelete = in_F_IsDelete;
	}

	public Date getF_Date() {
		return F_Date;
	}

	public void setF_Date(Date in_F_Date) {
		F_Date = in_F_Date;
	}

}