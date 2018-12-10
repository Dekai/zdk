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
import android.widget.CheckBox;
import android.widget.TextView;

import com.yy.android.R;
import com.yy.android.vo.Equiment;
import com.yy.android.vo.Project;

public class ProjectAdapter extends BaseAdapter {

	public List<Project> mlistAppInfo;
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

	public ProjectAdapter(Context context, List<Project> datas) {
		infater = LayoutInflater.from(context);
		clearIds = new ArrayList<Integer>();
		this.mlistAppInfo = datas;
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
			convertView = infater.inflate(R.layout.project_listview_item, null);
			holder = new ViewHolder();
			holder.tv_ProjectName = (TextView) convertView.findViewById(R.id.project_name);
			holder.tv_StartDate = (TextView) convertView.findViewById(R.id.tv_start_date);
			holder.tv_EndDate = (TextView) convertView.findViewById(R.id.tv_enddate);
			holder.tv_Status = (TextView) convertView.findViewById(R.id.tv_status);
			convertView.setTag(holder);
		} else {
			holder = (ViewHolder) convertView.getTag();
		}
		final Project dataInfo = (Project) getItem(position);
		holder.tv_ProjectName.setText(dataInfo.getF_Name());
		holder.tv_StartDate.setText(format(dataInfo.getF_StartDate()));
		if (dataInfo.getF_EndDate() == null) {
			holder.tv_EndDate.setText("未定");
		} else {
			holder.tv_EndDate.setText(format(dataInfo.getF_EndDate()));
		}
		if (dataInfo.isF_IsDelete()) {
			holder.tv_Status.setText("关闭");
		} else {
			holder.tv_Status.setText("开启");
		}
		return convertView;
	}

	class ViewHolder {
		TextView tv_ProjectName;
		TextView tv_StartDate;
		TextView tv_EndDate;
		TextView tv_Status;
	}

}
