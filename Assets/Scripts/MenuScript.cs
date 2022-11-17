using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public GameObject Settings;

    public void OnButtonPress()
    {
        SceneManager.LoadScene("Main Arena");
    }

    public void OnButtonPress2()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
    public void OnButtonPress3()
    {
        Settings.SetActive(true);
    }

    public void OnButtonPress4()
    {
        Settings.SetActive(false);
    }
}
