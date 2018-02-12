using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour {

    private void OnTriggerEnter(Collider collidedWithObj)
    {
        if (collidedWithObj.name != "Sphere") return;

        FindObjectOfType<GameController>().CheckIfEndOfGame();
    }
}
