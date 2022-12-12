using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Destroy : MonoBehaviour
{
    [SerializeField]
    GameObject prefabParticles;

    [SerializeField]
    Slider temporizador;

    [SerializeField]
    public float timeMax = 30;
    public float timeMin = 10;
    

    [SerializeField]
    float timer;

    [SerializeField]
    TextMeshProUGUI contador;
    public void Start()
    {

        timer = Random.Range(timeMin, timeMax);
        temporizador.maxValue = timer;

    }

    public void Update()
    {
        
        timer -= Time.deltaTime;
        temporizador.value = timer;
        contador.text = timer.ToString();
        if (temporizador.value <= 0)
        {
            timer = 0;
            contador.text = timer.ToString();
            Instantiate(prefabParticles, gameObject.transform.position, Quaternion.identity);
            LeanTween.scale(gameObject, Vector3.zero, 1f).setOnComplete(() =>
            {
                
                Destroy(gameObject);
            });

        }
        


    }
}
