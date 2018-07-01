using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;

public class ShareImage : MonoBehaviour
{

    private bool isProcessing = false;

    private string shareText = "Позвольте вас приветствовать с приездом\nВ приют желанный, в лоно тишины...\n";
    private string gameLink = "#ЧеркизовскийЦДиК #ШколаШервинских #КоломенскийГородскойОкруг #ТайныСтаройШколы #AR #Квест #ДополненнаяРеальность #АфишаМО #Подмосковье #Культмо #туризммо #moscowregion #аннаахматова #welcomemosreg #коломенскийокруг #коломна #пульс #galagramdigital #yourklmn #ARkolomna";
    private string imageName = "MyPic"; // without the extension, for iinstance, MyPic 

    public static string destination = string.Empty;
    public void shareImage()
    {

        if (!isProcessing)
            StartCoroutine(ShareScreenshot());

    }

    private IEnumerator ShareScreenshot()
    {
        isProcessing = true;
        yield return new WaitForEndOfFrame();

        if (!Application.isEditor)
        {
            if (destination != string.Empty)
            {
                AndroidJavaClass intentClass = new AndroidJavaClass("android.content.Intent");
                AndroidJavaObject intentObject = new AndroidJavaObject("android.content.Intent");
                intentObject.Call<AndroidJavaObject>("setAction", intentClass.GetStatic<string> ("ACTION_SEND"));
                AndroidJavaClass uriClass = new AndroidJavaClass("android.net.Uri");
                AndroidJavaObject uriObject = uriClass.CallStatic<AndroidJavaObject>("parse", "file://" + destination);
                intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_STREAM"), uriObject);
                intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_TEXT"), shareText + gameLink);
                intentObject.Call<AndroidJavaObject>("setType", "image/jpeg");
                AndroidJavaClass unity = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
                AndroidJavaObject currentActivity = unity.GetStatic<AndroidJavaObject>("currentActivity");
                currentActivity.Call("startActivity", intentObject);
            }
        }

        isProcessing = false;

    }

}