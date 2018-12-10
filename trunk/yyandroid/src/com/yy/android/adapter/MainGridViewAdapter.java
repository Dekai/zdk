package com.yy.android.adapter;

import java.util.List;

import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.ImageView;
import android.widget.TextView;

import com.yy.android.R;
import com.yy.android.activity.WorkSpaceMainActivity;
import com.yy.android.constants.MainFinal;
import com.yy.android.vo.ViewPagerBean;

public class MainGridViewAdapter extends BaseAdapter {
	private LayoutInflater inflater;
	private List<ViewPagerBean> applist;
	private int holdPosition; //
	private boolean isChanged = false; // 是否变化
	private boolean ShowItem = false; // 显示item

	public MainGridViewAdapter(WorkSpaceMainActivity c, int page) {
		this.inflater = LayoutInflater.from(c);
		if (page == 1) {
			this.applist = MainFinal.getbeans1();
		} else if (page == 2) {
			this.applist = MainFinal.getbeans2();
		}
	}
	
	public MainGridViewAdapter(WorkSpaceMainActivity c, List<ViewPagerBean> list) {
		this.inflater = LayoutInflater.from(c);
		this.applist = list;
	}


	@Override
	public int getCount() {
		// TODO Auto-generated method stub
		return applist.size();
	}

	@Override
	public Object getItem(int position) {
		// TODO Auto-generated method stub
		return applist.get(position);
	}

	@Override
	public long getItemId(int position) {
		// TODO Auto-generated method stub
		return position;
	}

	@Override
	public View getView(int position, View convertView, ViewGroup parent) {
		convertView = inflater.inflate(R.layout.main_gridview_item, null);
		TextView tv = (TextView) convertView
				.findViewById(R.id.main_gridview_item_name);
		ImageView iv = (ImageView) convertView
				.findViewById(R.id.main_gridview_src);
		tv.setText(applist.get(position).getName());
		iv.setBackgroundResource(applist.get(position).getId());
		ViewPagerBean bean = applist.get(position);
		if (isChanged) {
			if (position == holdPosition) {
				if (!ShowItem) {
					convertView.setVisibility(View.VISIBLE);
				}
			}
		}
		return convertView;
	}

	public void exchange(int startPosition, int endPosition) {
		Object start_obj = getItem(startPosition);
		holdPosition = endPosition;
		if (startPosition < endPosition) {
			applist.add(endPosition + 1, (ViewPagerBean) start_obj);
			applist.remove(startPosition);
		} else {
			applist.add(endPosition, (ViewPagerBean) start_obj);
			applist.remove(startPosition + 1);
		}
		isChanged = true;
		notifyDataSetChanged();
	}

	public void showDropItem(boolean b) {
		// TODO Auto-generated method stub
		this.ShowItem = b;
	}

}
