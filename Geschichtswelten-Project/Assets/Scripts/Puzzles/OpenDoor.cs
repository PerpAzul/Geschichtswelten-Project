using UnityEngine;
using UnityEngine.Serialization;


public class OpenDoor : MonoBehaviour
{
    //public List<PressurePlate> PressurePlates = new List<PressurePlate>();
    [SerializeField] private PressurePlate pressurePlate1;
    [SerializeField] private PressurePlate pressurePlate2; 
    public Animator animator;

    private void Update()
    {
        if (pressurePlate1.isActivated && pressurePlate2.isActivated || pressurePlate2.isActivated && pressurePlate1.isActivated)
        {
            animator.SetBool("OpenDoor",true);
        }
        else
        {
            animator.SetBool("OpenDoor",false);
        }
    }
}
