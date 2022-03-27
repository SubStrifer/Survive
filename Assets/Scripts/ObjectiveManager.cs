using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectiveManager : MonoBehaviour
{
    public Text objective0_title;
    public Text objective0_desc;
    public Text objective1_title;
    public Text objective1_desc;
    public Text objective2_title;
    public Text objective2_desc;
    public List<Objective> activeObjectives;
    Text[,] objectiveList;
    int maxObjectives =3;
    
    void Awake(){
        objective0_title.text = "";
        objective0_desc.text = "";
        objective1_title.text = "";
        objective1_desc.text = "";
        objective2_title.text = "";
        objective2_desc.text = "";
    }

    void Start()
    {
        activeObjectives = new List<Objective>();
        objectiveList = new Text[3,2] {{objective0_title, objective0_desc}, {objective1_title, objective1_desc}, {objective2_title, objective2_desc}};
    }

    public void addObjective(Objective ob)
    {
        activeObjectives.Add(ob);
        updateList();
    }

    void updateList()
    {

        //Clear out the list on the panel
        for (int row = 0; row < objectiveList.GetLength(0); row++){
            for(int col = 0; col < objectiveList.GetLength(1); col++){
                objectiveList[row,col].text = "";
            }
        }

        int obCount = 0;
        //Add the updated list in
        foreach(Objective ob in activeObjectives)
        {
            if(obCount==maxObjectives)
            {
                Debug.Log("Too many objectives");
                return;
            }
            objectiveList[obCount,0].text=ob.title;
            objectiveList[obCount,1].text=ob.description;
            obCount++;
        }
    }

    public void removeObjective(int completedObjectiveID)
    {

        List<Objective> tempObjectives = new List<Objective>(activeObjectives);

        foreach(Objective ob in activeObjectives)
        {

            if (ob.objectiveID==completedObjectiveID)
            {
                tempObjectives.Remove(ob);
            }

        }
        activeObjectives =  tempObjectives;
        updateList();
    }



}
