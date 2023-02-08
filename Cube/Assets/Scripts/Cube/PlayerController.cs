using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public ParticleSystem dust;
    public ParticleSystem damage;
    public bool shield;
    public Animator Squash;

    public GameObject levelChanger;

    public float speed;
    public float jumpForce;
    private float moveInput;

    private Rigidbody2D rb;
    private bool facingRight = true;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    private int extraJumps;
    public int extraJumpsValue;
    private bool salto;

    private AudioSource audioSource;
    public AudioClip landSound;
    public AudioClip hitSound;
    public AudioClip coinSound;
    public AudioClip shootSound;

    public Transform player;
    public GameObject pl;

    public int respawn;

    public GameObject bullet;
    private Vector2 bulletPos;
    public float fireRate = 0.5f;
    private float nextFire = 0.0f;
    public GameObject enemy;


    KeyCode left;
    KeyCode right;
    KeyCode up;
    KeyCode fire;

    public bool checkpoint;



    void Start()
    {

        if (!PlayerPrefs.HasKey("playerPosX")) //se non ho mai salvato
        {
            PlayerPrefs.SetFloat("playerPosX", -24.1f);
            PlayerPrefs.SetFloat("playerPosY", 0.81f);

        }

        Vector2 playerPosition = new Vector2(PlayerPrefs.GetFloat("playerPosX"), PlayerPrefs.GetFloat("playerPosY"));
        transform.position = playerPosition;


        shield = false;
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();

        if (!PlayerPrefs.HasKey("soundsEffect")) //se non ho mai salvato lo setto al 100%
        {
            PlayerPrefs.SetFloat("soundsEffect", 1);
        }

        if (!PlayerPrefs.HasKey("input")) //se non ho mai salvato lo setto le frecce
        {
            PlayerPrefs.SetString("input", "arrows");
        }

        if (!PlayerPrefs.HasKey("shoot")) //se non ho mai salvato lo setto shift
        {
            PlayerPrefs.SetString("shoot", "shift");
        }


		if (PlayerPrefs.GetString("input").Equals("WASD"))
		{
            left = KeyCode.A;
            right = KeyCode.D;
            up = KeyCode.W;
		}
		else
		{
            left = KeyCode.LeftArrow;
            right = KeyCode.RightArrow;
            up = KeyCode.UpArrow;
        }

        if (PlayerPrefs.GetString("shoot").Equals("shift")) //SHIFT = L         ENTER = F. I'VE CHANGED IT BECAUSE IT'S EASIER.
        {
            fire = KeyCode.L;
		}
		else
		{
            fire = KeyCode.F;
		}

            audioSource.volume = PlayerPrefs.GetInt("soundsEffect");

    }

	
	private void FixedUpdate()
	{

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        if (!isGrounded) salto = true;

       
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);    //it moves the player. moveInput calculated in update()

       
        if (player.position.y < -6f)
        {
            Squash.SetTrigger("Die");

            StartCoroutine("morto");
        }

        if (isGrounded == true)
        {
            extraJumps = extraJumpsValue;
            if (salto == true)
            {


                Squash.SetTrigger("Landing");
                audioSource.PlayOneShot(landSound);
                createDust();

                salto = false;

            }

        }

    }

    void Flip() //inverte
	{
        if (salto == false) createDust();


        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x = Scaler.x * -1;
        transform.localScale = Scaler;
	}

	public void playCoinSound()
	{
        audioSource.PlayOneShot(coinSound);
    }

	public void Hit()
	{
        audioSource.PlayOneShot(hitSound);
        damage.Play();
        Squash.SetTrigger("Hit");

        if (!shield)
            pl.GetComponent<HeartSys>().takeDamage();
        else
        {
            shield = false; //shield destroyed
            gameObject.GetComponent<getShield>().shieldDestroyed();

        }


    }

    public void Died()
	{
        
            Squash.SetTrigger("Die");
            StartCoroutine(morto());
		
    }

    IEnumerator morto()
	{

        yield return new WaitForSeconds(0.1f);

        if(!checkpoint)
        levelChanger.GetComponent<LevelChanger>().FadeToLevel(0);
        else
        levelChanger.GetComponent<LevelChanger>().FadeToLevel(SceneManager.GetActiveScene().buildIndex);

        //SceneManager.LoadScene(respawn);
    }

    public void jump()
	{
        rb.velocity = Vector2.up * jumpForce;

    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKey(left))
        {
            moveInput = -1;
            if (facingRight) Flip();

        }
        else if (Input.GetKey(right))
        {
           
            moveInput = 1;

            if (!facingRight) Flip();
        }
        else
        {  
          moveInput = 0;
        }


        if (Input.GetKeyDown(up) && extraJumps > 0)
		{
            playJumpSound();
            Squash.SetTrigger("Jump");
            //rb.velocity = Vector2.up * jumpForce;
            jump();
            extraJumps--;
            createDust();
        }
        else if (Input.GetKeyDown(up) && extraJumps == 0 && isGrounded == true)
		{
            //rb.velocity = Vector2.up * jumpForce;
            jump();
        }


		if (Input.GetKeyDown(fire) && Time.time > nextFire)    //shot
		{
            nextFire = Time.time + fireRate;
            Fire();
		}

		



    }

    void playJumpSound()
	{
        GetComponent<AudioSource>().Play();

    }

    

    void createDust()
	{
        dust.Play();

    }

	void Fire()
	{
        audioSource.PlayOneShot(shootSound);
        Squash.SetTrigger("Shoot");
        bulletPos = transform.position;
        bulletPos = bulletPos + new Vector2(0f, 0.5f);
        Instantiate(bullet, bulletPos, Quaternion.identity);
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.name.Equals("MovingPlatform"))
		{
            this.transform.parent = collision.transform;
		}
	}

	private void OnCollisionExit2D(Collision2D collision)
	{
        if (collision.gameObject.name.Equals("MovingPlatform"))
        {
            this.transform.parent = null;
        }
    }

	

}
