using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5;
    public float jumpForce = 1;
    public Vector3 direction;

    Animator pAnimator;
    Rigidbody pRig2D;
    SpriteRenderer pSp;
    
    void Start()
    {
        pAnimator = GetComponent<Animator>();
        pRig2D = GetComponent<Rigidbody>();
        pSp = GetComponent<SpriteRenderer>();
    }

    void KeyInput()
    {
        direction.x = Input.GetAxisRaw("Horizontal");   // -1 0 1
        if(direction.x < 0)
        {
            //left
            pSp.flipX = true;
        }
        else if(direction.x > 0)
        {
            //right
            pSp.flipX = false;
        }
        else if(direction.x == 0)
        {
            //idle
        }
    }


    void Update()
    {
        KeyInput();

        pAnimator.SetFloat("Speed", Mathf.Abs(direction.x));

        Vector3 move = new Vector3(direction.x * speed * Time.deltaTime, 0, 0);
        transform.position += move;

    }
}
