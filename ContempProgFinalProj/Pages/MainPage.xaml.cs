using ContempProgFinalProj.Models;
using ContempProgFinalProj.PageModels;

namespace ContempProgFinalProj.Pages
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainPageModel model)
        {
            InitializeComponent();
            BindingContext = model;
        }
    }
}