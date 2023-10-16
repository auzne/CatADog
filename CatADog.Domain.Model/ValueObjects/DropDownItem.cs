namespace CatADog.Domain.Model.ValueObjects;

public class DropDownItem<T>
{
    public string? Extra;
    public T Id;
    public string Text;

    public DropDownItem(T id, string text, string? extra = null)
    {
        Id = id;
        Text = text;
        Extra = extra;
    }
}