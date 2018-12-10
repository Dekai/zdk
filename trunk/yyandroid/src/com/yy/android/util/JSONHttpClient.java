package com.yy.android.util;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.io.UnsupportedEncodingException;
import java.lang.reflect.Type;
import java.util.ArrayList;
import java.util.List;
import java.util.zip.GZIPInputStream;

import org.apache.http.Header;
import org.apache.http.HttpEntity;
import org.apache.http.HttpResponse;
import org.apache.http.HttpStatus;
import org.apache.http.HttpVersion;
import org.apache.http.NameValuePair;
import org.apache.http.client.ClientProtocolException;
import org.apache.http.client.HttpClient;
import org.apache.http.client.methods.HttpDelete;
import org.apache.http.client.methods.HttpGet;
import org.apache.http.client.methods.HttpPost;
import org.apache.http.client.utils.URLEncodedUtils;
import org.apache.http.conn.ClientConnectionManager;
import org.apache.http.conn.params.ConnManagerParams;
import org.apache.http.conn.scheme.PlainSocketFactory;
import org.apache.http.conn.scheme.Scheme;
import org.apache.http.conn.scheme.SchemeRegistry;
import org.apache.http.conn.ssl.SSLSocketFactory;
import org.apache.http.entity.StringEntity;
import org.apache.http.impl.client.DefaultHttpClient;
import org.apache.http.impl.conn.tsccm.ThreadSafeClientConnManager;
import org.apache.http.params.BasicHttpParams;
import org.apache.http.params.HttpConnectionParams;
import org.apache.http.params.HttpParams;
import org.apache.http.params.HttpProtocolParams;
import org.apache.http.protocol.HTTP;

import com.google.gson.GsonBuilder;
import com.google.gson.JsonArray;

/**
 * Created with IntelliJ IDEA. User: ServusKevin Date: 4/7/13 Time: 4:42 PM To
 * change this template use File | Settings | File Templates.
 */

public class JSONHttpClient {
	private HttpClient customerHttpClient;

	public <T, K> K PostObject(final String url, final T object, final Class<K> objectClass) {
		HttpClient defaultHttpClient = getHttpClient();
		HttpPost httpPost = new HttpPost(url);
		try {

			StringEntity stringEntity = new StringEntity(new GsonBuilder().create().toJson(object), HTTP.UTF_8);
			httpPost.setEntity(stringEntity);
			httpPost.setHeader("Accept", "application/json");
			httpPost.setHeader("Content-type", "application/json;charset=utf-8");
			httpPost.setHeader("Accept-Encoding", "gzip");

			HttpResponse httpResponse = defaultHttpClient.execute(httpPost);
			HttpEntity httpEntity = httpResponse.getEntity();
			if (httpEntity != null) {
				InputStream inputStream = httpEntity.getContent();
				Header contentEncoding = httpResponse.getFirstHeader("Content-Encoding");
				if (contentEncoding != null && contentEncoding.getValue().equalsIgnoreCase("gzip")) {
					inputStream = new GZIPInputStream(inputStream);
				}

				String resultString = convertStreamToString(inputStream);
				inputStream.close();
				return new GsonBuilder().create().fromJson(resultString, objectClass);

			}

		} catch (UnsupportedEncodingException e) {
			e.printStackTrace(); // To change body of catch statement use File |
									// Settings | File Templates.
		} catch (ClientProtocolException e) {
			e.printStackTrace(); // To change body of catch statement use File |
									// Settings | File Templates.
		} catch (IOException e) {
			e.printStackTrace(); // To change body of catch statement use File |
									// Settings | File Templates.
		}
		return null;
	}

	public <T, K> K PostObjectWithParams(String url, List<NameValuePair> params, final T object, final Class<K> objectClass) {
		String paramString = URLEncodedUtils.format(params, "utf-8");
		url += "?" + paramString;
		return PostObject(url, object, objectClass);
	}

