using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class PlayerHandler : MonoBehaviour
{
    public RectTransform hadler;

    public Transform leftHandlerBord;
    public Transform rightHandlerBord;

    public float deltaShiftForFocusCard = 30f;

    public float timeTakeCardOnHanle = 1f;
    public float timeIntervalBetweenTakingCards = 0.3f;
    public float timeForSortCardInHand = 0.5f;

    [HideInInspector]
    public List<Card> cardInHand = new List<Card>();

    private bool isTurn = false;

    public Action<GameState> currentPlayerState;
    public Action<Card> playerTurn;

    private TypeSuit currentTypeSuit;

    public void Awake()
    {
        currentPlayerState += GameStateListener;
    }

    public void GetCards(List<Card> cards)
    {
        currentPlayerState.Invoke(GameState.Distribution);
        cardInHand = cards;     
        StartCoroutine(TakingKards());      
    }

    public void WaitingNextTurn()
    {
        currentPlayerState.Invoke(GameState.PlayersWaitingTurn);
        SetNexRandomCardSuid();
        SortCardsOnHand();
    }

    private void SetNexRandomCardSuid()
    {
        System.Random random = new System.Random();
        currentTypeSuit = (TypeSuit)random.Next(0, 3);       
    }


    IEnumerator TakingKards()
    {
        foreach(var card in cardInHand)
        {
            card.SetCurrentSide(false);
        }

        for (int i = 0; i < cardInHand.Count; i++)
        {
            Vector3 posX = Vector3.Lerp(leftHandlerBord.position, rightHandlerBord.position, (i / (cardInHand.Count - 1f)));
            cardInHand[i].CardSetPos(posX, timeTakeCardOnHanle);
            cardInHand[i].SetCurrentSide(true);
            yield return new WaitForSeconds(timeIntervalBetweenTakingCards);
            cardInHand[i].chekCard += TurnPlayer;
        }
        yield return new WaitForSeconds(1f);
        WaitingNextTurn();

    }

    private void GameStateListener(GameState state)
    {
        switch (state)
        {              
                case GameState.PlayersWaitingTurn:
                {                 
                    isTurn = true;
                    break;
                }

                default:
                {
                    isTurn = false;
                    break;
                }
        }
    }

    private void TurnPlayer(Card curentCard)
    {
        if (isTurn && curentCard.suitCard == currentTypeSuit)
        {
            currentPlayerState.Invoke(GameState.PlayersTurn);
            playerTurn.Invoke(curentCard);
            cardInHand.Remove(curentCard);
        }
    }

    private void SortCardsOnHand()
    {
        var newCardOrderOnHand = cardInHand.OrderBy(o => o.suitCard);
        cardInHand = newCardOrderOnHand.ToList();

        int firstIndex = cardInHand.FindIndex(o => o.suitCard == currentTypeSuit);
        int lastIndex = cardInHand.FindLastIndex(o => o.suitCard == currentTypeSuit);

        for (int i = 0; i < cardInHand.Count; i++)
        {
            cardInHand[i].transform.SetAsLastSibling();

            Vector3 posX = Vector3.Lerp(leftHandlerBord.position, rightHandlerBord.position, (i / (cardInHand.Count - 1f)));

            if(i < firstIndex)
            {
                posX -= new Vector3(deltaShiftForFocusCard, 0f, 0f);
            }
            if (i > firstIndex)
            {
                posX += new Vector3(deltaShiftForFocusCard, 0f, 0f);
            }

            cardInHand[i].CardSetPos(posX, timeForSortCardInHand);

            if (cardInHand[i].suitCard == currentTypeSuit)
                cardInHand[i].SetFocus(true);
            else
                cardInHand[i].SetFocus(false);
        }     
    }
    

   

   
}
