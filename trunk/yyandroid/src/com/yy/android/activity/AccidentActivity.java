package com.yy.android.activity;

import java.io.File;
import java.io.InputStream;
import java.lang.reflect.Type;
import java.util.ArrayList;
import java.util.Date;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import org.apache.http.NameValuePair;
import org.apache.http.message.BasicNameValuePair;

import android.content.Context;
import android.content.Intent;
import android.content.res.Resources;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.graphics.Color;
import android.graphics.drawable.BitmapDrawable;
import android.graphics.drawable.ColorDrawable;
import android.graphics.drawable.Drawable;
import android.os.AsyncTask;
import android.os.Handler;
import android.os.Message;
import android.provider.MediaStore;
import android.view.Gravity;
import android.view.KeyEvent;
import android.view.LayoutInflater;
import android.view.View;
import android.view.View.OnClickListener;
import android.view.ViewGroup;
import android.view.ViewGroup.LayoutParams;
import android.view.animation.AnimationUtils;
import android.widget.AdapterView;
import android.widget.AdapterView.OnItemClickListener;
import android.widget.AdapterView.OnItemSelectedListener;
import android.widget.BaseAdapter;
import android.widget.Button;
import android.widget.EditText;
import android.widget.GridView;
import android.widget.ImageSwitcher;
import android.widget.ImageView;
import android.widget.LinearLayout;
import android.widget.PopupWindow;
import android.widget.RelativeLayout;
import android.widget.Spinner;
import android.widget.TextView;
import android.widget.Toast;

import com.google.gson.reflect.TypeToken;
import com.yy.android.R;
import com.yy.android.util.Bimp;
import com.yy.android.util.FileUtils;
import com.yy.android.util.ImageItem;
import com.yy.android.util.JSONHttpClient;
import com.yy.android.util.Res;
import com.yy.android.util.SocketHttpRequester;
import com.yy.android.vo.Accident;
import com.yy.android.vo.AccidentImage;
import com.yy.android.vo.Equiment;
import com.yy.android.vo.JsonResult;

public class AccidentActivity extends MyBaseActivity implements OnItemClickListener, OnClickListener, OnItemSelectedListener {
	private GridView noScrollgridview;
	private GridAdapter adapter;
	private View parentView;
	private PopupWindow pop = null;
	private LinearLayout ll_popup;
	private RelativeLayout parent;
	private Button bt_camera;
	private Button bt_photo;
	private Button bt_cancel, btn_date, btn_back, btn_add, btn_delete;
	private String pageObjId;
	public static Bitmap bimap;
	private EditText et_accident_desc, et_name;
	private TextView tv_title;
	public boolean isAdd = true;
	private int dataID;
	private LinearLayout ll_accident_history;
	private LinearLayout ll_accident_images;
	
	
	private String addAccident_API = Service_Address + "accident/create";
	private String updateAccident_API = Service_Address + "accident/edit";
	private String imgUpload_API = Service_Address + "uploadimages/upload";

	@Override
	protected void setContentView() {
		Res.init(this);
		Bimp.clear();
		bimap = BitmapFactory.decodeResource(getResources(), R.drawable.icon_addpic_unfocused);
		parentView = getLayoutInflater().inflate(R.layout.accident, null);
		setContentView(parentView);
	}