	public <T> ArrayList<T> GetList(String url, List<NameValuePair> params, final Class<T> objectClass, Type mType) {
		ArrayList<T> returnList = new ArrayList<T>();
		HttpClient defaultHttpClient = getHttpClient();
		String paramString = URLEncodedUtils.format(params, "utf-8");
		url += "?" + paramString;
		HttpGet httpGet = new HttpGet(url);
		try {

			httpGet.setHeader("Accept", "application/json");
			httpGet.setHeader("Accept-Encoding", "gzip");

			HttpResponse httpResponse = defaultHttpClient.execute(httpGet);
			HttpEntity httpEntity = httpResponse.getEntity();
			if (httpEntity != null) {
				InputStream inputStream = httpEntity.getContent();
				Header contentEncoding = httpResponse.getFirstHeader("Content-Encoding");
				if (contentEncoding != null && contentEncoding.getValue().equalsIgnoreCase("gzip")) {
					inputStream = new GZIPInputStream(inputStream);
				}

				String resultString = convertStreamToString(inputStream);
				inputStream.close();

				returnList = new GsonBuilder().setDateFormat("yyyy-MM-dd").create().fromJson(resultString, mType);
				return returnList;

			}

		} catch (Exception e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		return null;
	}

	public String PostObjectArrayWithParams(String url, final JsonArray myCustomArray, List<NameValuePair> params) {
		String paramString = URLEncodedUtils.format(params, "utf-8");
		url += "?" + paramString;
		return PostObjectArray(url, myCustomArray);
	}
	
	public String PostObjectArray(final String url, final JsonArray myCustomArray) {
		HttpClient defaultHttpClient = getHttpClient();
		HttpPost httpPost = new HttpPost(url);
		try {

			// StringEntity stringEntity = new StringEntity(new
			// GsonBuilder().create().toJson(object));
			StringEntity stringEntity = new StringEntity(myCustomArray.toString(),HTTP.UTF_8);
			httpPost.setEntity(stringEntity);
			httpPost.setHeader("Accept", "application/json");
			httpPost.setHeader("Content-type", "application/json;charset=utf-8");
			httpPost.setHeader("Accept-Encoding", "gzip");

			HttpResponse httpResponse = defaultHttpClient.execute(httpPost);
			HttpEntity httpEntity = httpResponse.getEntity();
			if (httpEntity != null) {
				InputStream inputStream = httpEntity.getContent();
				Header contentEncoding = httpResponse.getFirstHeader("Content-Encoding");
				if (contentEncoding != null && contentEncoding.getValue().equalsIgnoreCase("gzip")) {
					inputStream = new GZIPInputStream(inputStream);
				}

				String resultString = convertStreamToString(inputStream);
				inputStream.close();
				return resultString;

			}

		} catch (UnsupportedEncodingException e) {
			e.printStackTrace(); // To change body of catch statement use File |
									// Settings | File Templates.
		} catch (ClientProtocolException e) {
			e.printStackTrace(); // To change body of catch statement use File |
									// Settings | File Templates.
		} catch (IOException e) {
			e.printStackTrace(); // To change body of catch statement use File |
									// Settings | File Templates.
		}
		return null;
	}

	public <T> T PostParams(String url, final List<NameValuePair> params, final Class<T> objectClass) {
		String paramString = URLEncodedUtils.format(params, "utf-8");
		url += "?" + paramString;
		return PostObject(url, null, objectClass);
	}

	private String convertStreamToString(InputStream inputStream) {
		BufferedReader bufferedReader = new BufferedReader(new InputStreamReader(inputStream));
		StringBuilder stringBuilder = new StringBuilder();
		String line = null;
		try {
			while ((line = bufferedReader.readLine()) != null) {
				stringBuilder.append(line + "\n");
			}
		} catch (IOException e) {
			e.printStackTrace(); // To change body of catch statement use File |
									// Settings | File Templates.
		} finally {
			try {
				inputStream.close();
			} catch (IOException e) {
				e.printStackTrace(); // To change body of catch statement use
										// File | Settings | File Templates.
			}
		}

		return stringBuilder.toString();
	}

	public <T> T Get(String url, List<NameValuePair> params, final Class<T> objectClass) {
		HttpClient defaultHttpClient = getHttpClient();
		String paramString = URLEncodedUtils.format(params, "utf-8");
		url += "?" + paramString;
		HttpGet httpGet = new HttpGet(url);
		try {

			httpGet.setHeader("Accept", "application/json");
			httpGet.setHeader("Accept-Encoding", "gzip");

			HttpResponse httpResponse = defaultHttpClient.execute(httpGet);
			HttpEntity httpEntity = httpResponse.getEntity();
			if (httpEntity != null) {
				InputStream inputStream = httpEntity.getContent();
				Header contentEncoding = httpResponse.getFirstHeader("Content-Encoding");
				if (contentEncoding != null && contentEncoding.getValue().equalsIgnoreCase("gzip")) {
					inputStream = new GZIPInputStream(inputStream);
				}

				String resultString = convertStreamToString(inputStream);
				inputStream.close();
				return new GsonBuilder().setDateFormat("yyyy-MM-dd").create().fromJson(resultString, objectClass);

			}

		} catch (UnsupportedEncodingException e) {
			e.printStackTrace(); // To change body of catch statement use File |
									// Settings | File Templates.
		} catch (ClientProtocolException e) {
			e.printStackTrace(); // To change body of catch statement use File |
									// Settings | File Templates.
		} catch (IOException e) {
			e.printStackTrace(); // To change body of catch statement use File |
									// Settings | File Templates.
		}
		return null;
	}

	public boolean Delete(String url, final List<NameValuePair> params) {
		HttpClient defaultHttpClient = getHttpClient();
		String paramString = URLEncodedUtils.format(params, "utf-8");
		url += "?" + paramString;
		HttpDelete httpDelete = new HttpDelete(url);

		HttpResponse httpResponse = null;
		try {
			httpResponse = defaultHttpClient.execute(httpDelete);
			return httpResponse.getStatusLine().getStatusCode() == HttpStatus.SC_NO_CONTENT;
		} catch (IOException e) {
			e.printStackTrace(); // To change body of catch statement use File |
									// Settings | File Templates.
		}

		return false;
	}

	/**
	 * 创建httpClient实例
	 * 
	 * @return
	 * @throws Exception
	 */
	private synchronized HttpClient getHttpClient() {
		if (null == customerHttpClient) {
			HttpParams params = new BasicHttpParams();
			// 设置一些基本参数
			HttpProtocolParams.setVersion(params, HttpVersion.HTTP_1_1);
			HttpProtocolParams.setContentCharset(params, HTTP.UTF_8);
			HttpProtocolParams.setUseExpectContinue(params, true);
			HttpProtocolParams.setUserAgent(params, "Mozilla/5.0(Linux;U;Android 2.2.1;en-us;Nexus One Build.FRG83) "
					+ "AppleWebKit/553.1(KHTML,like Gecko) Version/4.0 Mobile Safari/533.1");
			// 超时设置
			/* 从连接池中取连接的超时时间 */
			ConnManagerParams.setTimeout(params, 5000);
			/* 连接超时 */
			int ConnectionTimeOut = 8000;
			HttpConnectionParams.setConnectionTimeout(params, ConnectionTimeOut);
			/* 请求超时 */
			HttpConnectionParams.setSoTimeout(params, 6000);
			// 设置我们的HttpClient支持HTTP和HTTPS两种模式
			SchemeRegistry schReg = new SchemeRegistry();
			schReg.register(new Scheme("http", PlainSocketFactory.getSocketFactory(), 80));
			schReg.register(new Scheme("https", SSLSocketFactory.getSocketFactory(), 443));

			// 使用线程安全的连接管理来创建HttpClient
			ClientConnectionManager conMgr = new ThreadSafeClientConnManager(params, schReg);
			customerHttpClient = new DefaultHttpClient(conMgr, params);
		}
		return customerHttpClient;
	}
}
