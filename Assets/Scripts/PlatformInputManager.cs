using UnityEngine;

public class PlatformInputManager : MonoBehaviour
{
    public GameObject joystickGameObject; // Assign the joystick UI GameObject in the inspector

    void Start()
    {
#if UNITY_IOS || UNITY_ANDROID
            // Enable the joystick for mobile platforms
            joystickGameObject.SetActive(true);
#else
        // Disable the joystick for non-mobile platforms
        joystickGameObject.SetActive(false);
#endif
    }
}
