using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombEffector : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) {
            //this is extremely heavy because it reads all the script to find the specific name but effective for the bomb
            other.SendMessage("EnterBomb", 5, SendMessageOptions.DontRequireReceiver);
        }
    }
}