	@Override
	protected void findViewById() {
		
		
		ll_accident_images = (LinearLayout) findViewById(R.id.ll_accident_images);
		ll_accident_history = (LinearLayout) findViewById(R.id.ll_accident_history);
		sp_project = (Spinner) findViewById(R.id.sp_project);
		et_accident_desc = (EditText) findViewById(R.id.et_accident_des);
		et_name = (EditText) findViewById(R.id.et_accident_name);
		tv_title = (TextView) findViewById(R.id.tv_title);
		btn_date = (Button) findViewById(R.id.btn_date);
		btn_back = (Button) findViewById(R.id.btn_back);
		btn_add = (Button) findViewById(R.id.btn_add_accident);
		btn_delete = (Button) findViewById(R.id.btn_delete_accident);
		progress_loading = (LinearLayout) findViewById(R.id.progress_loading_item);
		pop = new PopupWindow(AccidentActivity.this);

		View view = getLayoutInflater().inflate(R.layout.addimg_popupwindows, null);

		ll_popup = (LinearLayout) view.findViewById(R.id.ll_popup);
		noScrollgridview = (GridView) findViewById(R.id.noScrollgridview);

		pop.setWidth(LayoutParams.MATCH_PARENT);
		pop.setHeight(LayoutParams.WRAP_CONTENT);
		pop.setBackgroundDrawable(new BitmapDrawable());
		pop.setFocusable(true);
		pop.setOutsideTouchable(true);
		pop.setContentView(view);

		parent = (RelativeLayout) view.findViewById(R.id.parent);
		bt_camera = (Button) view.findViewById(R.id.item_popupwindows_camera);
		bt_photo = (Button) view.findViewById(R.id.item_popupwindows_Photo);
		bt_cancel = (Button) view.findViewById(R.id.item_popupwindows_cancel);

	}

	@Override
	protected void initialize() {
		parent.setOnClickListener(this);
		bt_camera.setOnClickListener(this);
		bt_photo.setOnClickListener(this);
		bt_cancel.setOnClickListener(this);
		btn_back.setOnClickListener(this);
		btn_add.setOnClickListener(this);
		btn_delete.setOnClickListener(this);

		noScrollgridview.setSelector(new ColorDrawable(Color.TRANSPARENT));
		adapter = new GridAdapter(this);
		adapter.update();
		noScrollgridview.setAdapter(adapter);
		noScrollgridview.setOnItemClickListener(this);
		spCount=1;
		
		Intent intent = getIntent();
		Accident dataInfo = (Accident) intent.getSerializableExtra("accident");
		if (dataInfo != null) {
			dataID = dataInfo.getF_ID();
			et_name.setText(dataInfo.getF_AccidentName());
			btn_date.setText(dateFormat.format(dataInfo.getF_AccidentDate()));
			initProjectSpinner(this, String.valueOf(dataInfo.getF_ProjectID()));
			et_accident_desc.setText(dataInfo.getF_Description());
			
			// 加载照片
			LoadImages(String.valueOf(dataID));
			
			tv_title.setText("修改事故");
			btn_add.setText("修改事故");
			btn_delete.setText("删除事故");

			isAdd = false;
		} else {
			initProjectSpinner(this);
			btn_date.setText(format(calendar.getTime()));
			tv_title.setText("新增事故");
			btn_add.setText("新增事故");
			btn_delete.setText("返回列表");
			
			ll_accident_history.setVisibility(View.GONE);
		}

		btn_date.setOnClickListener(this);

	}



	@Override
	protected void onDestroy() {
		// TODO Auto-generated method stub
		super.onPause();
	}

	@Override
	public void onClick(View v) {
		switch (v.getId()) {
		case R.id.btn_add_accident:
			if (et_name.getText().toString().length() <= 0) {
				et_name.setError("请填写事故标题");
				Toast.makeText(AccidentActivity.this, "请填写事故标题", Toast.LENGTH_LONG).show();
			} else {
				new HandleAccident().execute();
			}
			break;
		case R.id.parent:
			pop.dismiss();
			ll_popup.clearAnimation();
			break;
		case R.id.item_popupwindows_camera:
			photo();
			pop.dismiss();
			ll_popup.clearAnimation();
			break;
		case R.id.item_popupwindows_Photo:
			Intent intent = new Intent(AccidentActivity.this, AlbumActivity.class);
			startActivity(intent);
			overridePendingTransition(R.anim.activity_translate_in, R.anim.activity_translate_out);
			pop.dismiss();
			ll_popup.clearAnimation();
			break;
		case R.id.item_popupwindows_cancel:
			pop.dismiss();
			ll_popup.clearAnimation();
			break;
		case R.id.btn_back:
			//finish();
			Intent intent1 = new Intent(AccidentActivity.this, AccidentListActivity.class);
			startActivity(intent1);
			AccidentActivity.this.finish();
			break;
		case R.id.btn_date:
			ShowTimePicker(btn_date);
			break;
		case R.id.btn_delete_accident:
			if (isAdd) {
				//finish();
				
				Intent intent2 = new Intent(AccidentActivity.this, AccidentListActivity.class);
				startActivity(intent2);
				
				AccidentActivity.this.finish();
			} else {
				new HandleAccident().execute("delete");
			}
			break;
		}
	}
	
