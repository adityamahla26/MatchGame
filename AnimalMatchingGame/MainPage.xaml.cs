namespace AnimalMatchingGame;

public partial class MainPage : ContentPage
{

    public MainPage()
    {
        InitializeComponent();
        AnimalButtons.IsVisible = false;
    }

    void PlayAgainButton_Clicked(System.Object sender, System.EventArgs e)
    {
        AnimalButtons.IsVisible = true;
        PlayAgainButton.IsVisible = false;
        List<string> animalEmoji = new List<string>()
        {
            "🐶","🐶",
            "🐮","🐮",
            "🐨","🐨",
            "🐒","🐒",
            "🐷","🐷",
            "🐍","🐍",
            "🐳","🐳",
            "🦧","🦧"
        };
        foreach (var button in AnimalButtons.Children.OfType<Button>())
        {
            int index = Random.Shared.Next(animalEmoji.Count);
            string nextEmoji = animalEmoji[index];
            button.Text = nextEmoji;
            animalEmoji.RemoveAt(index);
        }
    }

    void Button_Clicked(System.Object sender, System.EventArgs e)
    {
    }
}