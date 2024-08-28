using Mod02Act01.ViewModel;
namespace Mod02Act01.View;


public partial class StudentPage : ContentPage
{
	public StudentPage()
	{
		InitializeComponent();
		BindingContext = new StudentModel();
	}
}