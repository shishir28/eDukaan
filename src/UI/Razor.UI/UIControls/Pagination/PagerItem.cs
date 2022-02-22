namespace Razor.UI.UIControls.Pagination
{
    public class PagerItem
    {
        public int PageIndex { get; set; }
        public string Url { get; set; }
        public bool IsCurrent { get; set; }

        public PagerItem(int pageIndex, string url, bool isCurrent)
        {
            PageIndex = pageIndex;
            Url = url;
            IsCurrent = isCurrent;
        }
    }
}