namespace TodoApi;

// המודל מייצג שורה בטבלת items
public partial class Item
{
    public int Id { get; set; }

    public string? Name { get; set; } // שימוש ב-? מאפשר לשדה להיות Nullable

    public bool IsComplete { get; set; }
}