using System;
using System.Collections.Generic;

class HistoryBook : Book
{
    public bool isElectronic { get; set; }
    
    public HistoryBook(string title, string author,
                string description, string genre,
                int year, float rating, bool isElectronic)
                :base(title, author,
                description,  genre,
                year,  rating)
    {
        this.isElectronic = isElectronic;
    }

    public bool GetIsElectronic() { return isElectronic; }

    public void SetIsElectronic() { this.isElectronic = isElectronic; }
    
    //ternary operator to know book format
    public override string ToString()
    {
        return base.ToString() + (this.isElectronic ? " Electronic Format" : " Paper Format");
    }
}

