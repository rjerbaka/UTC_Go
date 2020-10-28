using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class CsvreadAndGenerate : MonoBehaviour
{
    public TextAsset File;
    static public string langage;
    


    void Start()
    {
        langage = LangChange.getLang();
        Debug.Log("Chargement BDD");
        Load(File);
        Debug.Log("Chargement BDD réussi");

        // Debug.Log(All_Groups());

        Debug.Log(langage);

    }

    public class Row
    {
        public string Nom_Lieu;
        public string Latitude;
        public string Longitude;
        public string Groupe;
        public string Visite;
        public string Description;
        public string Indications;
        public string Image_Mystere;
        public string Image_Lieu;
        public string GroupeEN;
        public string DescriptionEN;
        public string IndicationsEN;

    }

    static List<Row> rowList = new List<Row>();
    bool isLoaded = false;

    public bool IsLoaded()
    {
        return isLoaded;
    }

    public List<Row> GetRowList()
    {
        return rowList;
    }

    public void Load(TextAsset csv)
    {
        rowList.Clear();
        string[][] grid = CsvParser2.Parse(csv.text);
        for (int i = 1; i < grid.Length; i++)
        {
            Row row = new Row();
            row.Nom_Lieu = grid[i][0];
            row.Latitude = grid[i][1];
            row.Longitude = grid[i][2];
            row.Groupe = grid[i][3];
            row.Visite = grid[i][4];
            row.Description = grid[i][5];
            row.Indications = grid[i][6];
            row.Image_Mystere = grid[i][7];
            row.Image_Lieu = grid[i][8];
            row.GroupeEN = grid[i][9];
            row.DescriptionEN = grid[i][10];
            row.IndicationsEN = grid[i][11];


            rowList.Add(row);
        }
        isLoaded = true;
    }

    public static int NumRows()
    {
        return rowList.Count;
    }

    public Row GetAt(int i)
    {
        if (rowList.Count <= i)
            return null;
        return rowList[i];
    }

    public static Row Find_Nom_Lieu(string find)
    {
        return rowList.Find(x => x.Nom_Lieu == find);
    }

    static public List<Row> FindAll_Nom_Lieu()
    {
        return rowList.FindAll(x => x.Nom_Lieu != null);
    }

    public Row Find_Latitude(string find)
    {
        return rowList.Find(x => x.Latitude == find);
    }

    public List<Row> FindAll_Latitude()
    {
        return rowList.FindAll(x => x.Latitude != null);
    }

    public Row Find_Longitude(string find)
    {
        return rowList.Find(x => x.Longitude == find);
    }
    public List<Row> FindAll_Longitude()
    {
        return rowList.FindAll(x => x.Longitude != null);
    }
    public Row Find_Groupe(string find)
    {
        if (langage == "FR")
        {
            return rowList.Find(x => x.Groupe == find);
        }
        else
        {
            return rowList.Find(x => x.GroupeEN == find);
        }
    }
    public static List<Row> FindAll_Groupe()
    {
        if (langage == "FR")
        {
            return rowList.FindAll(x => x.Groupe != null);
        }
        else
        {
            return rowList.FindAll(x => x.GroupeEN != null);
        }
    }
    public Row Find_Visite(string find)
    {
        return rowList.Find(x => x.Visite == find);
    }
    public static List<Row> FindAll_Visite(string find)
    {
        return rowList.FindAll(x => x.Visite == find);
    }
    public Row Find_Description(string find)
    {
        if (langage == "FR")
        {
            return rowList.Find(x => x.Description == find);
        }
        else
        {
            return rowList.Find(x => x.DescriptionEN == find);
        }
    }
    public List<Row> FindAll_Description()
    {
        if (langage == "FR")
        {
            return rowList.FindAll(x => x.Description != null);
        }
        else
        {
            return rowList.FindAll(x => x.DescriptionEN != null);
        }
    }
    public Row Find_Indications(string find)
    {
        if (langage == "FR")
        {
            return rowList.Find(x => x.Indications == find);
        }
        else
        {
            return rowList.Find(x => x.IndicationsEN == find);
        }
    }
    public List<Row> FindAll_Indications()
    {
        if (langage == "FR")
        {
            return rowList.FindAll(x => x.Indications != null);
        }
        else
        {
            return rowList.FindAll(x => x.IndicationsEN != null);
        }
    }

    public static List<String> All_Groups()
    {
        langage = LangChange.getLang();
        List<Row> temp = FindAll_Groupe();
        List<String> groups = new List<String>();
        foreach (Row rRow in temp)
        {
            if (langage == null){
                Debug.LogError("lang is null");
            } else {
                Debug.Log("lang: "+langage);
            }
            if (langage == "FR")
            {
                if (!groups.Contains(rRow.Groupe))
                {
                    groups.Add(rRow.Groupe);
                }
            }
            else
            {
                if (!groups.Contains(rRow.GroupeEN))
                {
                    groups.Add(rRow.GroupeEN);
                }
            }
        }
        return groups;
    }

    public static List<Row> All_Lieux_Visite()
    {
        List<Row> temp = FindAll_Visite("1");
        return temp;
    }

    public static List<Row> All_Lieux_Non_Visite()
    {
        List<Row> temp = FindAll_Visite("0");
        return temp;
    }

    public static void Modif_Visite(string lieu)
    {
        Row modif = Find_Nom_Lieu(lieu);
        if (modif.Visite == "0")
        {
            modif.Visite = "1";
            for (int i =0; i < NumRows(); i++)
            {
                if (rowList[i].Nom_Lieu == lieu)
                {
                    rowList[i] = modif;
                }
            }
        }

    }

    public static List<Row> Lieux_Pour_Groupe(string group)
    {
        if (langage == "FR")
        {
            return rowList.FindAll(x => x.Groupe == group);
        }
        else
        {
            return rowList.FindAll(x => x.GroupeEN == group);
        }
    }

    public static List<string> Lieux_Pour_Groupe_String(string group)
    {
        List<String> lieux = new List<String>();
        if (langage == "FR")
        {
            List<Row> temp = rowList.FindAll(x => x.Groupe == group);            
            foreach (Row rRow in temp)
            {
                if (!lieux.Contains(rRow.Nom_Lieu))
                {
                    lieux.Add(rRow.Nom_Lieu);
                }
            }
        }
        else
        {
            List<Row> temp = rowList.FindAll(x => x.GroupeEN == group);
            foreach (Row rRow in temp)
            {
                if (!lieux.Contains(rRow.Nom_Lieu))
                {
                    lieux.Add(rRow.Nom_Lieu);
                }
            }
        }
        return lieux;
    }

    public static bool Groupe_Fini(string group)
    {
        bool result = false;
        List<Row> all_lieux;
        if (langage == "FR")
        {
            // List<Row> all_lieux = rowList.FindAll(x => x.Groupe == group);
            all_lieux = rowList.FindAll(x => x.Groupe == group);
        }
        else
        {
            // List<Row> all_lieux = rowList.FindAll(x => x.GroupeEN == group);
            all_lieux = rowList.FindAll(x => x.GroupeEN == group);
        }
        List<Row> visite = all_lieux.FindAll(x => x.Visite == "1");

        result = all_lieux.Equals(visite);

        return result;
    }

    public static string Image_Mystere(string lieu)
    {
        string img = Find_Nom_Lieu(lieu).Image_Mystere;
        return img;
    }

    public static string Image_Lieu(string lieu)
    {
        string img = Find_Nom_Lieu(lieu).Image_Lieu;
        return img;
    }

    public static List<int> getVisitedList()
    {
        List<int> visited = new List<int>();
        for (int i = 0; i < 28; i++)
        {
            visited.Add(int.Parse(rowList[i].Visite));

        }
        return visited;

    }
}