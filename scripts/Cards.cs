using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public enum Type
    {
        Gold,
        Silver,
        Weather,
        Boost,
        Leader,
    }
public abstract class Cards : ScriptableObject
{
    public string Name{get;protected set;}
    public string Description{get;protected set;}
    public bool Team {get;protected set;}
    protected Guid Id {get;set;}
    public Type Type{get ; set;}
    
    protected string[] Range{get;set;}
    public  Cards(string name,string description,bool team,Guid id,string[]range,Type type)
    {
        Name = name;
        Description = description;
        Team = team;
        Id = id;
        Range = range;
        Type = type;
    } 
}
public abstract class CardsWithAttack : Cards
{
    public int Attack {get;set;}
    DisplayCardWithAttack DisplayCardWithAttack {get;set;}
    public CardsWithAttack(string name,string description,bool team,Guid id,int attack,string [] range,Type type,DisplayCardWithAttack displayCardWithAttack) : base(name,description,team,id,range,type)
    {
        DisplayCardWithAttack = displayCardWithAttack;
        Attack = attack;
    }
    
}
public class GoldCards : CardsWithAttack
{
    GoldCards(string name,string description,bool team,Guid id,int attack,string [] range,Type type,DisplayCardWithAttack displayCardWithAttack) : base(name,description,team,id,attack,range,type,displayCardWithAttack)
    {

    }   
}
public class UnitCards : CardsWithAttack
{
    UnitCards(string name,string description,bool team,Guid id,int attack,string [] range,Type type,DisplayCardWithAttack displayCardWithAttack) : base(name,description,team,id,attack,range,type,displayCardWithAttack)
    {
        
    }
}
public abstract class CardsWithEffect : Cards
{
    public DisplayCard DisplayCard {get;set;}
    public CardsWithEffect(string name,string description, bool team, Guid id,string[] range,Type type,DisplayCard displayCard) : base(name,description,team,id,range,type)
    {
        DisplayCard = displayCard;
    }
}
public class WeatherCard : CardsWithEffect
{
    WeatherCard(string name,string description, bool team, Guid id,string[] range,Type type,DisplayCard displayCard): base(name,description,team,id,range,type,displayCard)
    {

    }
}
public class LeaderCard : CardsWithEffect
{
    LeaderCard(string name,string description, bool team, Guid id,string[] range,Type type,DisplayCard displayCard): base(name,description,team,id,range,type,displayCard)
    {

    }
}
public class PowerUpCards : CardsWithEffect
{
    PowerUpCards(string name,string description, bool team, Guid id,string[] range,Type type,DisplayCard displayCard): base(name,description,team,id,range,type,displayCard)
    {

    }
}