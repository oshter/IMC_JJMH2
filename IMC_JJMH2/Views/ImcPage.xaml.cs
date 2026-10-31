using IMC_JJMH2.ViewModels;

namespace IMC_JJMH2.Views;

public partial class ImcPage : ContentPage
{
	public ImcPage()
	{
		InitializeComponent();

        //Conecta la pantalla con sus datos y comando del VoiewModel
        BindingContext = new IMCViewModels();
    }
}