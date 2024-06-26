﻿namespace ProdavaonicaIgaraAPI.Data.Pageing
{
    public class PagedResult<T>
    {
        #region properties
        public int PageNumber { get; set; }

        public int PageSize { get; set; }

        public int TotalCount { get; set; }

        public List<T> Items { get; set; }

        #endregion
    }
}
