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
import com.yy.android.vo.Cost;
import com.yy.android.vo.User;

public class CostListAdapter extends BaseAdapter {

	public List<Cost> listInfo;
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

	public CostListAdapter(Context context, List<Cost> dataList) {
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
			convertView = infater.inflate(R.layout.cost_apply_listview_item, null);
			holder = new ViewHolder();
			holder.tv_ProjectName = (TextView) convertView
					.findViewById(R.id.project_name);
			holder.tv_ApplyUser = (TextView) convertView
					.findViewById(R.id.operator);
			holder.tv_CostAmount = (TextView) convertView
					.findViewById(R.id.cost_amount);
			holder.tv_CostDate = (TextView) convertView
					.findViewById(R.id.cost_date);
			convertView.setTag(holder);
		} else {
			holder = (ViewHolder) convertView.getTag();
		}
		final Cost costInfo = (Cost) getItem(position);
		holder.tv_ProjectName.setText(costInfo.getProject());
		//TODO update to user
		holder.tv_ApplyUser.setText(costInfo.getCostType());
		holder.tv_CostAmount.setText(String.valueOf(costInfo.getCostAmount()));
		holder.tv_CostDate.setText(format(costInfo.getCostDate()));
		return convertView;
	}

	class ViewHolder {
		TextView tv_ProjectName;
		TextView tv_ApplyUser;
		TextView tv_CostAmount;
		TextView tv_CostDate;

	}

}
