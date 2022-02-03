using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class EnemySau : MonoBehaviour
{
    public SkeletonAnimation skeletonAnim;
    public AnimationReferenceAsset walk, dead;
    //bool stomped = false;
    public string currentState;
    public string currentAnim;
    public  float speed = 1;


    bool facingLeft;
    bool cham;

    void Start()
    {
        cham = false;
      
        currentState = "walk";
        SetCharacterState(currentState);
    }


    private void Update()
    {
        if (StompedSau.cham)
        {
            if (cham)
            {
                SetCharacterState("dead");
                speed = 0;
                GetComponent<Rigidbody2D>().isKinematic = false;
            }
        }
        else
        {
            
            SetCharacterState("walk");

        }

        transform.Translate(-Vector2.left * speed * Time.deltaTime);
    }
    public void SetAnimation(AnimationReferenceAsset anim, bool loop, float timeScale)
    {

        if (anim.name.Equals(currentAnim))
        {
            return;
        }
        skeletonAnim.state.SetAnimation(0, anim, loop).TimeScale = timeScale;

        currentAnim = anim.name;
    }

    public void SetCharacterState(string state)
    {

        if (state.Equals("walk"))
        {
            SetAnimation(walk, true, 1f);
        }
        else if (state.Equals("dead"))
        {
            SetAnimation(dead, false, 1f);
        }
        currentState = state;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ong_nuoc")||collision.CompareTag("Untagged"))
        {
            facingLeft = !facingLeft;
        }

       
        if (collision.CompareTag("Player")||collision.CompareTag("attack"))
        {
            cham = true;
        }
        if (facingLeft)
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
    
    
}
