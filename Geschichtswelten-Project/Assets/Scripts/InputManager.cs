using UnityEngine;

public class InputManager : MonoBehaviour
{
    public PlayerInput playerInput;
    public PlayerInput.PlayerBasicsActions playerActions;
    private PlayerInput.PowersActions powersActions;

    private Player player;
    private PlayerLook look;
    private Flashlight flash;

    void Awake()
    {
        playerInput = new PlayerInput();
        playerActions = playerInput.PlayerBasics;
        powersActions = playerInput.Powers;
        
        player = GetComponent<Player>();
        look = GetComponent<PlayerLook>();
        flash = GetComponent<Flashlight>();
        
        playerActions.Jump.performed += ctx => player.Jump();
        playerActions.Run.started += ctx => player.StartRun();
        playerActions.Run.canceled += ctx => player.EndRun();
        playerActions.Flashlight.performed += ctx => flash.Flash();
        
        powersActions.GravityPull.performed += ctx => look.GravityPull();
        powersActions.ActivateGravityPush.performed += ctx => look.GravityPush();
        powersActions.GravityFloat.performed += ctx => look.GravityFloat();
    }

    private void FixedUpdate()
    { 
        player.Move(playerActions.Move.ReadValue<Vector2>());
    }

    private void LateUpdate()
    {
        look.Look(playerActions.Look.ReadValue<Vector2>());
    }

    private void OnEnable()
    {
        playerActions.Enable();
        powersActions.Enable();
    }

    private void OnDisable()
    {
        playerActions.Disable();
        powersActions.Disable();
    }
}
