using UnityEngine;
public interface ICard 
{
    int StrongCard { get; }
    TypeSuit Suit { get; }
    GameObject gameObject { get; }
    void Focus(bool isFocus);
    void Selected();

}

public enum TypeSuit
{
    C,
    D,
    H,
    S
}
