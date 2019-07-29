using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AnimationHash
{
    //readonly sets the word as superior 
    // this is cheap and effective way of setting the animation 
    //creating hte static class will less overload the game
    public static readonly int Walk = Animator.StringToHash("isWalk");
    public static readonly int Melee = Animator.StringToHash("IsMelee");

}
