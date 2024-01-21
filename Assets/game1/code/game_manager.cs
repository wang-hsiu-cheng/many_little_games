using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class game_manager : MonoBehaviour
{
    static public bool game_start = false;
    private Vector3 s_p, e_p;
    GameObject start_button, exit_button;
    // Start is called before the first frame update
    void Start()
    {
        start_button = transform.GetChild(1).gameObject;
        exit_button = transform.GetChild(2).gameObject;
        s_p = start_button.transform.position;
        e_p = exit_button.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnToolClicked()
    {
        if (start_button.transform.position.x - transform.position.x < 0) {
            start_button.transform.position += new Vector3((GetComponent <Transform> ().position.x - start_button.transform.position.x)*1.2f, 0, 0);
            exit_button.transform.position += new Vector3((GetComponent <Transform> ().position.x - exit_button.transform.position.x)*1.2f, 0, 0);
        } else {
            start_button.transform.position = s_p;
            exit_button.transform.position = e_p;
        }
        Debug.Log(start_button.transform.position);

    }
    public void OnStartClicked()
    {
        Debug.Log(game_start);
        game_start = true;
    }
    public void OnExitClicked()
    {
        game_start = false;
        SceneManager.LoadScene(0);
    }
}
