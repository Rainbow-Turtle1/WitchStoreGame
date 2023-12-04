using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Randomizer : MonoBehaviour
{
    [SerializeField] private Sprite[] spriteArray;  
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (spriteArray.Length > 0)
        {
            SetRandomSprite();
        }
        else
        {
            Debug.LogError("No sprites.");
        }
    }

    void SetRandomSprite()
    {
        int randomIndex = Random.Range(0, spriteArray.Length);

        spriteRenderer.sprite = spriteArray[randomIndex];
    }
}
