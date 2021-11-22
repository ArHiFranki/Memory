using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class MemoryCard : MonoBehaviour
{
    [SerializeField] private GameObject _cardBack;
    [SerializeField] private SceneController _sceneController;

    private int _id;

    public int Id => _id;

    public void OnMouseDown()
    {
        if (_cardBack.activeSelf && _sceneController.CanReveal)
        {
            _cardBack.SetActive(false);
            _sceneController.CardRevealed(this);
        }
    }

    public void SetCard(int id, Sprite image)
    {
        _id = id;
        GetComponent<SpriteRenderer>().sprite = image;
    }

    public void Unreveal()
    {
        _cardBack.SetActive(true);
    }
}
