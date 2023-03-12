using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pendulum : MonoBehaviour
{
    [SerializeField] float limit = 30f;
    private float extra;
    void Start()
    {
        extra = Random.Range(20, 91);
    }

    void Update()
    {
        //Угол будет изменяться по синусоиде
        float angle = limit * Mathf.Sin(Time.time + extra);     
        //Изменяем угол нашего маятника   
        transform.localRotation = Quaternion.Euler(angle, 0, 0);
    }
}
