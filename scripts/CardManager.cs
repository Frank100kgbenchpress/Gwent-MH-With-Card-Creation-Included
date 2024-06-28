using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour 
{
   List<Cards> Database{get; set;}
    public Cards Pop(Cards card)
    {
        Cards aux = card;
        Database.Remove(card);
        return aux;
    }
    public void Push(Cards card)
    {
        Database.Add(card);
    }
    public void SendBottom(Cards card)
    {
        Database.Insert(0,card);
    }
    public void Remove(Cards card)
    {
        Database.Remove(card);
    }
    public void Shuffle()
    {
        int n = Database.Count;
        while (n > 0)
        {
            n--;
            int k = Random.Range(0, n + 1);
            Cards aux = Database[k];
            Database[k] = Database[n];
            Database[n] = aux;
        }
    }
    public virtual void Start()
    {

    }
}
class Hand : CardManager
{
    public List<Cards> hand = new();
    public override void Start()
    {
        
    }
}
class Graveyard : CardManager
{
    public List<Cards> graveyard = new();
    public override void Start()
    {
        
    }
}
class Field : CardManager
{
    public UnitCards[] MeleeZone = new UnitCards[5];
    public UnitCards[] RangedZone = new UnitCards[5];
    public UnitCards[] SiegeZone = new UnitCards[5];
    public LeaderCard[] LeaderZone = new LeaderCard[1];
    public PowerUpCards[,] MeleeBoostZone = new PowerUpCards[3,1];
    public override void Start()
    {
        
    }
}