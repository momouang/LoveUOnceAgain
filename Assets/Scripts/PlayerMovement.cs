using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MoveState
{
    ConstantRight,
    FreeMode,
    HorizontalOnly,
}

public class PlayerMovement : MonoBehaviour
{

    public CharacterController controller;
    public float movingSpeed = 0f;
    Vector2 moveDirection;

    public SpriteRenderer sprite;

    public bool isDinoplayer = false;
    public bool isControllable = true;
    public bool isFlippable = false;
    private Animator anim;

    public MoveState CurrentState = MoveState.ConstantRight;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }


    public void SetState(MoveState state)
    {
        CurrentState = state;
    }


    void ConstantRight(Vector2 _direction)
    {
        Vector2 newDirection = _direction;
        newDirection.x = 1 * movingSpeed;
        controller.Move(newDirection * Time.deltaTime);
    }

    void FreeMode(Vector2 _direction)
    {
        Vector2 newDirection = _direction;

        if (isFlippable && newDirection.x < 0)
        {
            sprite.flipX = true;
        }
        else if (isFlippable && newDirection.x >= 0)
        {
            sprite.flipX = false;
        }
        controller.Move(newDirection * Time.deltaTime);

        //animation
        if (isDinoplayer)
        {
            if (moveDirection.x > 0 || moveDirection.x < 0)
            {
                anim.SetFloat("posX", 1f);
            }
            if (moveDirection.y > 0)
            {
                anim.SetFloat("posY", 1f);
            }
            if (moveDirection.y < 0)
            {
                anim.SetFloat("posY", -1f);
            }
            if (moveDirection.x == 0 && moveDirection.y == 0)
            {
                anim.SetFloat("posX", 0f);
                anim.SetFloat("posY", 0f);
            }
        }
    }

    void HorizontalOnly(Vector2 _direction)
    {
        Vector2 newDirection = _direction;
        newDirection.y = 0;

        if(isFlippable && newDirection.x < 0)
        {
            sprite.flipX = true;
        }
        else if(isFlippable && newDirection.x >=0)
        {
            sprite.flipX = false;
        }
        controller.Move(newDirection * Time.deltaTime);

        //animation
        if (isDinoplayer)
        {
            if (moveDirection.x > 0 || moveDirection.x < 0)
            {
                anim.SetFloat("posX", 1f);
            }
            if (moveDirection.y == 0)
            {               
                anim.SetFloat("posY", 0f);
            }
            if (moveDirection.x == 0)
            {
                anim.SetFloat("posX", 0f);
            }
        }
    }

    private void Update()
    {
        if(isControllable)
        {
            moveDirection.y = Input.GetAxis("Vertical") * movingSpeed;
            moveDirection.x = Input.GetAxis("Horizontal") * movingSpeed;


            switch (CurrentState)
            {
                case MoveState.ConstantRight:
                    ConstantRight(moveDirection);
                    break;
                case MoveState.FreeMode:
                    FreeMode(moveDirection);
                    break;
                case MoveState.HorizontalOnly:
                    HorizontalOnly(moveDirection);
                    break;

            }
        }    
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Meteor"))
        {
            Debug.Log("triggered");
            controller.Move(new Vector3(-5,0,0));
        }
    }

    public void SetControllable(bool controlState)
    {
        isControllable = controlState;
    }

    

}
