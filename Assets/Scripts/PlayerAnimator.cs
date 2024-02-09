using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    // Constant string holding the name of the parameter in the Animator controller responsible for the walking animation state.
    private const string IS_WALKING = "IsWalking";

    // referencing another script that holds information about the player
    [SerializeField] Player player;

    // a reference to the Animator component attached to the same GameObject.
    private Animator animator;

    private void Awake()
    {
        // Retrieves (take back) the Animator component attached to the same GameObject and assigns it to the animator field.
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Sets the boolean parameter IS_WALKING in the Animator to the value returned by player.IsWalking().
        animator.SetBool(IS_WALKING, player.IsWalking());
    }
}
