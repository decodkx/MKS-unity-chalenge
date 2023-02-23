using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RippleEffect : MonoBehaviour
{
    public Boat boat;
    public GameObject ripple;
    public float distance = 0.6f;
    float maxTime = 0.25f;
    float time;

    void Start()
    {
        boat = gameObject.GetComponent<Boat>();
        time = maxTime;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (boat.rb.velocity.magnitude > 0.2)
            DeployRipple();
    }

    private void DeployRipple()
    {
        time -= Time.deltaTime;
        if (time <= 0)
        {
            Instantiate(ripple, transform.position + DegreeToVector(transform.eulerAngles.z - 90) * distance, boat.transform.rotation);
            time = maxTime;
        }
    }

    private void OnDrawGizmosSelected(){
        Gizmos.color = Color.magenta;
        Gizmos.DrawLine(transform.position, transform.position + DegreeToVector(transform.eulerAngles.z -90)*1);
    }

    private Vector3 DegreeToVector(float angle)
    {   //Transforma o angulo da agulha, num vetor ortogonal a linha que conecta player e inimigo
        float radians = angle * Mathf.Deg2Rad;
        return new Vector3(Mathf.Cos(radians), Mathf.Sin(radians), 0);
    }
}
