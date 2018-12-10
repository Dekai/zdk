package com.yy.android.vo;

import java.util.Date;

public class EmployeeAttendance {
        private int F_ID;
        private int F_ProjectID;
        private int F_EmployeeID;
        private boolean F_IsAttendence;
        private Date F_AttendanceDate;
        private String F_AbenceComment;
        private int F_OperatorID;
        private Date F_OperateTime;

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

        public int getF_EmployeeID() {
              return F_EmployeeID;
        }

        public void setF_EmployeeID(int in_F_EmployeeID) {
              F_EmployeeID = in_F_EmployeeID;
        }

        public boolean isF_IsAttendence() {
              return F_IsAttendence;
        }

        public void setF_IsAttendence(boolean in_F_IsAttendence) {
              F_IsAttendence = in_F_IsAttendence;
        }

        public Date getF_AttendanceDate() {
              return F_AttendanceDate;
        }

        public void setF_AttendanceDate(Date in_F_AttendanceDate) {
              F_AttendanceDate = in_F_AttendanceDate;
        }

        public String getF_AbenceComment() {
              return F_AbenceComment;
        }

        public void setF_AbenceComment(String in_F_AbenceComment) {
              F_AbenceComment = in_F_AbenceComment;
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
