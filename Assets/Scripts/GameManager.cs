using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Player player;

    private AudioSource audioSource;
    public AudioClip gameOver;


    public bool isGameActive;

    public Button restartGame;
    public TextMesh gameOverTextMesh;

    public GameObject safetyArea;
    public GameObject dangerArea;
    private GameObject alan;
    private GameObject alanDanger;
    public GameObject cloud, cloud2;

    public float time;
    public TextMesh timeTextMesh;

    private float spawnRate = 1.0f;
    private float spawnRateDestroy = 1.5f;

    void Awake() 
    {
        audioSource = GetComponent<AudioSource>();
    }
    void Start()
    {
        time = 0.0f;
        StartGame();
    }
    IEnumerator SpawnTarget()
    {
        while(isGameActive)
        {
            //Time.timeScale += 0.05f;
            yield return new WaitForSeconds(spawnRate);
        
            int rnd = Random.Range(0,10);

            if(rnd < 5)
            {
                SpawnRandomSafetyArea();
 
                yield return new WaitForSeconds(spawnRateDestroy);

                SafetyAreaKill();
            }
            else
            {
                SpawnRandomDangerArea();

                yield return new WaitForSeconds(spawnRateDestroy);

                DangerAreaKill();
            }
        }  
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void StartGame()
    {
        isGameActive = true;
        StartCoroutine(SpawnTarget());
        audioSource.Play();
    }
     void Update()
    {
        TimeMetod();
        
    }
    public void GameOver()
    {
        restartGame.gameObject.SetActive(true);
        gameOverTextMesh.gameObject.SetActive(true);
        SafetyAreaKill();
        DangerAreaKill();
        CloudKill();
        isGameActive = false;
        audioSource.Stop();
        audioSource.PlayOneShot(gameOver, 1.0f);
    }
    void SpawnRandomSafetyArea()
    {
        if(player != null)
        {
            float playerPositionY = player.transform.position.y;

            if (isGameActive && playerPositionY < 0)
            {
                Instantiate(safetyArea, new Vector3(0, Random.Range(5, 1), 2), transform.rotation);
            }
            else
            {
                Instantiate(safetyArea, new Vector3(0, Random.Range(-1, -4), 2), transform.rotation);
            }
        }
            
    }
    void SpawnRandomDangerArea()
    {
        if(player != null)
        {
            float playerPositionY = player.transform.position.y;

            if (isGameActive && playerPositionY < 0)
            {
                Instantiate(dangerArea, new Vector3(0, Random.Range(5, 1), 2), transform.rotation);
            }
            else
            {
                Instantiate(dangerArea, new Vector3(0, Random.Range(-1, -4), 2), transform.rotation);
            }
        }
            
    }
    public void SafetyAreaKill()
    {
        alan = GameObject.FindWithTag("SafetyArea");
        Destroy(alan);
    }
    public void DangerAreaKill()
    {
        alanDanger = GameObject.FindWithTag("DangerArea");
        Destroy(alanDanger);
    }
    public void CloudKill()
    {
        cloud = GameObject.FindWithTag("Cloud");
        cloud2 = GameObject.FindWithTag("Cloud2");
        Destroy(cloud);
        Destroy(cloud2);
    }
    public void TimeMetod()
    {
        if (isGameActive)
        {
            time += Time.deltaTime;
            timeTextMesh.text = "    " + (int)time;
        }
        
    }

}
