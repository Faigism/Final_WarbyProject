namespace WarbyApp.UI.ViewModels
{
    public class Error_VM
    {
        public string Message { get; set; }
        public List<Error_VMItem> Errors { get; set; }
    }
    public class Error_VMItem
    {
        public string Key { get; set; }
        public string ErrorMessage { get; set; }
    }
}
