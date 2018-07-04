using System.Collections.Generic;
using System.Linq;

namespace Confie.Infrastructure.Web
{
    public class WebResponse<T> where T : WebRequest
    {
        public T Request { get; set; }

        public IList<string> Errors { get; set; }

        public bool HasErrors => Errors != null
                                 && Errors.Any();
    }
}