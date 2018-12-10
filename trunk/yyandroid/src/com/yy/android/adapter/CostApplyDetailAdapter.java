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
import com.yy.android.activity.MyBaseActivity.CostTypeEnum;
import com.yy.android.vo.Cost;
import com.yy.android.vo.ProjectCost;
import com.yy.android.vo.User;

public class CostApplyDetailAdapter extends BaseAdapter {

	public List<ProjectCost> mlistAppInfo;
	LayoutInflater infater = null;
	public static List<Integer> clearIds;
	protected Calendar calendar = Calendar.getInstance();
	private CostTypeEnum mCostType;

	protected String format(Date date) {
		String str = "";
		SimpleDateFormat ymd = null;
		ymd = new SimpleDateFormat("yyyy-MM-dd");
		str = ymd.format(date);
		return str;
	}

	public CostApplyDetailAdapter(Context context, List<ProjectCost> datas, CostTypeEnum costType) {
		infater = LayoutInflater.from(context);
		clearIds = new ArrayList<Integer>();
		this.mlistAppInfo = datas;
		mCostType = costType;
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
		final ProjectCost costInfo = (ProjectCost) getItem(position);
		if (convertView == null) {
			holder = new ViewHolder();
			
			if (mCostType.equals(CostTypeEnum.project)) {
				convertView = infater.inflate(R.layout.project_cost_apply_detail_listview_item, null);
				holder.tv_ProjectName = (TextView) convertView.findViewById(R.id.project_name);
				holder.tv_ProjectName.setText(costInfo.getProjectName());
				holder.tv_CostType = (TextView) convertView.findViewById(R.id.cost_type);
				holder.tv_CostType.setText(costInfo.getCostTypeName());
			} else {
				convertView = infater.inflate(R.layout.cost_apply_detail_listview_item, null);
				holder.tv_CostType = (TextView) convertView.findViewById(R.id.cost_type);
				holder.tv_CostType.setText(costInfo.getF_OtherCost());
			}
			holder.tv_CostAmount = (TextView) convertView.findViewById(R.id.cost_amount);
			holder.tv_CostDate = (TextView) convertView.findViewById(R.id.cost_date);
			convertView.setTag(holder);
		} else {
			holder = (ViewHolder) convertView.getTag();
		}

		holder.tv_CostAmount.setText(String.valueOf(costInfo.getF_CostAmount()));
		holder.tv_CostDate.setText(format(costInfo.getF_CostDate()));
		return convertView;
	}

	class ViewHolder {
		TextView tv_ProjectName;
		TextView tv_CostType;
		TextView tv_CostAmount;
		TextView tv_CostDate;
	}
}
