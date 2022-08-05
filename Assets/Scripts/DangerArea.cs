using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerArea : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip aci;

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
        audioSource.PlayOneShot(aci, 1.0f);
        //audioSource.Play();
    }
}
