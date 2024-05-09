using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
   public static SoundManager instance { get; set; }

    public AudioSource m4ShootingSound;

    private void Awake()
    {
        if (instance != null && instance!= this)
        {
            Destroy(gameObject);
        } else
        {
            instance = this;
        }
    }
}
