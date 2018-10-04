using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
    /* UI WINDOWS */
    [SerializeField]
    private GameObject nutrientList, nutrientView, foodView;

    /* NUTRIENT LIST */
    [SerializeField]
    private GameObject nutrientPrefab;
    [SerializeField]
    private Transform nutrientListContent;

    /* NUTRIENT VIEW */


    /* CONTAINERS */
    private NutrientContainer nutrientContainer;
    private FoodContainer foodContainer;

	// Use this for initialization
	void Start () {
        LoadNutrients();
        LoadFoods();

        initializeNutrientList();
	}

    private void LoadNutrients() {
        nutrientContainer = NutrientContainer.LoadFromXML("XML/Nutrients");
    }

    private void LoadFoods() {
        foodContainer = FoodContainer.LoadFromXML("XML/Foods");
    }

    private void initializeNutrientList() {
        foreach (Nutrient nutrient in nutrientContainer.nutrients) {
            GameObject nutrientItem = Instantiate(nutrientPrefab);
            nutrientItem.transform.SetParent(nutrientListContent);

            Text[] nutrientText = nutrientItem.GetComponentsInChildren<Text>();
            // Set nutrients name
            nutrientText[0].text = nutrient.name;

            // For each function, appends to nutrients function text
            for (int i=0; i < nutrient.functions.Length; i++) {
                nutrientText[1].text += nutrient.functions[i];

                // If it is not the last function in the list then add a new line
                if (i+1 != nutrient.functions.Length) {
                    nutrientText[1].text += "\n";
                }
            }

            // Sets the nutrients onclick method to call the displayNutrientView method with the foods name
            nutrientItem.GetComponent<Button>().onClick.AddListener(delegate {
                Navigate(nutrientList, nutrientView);
                initializeNutrientView(nutrient);
            });
        }
    }

    private void Navigate(GameObject current, GameObject destination) {
        current.GetComponent<UIWindow>().Navigate(destination);
    }

    private void initializeNutrientView(Nutrient nutrient) {
        
        // Populate nutrient view based upon 
    }
}
