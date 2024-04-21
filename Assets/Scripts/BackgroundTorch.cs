using TarodevController;
using UnityEngine;

public class BackgroundTorch : MonoBehaviour
{
	public GameObject flame;
	public bool startOn = false;

	private void Start()
	{
		if (startOn)
			TurnOn();
	}

	private void OnTriggerStay2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			if (other.isTrigger)
				return;

			var player = other.GetComponent<PlayerController>();
			if (player == null)
				return;
			if (player.FrameInput.LightOn)
				TurnOn();
			print("player in range");
		}
    }

	private void TurnOn()
	{
		flame.SetActive(true);
	}
}
