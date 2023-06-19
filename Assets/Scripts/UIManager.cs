using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject[] menus;
    private GameObject activeMenu;
    private Dictionary<string, GameObject> indexedMenus = new Dictionary<string, GameObject>();

    private void Start()
    {
        IndexMenus();

        foreach (string key in indexedMenus.Keys)
        {
            Debug.Log(key);
        }
    }

    private void IndexMenus()
    {
        foreach (GameObject menu in menus)
        {
            menu.SetActive(false);
            indexedMenus.Add(menu.name.ToLower(), menu);
        }
    }

    public void OpenMenu(string menuName)
    {
        GameObject menu = indexedMenus[menuName.ToLower()];

        CloseMenu();

        if (menu)
        {
            activeMenu = menu;
            menu.SetActive(true);
        }
    }

    public void CloseMenu()
    {
        if (activeMenu)
        {
            activeMenu.SetActive(false);
        }
    }
}
