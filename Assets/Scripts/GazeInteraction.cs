using UnityEngine;
using TMPro;

public class GazeInteraction : MonoBehaviour
{
    public float tempoOlhar = 0.5f;
    public string textoInformativo = "Objeto do laboratório";
    public GameObject painelTexto;
    public TextMeshProUGUI textoUI;

    private float timerOlhar = 0f;
    private bool estaMostrandoTexto = false;
    private TeleportPoint teleportPoint;

    private static GameObject painelGlobal;
    private static TextMeshProUGUI textoGlobal;

    void Start()
    {
        teleportPoint = GetComponent<TeleportPoint>();
        if (painelGlobal == null)
            CriarPainelGlobal();
    }

    static void CriarPainelGlobal()
    {
        GameObject canvasObj = new GameObject("CanvasInfo");
        Canvas canvas = canvasObj.AddComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        canvas.sortingOrder = 100;
        canvasObj.AddComponent<UnityEngine.UI.CanvasScaler>();

        painelGlobal = new GameObject("PainelInfo");
        painelGlobal.transform.SetParent(canvasObj.transform);
        UnityEngine.UI.Image bg = painelGlobal.AddComponent<UnityEngine.UI.Image>();
        bg.color = new Color(0, 0, 0, 0.7f);
        RectTransform rectPanel = painelGlobal.GetComponent<RectTransform>();
        rectPanel.anchorMin = new Vector2(0.1f, 0.7f);
        rectPanel.anchorMax = new Vector2(0.9f, 0.9f);
        rectPanel.offsetMin = Vector2.zero;
        rectPanel.offsetMax = Vector2.zero;

        GameObject textoObj = new GameObject("TextoInfo");
        textoObj.transform.SetParent(painelGlobal.transform);
        textoGlobal = textoObj.AddComponent<TextMeshProUGUI>();
        textoGlobal.fontSize = 56;
        textoGlobal.color = Color.white;
        textoGlobal.alignment = TextAlignmentOptions.Center;
        RectTransform rectTexto = textoObj.GetComponent<RectTransform>();
        rectTexto.anchorMin = Vector2.zero;
        rectTexto.anchorMax = Vector2.one;
        rectTexto.offsetMin = new Vector2(10, 5);
        rectTexto.offsetMax = new Vector2(-10, -5);

        painelGlobal.SetActive(false);
    }

    public void IniciarOlhar()
    {
        if (teleportPoint != null)
        {
            teleportPoint.IniciarOlhar();
            return;
        }

        timerOlhar += Time.deltaTime;
        if (timerOlhar >= tempoOlhar && !estaMostrandoTexto)
        {
            estaMostrandoTexto = true;
            if (textoGlobal != null) textoGlobal.text = textoInformativo;
            if (painelGlobal != null) painelGlobal.SetActive(true);
        }
    }

    public void PararOlhar()
    {
        if (teleportPoint != null)
        {
            teleportPoint.PararOlhar();
            return;
        }

        timerOlhar = 0f;
        if (estaMostrandoTexto)
        {
            estaMostrandoTexto = false;
            if (painelGlobal != null) painelGlobal.SetActive(false);
        }
    }
}