	@Override
	public boolean onKeyDown(int keyCode, KeyEvent event) {
		
		if (keyCode == KeyEvent.KEYCODE_BACK) {
			
			Intent intent1 = new Intent(AccidentActivity.this, AccidentListActivity.class);
			startActivity(intent1);
		
			AccidentActivity.this.finish();
			
		}
		return true;
	}

	
	   private Handler mAnimHandler = new Handler() {  
	        public void handleMessage (Message msg) {//此方法在ui线程运行  
	            switch(msg.what) {  
	            case 0:  
	            	 stopAnim();
	                break;  
	            }  
	        }  
	    }; 
	    
	    
	    
	private String imgList_API = Service_Address + "uploadimages/getlist";
	private String imgurl_API = Service_Address +"uploadimages/";
	private String imgDel_API = Service_Address + "uploadimages/Delete";
	
	protected List<AccidentImage> imageList = new ArrayList<AccidentImage>();
	private void LoadImages(final String dataID2) {

		showAnim();
		ll_accident_images.removeAllViews();
		ll_accident_images.removeAllViewsInLayout();
		
		JSONHttpClient jsonHttpClient = new JSONHttpClient();
		List<NameValuePair> nameValuePairs = new ArrayList<NameValuePair>();
		nameValuePairs.add(new BasicNameValuePair("aid", dataID2));

		Type listType = new TypeToken<List<AccidentImage>>() {
		}.getType();

		imageList = jsonHttpClient.GetList(imgList_API, nameValuePairs, AccidentImage.class, listType);

		for(AccidentImage imageinfo : imageList){
			
			String IMAGE_URL = imgurl_API +imageinfo.getF_ImagePath();
			 View 	view =  LayoutInflater.from(this).inflate(R.layout.accident_image, null);
			new DownLoadImage(view, String.valueOf(imageinfo.getF_ID())).execute(IMAGE_URL);
		}
		stopAnim();
	}
		
	private class DownLoadImage extends AsyncTask<String, String, Bitmap> {
		View MyView;
		String id;
        public DownLoadImage(View is,String fid) { 
             
            this.MyView = is; 
            this.id = fid;
            } 
         protected Bitmap doInBackground(String...  urls) {
         
             String url =urls[0];
             Bitmap tmpBitmap = null;  
             try { 
             InputStream is = new java.net.URL(url).openStream(); 
             tmpBitmap = BitmapFactory.decodeStream(is); 
             is.close();
             } catch (Exception e) { 
             e.printStackTrace(); 
           
             } 
             return tmpBitmap; 
             
         }
        protected void onPostExecute(Bitmap result) {
        
             Resources res=getResources();
             Drawable bd=new BitmapDrawable(res,result);
            
             
             TextView MyTextView =  (TextView) this.MyView.findViewById(R.id.tv_accident_btn);
             MyTextView.setOnClickListener(new View.OnClickListener() {
				@Override
				public void onClick(View v) {
					new HandleImage().execute(id);
				}
			});
             
             ImageView MyImageView =  (ImageView) this.MyView.findViewById(R.id.im_accident_image);
             MyImageView.setImageDrawable(bd);
        
             
             ll_accident_images.addView(this.MyView);
         }
     }
	
