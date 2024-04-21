using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loot : MonoBehaviour
{   
    private Rigidbody2D rb;
    private Collider2D col;
    public int lootValue = 1;
    public bool canBePickedUp = false;

    void Awake(){
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
    }

    void Start(){
        StartCoroutine(TurnOnCollider());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator TurnOnCollider()
    {
        yield return new WaitForSeconds(1f);
        canBePickedUp = true;
        gameObject.layer = 0; //SUPER JANK, IF LOOT IS ON LOOT LAYER, PLAYER CAN'T PICK IT UP
    }

    public void GetPickup()
    {
        rb.simulated = false;
    }
}
