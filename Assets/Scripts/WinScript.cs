using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScript : Singleton<WinScript>
{
	public Transform[] podiumPos = new Transform[3];
	public Transform shadowRealm;
	public int goblinsYeeted = 0;

	public GameObject destroyGo;
	public GameObject turnOn;

	public void YeetGoblin(Transform goblin)
	{
		goblin.position = shadowRealm.position;
		goblinsYeeted++;

		if (goblinsYeeted == 3)
			PlaceGoblins();
	}

	public async void PlaceGoblins()
	{
		Destroy(destroyGo);
		turnOn.SetActive(true);

		var goblins = GameObject.FindObjectsOfType<PickupLoot>();
		goblins = goblins.OrderByDescending(goblin => goblin.playerLoot).ToArray();

		for (int i = 0; i < podiumPos.Length; i++)
		{
			await Task.Delay(1000);
			goblins[i].transform.position = podiumPos[i].position;
		}
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.R))
			SceneManager.LoadScene("Menu");
	}
}
