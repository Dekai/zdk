package com.yy.android.vo;

import java.util.Date;

public class Cost {
	private String Project;
	private String CostType;
	private float CostAmount;
	private boolean Checked = true;

	public boolean isChecked() {
		return Checked;
	}

	public void setChecked(boolean checked) {
		Checked = checked;
	}

	public String getProject() {
		return Project;
	}

	public void setProject(String project) {
		Project = project;
	}

	public String getCostType() {
		return CostType;
	}

	public void setCostType(String costType) {
		CostType = costType;
	}

	public float getCostAmount() {
		return CostAmount;
	}

	public void setCostAmount(float costAmount) {
		CostAmount = costAmount;
	}

	public Date getCostDate() {
		return CostDate;
	}

	public void setCostDate(Date costDate) {
		CostDate = costDate;
	}

	private Date CostDate;
}
