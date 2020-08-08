using UnityEngine;

public class LightManager : MonoBehaviour
{
    public Light directionalLight;
    public Light deadZoneLight;
    public Light relicLight;
    public Light ramp1Light;
    public Light ramp2Light;

    private void Start()
    {
        directionalLight.enabled = false;
        deadZoneLight.enabled = false;
        relicLight.enabled = false;
        ramp1Light.enabled = false;
        ramp2Light.enabled = false;
    }

    public void StartLight()
    {
        directionalLight.enabled = true;
        deadZoneLight.enabled = true;
        relicLight.enabled = true;
        ramp1Light.enabled = true;
        ramp2Light.enabled = true;
    }

    public void StopLight()
    {
        directionalLight.enabled = false;
        deadZoneLight.enabled = false;
        relicLight.enabled = false;
        ramp1Light.enabled = false;
        ramp2Light.enabled = false;
    }
}
