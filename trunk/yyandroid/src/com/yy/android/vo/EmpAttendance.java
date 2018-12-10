package com.yy.android.vo;

import java.util.List;

public class EmpAttendance {
	private boolean isNew; 
	private String AttendanceNum;
	private String AbsenceNum;
	private List<Employee> empList;
	
	public boolean isNew() {
		return isNew;
	}
	public void setNew(boolean isNew) {
		this.isNew = isNew;
	}
	public String getAttendanceNum() {
		return AttendanceNum;
	}
	public void setAttendanceNum(String attendanceNum) {
		AttendanceNum = attendanceNum;
	}
	public String getAbsenceNum() {
		return AbsenceNum;
	}
	public void setAbsenceNum(String absenceNum) {
		AbsenceNum = absenceNum;
	}
	public List<Employee> getEmpList() {
		return empList;
	}
	public void setEmpList(List<Employee> empList) {
		this.empList = empList;
	}

}
