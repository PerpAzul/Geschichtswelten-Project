using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Open : Interactable
{
   protected override void Interact()
   {
      GetComponent<Animation>().Play("Crate_Open");
   }
}
