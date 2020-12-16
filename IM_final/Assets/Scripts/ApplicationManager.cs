using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ApplicationManager : MonoBehaviour {
    

	public void Quit () 
	{
		#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
		#else
		Application.Quit();
		#endif
	}
    
    public void Game()
    {
        // 씬을 로드
        SceneManager.LoadScene("GameScene");
        Debug.Log("start game");
        
    }
}
