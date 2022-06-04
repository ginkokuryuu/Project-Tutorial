using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    PlayerMovement playerMovement;
    Animator animator;
    Rigidbody2D rb2d;

    [SerializeField] float moveTolerance = 0.01f;

    private void Awake()
    {
        playerMovement = transform.parent.GetComponent<PlayerMovement>();
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        rb2d = playerMovement.Rb2d;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        CheckGroundAnimation();
        CheckAerialAnimation();
    }

    void CheckGroundAnimation()
    {
        if (!playerMovement.OnGround)
            return;

        bool isMoving = rb2d.velocity.x > moveTolerance || rb2d.velocity.x < -moveTolerance;
        if (isMoving)
            ChangeAnimationState(PLAYER_WALK);
        else
            ChangeAnimationState(PLAYER_IDLE);
    }

    void CheckAerialAnimation()
    {
        if (playerMovement.OnGround)
            return;

        if (rb2d.velocity.y > 0)
            ChangeAnimationState(PLAYER_JUMP);
        else if (rb2d.velocity.y < 0)
            ChangeAnimationState(PLAYER_FALL);
    }

    void ChangeAnimationState(string _state)
    {
        animator.Play(_state);
    }

    #region constant
    const string PLAYER_IDLE = "player-idle";
    const string PLAYER_WALK = "player-walk";
    const string PLAYER_JUMP = "player-jump";
    const string PLAYER_FALL = "player-fall";
    #endregion
}
