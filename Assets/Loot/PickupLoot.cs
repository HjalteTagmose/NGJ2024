using System;
using UnityEngine;

public class PickupLoot : MonoBehaviour
{
    public event Action<int> OnLootAdded;

    public int playerLoot = 0;
    [SerializeField] float lerpValue = 0.2f;
    [SerializeField] float distanceForPickup = 0.4f;
    int lootValue = 0;

    private void OnTriggerStay2D(Collider2D collision)
    {
        Transform loot = collision.gameObject.transform;
        Debug.Log("Collision with " + loot.name); 
        if (loot.tag == "Loot" && loot.GetComponent<Loot>().canBePickedUp)
        {
            Vector2 playerPosition = transform.position;
            playerPosition.y += 0.5f;
            loot.position = Vector2.Lerp(loot.position, playerPosition, lerpValue);
            loot.localScale = Vector2.Lerp(loot.localScale, Vector2.zero, lerpValue);
            if (Distance(playerPosition, loot.position) < distanceForPickup)
            {
                lootValue = loot.GetComponent<Loot>().lootValue;
                AddLoot(lootValue);
                Debug.Log("Player picked up loot");
                Destroy(collision.gameObject);
            }
        }
    }


    private float Distance(Vector2 playerposition, Vector2 lootposition)
    {
        float distance = Vector2.Distance(playerposition, lootposition);
        //Debug.Log("Distance between player and loot: " + distance);

        return distance;
    }

    private int AddLoot(int loot)
    {
        playerLoot += loot;
        Debug.Log("Player loot: " + playerLoot);
        OnLootAdded?.Invoke(loot);
        return playerLoot;
    }
}
