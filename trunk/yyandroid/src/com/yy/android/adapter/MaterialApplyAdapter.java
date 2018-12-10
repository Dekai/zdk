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
import com.yy.android.vo.MaterialApply;

public class MaterialApplyAdapter extends BaseAdapter {

	public List<MaterialApply> mlistAppInfo;
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

	public MaterialApplyAdapter(Context context, List<MaterialApply> datas) {
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
			convertView = infater.inflate(R.layout.material_apply_listview_item, null);
			holder = new ViewHolder();
			holder.tv_ProjectName = (TextView) convertView.findViewById(R.id.project_name);
			holder.tv_Material = (TextView) convertView.findViewById(R.id.tv_material);
			holder.tv_Amount = (TextView) convertView.findViewById(R.id.tv_amount);
			holder.tv_Date = (TextView) convertView.findViewById(R.id.tv_date);
			holder.tv_Operator = (TextView) convertView.findViewById(R.id.tv_operator);
			convertView.setTag(holder);
		} else {
			holder = (ViewHolder) convertView.getTag();
		}
		final MaterialApply dataInfo = (MaterialApply) getItem(position);
		holder.tv_ProjectName.setText(dataInfo.getProjectName());
		holder.tv_Material.setText(String.valueOf(dataInfo.getF_Materials()));
		holder.tv_Amount.setText(String.valueOf(dataInfo.getF_ApplyCount()));
		holder.tv_Date.setText(format(dataInfo.getF_ApplyDate()));
		holder.tv_Operator.setText(dataInfo.getOperator());
		return convertView;
	}

	class ViewHolder {
		TextView tv_ProjectName;
		TextView tv_Material;
		TextView tv_Amount;
		TextView tv_Operator;
		TextView tv_Date;
	}

}
