using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController), typeof(PlayerMovement))]
public class Player : MonoBehaviour
{
    PlayerMovement playerMovement;
    Gun gun;

    public PlayerMovement PlayerMovement { get => playerMovement; }
    public Gun Gun { get => gun; }

    // Start is called before the first frame update
    void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        gun = GetComponentInChildren<Gun>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
