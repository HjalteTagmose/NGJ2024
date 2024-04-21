using System.Linq;
using UnityEngine;

public class WinScript : MonoBehaviour
{
	public Transform[] podiumPos = new Transform[3];

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.P))
			PlaceGoblins();
	}

	public void PlaceGoblins()
	{
		var goblins = GameObject.FindObjectsOfType<PickupLoot>();
		goblins = goblins.OrderByDescending(goblin => goblin.playerLoot).ToArray();

		for (int i = 0; i < podiumPos.Length; i++)
		{
			goblins[i].transform.position = podiumPos[i].position;
		}
	}
}
