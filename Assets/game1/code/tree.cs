using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tree : MonoBehaviour
{
    private int spawnability;
    private bool restart;
    void Start()
    {
        spawnability = 1;
    }
    public void Update()
    {
        if (dino.start) {
            // restart = true;
            // if (restart) {
            //     restart = false;
            //     if (transform.position.x < 9f)
            //         Destroy(gameObject);
            // }
            transform.Translate(-5f*Time.deltaTime, 0, 0);
            this.transform.localEulerAngles = new Vector3(0, 0, 0);
            if (transform.position.x <= (9.5f - (/*Random.Range(0, 3) * 1f + */8f)) && spawnability > 0) {
                spawnability = 0;
                transform.parent.GetComponent<trees>().Spawnblock();
            }
            if(transform.position.x < -9.4f) {
                Destroy(gameObject);
            }
        }
    }
}
