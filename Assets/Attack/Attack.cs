using System.Collections;
using System.Collections.Generic;
using TarodevController;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Attack : MonoBehaviour
{
    PlayerAnimator playerAnimator;
    PlayerController player;
    Vector2 goblinHitBoxPosition;
    Vector2 goblinHitBoxSize = new Vector2(2.5f, 2.5f);
    bool insideHitBox = false;

    // Start is called before the first frame update
    void Start()
    {
        goblinHitBoxPosition = transform.position;
        goblinHitBoxPosition.x -= 1;
        player = this.GetComponent<PlayerController>();


    }

    // Update is called once per frame
    void Update()
    {
        if (player.FrameInput.Attack == true)
        {
            GoblinAttack();
        }
    }

    /*private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(goblinHitBoxPosition, goblinHitBoxSize);
    }*/

    void GoblinAttack()
    {
        insideHitBox = Physics2D.BoxCast(goblinHitBoxPosition, goblinHitBoxSize, 0, Vector2.right, 1);
        if (insideHitBox == true && gameObject.tag == "Player")
        {
            Debug.Log("Player is inside the hitbox");
            playerAnimator.Attack();
        }
    }
}
