using UnityEngine;
using TMPro;

public class GyroCam : MonoBehaviour
{
    public float sensibilidade = 2f;
    public bool usarGiroscopio = false;
    private float rotX = 0f;
    private float rotY = 0f;
    private Gyroscope gyro;
    private bool gyroDisponivel = false;
    private Quaternion offset;
    private Quaternion targetRotation;
    public float suavizacao = 10f;

    void Start()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        targetRotation = transform.rotation;
        if (SystemInfo.supportsGyroscope)
        {
            gyro = Input.gyro;
            gyro.enabled = true;
            gyroDisponivel = true;
            offset = Quaternion.Euler(90f, 0f, 0f);
        }
        CreateCursor();
        CreateBotaoGiro();
    }

    void Update()
    {
        if (usarGiroscopio && gyroDisponivel)
        {
            Quaternion gyroRot = gyro.attitude;
            Quaternion rot = new Quaternion(gyroRot.x, gyroRot.y, -gyroRot.z, -gyroRot.w);
            targetRotation = offset * rot;
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, suavizacao * Time.deltaTime);
        }
        else
        {
            if (Input.touchCount >= 1)
            {
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Moved)
                {
                    rotY += touch.deltaPosition.x * sensibilidade * Time.deltaTime;
                    rotX -= touch.deltaPosition.y * sensibilidade * Time.deltaTime;
                    rotX = Mathf.Clamp(rotX, -80f, 80f);
                }
            }
            targetRotation = Quaternion.Euler(rotX, rotY, 0f);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, suavizacao * Time.deltaTime);
        }
    }

    void CreateCursor()
    {
        GameObject cursorObj = new GameObject("Cursor");
        Canvas canvas = cursorObj.AddComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        canvas.sortingOrder = 999;
        UnityEngine.UI.CanvasScaler scaler = cursorObj.AddComponent<UnityEngine.UI.CanvasScaler>();
        scaler.uiScaleMode = UnityEngine.UI.CanvasScaler.ScaleMode.ScaleWithScreenSize;
        scaler.referenceResolution = new Vector2(1920, 1080);
        GameObject dot = new GameObject("Dot");
        dot.transform.SetParent(cursorObj.transform);
        UnityEngine.UI.Image img = dot.AddComponent<UnityEngine.UI.Image>();
        img.color = Color.white;
        RectTransform rect = dot.GetComponent<RectTransform>();
        rect.anchorMin = new Vector2(0.5f, 0.5f);
        rect.anchorMax = new Vector2(0.5f, 0.5f);
        rect.sizeDelta = new Vector2(20, 20);
        rect.anchoredPosition = Vector2.zero;
    }

    void CreateBotaoGiro()
    {
        GameObject btnObj = new GameObject("BotaoGiro");
        Canvas canvas = btnObj.AddComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        canvas.sortingOrder = 998;
        UnityEngine.UI.CanvasScaler scaler = btnObj.AddComponent<UnityEngine.UI.CanvasScaler>();
        scaler.uiScaleMode = UnityEngine.UI.CanvasScaler.ScaleMode.ScaleWithScreenSize;
        scaler.referenceResolution = new Vector2(1920, 1080);
        btnObj.AddComponent<UnityEngine.UI.GraphicRaycaster>();

        GameObject btn = new GameObject("Botao");
        btn.transform.SetParent(btnObj.transform);
        UnityEngine.UI.Image img = btn.AddComponent<UnityEngine.UI.Image>();
        img.color = new Color(0, 0, 0, 0.7f);
        UnityEngine.UI.Button button = btn.AddComponent<UnityEngine.UI.Button>();

        TextMeshProUGUI texto = new GameObject("Texto").AddComponent<TextMeshProUGUI>();
        texto.transform.SetParent(btn.transform);
        texto.text = "Giroscópio: OFF";
        texto.fontSize = 20;
        texto.alignment = TextAlignmentOptions.Center;
        texto.color = Color.white;
        RectTransform rectTxt = texto.GetComponent<RectTransform>();
        rectTxt.anchorMin = Vector2.zero;
        rectTxt.anchorMax = Vector2.one;
        rectTxt.sizeDelta = Vector2.zero;

        button.onClick.AddListener(() => {
            usarGiroscopio = !usarGiroscopio;
            texto.text = usarGiroscopio ? "Giroscópio: ON" : "Giroscópio: OFF";
        });

        RectTransform rect = btn.GetComponent<RectTransform>();
        rect.anchorMin = new Vector2(1f, 0f);
        rect.anchorMax = new Vector2(1f, 0f);
        rect.sizeDelta = new Vector2(250, 80);
        rect.anchoredPosition = new Vector2(-140, 60);
    }
}