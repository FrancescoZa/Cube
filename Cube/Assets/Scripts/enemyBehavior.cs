using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBehavior : MonoBehaviour
{

    public void checkTimetoFire(bool dead, float nextFire, float fireRate, Transform playerPos, GameObject bullet)
    {
        if (!dead)
            if (Time.time > nextFire)
            {

                if (playerPos.position.x < transform.position.x - 2)
                    Instantiate(bullet, transform.position, Quaternion.Euler(0f, 0f, -144));
                else if (playerPos.position.x > transform.position.x + 2)
                    Instantiate(bullet, transform.position, Quaternion.Euler(0f, 0f, -21));
                else
                    Instantiate(bullet, transform.position, Quaternion.Euler(0f, 0f, -80));

                nextFire = Time.time + fireRate;
            }
    }

    public virtual void flip()
    {
        
        Vector3 Scaler = transform.localScale;
        Scaler.x = Scaler.x * -1;
        transform.localScale = Scaler;
        print("flip");
    }

    public virtual void destroy(ParticleSystem dieParticles, Animator dieAnim)
    {
        GetComponent<AudioSource>().Play();
        dieParticles.Play();
        dieAnim.SetTrigger("Die");
        Destroy(gameObject, 1.5f);

    }

    public void setSoundEffect(AudioSource audioSource)
    {

        audioSource = GetComponent<AudioSource>();

        if (!PlayerPrefs.HasKey("soundsEffect")) //se non ho mai salvato lo setto al 100%
        {
            PlayerPrefs.SetFloat("soundsEffect", 1);
        }

        audioSource.volume = PlayerPrefs.GetInt("soundsEffect");

    }

}
