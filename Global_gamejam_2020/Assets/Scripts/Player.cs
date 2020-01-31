using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Player : MonoBehaviour
{
    InputMaster Controls;

    Vector2 move;

    private void Awake()
    {
        Controls = new InputMaster();
        Controls.Player.Fire.performed += _ => shoot();
        Controls.Player.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
        Controls.Player.Move.canceled += ctx => move = Vector2.zero;

    }

    void shoot()
    {
        Debug.Log("fire");
    }


    private void Update()
    {
        Vector2 m = new Vector2(move.x, move.y) * Time.deltaTime;
        transform.Translate(m, Space.World);
    }

    private void OnEnable()
    {
        Controls.Player.Enable();
    }

    private void OnDisable()
    {
        Controls.Player.Disable();
    }
}
