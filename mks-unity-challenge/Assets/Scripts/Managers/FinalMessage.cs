using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinalMessage : MonoBehaviour
{
   public TMP_Text message_Text;
   public TMP_Text score_Text;
    void Start()
    {
        if(GameManagment.gameManager.GetVictory())
            message_Text.text = "Você venceu!";
        else
            message_Text.text = "Você perdeu :(";

        score_Text.text = $"Pontuação:      {GameManagment.gameManager.GetScore()}";
    }
}
