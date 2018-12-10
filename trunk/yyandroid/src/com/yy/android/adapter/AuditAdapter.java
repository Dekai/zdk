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
import com.yy.android.vo.Audit;
import com.yy.android.vo.ExpatriateAttendance;

public class AuditAdapter extends BaseAdapter {

	public List<Audit> listInfo;
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

	public AuditAdapter(Context context,
			List<Audit> dataList) {
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
			convertView = infater.inflate(R.layout.audit_listview_item, null);
			holder = new ViewHolder();
			holder.tv_name = (TextView) convertView
					.findViewById(R.id.tv_name);
			holder.tv_money = (TextView) convertView
					.findViewById(R.id.tv_money);
			holder.tv_operator = (TextView) convertView
					.findViewById(R.id.tv_operator);
			holder.tv_Date = (TextView) convertView
					.findViewById(R.id.tv_date);
			convertView.setTag(holder);
		} else {
			holder = (ViewHolder) convertView.getTag();
		}
		
		final Audit dataInfo = (Audit) getItem(position);
		holder.tv_name.setText(dataInfo.getF_Name());
		holder.tv_money.setText(String.valueOf(dataInfo.getF_Money()));
		holder.tv_operator.setText(String.valueOf(dataInfo.getOperator()));
		holder.tv_Date.setText(format(dataInfo.getF_Date()));
		return convertView;
	}

	class ViewHolder {
		TextView tv_name;
		TextView tv_money;
		TextView tv_operator;
		TextView tv_Date;
	}

}