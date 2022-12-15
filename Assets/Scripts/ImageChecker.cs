using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageChecker : MonoBehaviour
{
    public Image image;
    public SpriteRenderer CurseRadius;
    public SpriteRenderer CurseCenter;
    public SpriteRenderer Antidote;
    [SerializeField] private float max = 100;
    [SerializeField] private float now = 0;
    [SerializeField] private float increaser = 5;
    private void Start()
    {
        image = GetComponent<Image>();
        image.fillAmount = now / max;
    }
    private void Update()
    {
        image.fillAmount = now / max;
        if (now > max / 3)
        {
            Antidote.color = new Color(Antidote.color.r, Antidote.color.g, Antidote.color.b, 0f);
            CurseCenter.color = new Color(CurseCenter.color.r, CurseCenter.color.g, CurseCenter.color.b, 0f);
            CurseRadius.color = new Color(CurseRadius.color.r, CurseRadius.color.g, CurseRadius.color.b, 0f);
        }
        else
        {
            CurseCenter.color = new Color(CurseCenter.color.r, CurseCenter.color.g, CurseCenter.color.b, 1f);
            CurseRadius.color = new Color(CurseRadius.color.r, CurseRadius.color.g, CurseRadius.color.b, 0.5f);
        }
        if(now > 2 * max / 3)
        {
            image.fillAmount = 0;
        }
        else
        {
            image.fillAmount = now / max;
        }
    }
    public void Updatenow()
    {
        if (now+increaser>max)
        {
            now = max;
        }
        else
        {
            now += increaser;
        }
    }
    public void Reversenow()
    {
        if (now - increaser <0)
        {
            now = 0;
        }
        else
        {
            now -= increaser;
        }
    }
    public float GetKoeff()
    {
        return now / max;
    }
}
