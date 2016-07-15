using System;

namespace XamarinForm.Models
{
    public class ListResult
    {
        public ListResult(object obj)
        {
            classResult = obj;
        }

        public ListResult()
        {
        }

        private object classResult;
        private PagingResult pagingResult;

        public object ClassResult
        {
            get
            {
                return classResult;
            }

            set
            {
                classResult = value;
            }
        }

        public PagingResult PagingResult
        {
            get
            {
                return pagingResult;
            }

            set
            {
                pagingResult = value;
            }
        }
    }
}
