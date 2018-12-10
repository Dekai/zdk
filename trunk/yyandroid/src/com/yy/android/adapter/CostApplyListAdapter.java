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
import com.yy.android.vo.CostApply;
import com.yy.android.vo.User;

public class CostApplyListAdapter extends BaseAdapter {

	public List<CostApply> listInfo;
	LayoutInflater infater = null;
	public static List<Integer> clearIds;
	protected Calendar calendar = Calendar.getInstance();
	protected String showType;

	protected String format(Date date) {
		String str = "";
		SimpleDateFormat ymd = null;
		ymd = new SimpleDateFormat("yyyy-MM-dd");
		str = ymd.format(date);
		return str;
	}

	public CostApplyListAdapter(Context context, List<CostApply> dataList, String showType) {
		infater = LayoutInflater.from(context);
		clearIds = new ArrayList<Integer>();
		this.listInfo = dataList;
		this.showType = showType;
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
			holder.tv_ProjectName = (TextView) convertView.findViewById(R.id.project_name);
			holder.tv_ApplyTitle = (TextView) convertView.findViewById(R.id.apply_title);
			holder.tv_Operator = (TextView) convertView.findViewById(R.id.tv_operator);
			holder.tv_ApplyUser = (TextView) convertView.findViewById(R.id.operator);
			holder.tv_ApplyAmount = (TextView) convertView.findViewById(R.id.apply_amount);
			holder.tv_ApplyDate = (TextView) convertView.findViewById(R.id.apply_date);
			convertView.setTag(holder);
		} else {
			holder = (ViewHolder) convertView.getTag();
		}
		final CostApply costInfo = (CostApply) getItem(position);
		holder.tv_ProjectName.setText(costInfo.getProjectName());
		holder.tv_ApplyTitle.setText(costInfo.getF_ApplyTitle());
		holder.tv_ApplyUser.setText(costInfo.getOperator());
		holder.tv_ApplyAmount.setText(String.valueOf(costInfo.getF_ApplyAmount()));
		holder.tv_ApplyDate.setText(format(costInfo.getF_ApplyDate()));
		if (showType.equals("MyApply")) {
			holder.tv_Operator.setText("状态：");
			holder.tv_ApplyUser.setText(costInfo.getApplyState());
		} else if (showType.equals("CostApply")) {
			holder.tv_Operator.setText("申请人：");
			holder.tv_ApplyUser.setText(costInfo.getOperator());
		}
		return convertView;
	}

	class ViewHolder {
		TextView tv_ProjectName;
		TextView tv_ApplyTitle;
		TextView tv_Operator;
		TextView tv_ApplyUser;
		TextView tv_ApplyAmount;
		TextView tv_ApplyDate;

	}

}
