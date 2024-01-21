using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dino : MonoBehaviour
{
    private Rigidbody2D _rb;

    public float jumppower;
    public int jumpAbility;
    static public bool start;
    // Start is called before the first frame update
    void Start()
    {
        _rb = this.gameObject.GetComponent<Rigidbody2D>();

        start = false;
        jumpAbility = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            start = true;
            if(jumpAbility > 0){
                _rb.velocity = new Vector2(0, jumppower);
                jumpAbility -=1;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "ground") {
            jumpAbility = 1;
        }
        if (other.gameObject.tag == "tree") {
            start = false;
        }
    }
}
