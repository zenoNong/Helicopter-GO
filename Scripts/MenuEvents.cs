using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuEvents : MonoBehaviour
{
    public void LoadGame(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void OnPausePlay(int val)
    {
        Time.timeScale = val;
    }
}
