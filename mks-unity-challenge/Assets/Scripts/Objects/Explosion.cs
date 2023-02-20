using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Explosion : MonoBehaviour
{
    void removeExplosion(){
        Destroy(this.gameObject);
    }
}
