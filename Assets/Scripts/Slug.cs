using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slug : MonoBehaviour
{
    public float speed;
    private bool movingLeft = true;
    public Transform groundDetection;
    private Animator animator;
    private AudioSource audio;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, 2f);

        if(groundInfo.collider == false)
        {
            if(movingLeft == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingLeft = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingLeft = true;
            }
        }
    }
    public void Tremble()
    {
        audio.Play();
        animator.SetTrigger("Death");
    }

    private void Death()
    {
        Destroy(this.gameObject);
    }
}
