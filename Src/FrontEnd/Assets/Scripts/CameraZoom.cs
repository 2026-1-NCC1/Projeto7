using Unity.Cinemachine;
using UnityEngine;

public class CameraZoomCinemachine : MonoBehaviour
{
    public CinemachineCamera cinemachineCamera;

    private CinemachineFollow follow;

    [Header("Zoom")]
    public float zoomMin = 1f;
    public float zoomMax = 20f;
    public float velocidadeZoom = 10f;

    private float distanciaAtual;
    private float alvoDistancia;

    void Start()
    {
        follow = cinemachineCamera.GetComponent<CinemachineFollow>();
        distanciaAtual = Mathf.Abs(follow.FollowOffset.z);
        alvoDistancia = distanciaAtual;
    }

    void Update()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        if (scroll != 0f)
        {
            alvoDistancia -= scroll * velocidadeZoom;
            alvoDistancia = Mathf.Clamp(alvoDistancia, -zoomMin, -zoomMax);
        }

        distanciaAtual = Mathf.Lerp(distanciaAtual, alvoDistancia, Time.deltaTime * 10f);

        Vector3 offset = follow.FollowOffset;
        offset.z = -distanciaAtual;
        follow.FollowOffset = offset;
    }
}