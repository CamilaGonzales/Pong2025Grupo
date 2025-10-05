using UnityEngine;

public class PaddleController : MonoBehaviour
{
    [Header("Teclas")]
    public KeyCode upKey = KeyCode.W;
    public KeyCode downKey = KeyCode.S;

    [Header("Movimiento")]
    public float speed = 10f;
    public float padding = 0.5f; // margen contra el borde

    float minY, maxY, halfHeight;

    void Start()
    {
        // altura de la paleta
        var sr = GetComponent<SpriteRenderer>();
        halfHeight = sr ? sr.bounds.extents.y : 0.8f;

        // límites de la cámara
        var cam = Camera.main;
        Vector3 top = cam.ViewportToWorldPoint(new Vector3(0.5f, 1f, 0f));
        Vector3 bottom = cam.ViewportToWorldPoint(new Vector3(0.5f, 0f, 0f));
        maxY = top.y - padding - halfHeight;
        minY = bottom.y + padding + halfHeight;
    }

    void Update()
    {
        float dir = 0f;
        if (Input.GetKey(upKey)) dir = 1f;
        else if (Input.GetKey(downKey)) dir = -1f;

        Vector3 pos = transform.position + Vector3.up * dir * speed * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        transform.position = pos;
    }
}
