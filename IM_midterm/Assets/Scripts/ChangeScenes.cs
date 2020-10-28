using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScenes : MonoBehaviour
{
    public void ChangeStartScene()
    {
        SceneManager.LoadScene("1.StartingScene");
    }

    public void ChangeGame1Scene()
    {
        SceneManager.LoadScene("2.FirstGameScene");
    }

    public void ChangeGame2Scene()
    {
        SceneManager.LoadScene("3.SecondGameScene");
    }

    public void ChangeGame3Scene()
    {
        SceneManager.LoadScene("4.ThirdGameScene");
    }

    public void ChangeEndingScene()
    {
        SceneManager.LoadScene("5.EndingScene");
    }
}
