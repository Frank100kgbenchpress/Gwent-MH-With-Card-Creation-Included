using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effects : MonoBehaviour
{
   /*void RowPowerUpp(Cards cardPlayed,int zone,bool UpOrDown,int ammount)
   {
      //int cardPosition = cardPlayed.GetComponent<DisplayCard>().position;
      //displayCard[] cards = zone1.GetComponentsInChildren<DisplayCard>();
      if(UpOrDown)
      {
         foreach(var UnitCards in cards)
         {
            UnitCards.points += ammount;
            UnitCards.attackText.text = UnitCards.points.ToString();
         }
         return;
      }
      foreach(var UnitCards in cards)
         {
            UnitCards.points += ammount;
            UnitCards.attackText.text = UnitCards.points.ToString();
         }     
   }
   */
   /*void DestroyHightAttack()
    {
        int max = int.MinValue;
        int maxenemy = int.MinValue;
        GameObject destroy = null;
        GameObject destroyE = null;
        zone1 = GameObject.Find("UnitZones");
        foreach (var zone in zone1.transform)
        {
            displayCard[] cards = zone1.GetComponentsInChildren<displayCard>();
            foreach (var card in cards)
            {
                if(card.card.golden)
                {
                    continue;
                }   
                if(card.points > max)
                {
                    max = card.points;
                    destroy = card.gameObject;
                }
            }  
        }
        zone2 = GameObject.Find("EnemyUnitsZones");
        foreach (var zone in zone2.transform)
        {
            displayCard[] cards = zone2.GetComponentsInChildren<displayCard>();
            foreach (var card in cards)
            {
                if(card.card.golden)
                {
                    continue;
                }   
                if(card.points > max)
                {
                    max = card.points;
                    destroyE = card.gameObject;
                }
            }  
        }
        if(max>maxenemy)
        {
            Destroy(destroy);
        }
        else
        {
            Destroy(destroyE);
        }
    }*/
}
