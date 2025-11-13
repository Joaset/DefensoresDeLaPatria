using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ataque4Jefe1State : IJefeState
{
    private JefeController jefe;
    private Transform player;
    private Vector3 targetCorner;
    private float moveSpeed = 5f;
    private float waitBeforeBomb = 1.5f;
    private float timer;
    private bool reachedCorner = false;
    private Vector3 ultimaPosPlayer;

    public void Enter(JefeController jefe)
    {
        this.jefe = jefe;
        player = jefe.player;
        timer = 0f;
        reachedCorner = false;

        // Guardamos la última posición del jugador
        ultimaPosPlayer = player.position;

        // Elegimos la esquina más lejana al jugador
        targetCorner = ElegirEsquinaMasLejana();

        // Activamos animación de movimiento o desplazamiento
        //jefe.animator.SetTrigger("Ataque4);
    }

    public void Update()
    {
        if (!reachedCorner)
        {
            // Mover hacia la esquina elegida
            jefe.transform.position = Vector2.MoveTowards(
                jefe.transform.position,
                targetCorner,
                moveSpeed * Time.deltaTime
            );

            if (Vector2.Distance(jefe.transform.position, targetCorner) < 0.1f)
            {
                reachedCorner = true;
                timer = 0f;
            }
        }
        else
        {
            timer += Time.deltaTime;
            if (timer >= waitBeforeBomb)
            {
                LanzarBombardeo();
                jefe.ChangeState(new IdleJefeState());
            }
        }
    }

    public void Exit(){}

    // === Métodos auxiliares ===

    private Vector3 ElegirEsquinaMasLejana()
    {
        // Suponiendo que el jefe tiene un arreglo de esquinas públicas
        // (las podés arrastrar desde el editor)
        Transform[] esquinas = jefe.esquinas;

        Vector3 esquinaMasLejana = esquinas[0].position;
        float mayorDistancia = Vector2.Distance(player.position, esquinaMasLejana);

        foreach (Transform esquina in esquinas)
        {
            float dist = Vector2.Distance(player.position, esquina.position);
            if (dist > mayorDistancia)
            {
                mayorDistancia = dist;
                esquinaMasLejana = esquina.position;
            }
        }

        return esquinaMasLejana;
    }

    private void LanzarBombardeo()
    {
        // Crea una lluvia de proyectiles en la última posición conocida del jugador
        int cantidad = 5;
        float dispersion = 1.5f;

        for (int i = 0; i < cantidad; i++)
        {
            Vector3 spawnPos = new Vector3(
                ultimaPosPlayer.x + Random.Range(-dispersion, dispersion),
                ultimaPosPlayer.y + 8f,
                0
            );

            GameObject proyectil = PoolManagerJefe1.instance.GetFromPool("Bolas");
            proyectil.transform.position = spawnPos;
            proyectil.GetComponent<Rigidbody2D>().velocity = Vector2.down * 8f;
        }
    }
}
