package com.yy.android.util;

import java.io.File;
import java.nio.charset.Charset;
import java.util.ArrayList;
import java.util.Map;

import org.apache.http.HttpEntity;
import org.apache.http.HttpResponse;
import org.apache.http.HttpStatus;
import org.apache.http.HttpVersion;
import org.apache.http.client.ClientProtocolException;
import org.apache.http.client.HttpClient;
import org.apache.http.client.methods.HttpPost;
import org.apache.http.conn.ConnectTimeoutException;
import org.apache.http.entity.mime.HttpMultipartMode;
import org.apache.http.entity.mime.MultipartEntityBuilder;
import org.apache.http.impl.client.DefaultHttpClient;
import org.apache.http.params.CoreConnectionPNames;
import org.apache.http.params.CoreProtocolPNames;
import org.apache.http.protocol.HTTP;

import android.app.ProgressDialog;
import android.content.Context;
import android.os.AsyncTask;
import android.util.Log;
import android.widget.Toast;

import com.yy.android.util.ProgressOutHttpEntity.ProgressListener;

public class UploadUtilsAsync extends AsyncTask<String, Integer, String> {
	/** 服务器路径 **/
	private String url;
	/** 上传的参数 **/
	private Map<String, String> paramMap;
	/** 要上传的文件 **/
	private ArrayList<File> files;
	private long totalSize;
	private Context context;
	private ProgressDialog progressDialog;

	public UploadUtilsAsync(Context context, String url,
			Map<String, String> paramMap, ArrayList<File> files) {
		this.context = context;
		this.url = url;
		this.paramMap = paramMap;
		this.files = files;
	}

	public void dismissDialog() {
		progressDialog.dismiss();
	}

	@Override
	protected void onPreExecute() {// 执行前的初始化
		// TODO Auto-generated method stub
		progressDialog = new ProgressDialog(context);
		progressDialog.setTitle("请稍等...");
		progressDialog.setProgressStyle(ProgressDialog.STYLE_HORIZONTAL);
		progressDialog.setCancelable(true);
		progressDialog.show();
		super.onPreExecute();
	}

	@Override
	protected String doInBackground(String... params) {// 执行任务
		// TODO Auto-generated method stub
		MultipartEntityBuilder builder = MultipartEntityBuilder.create();

		builder.setCharset(Charset.forName(HTTP.UTF_8));// 设置请求的编码格式
		builder.setMode(HttpMultipartMode.BROWSER_COMPATIBLE);// 设置浏览器兼容模式
		int count = 0;
		for (File file : files) {
			// FileBody fileBody = new FileBody(file);//把文件转换成流对象FileBody
			// builder.addPart("file"+count, fileBody);
			builder.addBinaryBody("file" + count, file);
			count++;
		}
		builder.addTextBody("action", paramMap.get("action"));// 设置请求参数
		// builder.addTextBody("fileTypes", paramMap.get("fileTypes"));// 设置请求参数
		HttpEntity entity = builder.build();// 生成 HTTP POST 实体
		totalSize = entity.getContentLength();// 获取上传文件的大小
		ProgressOutHttpEntity progressHttpEntity = new ProgressOutHttpEntity(
				entity, new ProgressListener() {
					@Override
					public void transferred(long transferedBytes) {
						publishProgress((int) (100 * transferedBytes / totalSize));// 更新进度
					}
				});
		return uploadFile(url, progressHttpEntity);
	}

	@Override
	protected void onProgressUpdate(Integer... values) {// 执行进度
		// TODO Auto-generated method stub
		Log.i("info", "values:" + values[0]);
		progressDialog.setProgress((int) values[0]);// 更新进度条
		super.onProgressUpdate(values);
	}

	@Override
	protected void onPostExecute(String result) {// 执行结果
		// TODO Auto-generated method stub
		Log.i("info", result);
		Toast.makeText(context, result, Toast.LENGTH_LONG).show();
		progressDialog.dismiss();
		super.onPostExecute(result);
	}

	/**
	 * 向服务器上传文件
	 * 
	 * @param url
	 * @param entity
	 * @return
	 */
	public String uploadFile(String url, ProgressOutHttpEntity entity) {
		HttpClient httpClient = new DefaultHttpClient();// 开启一个客户端 HTTP 请求
		httpClient.getParams().setParameter(
				CoreProtocolPNames.PROTOCOL_VERSION, HttpVersion.HTTP_1_1);
		httpClient.getParams().setParameter(
				CoreConnectionPNames.CONNECTION_TIMEOUT, 5000);// 设置连接超时时间
		HttpPost httpPost = new HttpPost(url);// 创建 HTTP POST 请求
		httpPost.setEntity(entity);
		httpPost.setHeader("Content-Type", "multipart/form-data");
		httpPost.setHeader("Accept", "application/image");
		try {
			HttpResponse httpResponse = httpClient.execute(httpPost);
			if (httpResponse.getStatusLine().getStatusCode() == HttpStatus.SC_OK) {
				return "文件上传成功";
			}
		} catch (ClientProtocolException e) {
			e.printStackTrace();
		} catch (ConnectTimeoutException e) {  
			e.printStackTrace();
		} catch (Exception e) {
			e.printStackTrace();
		} finally {
			if (httpClient != null && httpClient.getConnectionManager() != null) {
				httpClient.getConnectionManager().shutdown();
			}
		}
		return "文件上传失败";
	}

}