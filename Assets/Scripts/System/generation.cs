using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Generation : MonoBehaviour
{
    public GameObject[] objetosaleatorios;
    public Transform[] locaisaleatorios;

    public float tempoentreobjetos;
    public float tempo;

    void Start()
    {
        // tempo pode começar zerado ou já com o intervalo inicial
        tempo = tempoentreobjetos;
    }

    void Update()
    {
        tempo -= Time.deltaTime;

        if (tempo <= 0)
        {
            int objaleatorio = Random.Range(0, objetosaleatorios.Length);
            int ptaleatorio = Random.Range(0, locaisaleatorios.Length);
            Instantiate(objetosaleatorios[objaleatorio], locaisaleatorios[ptaleatorio].position, locaisaleatorios[ptaleatorio].rotation);
            tempo = tempoentreobjetos;
        }
    }
}
