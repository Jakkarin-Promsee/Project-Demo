using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Unity.Mathematics;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Animator animator;

    public PlayerControll playerControll;
    private SpriteRenderer playerRenderer;
    private float TimeHurt = 0.2f;
    private float countTimeHurt = 0;

    void Start()
    {
        // Get the renderer component of the player
        playerRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("attackSpeed", playerControll.attackSpeed);
        animator.SetFloat("movementSpeed", playerControll.movementSpeed);

        animator.SetBool("running", math.abs(playerControll.horizontal*10)>0 || math.abs(playerControll.vertical*10)>0);
        if(playerControll.isAttacking) {
            animator.SetBool("attacking", true);
            playerControll.isAttacking = false; 
        }
        else{
            animator.SetBool("attacking", false);
        }

        if (playerControll.isHurt){ 
            playerRenderer.color = new Color(1f, 0.31f, 0.31f);
            countTimeHurt = 0;
            playerControll.isHurt = false;
        }

        countTimeHurt+=Time.deltaTime;

        if(countTimeHurt>=TimeHurt){
            playerRenderer.color = Color.white;
        }

    }
}
