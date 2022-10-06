namespace MemeChat.ViewModel
{
    public class ExampleViewModel
    {
        public ExampleViewModel()
        {
        }

        public void ExampleMethod()
        {
            var example = new ExampleViewModel();
            example.ExampleProperty = "Example";
        }

        public string ExampleProperty { get; set; }
    }
}
