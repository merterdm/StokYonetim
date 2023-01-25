namespace StokYonetimMobile
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }

        private void ButtonCategory_Clicked(object sender, EventArgs e)
        {

            try
            {


                //WebApiClient<Category> apiClient = new WebApiClient<Category>();
                //var result = apiClient.Get(ApiUrl.Categories).Result;
                //if (result != null)
                //{

                //    DisplayAlert("Alert", $"{result.name}", "OK");

                //}
                //else
                //{
                //    DisplayAlert("Alert", $"Web Service ulasilamadi", "OK");
                //}

                DisplayAlert("Test", $" Deneme", "Ok");


            }
            catch (Exception ex)
            {

                DisplayAlert("Hata", $"{ex.Message}", "Ok");
            }
        }
    }
}