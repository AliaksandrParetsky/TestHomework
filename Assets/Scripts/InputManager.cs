using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private CreateObject createObj;
    private CreateObject.ControlsObjectActions createObjectActions;

    private SceneController sceneController;
    public SceneController SceneController { get { if(sceneController == null) 
                sceneController = GetComponent<SceneController>(); return sceneController; } }

    public bool isPressed {  get; private set; }

    private void Awake()
    {
        createObj = new CreateObject();
        createObjectActions = createObj.ControlsObject;
    }

    private void OnEnable()
    {
        createObj.Enable();

        createObjectActions.Create.performed += ctx => SceneController.OnCreateObject();
    }

    private void OnDisable()
    {
        createObj.Disable();

        createObjectActions.Create.performed -= ctx => SceneController.OnCreateObject();
    }
}
