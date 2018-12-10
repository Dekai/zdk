package com.yy.android.vo;

import java.util.List;

public class UserRole {
	public int RoleId;
	public String RoleName;
	public List<Right> Rights;
	public List<WorkFlow> WorkFlows;

	public List<WorkFlow> getWorkFlows() {
		return WorkFlows;
	}

	public void setWorkFlows(List<WorkFlow> workFlows) {
		WorkFlows = workFlows;
	}

	public int getRoleId() {
		return RoleId;
	}

	public void setRoleId(int roleId) {
		RoleId = roleId;
	}

	public String getRoleName() {
		return RoleName;
	}

	public void setRoleName(String roleName) {
		RoleName = roleName;
	}

	public List<Right> getRights() {
		return Rights;
	}

	public void setRights(List<Right> rights) {
		Rights = rights;
	}
}
