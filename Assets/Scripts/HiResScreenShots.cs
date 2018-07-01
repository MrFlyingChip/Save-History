using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class HiResScreenShots : MonoBehaviour
{ 

    public Camera cameraM;
    private bool m_screenShotLock = false;

    public GameObject buttons;

    public void OnSaveScreenshotPress()
    {
        GetComponent<Animator>().SetBool("Flash", true);
        ScreenshotManager.SaveScreenshot("Школа_Шервинских_" + System.DateTime.Now.ToString("yyyyMMdd_Hmmss"), "Школа Шервинских", "png");
    }

    public void LoadScene(int scene)
    {
        SceneManager.LoadSceneAsync(scene);
    }
}