using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PickupLoot : MonoBehaviour
{   
    [SerializeField ]int playerLoot = 0;
    [SerializeField] float lerpValue = 0.2f;
    [SerializeField] float distanceForPickup = 0.4f;
    int lootValue = 0;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Transform loot = collision.gameObject.transform;
        Debug.Log("Collision with " + loot.name); 
        if (loot.tag == "Loot")
        {
            Vector2 playerPosition = transform.position;
            playerPosition.y += 0.5f;

            loot.position = Vector2.Lerp(loot.position, playerPosition, lerpValue);
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
        Debug.Log("Distance between player and loot: " + distance);

        return distance;
    }

    private int AddLoot(int loot)
    {
        playerLoot += loot;
        Debug.Log("Player loot: " + playerLoot);
        return playerLoot;
    }
}
