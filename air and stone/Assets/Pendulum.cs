using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pendulum : MonoBehaviour
{
    private float timer;
    public float speed;
    int phase = 0;


    void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;

        if (timer < 1f) {
            phase++;
            phase %= 2;
            timer = 0f;
        }

        switch (phase) {
            case 0:
                transform.Rotate(0f, 0f, speed * (1 - timer));
                break;
            case 1:
                transform.Rotate(0f, 0f, -speed * timer);
                break;
            case 2:
                transform.Rotate(0f, 0f, -speed * (1 - timer));
                break;
            case 3:
                transform.Rotate(0f, 0f, speed * timer);
                break;

        }
    }
}
