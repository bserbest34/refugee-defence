using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager bManager;
    private void Start()
    {
        bManager = BuildManager.instance;
    }
    public void PurchaseStandartTurret()
    {
        bManager.SetTurretToBuild(bManager.standartTurretPrefab);
    }
    public void PurchaseAnotherTurret()
    {
        bManager.SetTurretToBuild(bManager.anotherTurretPrefab);
    }

}
