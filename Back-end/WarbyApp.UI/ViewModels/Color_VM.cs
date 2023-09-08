namespace WarbyApp.UI.ViewModels
{
    public class Color_VM
    {
        public List<Color_VMItem> Colors { get; set; }
    }
    public class Color_VMItem
    {
        public int Id { get; set; }
        public string ColorName { get; set; }
        public string ColorImage { get; set; }
    }
}
