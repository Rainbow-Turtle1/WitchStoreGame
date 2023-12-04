using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourRandomizer : MonoBehaviour
{
     [SerializeField] private Color[] availableColors; 

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (availableColors != null && availableColors.Length > 0)
        {
            SetRandomColor();
        }
        else
        {
            Debug.LogError("Please assign colors to the 'availableColors' array in the Unity Editor.");
        }
    }

    void SetRandomColor()
    {
        int randomIndex = Random.Range(0, availableColors.Length);

        spriteRenderer.color = availableColors[randomIndex];
    }
}
