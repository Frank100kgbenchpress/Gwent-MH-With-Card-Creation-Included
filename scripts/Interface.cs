using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
interface IMoveAroundArray 
{
    Cards[] MoveAroundArray(Cards[] cards,string action,string position)
    {
        if(cards.Length==0)
        {
            return cards;
        }
        for(int i = 0; i < cards.Length;i++);
        return cards;
    }
}
/*
interface CleanField
{
    void Clean() //This method eliminates the cards from the field
    {
        GameObject units = GameObject.Find("UnitsZones");
        foreach(Transform zone in units.transform)
        {
            foreach(Transform card in zone.transform)
            {
                Destroy(card.gameObject);
            }
        }
        GameObject units1 = GameObject.Find("EnemyUnitsZones");
        foreach(Transform zone in units1.transform)
        {
            foreach(Transform card in zone.transform)
            {
                Destroy(card.gameObject);
            }
        }
        GameObject support = GameObject.Find("SupportZone");
        foreach(Transform zone in support.transform)
        {
            foreach(Transform card in zone.transform)
            {
                Destroy(card.gameObject);
            }
        }
        GameObject support1 = GameObject.Find("EnemySupportZones");
        foreach(Transform zone in support1.transform)
        {
            foreach(Transform card in zone.transform)
            {
                Destroy(card.gameObject);
            }
        }
        GameObject weather = GameObject.Find("WeatherZone");
        foreach(Transform card in weather.transform)
        {
            displayCard cardDisplay = card.gameObject.GetComponent<displayCard>();
            Destroy(card.gameObject);
        }
    }
    
}
*/