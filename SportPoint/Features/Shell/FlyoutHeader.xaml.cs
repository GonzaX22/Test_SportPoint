namespace SportPoint.Features.Shell
{
    public partial class FlyoutHeader
    {
        public FlyoutHeader() {
            InitializeComponent();
            BindingContext = new FlyoutHeaderViewModel();
        }
    }
}