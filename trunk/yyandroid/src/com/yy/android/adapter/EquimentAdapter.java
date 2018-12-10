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

public class EquimentAdapter extends BaseAdapter {

	public List<Equiment> mlistAppInfo;
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

	public EquimentAdapter(Context context, List<Equiment> datas) {
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
			convertView = infater.inflate(R.layout.equiment_listview_item, null);
			holder = new ViewHolder();
			holder.tv_ProjectName = (TextView) convertView.findViewById(R.id.project_name);
			holder.tv_CostType = (TextView) convertView.findViewById(R.id.cost_type);
			holder.tv_CostAmount = (TextView) convertView.findViewById(R.id.cost_amount);
			holder.tv_CostDate = (TextView) convertView.findViewById(R.id.cost_date);
			holder.cb_Cost = (CheckBox) convertView.findViewById(R.id.cb_cost);
			convertView.setTag(holder);
		} else {
			holder = (ViewHolder) convertView.getTag();
		}
		final Equiment dataInfo = (Equiment) getItem(position);
		holder.tv_ProjectName.setText(dataInfo.getProjectName());
	
		
		holder.tv_CostDate.setText(format(dataInfo.getF_AttendanceDate()));
	//	holder.cb_Cost.setChecked(dataInfo.isF_IsHired());
		if (dataInfo.isF_IsHired()) {
			holder.tv_CostType.setText(dataInfo.getF_EquimentName());
			holder.tv_CostAmount.setText("租用数量："+String.valueOf(dataInfo.getF_EquimentCount()));
	
		} else {
			holder.tv_CostType.setText(dataInfo.getName());
			holder.tv_CostAmount.setText("");
		}

		return convertView;
	}

	class ViewHolder {
		TextView tv_ProjectName;
		TextView tv_CostType;
		TextView tv_CostAmount;
		TextView tv_CostDate;
		CheckBox cb_Cost;
	}

}
