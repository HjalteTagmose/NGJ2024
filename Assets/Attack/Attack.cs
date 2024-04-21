using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TarodevController;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerController))]
[RequireComponent(typeof(PlayerAnimator))]
[RequireComponent(typeof(PickupLoot))]
public class Attack : MonoBehaviour
{
    PlayerAnimator playerAnimator;
    PlayerController player;
    Vector2 goblinHitBoxPosition;
    Vector2 goblinHitBoxSize = new Vector2(2.5f, 2.5f);
    float timer = 0;
    [SerializeField] float attackTimeOut = 1f;  
    PickupLoot lootManager;
    public float damage = 0.3f;
    public GameObject lootPrefab;

    // Start is called before the first frame update
    void Start()
    {
        lootManager = GetComponent<PickupLoot>();
        goblinHitBoxPosition = transform.position;
        goblinHitBoxPosition.x -= 1;
        player = this.GetComponent<PlayerController>();
        playerAnimator = GetComponentInChildren<PlayerAnimator>();


    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > attackTimeOut && player.FrameInput.Attack)
        {
            timer = 0;
            Debug.Log("attacking goblins");
            GoblinAttack();
        }   
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(goblinHitBoxPosition, goblinHitBoxSize);
    }

    void GoblinAttack()
    {
            playerAnimator.Attack();

            goblinHitBoxPosition = transform.position;
            goblinHitBoxPosition.x -= Mathf.Sign(playerAnimator.transform.localScale.x);

            RaycastHit2D[] results = new RaycastHit2D[10];
            var filter = new ContactFilter2D();
            int amount = Physics2D.BoxCast(goblinHitBoxPosition, goblinHitBoxSize, 0, Vector2.right, filter, results, 1);

            var otherGoblins = results.Where(x => x.collider != null).Where(x => x.collider.transform != transform).Where(x => x.collider.tag == "Player");
            if (otherGoblins.Count() > 0)
            {
                var otherGoblin = otherGoblins.First();
                otherGoblin.collider.GetComponent<Attack>().WasAttacked();
            }
    }

    public void WasAttacked()
    {
        int lootToBeSpawned = (int)(lootManager.playerLoot * damage);
        lootManager.playerLoot -= lootToBeSpawned;

        for (int i = 0; i < lootToBeSpawned; i++)
        {
            GameObject loot = Instantiate(lootPrefab, transform.position, Quaternion.identity);
            loot.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-1, 1), Random.Range(0, 1)) * 10, ForceMode2D.Impulse);
        }
    }
}
