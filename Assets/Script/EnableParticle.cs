using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableParticle : MonoBehaviour {


    public ParticleSystem system;
    private void Start()
    {

        system.Play();
        
    }
  
}
