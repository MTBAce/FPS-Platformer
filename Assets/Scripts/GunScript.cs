using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class NewGunScript : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float bulletspeed;  

    public timeController timeController;

    // Update is called once per frame
  public  void Update ()
    {
      if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            var bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            bullet.GetComponent<Rigidbody>().velocity = transform.forward * bulletspeed;
        }

      if (Input .GetKey(KeyCode.Mouse1))
        {
            timeController.DoSlowMotion();
        }

    }

}
