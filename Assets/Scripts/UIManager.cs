using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {

    public GameObject loadingScreen;

    public GameObject[] menu;

    public void LoadScene(int scene)
    {
        loadingScreen.SetActive(true);
        SceneManager.LoadSceneAsync(scene);
    }

    public void LoadMenuItem(int item)
    {
        menu[item].SetActive(true);
    }

    public void BackButton()
    {
        foreach (var item in menu)
            item.SetActive(false);
        menu[0].SetActive(true);
    }

    public void LoadURL(string url)
    {
        Application.OpenURL(url);
    }

}
