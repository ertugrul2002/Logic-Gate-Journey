
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;


public class ZombieSpawnController : MonoBehaviour
{
    public int initialZombiesPerWave =5;
    public int currentZombiesPerWave;
    public float spawnDelay =0.5f; // Delay between spawinging each zombie in a wave
    public int currentWave =0; 
    public float waveCooldown =10.0f;// Time in seconds between waves
    public bool inCooldown;
    public float cooldownCounter =0;// we only use this for tisting and the UI
    public List<Enemy> currentZombiesAlive;

    public GameObject zombiePerfab;
    public TextMeshProUGUI waveOverUI;
    public TextMeshProUGUI cooldownCounterUI;
    public TextMeshProUGUI currentWaveUI;
    private void Start()
    {
        currentZombiesPerWave =initialZombiesPerWave;
        GlobalRefrencse.Instace.waveNumber = currentWave;
        StartNextWave();
    }

    private void StartNextWave()
    {
        currentZombiesAlive.Clear();
        currentWave++;
        GlobalRefrencse.Instace.waveNumber = currentWave;
        currentWaveUI.text = "Wave: "+currentWave.ToString();
        StartCoroutine(SpawnWave());
    }

    private IEnumerator SpawnWave()
    {
        for(int i=0;i < currentZombiesPerWave; i++)
        {
            //Generate a random offset within a specified ranfe
            Vector3 spawnOffset = new Vector3(Random.Range(-1f,1f),0f,Random.Range(-1f,1f));
            Vector3 spawnPosition = transform.position + spawnOffset;

            // Instantiate the zombie
            var zombie = Instantiate(zombiePerfab, spawnPosition,Quaternion.identity);
            // Get Enemy Script
            Enemy enemyScript = zombie.GetComponent<Enemy>();

            // Track this zombie
            currentZombiesAlive.Add(enemyScript);
            yield return new WaitForSeconds(spawnDelay); 
        }
    }

    private void Update()
    {
        //Get all dead zombies
        List<Enemy> zombiesToRemove = new List<Enemy>();
        foreach (Enemy zombie in currentZombiesAlive)
        {
            if (zombie.isDead)
            {
                zombiesToRemove.Add(zombie);
            }
        }
        // Actually remve all dead zombies
        foreach(Enemy zombie in zombiesToRemove)
        {
            currentZombiesAlive.Remove(zombie);
        }
        zombiesToRemove.Clear();

        //start cooldown if all zombies are dead
        if( currentZombiesAlive.Count == 0 && inCooldown == false)
        {
            //Start cooldow for next wave
            StartCoroutine(WaveCooldown());
        }

        //Run the cooldown counter
        if(inCooldown)
        {
            cooldownCounter -=Time.deltaTime;
        }
        else
        {
            // reset the counter
            cooldownCounter = waveCooldown;
        }
        cooldownCounterUI.text =cooldownCounter.ToString("F0");

    }

    private IEnumerator WaveCooldown()
    {
        inCooldown = true;
        waveOverUI.gameObject.SetActive(true);
        yield return new WaitForSeconds(waveCooldown);

        inCooldown = false;
        waveOverUI.gameObject.SetActive(false);
        currentZombiesPerWave *=2;
        StartNextWave();
    }
}
