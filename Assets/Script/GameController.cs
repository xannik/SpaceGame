using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public GameObject enemy_prefab = null;
    public GameObject player = null;

    private int wave_counter = 0;
    private List<GameObject> enemies = new List<GameObject>();

	// Use this for initialization
	void Start () {
        if (player == null)
            player = GameObject.FindGameObjectWithTag("Player");
        if (enemy_prefab == null)
            throw new System.Exception("Enemy prefab is missing");
        Random.InitState((int)System.DateTime.Now.Ticks);
    }
	
    void wavesSpawner()
    {
        enemies.RemoveAll(item => item == null);
        if (enemies.Count == 0)
        {
            wave_counter++;
            for (int i = 0; i < (10 + 5 * wave_counter); i++)
            {
                GameObject enemy = GameObject.Instantiate(enemy_prefab, Random.insideUnitSphere * 1000, Random.rotationUniform) as GameObject;
                enemies.Add(enemy);
            }
        }
    }

	// Update is called once per frame
	void Update () {
        if (player == null)
            Debug.Log("Player == null");
        else
        {
            wavesSpawner();
        }
	}
}
