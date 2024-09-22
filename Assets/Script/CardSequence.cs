using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CardSequence : MonoBehaviour
{
    private Vector3 originalScale;
    public float enlargeScaleFactor = 1.2f;
    public float animationDuration = 0.3f;

    void Start()
    {
        originalScale = transform.localScale;
    }

    void OnMouseEnter()
    {
        transform.DOScale(originalScale * enlargeScaleFactor, animationDuration);
    }

    void OnMouseExit()
    {
        transform.DOScale(originalScale, animationDuration);
    }

    void OnMouseDown()
    {
        transform.DORotate(new Vector3(180f, 0, 0), animationDuration, RotateMode.LocalAxisAdd).OnComplete(() =>
        {
            ShakeCard();
        });
    }

    private void ShakeCard()
    {
        transform.DOShakePosition(0.5f, strength: new Vector3(0.01f, 0.01f, 0), vibrato: 7, randomness: 30);
    }
}

