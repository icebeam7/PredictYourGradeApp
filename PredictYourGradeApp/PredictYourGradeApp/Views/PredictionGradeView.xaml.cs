using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using PredictYourGradeApp.Models;
using PredictYourGradeApp.ViewModels;

namespace PredictYourGradeApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PredictionGradeView : ContentPage
	{
        Student student;

		public PredictionGradeView ()
		{
			InitializeComponent ();

            student = new Student();
            BindingContext = new PredictionGradeViewModel(student);
        }
	}
}