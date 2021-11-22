using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    public const int gridRows = 2;
    public const int gridCols = 4;
    public const float offsetX = 2f;
    public const float offsetY = 2.5f;

    [SerializeField] private MemoryCard _originalCard;
    [SerializeField] private Sprite[] _images;

    private void Start()
    {
        Vector3 startPosition = _originalCard.transform.position;

        int[] numbers = { 0, 0, 1, 1, 2, 2, 3, 3 };
        numbers = ShuffleArray(numbers);

        for (int i = 0; i < gridCols; i++)
        {
            for (int j = 0; j < gridRows; j++)
            {
                MemoryCard card;
                if (i == 0 && j == 0)
                {
                    card = _originalCard;
                }
                else
                {
                    card = Instantiate(_originalCard);
                }

                int index = j * gridCols + i;
                int id = numbers[index];
                card.SetCard(id, _images[id]);

                float positionX = (offsetX * i) + startPosition.x;
                float positionY = -(offsetY * j) + startPosition.y;

                card.transform.position = new Vector3(positionX, positionY, startPosition.z);
            }
        }
    }

    private int[] ShuffleArray(int[] numbers)
    {
        int[] newArray = numbers.Clone() as int[];

        for (int i = 0; i < newArray.Length; i++)
        {
            int tmp = newArray[i];
            int randomNumber = Random.Range(i, newArray.Length);
            newArray[i] = newArray[randomNumber];
            newArray[randomNumber] = tmp;
        }

        return newArray;
    }
}
