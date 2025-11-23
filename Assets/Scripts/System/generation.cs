using UnityEngine;                        // Biblioteca principal do Unity
using System.Collections;                // Coleções não genéricas
using System.Collections.Generic;        // Coleções genéricas

public class Generation : MonoBehaviour  // Classe responsável pela geração de objetos
{
    public GameObject[] objetosaleatorios; // Prefabs que podem aparecer
    public Transform[] locaisaleatorios;   // Locais onde podem surgir

    public float tempoentreobjetos;        // Intervalo de tempo entre objetos
    public float tempo;                    // Temporizador interno

    void Start()                           // Executado no início
    {
        // tempo inicia com tempoentreobjetos (o intervalo inicial)
        tempo = tempoentreobjetos;         // Define o valor inicial do tempo
    }                                      // Fim do Start

    void Update()                          // Chamado a cada frame
    {
        tempo -= Time.deltaTime;           // Diminui o temporizador

        if (tempo <= 0)                    // Quando o tempo chega a zero
        {
            int objaleatorio = Random.Range(0, objetosaleatorios.Length); // Escolhe objeto
            int ptaleatorio = Random.Range(0, locaisaleatorios.Length);   // Escolhe posição
            Instantiate(objetosaleatorios[objaleatorio], locaisaleatorios[ptaleatorio].position, locaisaleatorios[ptaleatorio].rotation); // Instancia o objeto
            tempo = tempoentreobjetos;     // Reinicia o temporizador
        }                                  // Fim do if
    }                                      // Fim do Update
}                                          // Fim da classe
