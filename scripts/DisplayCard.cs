using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class DisplayCard : MonoBehaviour
{
    public CardsWithEffect card1;
    public TextMeshProUGUI description;
    public TextMeshProUGUI nameText;
    public Image artImage;
    public bool team;
    public bool boost;
    string type;
    protected virtual void Start()
    {
        nameText.text = card1.Name;
        description.text = card1.Description;
        type = card1.Type.ToString();
    }

}
public class DisplayCardWithAttack : DisplayCard 
{
    public CardsWithAttack card;
    public TextMeshProUGUI attackText;
    public int points;
    public int attackOriginal;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        attackText.text = card.Attack.ToString();
        //artImage.sprite = card.cardImage;
        attackOriginal = card.Attack;
        points = card.Attack;
    } 
}
