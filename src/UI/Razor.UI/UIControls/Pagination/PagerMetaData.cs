namespace Razor.UI.UIControls.Pagination
{
    public class PagerMetaData
    {
        public int TotalItemCount { get; set; }
        public int CurrentPageIndex { get; set; }
        public int PageSize { get; set; }

        public int TotalPageCount
        {
            get
            {
                var count = (int)Math.Ceiling(TotalItemCount / (double)PageSize);
                return count == 0 ? 1 : count;
            }
        }

        public List<PagerItem> PagerItems { get; set; }

        public string PageIndexParameterName { get; }

        public bool HasPreviousPage => CurrentPageIndex > 1;

        public bool HasNextPage => CurrentPageIndex < TotalPageCount;

        public bool IsFirstPage => CurrentPageIndex == 1;
        public bool IsLastPage => CurrentPageIndex == TotalPageCount;

        public string FirstPageUrl => generatePaginationUrl(1);

        public string NextPageUrl
        {
            get
            {
                var nextPageIndex = CurrentPageIndex + 1;
                if (nextPageIndex > TotalPageCount)
                {
                    nextPageIndex = TotalPageCount;
                }
                return generatePaginationUrl(nextPageIndex);
            }
        }

        public string PreviousPageUrl
        {
            get
            {
                var prevPageIndex = CurrentPageIndex - 1;
                if (prevPageIndex < 1)
                {
                    prevPageIndex = 1;
                }
                var url = generatePaginationUrl(prevPageIndex);
                return url;
            }
        }

        public string LastPageUrl => generatePaginationUrl(TotalPageCount);

        public string CurrentPageUrl => generatePaginationUrl(CurrentPageIndex);

        public int StartPageIndex => _startPageIndex;

        public int EndPageIndex => _endPageIndex;

        private RouteValueDictionary _routeValues { get; }

        private IUrlHelper _urlHelper { get; }

        private int _startPageIndex;

        private int _endPageIndex;

        string generatePaginationUrl(int pageIndex)
        {
            var qryPrms = _urlHelper.ActionContext?.HttpContext?.
                Request?.Query?.ToDictionary(d => d.Key, d => d.Value.ToString());
            var rvalues = new RouteValueDictionary(qryPrms);
            rvalues = new RouteValueDictionary(rvalues.Union(_routeValues));

            rvalues[PageIndexParameterName] = pageIndex;
            return _urlHelper.Page(_routeValues["page"] as string, rvalues);
        }

        public string GetPaginationUrl(int pageIndex)
        {
            return generatePaginationUrl(pageIndex);
        }


        public PagerMetaData(int total, int pageIndex, int pageSize,
            string pageParameterName, RouteValueDictionary routeValues,
            int maxPagerItems, IUrlHelper urlHelper)
        {
            TotalItemCount = total;
            CurrentPageIndex = pageIndex;
            PageSize = pageSize;
            _urlHelper = urlHelper;
            _routeValues = routeValues;
            PageIndexParameterName = pageParameterName;

            _startPageIndex = CurrentPageIndex - (maxPagerItems / 2);
            if (_startPageIndex + maxPagerItems > TotalPageCount)
            {
                _startPageIndex = TotalPageCount + 1 - maxPagerItems;
            }
            if (_startPageIndex < 1)
            {
                _startPageIndex = 1;
            }

            _endPageIndex = _startPageIndex + maxPagerItems - 1;
            if (_endPageIndex > TotalPageCount)
            {
                _endPageIndex = TotalPageCount;
            }

            PagerItems = new List<PagerItem>();
            for (int i = _startPageIndex; i <= _endPageIndex; i++)
            {
                PagerItems.Add(new PagerItem(i, generatePaginationUrl(i), i == CurrentPageIndex));
            }
        }




    }
}
