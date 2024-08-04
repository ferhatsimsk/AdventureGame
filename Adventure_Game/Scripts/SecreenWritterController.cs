using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SecreenWritterController : MonoBehaviour
{
    public TextMeshProUGUI[] textMeshObjects;
    public float displayDuration = 7f;

    private int currentIndex = 0;
    private float timer = 0f;
    private bool isDisplaying = false;

    private void Start()
    {
        HideAllTextMeshObjects();
    }

    private void Update()
    {
        if (!isDisplaying)
        {
            ShowNextTextMeshObject();
        }
        else
        {
            timer += Time.deltaTime;

            if (timer >= displayDuration)
            {
                HideCurrentTextMeshObject();
                ShowNextTextMeshObject();
            }
        }
    }

    private void ShowNextTextMeshObject()
    {
        HideAllTextMeshObjects();

        if (currentIndex < textMeshObjects.Length)
        {
            textMeshObjects[currentIndex].gameObject.SetActive(true);
            isDisplaying = true;
            timer = 0f;
            currentIndex++;
        }
    }

    private void HideCurrentTextMeshObject()
    {
        if (currentIndex - 1 >= 0 && currentIndex - 1 < textMeshObjects.Length)
        {
            textMeshObjects[currentIndex - 1].gameObject.SetActive(false);
        }
    }

    private void HideAllTextMeshObjects()
    {
        foreach (TextMeshProUGUI textMeshObject in textMeshObjects)
        {
            textMeshObject.gameObject.SetActive(false);
        }
    }
}
