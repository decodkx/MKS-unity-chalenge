using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private GameObject sliderPrefab;
    private GameObject slider;
    private Transform fill;
    private GameObject actor;
    private float offsetY = 1.3f;

    #region DefaultValues
        private Vector3 adjust = Vector3.zero;
        private Vector3 position = new Vector3(2300,2300,2300);
        private Quaternion rotation= Quaternion.Euler(0,0,0);
    #endregion
    
    void Start()
    {  
        slider = Instantiate(sliderPrefab, position, rotation);
        actor = this.gameObject;
        fill = slider.transform.GetChild(0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        adjust.y = offsetY; // change to start when satisfied 
        slider.transform.position = actor.transform.position + adjust;
    }

    public void UpdateVisuals(float value){
        fill.localScale = new Vector3 (value,1,1);
    }
}
