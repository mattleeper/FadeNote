using System;
using System.Collections.Generic;
using System.Text;

namespace FadeNote.Domain.Providers
{
    public interface INoteIdProvider
    {
        string New();
    }
}
