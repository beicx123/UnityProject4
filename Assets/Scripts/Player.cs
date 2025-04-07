using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum PlayerType
{
    idle,
    run,
    atk,
    hurt,
    die
}
public class Player : MonoBehaviour
{
    
    public PlayerType type;
    public Animator ani;
    void Start()
    {
        ani = GetComponent<Animator>();
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            type = PlayerType.idle;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            type = PlayerType.run;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            type = PlayerType.atk;
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            type = PlayerType.hurt;
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            type = PlayerType.die;
        }

        switch (type)
        {
            case PlayerType.idle:
                Idle();
                break;
            case PlayerType.run:
                Run();
                break;
            case PlayerType.atk:
                Attack();
                break;
            case PlayerType.hurt:
                Hurt();
                break;
            case PlayerType.die:
                Die();
                break;
        }
    }

    private void Die()
    {
        ani.Play("Die");

    }

    private void Hurt()
    {
        ani.Play("Hurt");

    }

    private void Attack()
    {
        ani.Play("Attack");

    }

    private void Run()
    {
        ani.Play("Run");

    }

    private void Idle()
    {
        ani.Play("Idle");
    }
}
