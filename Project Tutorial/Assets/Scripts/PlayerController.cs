using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    PlayerControl playerControl;

    Player player;
    float moveDir = 0f;

    private void Awake()
    {
        playerControl = new PlayerControl();
        BindControl();

        player = GetComponent<Player>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CheckDirectionalAxis();
        CheckSprayShoot();
    }

    void BindControl()
    {
        playerControl.PlayerMovement.Jump.started += context => Jump();

        playerControl.PlayerMovement.Shoot.started += context => TapShoot();
    }

    void CheckDirectionalAxis()
    {
        bool left = playerControl.PlayerMovement.Left.ReadValue<float>() == 1f;
        bool right = playerControl.PlayerMovement.Right.ReadValue<float>() == 1f;
        bool up = playerControl.PlayerMovement.Up.ReadValue<float>() == 1f;
        bool down = playerControl.PlayerMovement.Down.ReadValue<float>() == 1f;

        if (left)
        {
            moveDir = -1f;
        }
        else if (right)
        {
            moveDir = 1f;
        }
        else
        {
            moveDir = 0f;
        }

        player?.PlayerMovement?.Move(moveDir);
    }

    void Jump()
    {
        player?.PlayerMovement?.Jump();
    }

    void CheckSprayShoot()
    {
        bool shooting = playerControl.PlayerMovement.Shoot.ReadValue<float>() == 1f;

        if (shooting)
        {
            player?.Gun?.SprayShoot();
        }
    }

    void TapShoot()
    {
        player?.Gun?.TapShoot();
    }

    private void OnEnable()
    {
        playerControl.Enable();
    }

    private void OnDisable()
    {
        playerControl.Disable();
    }
}
