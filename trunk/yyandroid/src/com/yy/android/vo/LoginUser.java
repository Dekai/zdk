package com.yy.android.vo;

import java.io.Serializable;

public class LoginUser implements Serializable{

	private UserRole UserRole;
	public UserRole getUserRole() {
		return UserRole;
	}

	public void setUserRole(UserRole userRole) {
		UserRole = userRole;
	}

	private int F_ID;
	public int getF_ID() {
		return F_ID;
	}

	public void setF_ID(int in_F_ID) {
		F_ID = in_F_ID;
	}
	
	private String F_LoginName;
	public String getF_LoginName() {
		return F_LoginName;
	}

	public void setF_LoginName(String in_F_LoginName) {
		F_LoginName = in_F_LoginName;
	}
	
	private int F_UserID;
	public int getF_UserID() {
		return F_UserID;
	}

	public void setF_UserID(int in_F_UserID) {
		F_UserID = in_F_UserID;
	}
	
	private int F_RoleID;
	public int getF_RoleID() {
		return F_RoleID;
	}

	public void setF_RoleID(int in_F_RoleID) {
		F_RoleID = in_F_RoleID;
	}
	
	private int F_IsActive;
	public int getF_IsActive() {
		return F_IsActive;
	}

	public void setF_IsActive(int in_F_IsActive) {
		F_IsActive = in_F_IsActive;
	}
	
}
