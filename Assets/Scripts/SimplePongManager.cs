using UnityEngine;
using TMPro;

public class SimplePongManager : MonoBehaviour
{
    public Ball pelota;
    public float limitX = 9f;

    public TMP_Text textoJugador1;
    public TMP_Text textoJugador2;

    int p1 = 0, p2 = 0;

    void Update()
    {
        if (!pelota) return;

        float x = pelota.transform.position.x;

        if (x > limitX)
        {
            p1++;
            ActualizarMarcador();
            pelota.Reiniciar(false);
        }
        else if (x < -limitX)
        {
            p2++;
            ActualizarMarcador();
            pelota.Reiniciar(true);
        }
    }

    void ActualizarMarcador()
    {
        if (textoJugador1) textoJugador1.text = p1.ToString();
        if (textoJugador2) textoJugador2.text = p2.ToString();
    }
}