	class HandleImage extends AsyncTask<String, String, String> {
		@Override
		protected String doInBackground(String... params) {
			try {
				JSONHttpClient jsonHttpClient = new JSONHttpClient();
;
				if (params.length > 0 ) {
					List<NameValuePair> nameValuePairs = new ArrayList<NameValuePair>();
					nameValuePairs.add(new BasicNameValuePair("id", params[0]));
					int result = jsonHttpClient.Get(imgDel_API, nameValuePairs,int.class);
				} 
				
			
			} catch (Exception e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			}
			return null;
		}

		@Override
		protected void onPreExecute() {
			super.onPreExecute();
			
		}

		@Override
		protected void onPostExecute(String s) {
			runOnUiThread(new Runnable() {
				@Override
				public void run() {
					
					LoadImages(String.valueOf(dataID));
				 
				}
			});
		}
	}
	
	
	private void UploadImages(final String accidentId) {

		new Thread(new Runnable() { // 开启线程上传文件
					@Override
					public void run() {
						Map<String, String> paramMap = new HashMap<String, String>();
						paramMap.put("accidentId", accidentId);
						try {
							SocketHttpRequester.post(imgUpload_API, paramMap, Bimp.getFormImageFiles());
						} catch (Exception e) {
							// TODO Auto-generated catch block
							e.printStackTrace();
						}
						
						
						mAnimHandler.obtainMessage(0,accidentId).sendToTarget();
				
						
						Bimp.clear();
						Intent intent = new Intent();
						intent.setClass(AccidentActivity.this, AccidentListActivity.class);
						startActivity(intent);
						
						AccidentActivity.this.finish();
					}
				}).start();

	}

	class HandleAccident extends AsyncTask<String, String, String> {
		@Override
		protected String doInBackground(String... params) {
			try {
				JSONHttpClient jsonHttpClient = new JSONHttpClient();
				Accident pageData = GatherPageData();
				JsonResult result;
				if (params.length > 0 && params[0].equals("delete")) {
					pageData.setF_ID(dataID);
					pageData.setF_IsDelete(true);
					result = jsonHttpClient.PostObject(updateAccident_API, pageData, JsonResult.class);
				} else {
					if (isAdd) {
						result = jsonHttpClient.PostObject(addAccident_API, pageData, JsonResult.class);
					} else {
						pageData.setF_ID(dataID);
						result = jsonHttpClient.PostObject(updateAccident_API, pageData, JsonResult.class);
					}
				}
				if (result.type == 0) {
					// Json call failed
					String errorMsg = result.message;
				} else {
					pageObjId = result.value;
				}
			} catch (Exception e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			}
			return null;
		}

		@Override
		protected void onPreExecute() {
			super.onPreExecute();
			showAnim();
		}

		@Override
		protected void onPostExecute(String s) {
			runOnUiThread(new Runnable() {
				@Override
				public void run() {
					UploadImages(pageObjId);
				
					
				}
			});
		}
	}

	private Accident GatherPageData() {
		Accident pageData = new Accident();

		pageData.setF_ProjectID(getSelectedProjectId());
		pageData.setF_AccidentName(et_name.getText().toString());
		pageData.setF_Description(et_accident_desc.getText().toString());
		pageData.setF_OperatorID(getOperatorId());
		pageData.setF_AccidentDate(GetBtnDate(btn_date));
		pageData.setF_OperateTime(new Date());

		return pageData;
	}

