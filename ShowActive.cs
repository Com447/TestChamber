using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShowActive : MonoBehaviour
{
   public GameObject Level;
   public GameObject Item1;

   private void Update()
   {
      if (Level.activeSelf)
      {
         Item1.SetActive(true);
      } 
   }
}
