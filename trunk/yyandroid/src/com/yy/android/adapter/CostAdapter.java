package com.yy.android.adapter;

import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.Date;
import java.util.List;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.View.OnClickListener;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.CheckBox;
import android.widget.CompoundButton;
import android.widget.TextView;

import com.yy.android.R;
import com.yy.android.activity.MyBaseActivity.CostTypeEnum;
import com.yy.android.vo.ProjectCost;

public class CostAdapter extends BaseAdapter {

	public List<ProjectCost> mlistAppInfo;
	LayoutInflater infater = null;
	public static List<Integer> clearIds;
	protected Calendar calendar = Calendar.getInstance();
	private int mtype = 1;
	private CostTypeEnum mCostType;

	protected String format(Date date) {
		String str = "";
		SimpleDateFormat ymd = null;
		ymd = new SimpleDateFormat("yyyy-MM-dd");
		str = ymd.format(date);
		return str;
	}

	public CostAdapter(Context context, List<ProjectCost> datas, int type, CostTypeEnum costType) {
		infater = LayoutInflater.from(context);
		clearIds = new ArrayList<Integer>();
		this.mlistAppInfo = datas;
		mtype = type;
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

	ViewHolder holder = null;

	@Override
	public View getView(int position, View convertView, ViewGroup parent) {
		holder = null;
		if (convertView == null) {
			holder = new ViewHolder();
			ProjectCost costInfo = (ProjectCost) getItem(position);
			
			if (mCostType.equals(CostTypeEnum.project)) {
				convertView = infater.inflate(R.layout.project_cost_listview_item, null);
				holder.tv_ProjectName = (TextView) convertView.findViewById(R.id.tv_project_name);
				holder.tv_ProjectName.setText(costInfo.getProjectName());
			} else {
				convertView = infater.inflate(R.layout.cost_listview_item, null);
			}
			
			holder.tv_CostType = (TextView) convertView.findViewById(R.id.cost_type);
			holder.tv_CostAmount = (TextView) convertView.findViewById(R.id.cost_amount);
			holder.tv_CostDate = (TextView) convertView.findViewById(R.id.cost_date);
			holder.cb_Cost = (CheckBox) convertView.findViewById(R.id.cb_cost);
			convertView.setTag(holder);

			holder.tv_CostAmount.setText(String.valueOf(costInfo.getF_CostAmount()));
			holder.tv_CostDate.setText(format(costInfo.getF_CostDate()));
			if (!costInfo.isF_IsProjectCost() || costInfo.getF_CostType() == 108) {
				holder.tv_CostType.setText(costInfo.getF_OtherCost());
			} else {
				holder.tv_CostType.setText(costInfo.getCostTypeName());
			}
			// Default set all to apply cost
			holder.cb_Cost.setChecked(true);
			if (mtype == 2) {
				holder.cb_Cost.setVisibility(View.INVISIBLE);
			}
			holder.cb_Cost.setOnClickListener(new lvButtonListener(position));
			costInfo.setChecked(true);

		} else {
			holder = (ViewHolder) convertView.getTag();
		}
		// ProjectCost costInfo = (ProjectCost) getItem(position);
		// holder.tv_ProjectName.setText(costInfo.getProjectName());
		// holder.tv_CostAmount.setText(String.valueOf(costInfo.getF_CostAmount()));
		// holder.tv_CostDate.setText(format(costInfo.getF_CostDate()));
		// if (!costInfo.isF_IsProjectCost() || costInfo.getF_CostType() == 108)
		// {
		// holder.tv_CostType.setText(costInfo.getF_OtherCost());
		// } else {
		// holder.tv_CostType.setText(costInfo.getCostTypeName());
		// }
		// // Default set all to apply cost
		// holder.cb_Cost.setChecked(true);
		// if(mtype ==2){
		// holder.cb_Cost.setVisibility(View.INVISIBLE);
		// }
		// holder.cb_Cost.setOnClickListener(new lvButtonListener(position) );
		// costInfo.setChecked(true);
		return convertView;
	}

	public OnClickListener MyOnCheckedChangeListener;

	class lvButtonListener implements OnClickListener {
		public int position;

		public lvButtonListener(int pos) {
			position = pos;
		}

		@Override
		public void onClick(View v) {
			int vid = v.getId();
			if (vid == holder.cb_Cost.getId()) {
				v.setTag(position);
				MyOnCheckedChangeListener.onClick(v);
			}

		}

	}

	class ViewHolder {
		TextView tv_ProjectName;
		TextView tv_CostType;
		TextView tv_CostAmount;
		TextView tv_CostDate;
		CheckBox cb_Cost;

	}

}
