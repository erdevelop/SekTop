using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
    private Rigidbody playerRb;

    public float gravityModifier = 1;
    public float jumpForce = 10;

    private AudioSource audioSource;

    public TextMesh puanTextMesh;
    private float puan = 5;

    public GameObject safetyArea;
    public GameObject dangerArea;
    public GameManager gameManager;
    
    void Start()
    {
        puanTextMesh.text = "    " + puan;
        
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;

        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
                audioSource.Play();
                playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                playerRb.AddTorque(0,0,1, ForceMode.Impulse);
        }
        if (transform.position.y > 10 || transform.position.y < -10 || puan <= 0)
        {
            
                Destroy(gameObject);
                gameManager.GameOver();
                puanTextMesh.text = "    " + puan;
            
        }
            
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("SafetyArea"))
        {
            puan += 5;
            puanTextMesh.text = "    " + puan;
            SafetyGone();
        }
        else if(other.CompareTag("DangerArea"))
        {
            puan -= 5;
            puanTextMesh.text = "    " + puan;
            DangerGone();
        }
        else
        {
            puanTextMesh.text = "    " + puan;
        }
    }

    IEnumerator SafetyGone()
    {
        yield return new WaitForSeconds(0.1f);
            
        gameManager.SafetyAreaKill();
    }
    IEnumerator DangerGone()
    {
        yield return new WaitForSeconds(0.1f);

        gameManager.DangerAreaKill();
    }
}
