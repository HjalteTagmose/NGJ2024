using UnityEngine;

public class Lootbag : MonoBehaviour
{
    private const float lootToBeMax = 25;
    private const float min = .6f;
    private const float max = 1.6f;

    public PickupLoot PickupLoot;

	private void Start()
	{
        UpdateSize(0);
	}

	private void Update()
	{
        UpdateSize(PickupLoot.playerLoot);
	}

	public void UpdateSize(int loot)
    {
        float t = Mathf.Clamp(loot, 0.01f, lootToBeMax) / lootToBeMax;
        transform.localScale = Vector3.one * Mathf.Lerp(min, max, t);
    }
}
