using TarodevController;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
	private Animator anim;
	private SpriteRenderer sr;
	private IPlayerController player;

	private void Awake()
	{
		anim = GetComponent<Animator>();
		sr = GetComponent<SpriteRenderer>();
		player = GetComponentInParent<IPlayerController>();
	}

	private void Update()
	{
		var input = player.FrameInput;
		bool isMoving = input.Move.x != 0;
		anim.SetBool("IsMoving", isMoving);

		if (isMoving)
		{
			bool goingRight = input.Move.x > 0;
			transform.localScale = new Vector2(
				transform.localScale.y * (goingRight ? -1 : 1),
				transform.localScale.y);
		}
	}

	public void Attack() => anim.SetTrigger("Attack");
}
