using UnityEngine;

public class GazeController : MonoBehaviour
{
    public float distanciaMaxima = 15f;
    private GazeInteraction objetoAtual = null;

    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, distanciaMaxima))
        {
            GazeInteraction gaze = hit.collider.GetComponentInParent<GazeInteraction>();
            if (gaze == null)
                gaze = hit.collider.GetComponentInChildren<GazeInteraction>();

            if (gaze != null)
            {
                if (objetoAtual != gaze)
                {
                    if (objetoAtual != null) objetoAtual.PararOlhar();
                    objetoAtual = gaze;
                }
                objetoAtual.IniciarOlhar();
            }
            else
            {
                if (objetoAtual != null) { objetoAtual.PararOlhar(); objetoAtual = null; }
            }
        }
        else
        {
            if (objetoAtual != null) { objetoAtual.PararOlhar(); objetoAtual = null; }
        }
    }
}