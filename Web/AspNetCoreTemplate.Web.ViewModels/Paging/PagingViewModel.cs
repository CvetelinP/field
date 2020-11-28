﻿namespace AspNetCoreTemplate.Web.ViewModels.Paging
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class PagingViewModel
    {
        public int PageNumber { get; set; }

        public bool HasPreviousPage => this.PageNumber > 1;

        public int PreviousPageNumber => this.PageNumber - 1;

        public bool HasNextPage => this.PageNumber < this.PagesCount;

        public int NextPageNumber => this.PageNumber + 1;

        public int PagesCount => (int)Math.Ceiling((double)this.PromotersCount / this.ItemsPerPage);

        public int PromotersCount { get; set; }

        public int ItemsPerPage { get; set; }
    }
}
