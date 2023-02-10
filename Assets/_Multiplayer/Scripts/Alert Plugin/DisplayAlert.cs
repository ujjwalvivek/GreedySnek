using UnityEngine;
using System.Collections;
using UnityEngine.Android;

public class DisplayAlert : MonoBehaviour
{
    private AndroidJavaObject unityActivity;
    private AndroidJavaClass unityAlertClass;
    private AndroidJavaObject pluginInstance;

    private void Start()
    {
        InitializePlugins("com.example.unityalertplugin.PluginInstance");
        CreateAlert();
        //unityAlertClass = new AndroidJavaClass("com.example.UnityAlert.PluginInstance");
    }

    private void InitializePlugins(string pluginName)
    {
        unityAlertClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        unityActivity = unityAlertClass.GetStatic<AndroidJavaObject>("currentActivity");
        pluginInstance = new AndroidJavaObject(pluginName);

        if (pluginInstance == null) return;
        pluginInstance.CallStatic("receiveUnityActivity", unityActivity);
    }

    void CreateAlert()
    {
        pluginInstance.Call("CreateAlert");
    }

    public void ShowAlert()
    {
        pluginInstance.Call("ShowAlert");
        //AndroidJavaObject unityAlert = unityAlertClass.CallStatic<AndroidJavaObject>("create", currentActivity);
        //unityAlert.Call("show", title, message);
    }
}

