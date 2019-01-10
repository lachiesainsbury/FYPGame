using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
    /* UI WINDOWS */
    [SerializeField]
    private GameObject nutrientList, nutrientView, foodView, inventory;

    /* NUTRIENT LIST */
    [SerializeField]
    private GameObject nutrientPrefab;
    [SerializeField]
    private Transform nutrientListContent;

    /* NUTRIENT VIEW */
    [SerializeField]
    private GameObject nutrientInfo, foodPrefab;
    [SerializeField]
    private Transform nutrientViewContent;

    /* CONTAINERS */
    private NutrientContainer nutrientContainer;
    private FoodContainer foodContainer;
    private QuestContainer questContainer;
    private DialogueContainer dialogueContainer;
    private QuestionContainer questionContainer;

	// Use this for initialization
	void Start () {
        LoadNutrients();
        LoadFoods();
        LoadQuests();
        LoadDialogue();
        LoadQuestions();

        InitializeNutrientList();
	}

    private void LoadNutrients() {
        nutrientContainer = NutrientContainer.LoadFromXML("XML/Nutrients");
    }

    private void LoadFoods() {
        foodContainer = FoodContainer.LoadFromXML("XML/Foods");
    }

    private void LoadQuests() {
        questContainer = QuestContainer.LoadFromXML("XML/Quests");
    }

    private void LoadDialogue() {
        dialogueContainer = DialogueContainer.LoadFromXML("XML/Dialogue");
    }

    private void LoadQuestions() {
        questionContainer = QuestionContainer.LoadFromXML("XML/Questions");
    }

    public QuestionContainer GetQuestionContainer() {
        return this.questionContainer;
    }

    private void InitializeNutrientList() {
        foreach (Nutrient nutrient in nutrientContainer.nutrients) {
            GameObject nutrientItem = Instantiate(nutrientPrefab);
            nutrientItem.transform.SetParent(nutrientListContent, false);

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

            // Sets the nutrients onclick methods
            nutrientItem.GetComponent<Button>().onClick.AddListener(delegate {
                Navigate(nutrientList, nutrientView);
                InitializeNutrientView(nutrient);
            });
        }
    }

    private void InitializeNutrientView(Nutrient nutrient) {
        // Wipe existing content in food list
        foreach (Transform child in nutrientViewContent) {
            Destroy(child.gameObject);
        }

        Text[] nutrientText = nutrientInfo.GetComponentsInChildren<Text>();

        // Sets the nutrient name in uppercase
        nutrientText[0].text = nutrient.name.ToUpper();

        // Sets the nutrient description
        nutrientText[1].text = nutrient.description;

        foreach (string foodName in nutrient.foods) {
            GameObject foodItem = Instantiate(foodPrefab);
            foodItem.transform.SetParent(nutrientViewContent, false);

            // Find food by name in foodContainer
            Food food = FindFoodByName(foodName);

            // Set foods icon
            Image icon = foodItem.GetComponentsInChildren<Image>()[1];
            icon.sprite = Resources.Load<Sprite>("Foods/" + food.foodIcon);

            // Set foods name and nutritional information
            Text[] foodText = foodItem.GetComponentsInChildren<Text>();

            foodText[0].text = food.name;
            foodText[1].text = food.kJPer100g;
            foodText[2].text = food.contentPerServe;
            foodText[3].text = food.RDI;

            // Sets the foods onclick methods
            foodItem.GetComponent<Button>().onClick.AddListener(delegate {
                Navigate(nutrientView, foodView);
                InitializeFoodView(food);
            });
        }
    }

    private void InitializeFoodView(Food food) {
        // Sets the foods name and description
        Text[] foodText = foodView.GetComponentsInChildren<Text>();

        foodText[0].text = food.name.ToUpper();
        foodText[1].text = food.description.Replace("\\n", "\n");

        // Sets the foods icon
        Image icon = foodView.GetComponentsInChildren<Image>()[2];
        icon.sprite = Resources.Load<Sprite>("Foods/" + food.foodIcon);

        // Sets the onclick method for the back button
        Button[] foodButtons = foodView.GetComponentsInChildren<Button>();
        Button backButton = foodButtons[0];
        Button chooseButton = foodButtons[1];
        Button exitButton = foodButtons[2];

        if (food.buyable) {
            chooseButton.onClick.AddListener(delegate {
                food.itemType = ItemType.Seeds;
                inventory.GetComponent<Inventory>().AddItem(food);
            });
        } else {
            chooseButton.gameObject.SetActive(false);
        }

        backButton.onClick.AddListener(delegate {
            chooseButton.gameObject.SetActive(true);
            Navigate(foodView, nutrientView);
            chooseButton.onClick.RemoveAllListeners();
        });

        exitButton.onClick.AddListener(delegate {
            chooseButton.gameObject.SetActive(true);
            chooseButton.onClick.RemoveAllListeners();
        });
    }

    private void Navigate(GameObject current, GameObject destination) {
        current.GetComponent<UIWindow>().Navigate(destination);
    }

    public Food FindFoodByName(string name) {
        foreach (Food food in foodContainer.foods) {
            if (name.Equals(food.name)) {
                return food;
            }
        }

        return null;
    }

    public Quest FindQuestByNPC(string name) {
        foreach (Quest quest in questContainer.quests) {
            if (name.Equals(quest.questNPC)) {
                return quest;
            }
        }

        return null;
    }

    public Dialogue FindDialogueByNPC(string name) {
        foreach (Dialogue dialogue in dialogueContainer.dialogues) {
            if (name.Equals(dialogue.NPC)) {
                return dialogue;
            }
        }

        return null;
    }
}
