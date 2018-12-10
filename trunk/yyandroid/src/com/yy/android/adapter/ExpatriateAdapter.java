package com.yy.android.adapter;

import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.Date;
import java.util.List;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.TextView;

import com.yy.android.R;
import com.yy.android.vo.ExpatriateAttendance;

public class ExpatriateAdapter extends BaseAdapter {

	public List<ExpatriateAttendance> listInfo;
	LayoutInflater infater = null;
	public static List<Integer> clearIds;
	protected Calendar calendar = Calendar.getInstance();

	protected String format(Date date) {
		String str = "";
		SimpleDateFormat ymd = null;
		ymd = new SimpleDateFormat("yyyy-MM-dd");
		str = ymd.format(date);
		return str;
	}

	public ExpatriateAdapter(Context context,
			List<ExpatriateAttendance> dataList) {
		infater = LayoutInflater.from(context);
		clearIds = new ArrayList<Integer>();
		this.listInfo = dataList;
	}

	@Override
	public int getCount() {
		// TODO Auto-generated method stub
		return listInfo.size();
	}

	@Override
	public Object getItem(int position) {
		// TODO Auto-generated method stub
		return listInfo.get(position);
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
			convertView = infater.inflate(R.layout.worker_listview_item, null);
			holder = new ViewHolder();
			holder.tv_ProjectName = (TextView) convertView
					.findViewById(R.id.project_name);
			holder.tv_GongTou = (TextView) convertView
					.findViewById(R.id.gt_amount);
			holder.tv_PaGong = (TextView) convertView
					.findViewById(R.id.pg_amount);
			holder.tv_Worker = (TextView) convertView
					.findViewById(R.id.worker_amount);
			holder.tv_Date = (TextView) convertView
					.findViewById(R.id.attendance_date);
			convertView.setTag(holder);
		} else {
			holder = (ViewHolder) convertView.getTag();
		}
		
		final ExpatriateAttendance dataInfo = (ExpatriateAttendance) getItem(position);
		holder.tv_ProjectName.setText(dataInfo.getProjectName());
		// TODO update to user
		holder.tv_GongTou.setText(String.valueOf(dataInfo.getF_GongTou()));
		holder.tv_PaGong.setText(String.valueOf(dataInfo.getF_PaGong()));
		holder.tv_Worker.setText(String.valueOf(dataInfo.getF_Worker()));
		holder.tv_Date.setText(format(dataInfo.getF_AttendanceDate()));
		return convertView;
	}

	class ViewHolder {
		TextView tv_ProjectName;
		TextView tv_GongTou;
		TextView tv_PaGong;
		TextView tv_Worker;
		TextView tv_Date;
	}

}