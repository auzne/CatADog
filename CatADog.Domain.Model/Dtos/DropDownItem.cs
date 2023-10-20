namespace CatADog.Domain.Model.Dtos;

public class DropDownItem<T>
{
    public T Value { get; set; }

    public string Text { get; set; }

    public string? Extra { get; set; }
}