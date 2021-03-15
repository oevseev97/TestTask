using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CardRegister : MonoBehaviour
{
    public List<Card> cards = new List<Card>();

    public Stack<Card> GetRandomStackCards(int count)
    {
        Stack<Card> result = new Stack<Card>();
        System.Random random = new System.Random();

        for(int i = 0; i < count; i++)
        {
            result.Push(cards[random.Next(0, cards.Count - 1)]);
        }

        return result;
    }
}
