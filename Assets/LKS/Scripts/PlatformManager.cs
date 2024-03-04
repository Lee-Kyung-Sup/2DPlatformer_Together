using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    public static PlatformManager Instance = null;
    [SerializeField] GameObject platform;
    [SerializeField] float posX1, posX2, posX3, posX4, posX5, posX6, posX7, posX8, posY1, posY2, posY3, posY4, posY5, posY6, posY7, posY8;
    [SerializeField] float spawnTime = 2f;
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        Instantiate(platform, new Vector2(posX1, posY1), platform.transform.rotation);
        Instantiate(platform, new Vector2(posX2, posY2), platform.transform.rotation);
        Instantiate(platform, new Vector2(posX3, posY3), platform.transform.rotation);
        Instantiate(platform, new Vector2(posX4, posY4), platform.transform.rotation);
        Instantiate(platform, new Vector2(posX5, posY5), platform.transform.rotation);
        Instantiate(platform, new Vector2(posX6, posY6), platform.transform.rotation);
        Instantiate(platform, new Vector2(posX7, posY7), platform.transform.rotation);
        Instantiate(platform, new Vector2(posX8, posY8), platform.transform.rotation);
    }
    
    IEnumerator SpawnPlatform(Vector2 spawnPos)
    {
        yield return new WaitForSeconds (spawnTime);
        Instantiate(platform, spawnPos, platform.transform.rotation);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
