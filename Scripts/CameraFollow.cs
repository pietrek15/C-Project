using UnityEngine;
using System.Collections;
/*
 * 
 * JAK ZACHOWUJE SIE KAMERA
 * 
 */

public class CameraFollow : MonoBehaviour
{
    public Transform target;            // DO SZEGO PRZYCZEPIAMY
    public float smoothing = 5f;        // JAK GLADKO MA SIE PORUSZAC

    public float zoomSpeed = 1;         // SZYBKOSC POWIEKSZANIA
    public float targetOrtho;           // CO SLEDZI
    public float smoothSpeed = 2.0f;    
    public float minOrtho = 8.0f;       // JAK BLISKO MOZNA PRZYBLIZYC
    public float maxOrtho = 20.0f;      // JAK DALEKO MOZNA ODDALIC 


    Vector3 offset;                     


    public void Start()
    {  
        target = GameObject.FindGameObjectWithTag("Player").transform;          // MA SZUKAC OBJEKTUZ TAKIEM PLAYER
        offset = transform.position + target.position;                          //W SUMIE TO MOGE TO WYRZUCIC

        targetOrtho = Camera.main.orthographicSize;                             // POBIERANIE WIELKOSCI KAMERY
    }


    void FixedUpdate()
    {
        if (target == null)                                                     // NIE TYKAC !  NIE WYWALA BLEDY GDY GRACZ UMIERA, BO INACZEJ CALY CZAS BY SZUKALA TAGU PLAYER
            return;

        Vector3 targetCamPos = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);

        float scroll = Input.GetAxis("Mouse ScrollWheel");                                  // PRZYBLIZANIE KAMERY 
        if (scroll != 0.0f)
        {
            targetOrtho -= scroll * zoomSpeed;
            targetOrtho = Mathf.Clamp(targetOrtho, minOrtho, maxOrtho);
        }

        Camera.main.orthographicSize = Mathf.MoveTowards(Camera.main.orthographicSize, targetOrtho, smoothSpeed * Time.deltaTime);      // TU SIE DZIEJE CALA MAGIA ZWIAZANA Z ZOOMEME

    }
}
