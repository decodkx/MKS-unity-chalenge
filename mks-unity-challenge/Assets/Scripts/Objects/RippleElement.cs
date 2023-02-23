using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RippleElement : MonoBehaviour
{
    float rippleSpeed = 0.0008f;

    void Update()
    {
        transform.position -= transform.up * rippleSpeed;
    }

	public void Exclude()
	{
        Destroy(gameObject);
	}
}
