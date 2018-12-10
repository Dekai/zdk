package com.yy.android.adapter;

import java.util.ArrayList;
import java.util.List;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.CheckBox;
import android.widget.ImageView;
import android.widget.RelativeLayout;
import android.widget.TextView;

import com.yy.android.R;
import com.yy.android.activity.StaffAttendanceActivity;
import com.yy.android.vo.Employee;
import com.yy.android.vo.User;

public class StaffAttendanceAdapter extends BaseAdapter {

	public List<Employee> mlistAppInfo;
	LayoutInflater infater = null;
	public static List<Integer> clearIds;
	public boolean isNew;

	public StaffAttendanceAdapter(Context context, List<Employee> apps, boolean isNew) {
		infater = LayoutInflater.from(context);
		clearIds = new ArrayList<Integer>();
		this.mlistAppInfo = apps;
		this.isNew = isNew;
	}

	@Override
	public int getCount() {
		// TODO Auto-generated method stub
		return mlistAppInfo.size();
	}

	@Override
	public Object getItem(int position) {
		// TODO Auto-generated method stub
		return mlistAppInfo.get(position);
	}

	@Override
	public long getItemId(int position) {
		// TODO Auto-generated method stub
		return position;
	}

	@Override
	public View getView(int position, View convertView, ViewGroup parent) {
		ViewHolder holder = null;
		if (convertView == null) {
			convertView = infater.inflate(R.layout.staff_attendance_listview_item, null);
			holder = new ViewHolder();
			holder.tvUserName = (TextView) convertView.findViewById(R.id.user_name);
			holder.tvUserMobile = (TextView) convertView.findViewById(R.id.user_mobile);
			holder.cb = (CheckBox) convertView.findViewById(R.id.staff_attendance_cb);
			convertView.setTag(holder);
		} else {
			holder = (ViewHolder) convertView.getTag();
		}
		final Employee empInfo = (Employee) getItem(position);
		holder.tvUserName.setText(empInfo.getF_Name());
		holder.tvUserMobile.setText(empInfo.getF_Mobile());
		if (isNew) {
			// default set true for user
			holder.cb.setChecked(true);
			holder.cb.setClickable(true);
		} else {
			holder.cb.setChecked(empInfo.isF_IsAttendance());
			holder.cb.setClickable(false);
		}
		return convertView;
	}

	class ViewHolder {
		TextView tvUserName;
		TextView tvUserMobile;
		RelativeLayout cb_rl;
		CheckBox cb;

		public CheckBox getCb() {
			return cb;
		}

		public void setCb(CheckBox cb) {
			this.cb = cb;
		}
	}

}
