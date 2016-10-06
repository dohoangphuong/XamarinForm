using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TNPA.Model
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
