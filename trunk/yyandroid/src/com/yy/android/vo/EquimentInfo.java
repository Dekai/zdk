package com.yy.android.vo;

import java.io.Serializable;
import java.util.Date;

public class EquimentInfo implements Serializable{
	private static final long serialVersionUID = 1L;
	private int F_ID;
	private String F_Name;
	private String F_Desc;

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

	

	public String getF_Desc() {
		return F_Desc;
	}

	public void setF_Desc(String in_F_Desc) {
		F_Desc= in_F_Desc;
	}

}
