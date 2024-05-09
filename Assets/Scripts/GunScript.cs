using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class NewGunScript : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float bulletspeed;
    
    public bool isShooting, readyToShoot;
    bool allowReset = true;
    public float shootingDelay = 2f;
    public GameObject firePoint;

    public timeController timeController;

    public GameObject muzzleEffect;

    private Animator animator;


    public enum ShootingMode 
    {
        Single,
        Auto,
    }

    public ShootingMode currentShootingMode;

    private void Awake()
    {
        readyToShoot = true;
        animator = GetComponent<Animator>();
        
    }

    public  void Update ()
    {
        //Håller in vänsterklick
      if(currentShootingMode == ShootingMode.Single)
        {
            isShooting = Input.GetKeyDown(KeyCode.Mouse0);
        }
        //Trycker vänsterklick
      else if (currentShootingMode == ShootingMode.Auto)
        {
            isShooting = Input.GetKey(KeyCode.Mouse0);
        }

    if (readyToShoot && isShooting)
        {
            FireWeapon();
        }
      if (Input .GetKey(KeyCode.Mouse1))
        {
            SlowMotion();
        }
    }

    void FireWeapon()
    {
        readyToShoot = false;

        muzzleEffect.GetComponent<ParticleSystem>().Play();
        animator.SetTrigger("RECOIL");

        SoundManager.instance.m4ShootingSound.Play();

        var bullet = Instantiate(bulletPrefab, firePoint.transform.position, firePoint.transform.rotation); //Spawnar skotten på FirePoint objektet
        bullet.GetComponent<Rigidbody>().velocity = firePoint.transform.forward * bulletspeed; //Ger skotten hastighet
        if(allowReset)
        {
            Invoke("ResetShot", shootingDelay);
            allowReset = false;
        }
    }

    public void ResetShot()
    {
        readyToShoot = true;
        allowReset = true;
    }
    void SlowMotion()
    {
        timeController.DoSlowMotion(); //Kallar på Slowmotion funktionen, som saktar ner tiden
    }
}
