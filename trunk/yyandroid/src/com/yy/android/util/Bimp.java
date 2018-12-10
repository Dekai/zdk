package com.yy.android.util;

import java.io.BufferedInputStream;
import java.io.ByteArrayOutputStream;
import java.io.File;
import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.IOException;
import java.util.ArrayList;

import android.graphics.Bitmap;
import android.graphics.Bitmap.CompressFormat;
import android.graphics.BitmapFactory;

public class Bimp {
	
	public static void clear(){
		
		 max = 0;
		 tempSelectBitmap.clear();
	}
	
	
	public static int max = 0;

	public static ArrayList<ImageItem> tempSelectBitmap = new ArrayList<ImageItem>(); // 选择的图片的临时列表

	public static Bitmap revitionImageSize(String path) throws IOException {
		BufferedInputStream in = new BufferedInputStream(new FileInputStream(new File(path)));
		BitmapFactory.Options options = new BitmapFactory.Options();
		options.inJustDecodeBounds = true;
		BitmapFactory.decodeStream(in, null, options);
		in.close();
		int i = 0;
		Bitmap bitmap = null;
		while (true) {
			if ((options.outWidth >> i <= 1000) && (options.outHeight >> i <= 1000)) {
				in = new BufferedInputStream(new FileInputStream(new File(path)));
				options.inSampleSize = (int) Math.pow(2.0D, i);
				options.inJustDecodeBounds = false;
				bitmap = BitmapFactory.decodeStream(in, null, options);
				break;
			}
			i += 1;
		}

		return bitmap;
	}

	public static ArrayList<File> getImageFiles() {
		ArrayList<File> imgFiles = new ArrayList<File>();
		for (ImageItem img : tempSelectBitmap) {
			File imgFile = new File(img.imagePath);
			imgFiles.add(imgFile);
		}

		return imgFiles;
	}

	public static FormFile[] getFormImageFiles() {
		ArrayList<FormFile> imgFiles = new ArrayList<FormFile>();
		for (ImageItem img : tempSelectBitmap) {
			File imgFile = CompressImg(img);

			FormFile formImg = new FormFile(imgFile.getName(), imgFile, "Upload", "image/jpeg");
			imgFiles.add(formImg);
		}
		final int size = imgFiles.size();
		return (FormFile[]) imgFiles.toArray(new FormFile[size]);
	}

	/***
	 * 图片压缩
	 * @param img
	 * @return
	 */
	public static File CompressImg(ImageItem img) {
		File imgFile = new File(img.imagePath);
		try {
			FileOutputStream out = new FileOutputStream(imgFile);
			img.getBitmap().compress(CompressFormat.JPEG, 75, out);
			out.flush();
			out.close();
		} catch (Exception e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}

		return imgFile;
	}
}
