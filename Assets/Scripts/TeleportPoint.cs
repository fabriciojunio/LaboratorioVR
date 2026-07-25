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
        if (cameraRig == null && Camera.main != null)
            cameraRig = Camera.main.transform;
        if (cameraRig == null)
            Debug.LogWarning("TeleportPoint sem cameraRig e sem Camera.main na cena; o teletransporte ficara inativo.", this);
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
        if (cameraRig == null) return;
        cameraRig.position = new Vector3(
            transform.position.x,
            cameraRig.position.y,
            transform.position.z
        );
        timer = 0f;
    }
}