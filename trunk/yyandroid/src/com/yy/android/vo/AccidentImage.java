package com.yy.android.vo;

import java.io.Serializable;
import java.util.Date;

public class AccidentImage implements Serializable {
	private static final long serialVersionUID = 1L;
	private int F_ID;
	private int F_AccidentID;
	private String F_ImagePath;
	private Date F_OperateTime = new Date();

	public int getF_ID() {
		return F_ID;
	}

	public void setF_ID(int in_F_ID) {
		F_ID = in_F_ID;
	}

	public int getF_AccidentID() {
		return F_AccidentID;
	}

	public void setF_AccidentID(int in_F_AccidentID) {
		F_AccidentID = in_F_AccidentID;
	}

	
	public String getF_ImagePath() {
		return F_ImagePath;
	}

	public void setF_ImagePath(String in_F_ImagePath) {
		F_ImagePath = in_F_ImagePath;
	}

	public Date getF_OperateTime() {
		return F_OperateTime;
	}

	public void setF_OperateTime(Date in_F_OperateTime) {
		F_OperateTime = in_F_OperateTime;
	}
}
