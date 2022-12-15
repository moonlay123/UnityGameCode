using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class CurseCheck : MonoBehaviour
{
    public ImageHpChecker hpChecker;
    public ImageChecker checker;
    private float cursedmgtime = 0;
    [SerializeField] private float cursetime=1f;
    [SerializeField] private float antidotetime = 0.5f;
    [SerializeField] private LayerMask curse;
    [SerializeField] Collider2D col2d;
    [SerializeField] private bool coroutinescurse = false;
    [SerializeField] private bool coroutinesantiodote = false;
    public SpriteRenderer Antidote;
    public GameObject AntidoteCenter;
    private void Start()
    {
        col2d = GetComponent<Collider2D>();
        Antidote.color = new Color(Antidote.color.r, Antidote.color.g, Antidote.color.b, 0);
    }
    private void Update()
    {
        cursedmgtime += Time.deltaTime;
        if (cursedmgtime > 2)
        {
            Debug.Log("fdgdfg");
            hpChecker.Reversenow(checker.GetKoeff() * 10f);
            cursedmgtime = 0;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "AntidoteZone" && !coroutinesantiodote)
        {
            coroutinesantiodote = true;
            coroutinescurse = false;
            StopAllCoroutines();
            StartCoroutine(Antidoter());
        }
        else if (collision.tag=="Cursezone" && !coroutinescurse && !coroutinesantiodote)
        {
            AntidoteCenter.transform.eulerAngles = new Vector3(AntidoteCenter.transform.eulerAngles.x, AntidoteCenter.transform.eulerAngles.y,Random.Range(0f,360f));
            Antidote.color = new Color(Antidote.color.r, Antidote.color.g, Antidote.color.b, 0.8f);
            coroutinescurse = true;
            StopAllCoroutines();
            StartCoroutine(Curse());
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "AntidoteZone")
        {
            coroutinesantiodote = false;
            StopAllCoroutines();
            StartCoroutine(Curse());
        }
        else if (collision.tag=="Cursezone")
        {
            Antidote.color = new Color(Antidote.color.r, Antidote.color.g, Antidote.color.b, 0);
            coroutinescurse = false;
            StopAllCoroutines();
        }
    }
    public IEnumerator Curse()
    {
        while (1>0)
        {
            yield return new WaitForSeconds(cursetime);
            checker.Updatenow();
        }
    }
    public IEnumerator Antidoter()
    {
        while (1 > 0)
        {
            yield return new WaitForSeconds(antidotetime);
            checker.Reversenow();
        }
    }
}
