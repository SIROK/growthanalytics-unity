using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class GrowthAnalyticsAndroid {

	private static GrowthAnalyticsAndroid instance = new GrowthAnalyticsAndroid ();

	#if UNITY_ANDROID
	private static AndroidJavaObject growthAnalytics;
	#endif
	
	private GrowthAnalyticsAndroid() {
		#if UNITY_ANDROID
		using(AndroidJavaClass gbcclass = new AndroidJavaClass( "com.growthbeat.analytics.GrowthAnalytics" )) {
			growthAnalytics = gbcclass.CallStatic<AndroidJavaObject>("getInstance"); 
		}
		#endif
	}

	public static void Initialize (string applicationId, string credentialId) {
		#if UNITY_ANDROID
		if (growthAnalytics == null)
			return;
		AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"); 
		AndroidJavaObject activity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity"); 
		growthAnalytics.Call("initialize", activity, applicationId, credentialId);
		#endif
	}
	
	public static void Tag (string tagId, string value) {
		#if UNITY_ANDROID
		if (growthAnalytics == null)
			return;
		growthAnalytics.Call("tag",tagId, value);
		#endif
	}
	
	public static void Track(string eventId, Dictionary<string, string> properties,GrowthAnalytics.TrackOption option) {
		#if UNITY_ANDROID
		if (growthAnalytics == null)
			return;

		using (AndroidJavaObject obj_HashMap = new AndroidJavaObject("java.util.HashMap")) {
			System.IntPtr method_Put = AndroidJNIHelper.GetMethodID (obj_HashMap.GetRawClass (), "put",
			                                                        "(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;");
			object[] args = new object[2];
			foreach (KeyValuePair<string, string> kvp in properties) {
				using (AndroidJavaObject k = new AndroidJavaObject("java.lang.String", kvp.Key)) {
					using (AndroidJavaObject v = new AndroidJavaObject("java.lang.String", kvp.Value)) {
						args [0] = k;
						args [1] = v;
						AndroidJNI.CallObjectMethod (obj_HashMap.GetRawObject (),
						                            method_Put, AndroidJNIHelper.CreateJNIArgArray (args));
					}
				}
			}
			AndroidJavaClass growthAnalyticsClass = new AndroidJavaClass( "com.growthbeat.analytics.GrowthAnalytics$TrackOption" );
			AndroidJavaObject optionObject = growthAnalyticsClass.GetStatic<AndroidJavaObject>(option == GrowthAnalytics.TrackOption.TrackOptionOnce ? "ONCE" : "COUNTER");
			growthAnalytics.Call("track",eventId, obj_HashMap, optionObject);
		}
		#endif
	}
	
	public static void Open() {
		#if UNITY_ANDROID
		if (growthAnalytics == null)
			return;
		growthAnalytics.Call("open");
		#endif
	}
	
	public static void Close() {
		#if UNITY_ANDROID
		if (growthAnalytics == null)
			return;
		growthAnalytics.Call("close");
		#endif
	}
	
	public static void Purchase(int price, string category, string product) {
		#if UNITY_ANDROID
		if (growthAnalytics == null)
			return;
		growthAnalytics.Call("purchase",price, category, product);
		#endif
	}
	
	public static void SetUserId(string userId) {
		#if UNITY_ANDROID
		if (growthAnalytics == null)
			return;
		growthAnalytics.Call("setUserId",userId);
		#endif
	}
	
	public static void SetName(string name) {
		#if UNITY_ANDROID
		if (growthAnalytics == null)
			return;
		growthAnalytics.Call("setName",name);
		#endif
	}
	
	public static void SetAge(int age) {
		#if UNITY_ANDROID
		if (growthAnalytics == null)
			return;
		growthAnalytics.Call("setAge",age);
		#endif
	}


	public static void SetGender(GrowthAnalytics.Gender gender) {
		#if UNITY_ANDROID
		if (growthAnalytics == null)
			return;
		AndroidJavaClass growthAnalyticsClass = new AndroidJavaClass( "com.growthbeat.analytics.GrowthAnalytics$Gender" );
		AndroidJavaObject genderObject = growthAnalyticsClass.GetStatic<AndroidJavaObject>(gender == GrowthAnalytics.Gender.GenderMale ? "MALE" : "FEMALE");
		growthAnalytics.Call("setGender",genderObject);
		#endif
	}
	
	public static void SetLevel(int level) {
		#if UNITY_ANDROID
		if (growthAnalytics == null)
			return;
		growthAnalytics.Call("setLevel",level);
		#endif
	}
	
	public static void SetDevelopment(bool development) {
		#if UNITY_ANDROID
		if (growthAnalytics == null)
			return;
		growthAnalytics.Call("setDevelopment",development);
		#endif
	}
	
	public static void SetDeviceModel() {
		#if UNITY_ANDROID
		if (growthAnalytics == null)
			return;
		growthAnalytics.Call("setDeviceModel");
		#endif
	}
	
	public static void SetOS() {
		#if UNITY_ANDROID
		if (growthAnalytics == null)
			return;
		growthAnalytics.Call("setOS");
		#endif
	}
	
	public static void SetLanguage() {
		#if UNITY_ANDROID
		if (growthAnalytics == null)
			return;
		growthAnalytics.Call("setLanguage");
		#endif
	}
	
	public static void SetTimeZone() {
		#if UNITY_ANDROID
		if (growthAnalytics == null)
			return;
		growthAnalytics.Call("setTimeZone");
		#endif
	}
	
	public static void SetTimeZoneOffset() {
		#if UNITY_ANDROID
		if (growthAnalytics == null)
			return;
		growthAnalytics.Call("setTimeZoneOffset");
		#endif
	}
	
	public static void SetAppVersion() {
		#if UNITY_ANDROID
		if (growthAnalytics == null)
			return;
		growthAnalytics.Call("setAppVersion");
		#endif
	}
	
	public static void SetRandom() {
		#if UNITY_ANDROID
		if (growthAnalytics == null)
			return;
		growthAnalytics.Call("setRandom");
		#endif
	}
	
	public static void SetAdvertisingId() {
		#if UNITY_ANDROID
		if (growthAnalytics == null)
			return;
		growthAnalytics.Call("setAdvertisingId");
		#endif
	}
	
	public static void SetBasicTags() {
		#if UNITY_ANDROID
		if (growthAnalytics == null)
			return;
		growthAnalytics.Call("setBasicTags");
		#endif
	}

}
