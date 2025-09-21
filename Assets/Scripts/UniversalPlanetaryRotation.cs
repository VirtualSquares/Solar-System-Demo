using UnityEngine;

public class PlanetOrbitUniversal : MonoBehaviour
{
    public Transform sun;
    private float orbitRadius;
    private float orbitSpeed;
    private float rotationSpeed;
    private float angle;

    void Start()
    {
        if (sun == null)
        {
            GameObject sunObj = GameObject.Find("sun");
            if (sunObj != null)
                sun = sunObj.transform;
            else
                Debug.LogError("No Sun object found in the scene!");
        }

        string textureName = GetComponent<Renderer>().material.mainTexture.name;

        switch (textureName)
        {
            case "MercuryTexture":
                orbitRadius = 10f; orbitSpeed = 50f; rotationSpeed = 10f; break;
            case "VenusTexture":
                orbitRadius = 15f; orbitSpeed = 35f; rotationSpeed = 5f; break;
            case "EarthTexture":
                orbitRadius = 20f; orbitSpeed = 30f; rotationSpeed = 20f; break;
            case "MarsTexture":
                orbitRadius = 25f; orbitSpeed = 24f; rotationSpeed = 15f; break;
            case "JupiterTexture":
                orbitRadius = 40f; orbitSpeed = 13f; rotationSpeed = 40f; break;
            case "SaturnTexture":
                orbitRadius = 55f; orbitSpeed = 9f; rotationSpeed = 35f; break;
            case "UranusTexture":
                orbitRadius = 70f; orbitSpeed = 6f; rotationSpeed = 25f; break;
            case "NeptuneTexture":
                orbitRadius = 85f; orbitSpeed = 5f; rotationSpeed = 20f; break;
            case "SaturnRingTexture":
                orbitRadius = 55f; orbitSpeed = 9f; rotationSpeed = 60f; break;
            default:
                orbitRadius = 10f; orbitSpeed = 20f; rotationSpeed = 10f; break;
        }

        orbitRadius *= 8f;
        orbitSpeed *= 1.5f;
        rotationSpeed *= 1.5f;
    }

    void Update()
    {
        angle += orbitSpeed * Time.deltaTime;
        float rad = angle * Mathf.Deg2Rad;
        Vector3 offset = new Vector3(Mathf.Cos(rad), 0, Mathf.Sin(rad)) * orbitRadius;
        transform.position = sun.position + offset;
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime, Space.Self);
    }
}
