using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;


//this is a handeler script that does the actual inputs that are passed to the player controller
public class PlayerInputHandler : MonoBehaviour
{
    private PlayerController playerController;

    private PlayerInput playerInput;

    // Start is called before the first frame update
    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        var playerControllers = FindObjectsOfType<PlayerController>();

        var index = playerInput.playerIndex;

        playerController = playerControllers.FirstOrDefault(m =>m.getPlayerIndex() == index);
    }

    public void OnMove(CallbackContext context) {
        playerController.setInputDirection(context.ReadValue<Vector2>());
    }
}
