using UnityEngine;

public class TeleportPoint : MonoBehaviour
{
    public float tempoOlhar = 2f;
    public Transform cameraRig;
    private float timer = 0f;
    private Renderer rend;
    private Color corOriginal;

    void Start()
    {
        rend = GetComponent<Renderer>();
        if (rend != null) corOriginal = rend.material.color;
        if (cameraRig == null)
            cameraRig = Camera.main.transform;
    }

    public void IniciarOlhar()
    {
        timer += Time.deltaTime;
        float progresso = timer / tempoOlhar;
        if (rend != null)
            rend.material.color = Color.Lerp(corOriginal, Color.green, progresso);
        if (timer >= tempoOlhar)
            Teleportar();
    }

    public void PararOlhar()
    {
        timer = 0f;
        if (rend != null)
            rend.material.color = corOriginal;
    }

    void Teleportar()
    {
        cameraRig.position = new Vector3(
            transform.position.x,
            cameraRig.position.y,
            transform.position.z
        );
        timer = 0f;
    }
}