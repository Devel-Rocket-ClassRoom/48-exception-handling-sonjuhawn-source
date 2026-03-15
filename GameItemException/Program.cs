using System;
using System.Collections.Generic;

// README.md를 읽고 코드를 작성하세요.
Console.WriteLine("코드를 작성하세요.");



class Inventory
{
    public List<string> items = new List<string>();

    public int maxCapacity {  get; private set; }

    public Inventory(int maxcapacity)
    {
        this.maxCapacity = maxcapacity;
    }

    public void AddItem(string itemname)
    {
        try
        {
            items.Add(itemname);
        }
        catch(InventoryFullException ex) when()
        {
            
        }
    }
}