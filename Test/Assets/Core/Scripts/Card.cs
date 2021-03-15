using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.EventSystems;
using System;

public class Card : MonoBehaviour, IPointerDownHandler
{
    public int strongCard = 2;
    public TypeSuit suitCard;
    public Action<Card> chekCard;
    public Sprite frontSide;
    public Sprite backSide; 
    public Color Active;
    public Color Deactive;

    private Image _cureentImg;

    private Tween _move;

    public void Awake()
    {
        _cureentImg = GetComponent<Image>();
    }
    public void SetCurrentSide(bool isFrontSide)
    {
        if (isFrontSide)
        {
            _cureentImg.sprite = frontSide;
        }
        else
        {
            _cureentImg.sprite = backSide;
        }
    }

    public void SetFocus(bool isFocus)
    {
        if (isFocus)
        {
            _cureentImg.color = Active;
            transform.SetAsLastSibling();           
        }
        else
        {
            _cureentImg.color = Deactive;
        }
    }

    public void CardSetPos(Vector3 position, float speed)
    {
        _move = transform.DOMove(position, speed).SetEase(Ease.Linear);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        chekCard.Invoke(this);
    }

    public void OnDestroy()
    {
        _move.Kill();
    }


}
