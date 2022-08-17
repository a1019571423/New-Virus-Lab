using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    PlayerCha playerCha;
    bool jump;
    bool attack;
    public int btIndex = 0;

    void Start()
    {
        playerCha = GetComponent<PlayerCha>();
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Jump")) 
        {
            jump = true;
        }

        playerCha.Move(h, jump);
        jump = false;

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            btIndex = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            btIndex = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            btIndex = 2;
        }
        

        if (Input.GetButtonDown("Fire2"))
        {
            attack = true;
        }

        playerCha.Attack(attack, btIndex);
        attack = false;
    }
}
