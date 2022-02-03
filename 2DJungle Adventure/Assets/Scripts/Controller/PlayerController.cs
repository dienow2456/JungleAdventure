using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using Spine.Unity;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
    public AdsManager adsManager;
    public Text coinDc;
    [SerializeField]
    ParticleSystem smoke, particleChamdat, oxi;
    [SerializeField]
    GameObject[] star1, star2;
    bool isWin = false;
    public static bool isComplete;
    public static PlayerController Instance;
    public SkeletonAnimation skeletonAnim;
    public AnimationReferenceAsset idle, walk, jump, lose, win, shot, slip, swing, dead;
    public string currentState;
    public string currentAnim;
    public string previousState;
   
    [SerializeField] float sliderFactor = 1.1f;
    [SerializeField]
    private LayerMask layerMask, wallLayer, waterLayer;
    [SerializeField]
    GameObject gameOverPage, magnet,magnetCheck, gameLosePage, addcoin, particleMagnet;
    [SerializeField]
    Rigidbody2D rb;
    float dirX;
    [SerializeField]
    float moveSpeed = 5f, jumpForce = 600f;
    bool facingRight = true;
    Vector3 localScale;
    bool canbeDouble, chamDat=true;
    private BoxCollider2D box2d;
     public static int count;
   
    [SerializeField]
    AudioSource chucmung, nhay, walkAudio,anhsao, thatvong;

    
    // Start is called before the first frame update
    void Start()
    {
        
        Instance = this;
        isComplete = false;
        
        localScale = transform.localScale;
        
        

       box2d = transform.GetComponent<BoxCollider2D>();
        isWin = false;
        currentState = "Idle";
        SetCharacterState(currentState);
    }

    // Update is called once per frame
    void Update()
    {
       
        if (IsGround())
        {
           
            canbeDouble = true;
            if (!chamDat)
            {
                chamDat = true;
                particleChamdat.Play();
                if (!GameManager.mute)
                    walkAudio.Play();
            }
        }
        magnet.transform.position = new Vector2(transform.position.x, transform.position.y);

        if (  CrossPlatformInputManager.GetButtonDown("Jump"))
        {
            
            if (IsGround()) 
            {
                if (IsWater())
                {
                    rb.velocity = Vector2.up * (jumpForce - 5f);
                    
                }
                else
                {
                    rb.velocity = Vector2.up * jumpForce;
                    if (!GameManager.mute)
                        nhay.Play();
                   
                }
            }
            else
            {
                if (canbeDouble)
                {
                    if (IsWater())
                    {
                        rb.velocity = Vector2.up * (jumpForce - 6f);
                        
                    }
                    else
                    {
                        rb.velocity = Vector2.up * (jumpForce - 2f);
                        smoke.Play();

                        var x = smoke.velocityOverLifetime;
                        x.enabled = false;
                        if (!GameManager.mute)
                            nhay.Play();
                        canbeDouble = false;
                       
                    }
                    
                }
                
            }
            if (!currentState.Equals("jump"))
            {
                previousState = currentState;
            }
            if (IsWater())
            {
                SetCharacterState("swing");
                
            }
            else
            {
                SetCharacterState("jump");
                
            }
            
        }
        if (!IsGround())
        {
            chamDat = false;
        }


        if (IsWater())
        {
            moveSpeed = 2.6f;
            rb.gravityScale = 1.8f;
            if (!oxi.isPlaying)
                oxi.Play() ;
        }
        else
        {
            rb.gravityScale = 2.8f;
            moveSpeed = 5;
            oxi.Stop();
        }
        dirX = CrossPlatformInputManager.GetAxis("Horizontal")*moveSpeed;
        
        if (dirX != 0 && !NotDead.dead && !isWin) 
        {
            
            if (!currentState.Equals("jump"))
            {
                SetCharacterState("walk");
                

            }
            
        }
        else if (NotDead.dead)
        {
            SetCharacterState("lose");

        }
        else if (isWin)
        {
            SetCharacterState("victory");
        }
        else if (ButtonAttack.attack)
        {
            SetCharacterState("shot");
           
            StartCoroutine(DelayAttack());
        }
        else if(dirX == 0)
        {
            if (!currentState.Equals("jump"))
            {
                SetCharacterState("idle");
            }
        }
       
        CheckWall();
    }
    
    void CheckWall()
    {
        if(OnCotCo() && !IsGround())
        {
            SetCharacterState("slip");
            Vector2 v = rb.velocity;
            v.y = -sliderFactor;
            rb.velocity = v;
        }
        if(IsWater() && !IsGround())
        {
            SetCharacterState("swing");

        }
    }
    public void CreateSmokeAndSound()
    {
        var x = smoke.velocityOverLifetime;
        x.enabled = true;

        if (dirX < 0)
        {
            Vector3 r = new Vector3(0, 90, 360);
            ParticleSystem.ShapeModule ps = smoke.shape;
            ps.rotation = r;
        }
        else if(dirX>0)
        {
            Vector3 r = new Vector3(0, -90, 180);
            ParticleSystem.ShapeModule ps = smoke.shape;
            ps.rotation = r;
        }
           smoke.Play();
        
    }
    private void FixedUpdate()
    {
        
        rb.velocity = new Vector2(dirX, rb.velocity.y);
       
    }

    private void LateUpdate()
    {
        if (dirX > 0)
        {
            facingRight = true;
        }
        else if(dirX < 0)
        {
            facingRight = false;
        }
        if( (facingRight)&&(localScale.x<0)||((!facingRight)&& (localScale.x > 0)))
        {
            localScale.x *= -1;
        }

        transform.localScale = localScale;
    }
    

    private bool IsGround()
    {
      RaycastHit2D raycastHit2d=  Physics2D.BoxCast(box2d.bounds.center, box2d.bounds.size, 0f, Vector2.down ,0.1f, layerMask);
        
        return raycastHit2d.collider != null;
    }
    private bool OnCotCo()
    {
        RaycastHit2D raycastHit2d = Physics2D.BoxCast(box2d.bounds.center, box2d.bounds.size, 0f, new Vector2(transform.localScale.x,0), 0.2f, wallLayer);

        return raycastHit2d.collider != null;
    }
    private bool IsWater()
    {
        RaycastHit2D raycastHit2d = Physics2D.BoxCast(box2d.bounds.center, box2d.bounds.size, 0f, new Vector2(transform.localScale.x, 0), 0.1f, waterLayer);

        return raycastHit2d.collider != null;
    }
    public void SetAnimation( AnimationReferenceAsset anim, bool loop, float timeScale)
    {

        if(anim.name.Equals(currentAnim))
        {
            return;
        }
        Spine.TrackEntry animationEntry = skeletonAnim.state.SetAnimation(0, anim, loop);
        animationEntry.TimeScale = timeScale;
        animationEntry.Complete += AnimationEntry_Complete;
        
        currentAnim = anim.name;
    }


    private void AnimationEntry_Complete(Spine.TrackEntry trackEntry)
    {
        if (currentState.Equals("jump"))
        {
            SetCharacterState(previousState);
        }
    }

    public void SetCharacterState(string state)
    {
        
        if (state.Equals("walk"))
        {
            SetAnimation(walk, true, 1f);
        }
        else if (state.Equals("jump"))
        {
            SetAnimation(jump, false, 1f);
        }
        else if (state.Equals("lose"))
        {
            SetAnimation(lose, false, 2f);
        }
        else if (state.Equals("victory"))
        {
            SetAnimation(win, true, 1f);
        }
        else if (state.Equals("shot"))
        {
            SetAnimation(shot, false, 0.8f);
           
        }
        else if (state.Equals("slip"))
        {
            SetAnimation(slip, true, 0.4f);
        }else if (state.Equals("swing"))
        {
            SetAnimation(swing, true, 0.4f);
        }
        else if (state.Equals("dead"))
        {
            SetAnimation(dead, true, 0.4f);
        }
        else
        {
            SetAnimation(idle, true, 1f);
        }

        
        currentState = state;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("cotco"))
        {
            collision.gameObject.GetComponent<Animator>().SetBool("State", true);
            isWin = true;
            
            
            StartCoroutine(Ketthuc());
        }
        if (collision.CompareTag("ground"))
        {
            collision.gameObject.GetComponentInParent<BoxCollider2D>().isTrigger = false;
           
            
        }
        if (collision.CompareTag("devo"))
        {
            collision.gameObject.GetComponent<Animator>().enabled = true;

        }
        if (collision.CompareTag("Finish"))
        {
            collision.gameObject.GetComponentInParent<BoxCollider2D>().isTrigger = true;
          
        }
        if (collision.CompareTag("magnetCheck"))
        {
            magnet.SetActive(true);
            particleMagnet.SetActive(true);
            magnetCheck.SetActive(false);
            StartCoroutine(Delay());
        }
        if (collision.CompareTag("dead"))
        {
            SetCharacterState("dead");
            StartCoroutine(Delay1());

        }
    }
    IEnumerator Delay1()
    {
        moveSpeed = 0;
        yield return new WaitForSeconds(1);
        gameLosePage.SetActive(true);
        if (!GameManager.mute)
            thatvong.Play();
        Time.timeScale = 0;
    }
    IEnumerator Delay()
    {
        yield return new WaitForSeconds(7);
        magnet.SetActive(false);
        particleMagnet.SetActive(false);
    }
    IEnumerator DelayAttack()
    {
       
        yield return new WaitForSeconds(0.8f);
        
        ButtonAttack.attack = false;
    }
    
    IEnumerator Ketthuc()
    {
        moveSpeed = 0;
        yield return new WaitForSeconds(1.5f);
        gameOverPage.SetActive(true);
        if(!IAPShop.checkBuyAds)
            adsManager.Playads();
        coinDc.text = EatCoins.demCoins.ToString();
        isComplete = true;
        if (!GameManager.mute)
            chucmung.Play();
        StartCoroutine(DemSao());
    }
    IEnumerator DemSao()
    {
        count = 0;
        for (int i = 0; i < star1.Length; i++)
        {
            if (star1[i].activeSelf)
            {
                count ++;
            }
        }
        
        for (int a = 0; a < count; a++)
        {
            star2[a].SetActive(true);
            if (!GameManager.mute)
            {
                anhsao.Play();
                anhsao.volume += 0.1f;
            }
            yield return new WaitForSeconds(0.5f);
        }
    }
    public void AddCoin()
    {
        int coinsNow = PlayerPrefs.GetInt("CoinScore");
        coinsNow += EatCoins.demCoins;
        PlayerPrefs.SetInt("CoinScore", coinsNow);
        if (!IAPShop.checkBuyAds)
            adsManager.PlayAdsReward();
        addcoin.SetActive(false);
       
    }
}
