using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GameContext : MonoBehaviour
{
    public Text pointsUi;

    public int cardsCount = 13;

    public RectTransform spawnPoint;

    public PlayerHandler player;

    public TypeSuit currentTypeSuit = TypeSuit.C;

    public float speedCardToTable = 0.5f;

    public Stack<Card> cards;

    private CardRegister _cardRegister;

    private int point = 0;

    public void Start()
    {       
        player.playerTurn += PlayerTurn;
        CardInst();
    }


    private void PlayerTurn(Card card)
    {
        StartCoroutine(CardReset(card));              
    }

    private IEnumerator CardReset(Card card)
    {
        card.CardSetPos(spawnPoint.position, speedCardToTable);
        yield return new WaitForSeconds(2f);
        Destroy(card.gameObject);
        point++;
        pointsUi.text = point.ToString();
        player.WaitingNextTurn();
    }


  

    private void CardInst()
    {
        _cardRegister = GetComponent<CardRegister>();
        cards = _cardRegister.GetRandomStackCards(cardsCount);

        List<Card> cardsToPlayer = new List<Card>();

        while (cards.Count != 0)
        {
            var instCard = cards.Pop();
            cardsToPlayer.Add(Instantiate(instCard, spawnPoint));            
        }

        player.GetCards(cardsToPlayer);
    }

   
}

public enum GameState
{
    Distribution,
    PlayersWaitingTurn,
    PlayersTurn

}
