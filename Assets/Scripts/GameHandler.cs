using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{   
    GameObject player_obj;
    Vector2 player_pos;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("GameHandler.Start");

        player_obj = GameObject.FindGameObjectWithTag("Player");
        player_pos = player_obj.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        player_pos = player_obj.transform.position;
    }

    public Vector2 getPlayerPos(){
        return player_pos;
    }
}
