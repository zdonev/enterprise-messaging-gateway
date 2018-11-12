using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnterpriseMessagingGateway.Services.Helpers
{
    public class TaskResourceParameters
    {
        const int maxPageSize = 20;
        public int PageNumber { get; set; } = 1;
        private int _pageSize = 10;

        public int PageSize
        {
            get { return _pageSize; }
            set { _pageSize = (value > maxPageSize) ? maxPageSize: value; }
        }

        public string Name { get; set; }
        public string OrderBy { get; set; } = "Name";
        public string SearchQuery { get; set; }
    }
}