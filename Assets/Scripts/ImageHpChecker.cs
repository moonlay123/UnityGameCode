using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageHpChecker : MonoBehaviour
{
    public Image image;
    [SerializeField] private float max = 100;
    [SerializeField] private float now = 100;
    private void Start()
    {
        image = GetComponent<Image>();
        image.fillAmount = now / max;
    }
    private void Update()
    {
        image.fillAmount = now / max;
    }
    public void Updatenow(float increaser)
    {
        if (now + increaser > max)
        {
            now = max;
        }
        else
        {
            now += increaser;
        }
    }
    public void Reversenow(float increaser)
    {
        if (now - increaser < 0)
        {
            now = 0;
        }
        else
        {
            now -= increaser;
        }
    }
}
