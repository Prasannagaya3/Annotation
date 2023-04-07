using UnityEngine;
using System.IO;
using TMPro;

public class DataRetrieve : MonoBehaviour
{
    public StreamReader FileReader;
    public string FilePath, FileName, SplitMethod;
    public string[] StrigSplit;
    public TextMeshProUGUI[] Names;

    public void Start()
    {
        ReadFileSystem();
    }

    public void ReadFileSystem()
    {
        FileReader = new StreamReader(FilePath + FileName);
        
        bool notCreated = false;
        while(!notCreated)
        {
            SplitMethod = FileReader.ReadLine();

            if(SplitMethod == null)
            {
                notCreated = true;
                break;
            }

            StrigSplit = SplitMethod.Split(',');
        }
    }

    public void DataUpdate(int Count)
    {
        for (int i = 0; i < StrigSplit.Length; i++)
        {
            if(i == Count)
            {
                Names[i].text = StrigSplit[i].ToString();
            }
            else
            {
                Names[i].text = " ";
            }
        }
    }
}