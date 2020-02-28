using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform[] Lanes;
    public Transform[] Objects;
    public float timer;
    public float countdown;

    void Start()
    {
        timer = 3;
    }

    // Update is called once per frame
    void Update()
    {
        countdown += Time.deltaTime;

        if (countdown > timer) {
            if (timer > 1) { 
            timer -= 0.2f;
            }
            countdown = 0;
            Instantiate(Objects[Random.Range(0, 3)], Lanes[Random.Range(0,3)].position, Quaternion.identity);
        }
    }
}
