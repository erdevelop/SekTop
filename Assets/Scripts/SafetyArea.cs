using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafetyArea : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip blip;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        audioSource.PlayOneShot(blip, 1.0f);
        //audioSource.Play();
    }
    
        
}