	@Override
	public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
		if (position == Bimp.tempSelectBitmap.size()) {
			ll_popup.startAnimation(AnimationUtils.loadAnimation(AccidentActivity.this, R.anim.activity_translate_in));
			pop.showAtLocation(parentView, Gravity.BOTTOM, 0, 0);
		} else {
			Intent intent = new Intent(AccidentActivity.this, GalleryActivity.class);
			intent.putExtra("position", "1");
			intent.putExtra("ID", position);
			startActivity(intent);
		}

	}

	public class GridAdapter extends BaseAdapter {
		private LayoutInflater inflater;
		private int selectedPosition = -1;
		private boolean shape;

		public boolean isShape() {
			return shape;
		}

		public void setShape(boolean shape) {
			this.shape = shape;
		}

		public GridAdapter(Context context) {
			inflater = LayoutInflater.from(context);
		}

		public void update() {
			loading();
		}

		public int getCount() {
			if (Bimp.tempSelectBitmap.size() == 9) {
				return 9;
			}
			return (Bimp.tempSelectBitmap.size() + 1);
		}

		public Object getItem(int arg0) {
			return null;
		}

		public long getItemId(int arg0) {
			return 0;
		}

		public void setSelectedPosition(int position) {
			selectedPosition = position;
		}

		public int getSelectedPosition() {
			return selectedPosition;
		}

		public View getView(int position, View convertView, ViewGroup parent) {
			ViewHolder holder = null;
			if (convertView == null) {
				convertView = inflater.inflate(R.layout.item_published_grida, parent, false);
				holder = new ViewHolder();
				holder.image = (ImageView) convertView.findViewById(R.id.item_grida_image);
				convertView.setTag(holder);
			} else {
				holder = (ViewHolder) convertView.getTag();
			}

			if (position == Bimp.tempSelectBitmap.size()) {
				holder.image.setImageBitmap(BitmapFactory.decodeResource(convertView.getResources(), R.drawable.icon_addpic_unfocused));
				if (position == 9) {
					holder.image.setVisibility(View.GONE);
				}
			} else {
				holder.image.setImageBitmap(Bimp.tempSelectBitmap.get(position).getBitmap());
			}

			return convertView;
		}

		public class ViewHolder {
			public ImageView image;
		}

		Handler handler = new Handler() {
			public void handleMessage(Message msg) {
				switch (msg.what) {
				case 1:
					adapter.notifyDataSetChanged();
					break;
				}
				super.handleMessage(msg);
			}
		};

		public void loading() {
			new Thread(new Runnable() {
				public void run() {
					while (true) {
						if (Bimp.max == Bimp.tempSelectBitmap.size()) {
							Message message = new Message();
							message.what = 1;
							handler.sendMessage(message);
							break;
						} else {
							Bimp.max += 1;
							Message message = new Message();
							message.what = 1;
							handler.sendMessage(message);
						}
					}
				}
			}).start();
		}
	}

	public String getString(String s) {
		String path = null;
		if (s == null)
			return "";
		for (int i = s.length() - 1; i > 0; i++) {
			s.charAt(i);
		}
		return path;
	}

	protected void onRestart() {
		adapter.update();
		super.onRestart();
	}

	private static final int TAKE_PICTURE = 0x000001;

	public void photo() {
		Intent openCameraIntent = new Intent(MediaStore.ACTION_IMAGE_CAPTURE);
		startActivityForResult(openCameraIntent, TAKE_PICTURE);
	}

	protected void onActivityResult(int requestCode, int resultCode, Intent data) {
		switch (requestCode) {
		case TAKE_PICTURE:
			if (Bimp.tempSelectBitmap.size() < 9 && resultCode == RESULT_OK) {

				String fileName = String.valueOf(System.currentTimeMillis());
				Bitmap bm = (Bitmap) data.getExtras().get("data");
				///storage/sdcard0/Photo_LJ/1434532906234.JPEG
				File f= FileUtils.saveBitmap(bm, fileName);

				ImageItem takePhoto = new ImageItem();
				takePhoto.setBitmap(bm);
				takePhoto.setImagePath(f.getPath());
				
				Bimp.tempSelectBitmap.add(takePhoto);
				
			
			}
			break;
		}
	}

	@Override
	public void onItemSelected(AdapterView<?> parent, View view, int position, long id) {
		int index = parent.getSelectedItemPosition();

		// storing string resources into Array
		// projects = getResources().getStringArray(R.array.project);
		//
		// Toast.makeText(getBaseContext(), "You have selected : " +
		// projects[index], Toast.LENGTH_SHORT).show();

	}

	@Override
	public void onNothingSelected(AdapterView<?> parent) {
		// TODO Auto-generated method stub

	}

	@Override
	protected void updateList() {
		// TODO Auto-generated method stub

	}

}
