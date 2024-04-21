using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	private void Update()
	{
		if(Input.anyKeyDown)
			StartGame();
	}

	public void StartGame()
	{
		SceneManager.LoadScene("Game");
	}
}
