    using System.Collections;
using System.Collections.Generic;
using System.Drawing.Text;
using JetBrains.Annotations;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
 
    // Start is called before the first frame update
    public WarriorlegendplayerControl inputControl;

    private Rigidbody2D rb;
    public Vector2 inputDirection;
    public float Speed;
    private void Awake() {
    inputControl = new WarriorlegendplayerControl();    
    rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable() {
        inputControl.Enable();
    }
    private void OnDisable() {
        inputControl.Disable();
    }
    private void Update() {
        inputDirection = inputControl.GamePlay.Move.ReadValue<Vector2>();
    }

    private void FixedUpdate() {
        Move();
    }
    public void Move(){
        rb.velocity = new Vector2(inputDirection.x*Speed*Time.deltaTime, rb.velocity.y);
    }
    
}
