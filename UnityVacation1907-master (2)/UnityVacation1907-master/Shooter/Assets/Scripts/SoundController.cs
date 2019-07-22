using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum eEffectSoundType {
    ExpAst,
    ExpEnemy,
    ExpPlayer,
    FireEnemy,
    FirePlayer
}

public class SoundController : MonoBehaviour
{
    public AudioClip[] EffectArr;
    public AudioClip[] BGMArr;

    public AudioSource BGMSource;
    public AudioSource EffectSource;

    public 

    // Start is called before the first frame update
    void Start()
    {
        BGMSource.clip = BGMArr[0];
        BGMSource.Play();
    }

    public void PlayEffectSound(int effectSoundID) {
        //this method is to instiate the audiosource but it creates the problem later also cannot control the sound on the inspector
        //AudioSource.PlayClipAtPoint(EffectSoudArr[effectSoundID], transform.position);
        EffectSource.PlayOneShot(EffectArr[effectSoundID]);

    }
}
