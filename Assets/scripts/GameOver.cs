using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour {

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name != "Sphere") return;
   
        Debug.Log("Sphere on grass !");
        FindObjectOfType<GameController>().EndOfGame(false);
    }

}
