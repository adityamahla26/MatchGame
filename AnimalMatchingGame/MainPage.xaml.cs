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

        Dispatcher.StartTimer(TimeSpan.FromSeconds(.1), TimerTick);

    }

    int tenthsOfSecondsElapsed = 0;

    private bool TimerTick()
    {
        if (!this.IsLoaded) return false;
        tenthsOfSecondsElapsed++;
        TimeElapsed.Text = "Time elapsed: " + (tenthsOfSecondsElapsed / 10F).ToString("0.0");
        if (PlayAgainButton.IsVisible)
        {
            tenthsOfSecondsElapsed = 0;
            return false;
        }
        return true;
    }

    Button lastClicked;
    bool findingMatch = false;
    int matchesFound;

    void Button_Clicked(System.Object sender, System.EventArgs e)
    {
     if(sender is Button buttonClicked)
        {
            if(!string.IsNullOrEmpty(buttonClicked.Text)&& (findingMatch == false))
            {
                buttonClicked.BackgroundColor = Colors.Red;
                lastClicked = buttonClicked;
                findingMatch = true;
            }
            else
            {
                if ((buttonClicked != lastClicked) && (buttonClicked.Text == lastClicked.Text) && !string.IsNullOrEmpty(buttonClicked.Text))
                {
                    matchesFound++;
                    lastClicked.Text = "";
                    buttonClicked.Text = "";
                }
                lastClicked.BackgroundColor = Colors.LightBlue;
                buttonClicked.BackgroundColor = Colors.LightBlue;
                findingMatch = false;
                
            }
        }
     if(matchesFound == 8)
        {
            matchesFound = 0;
            AnimalButtons.IsVisible = false;
            PlayAgainButton.IsVisible = true;
        }


    }
}