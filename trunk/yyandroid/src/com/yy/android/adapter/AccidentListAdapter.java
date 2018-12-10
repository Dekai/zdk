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
import android.widget.RelativeLayout;
import android.widget.TextView;

import com.yy.android.R;
import com.yy.android.vo.Accident;
import com.yy.android.vo.Cost;
import com.yy.android.vo.CostApply;
import com.yy.android.vo.User;

public class AccidentListAdapter extends BaseAdapter {

	public List<Accident> listInfo;
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

	public AccidentListAdapter(Context context, List<Accident> dataList) {
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
			convertView = infater.inflate(R.layout.accident_listview_item, null);
			holder = new ViewHolder();
			holder.tv_ProjectName = (TextView) convertView.findViewById(R.id.tv_project_name);
			holder.tv_AccidentName = (TextView) convertView.findViewById(R.id.tv_accident_name);
			holder.tv_AccidentDate = (TextView) convertView.findViewById(R.id.tv_accident_date);
			holder.tv_Operator = (TextView) convertView.findViewById(R.id.tv_operator);
			convertView.setTag(holder);
		} else {
			holder = (ViewHolder) convertView.getTag();
		}
		final Accident costInfo = (Accident) getItem(position);
		holder.tv_ProjectName.setText(costInfo.getProjectName());
		holder.tv_AccidentName.setText(costInfo.getF_AccidentName());
		holder.tv_Operator.setText(costInfo.getOperator());
		holder.tv_AccidentDate.setText(format(costInfo.getF_AccidentDate()));
		return convertView;
	}

	class ViewHolder {
		TextView tv_ProjectName;
		TextView tv_AccidentName;
		TextView tv_AccidentDate;
		TextView tv_Operator;
	}

}
