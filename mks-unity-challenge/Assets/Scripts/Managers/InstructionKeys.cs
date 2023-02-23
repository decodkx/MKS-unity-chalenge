using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InstructionKeys : MonoBehaviour
{
    public Sprite[] sprites;
    public Image[] images;
    public TMP_Text[] texts;
    void Start()
    {
        texts[0].text = "";
        texts[1].text = "";
        texts[2].text = "";
        texts[3].text = "";
        texts[4].text = "";
    }

    // Update is called once per frame
    void Update()
    {
        //botoes pressionados
        if(Input.GetKeyDown(KeyCode.W)){
            images[0].sprite = sprites[5];
            texts[0].text = "Impulsiona a embarcação para frente";
        }
        if(Input.GetKeyDown(KeyCode.A)){
            images[1].sprite = sprites[6];
            texts[1].text = "Rotaciona o barco para a esquerda";
        }
        if(Input.GetKeyDown(KeyCode.D)){
            images[2].sprite = sprites[7];
            texts[2].text = "Rotaciona o barco para a direita";
        }
        if(Input.GetKeyDown(KeyCode.J)){
            images[3].sprite = sprites[8];
            texts[3].text = "Aciona o canhão frontal";
        }
        if(Input.GetKeyDown(KeyCode.K)){
            images[4].sprite = sprites[9];
            texts[4].text = "Aciona os canhões laterais";
        }

        //botoes soltados
        if(Input.GetKeyUp(KeyCode.W)){
            images[0].sprite = sprites[0];
            texts[0].text = "";
        }
        if(Input.GetKeyUp(KeyCode.A)){
            images[1].sprite = sprites[1];
            texts[1].text = "";
        }
        if(Input.GetKeyUp(KeyCode.D)){
            images[2].sprite = sprites[2];
            texts[2].text = "";
        }
        if(Input.GetKeyUp(KeyCode.J)){
            images[3].sprite = sprites[3];
            texts[3].text = "";
        }
        if(Input.GetKeyUp(KeyCode.K)){
            images[4].sprite = sprites[4];
            texts[4].text = "";
        }
    }
}
